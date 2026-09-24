﻿﻿using EquipmentManageSystem.Utils;
using SLControls.SLGlobal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static EquipmentManageSystem.模板.导入导出模板.ExcelTemplate;
using static EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo;

namespace EquipmentManageSystem.模板.导入导出模板
{
    public partial class uc数据导入 : UserControl
    {
        /// <summary>
        /// 模版列表
        /// </summary>
        private List<ExcelTemplate> ExcelTemplates;

        /// <summary>
        /// 用于提醒用户导入时导入重复数据
        /// </summary>
        private bool IsRepeat;

        /// <summary>
        /// 最终插入数据库数据
        /// </summary>
        public DataTable DataSource { get; set; }

        /// <summary>
        /// 插入数据的数据库表
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 导入前事件：在数据读取完成后、准备插入数据库前触发
        /// </summary>
        /// <returns>返回true表示继续导入，返回false表示终止导入</returns>
        public event Func<DataTable, bool> BeforeImport;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="excelTemplates">模版列表</param>
        /// <param name="tableName">数据库表名</param>
        public uc数据导入(List<ExcelTemplate> excelTemplates, string tableName)
        {
            InitializeComponent();
            this.ExcelTemplates = excelTemplates;
            this.TableName = tableName;
        }

        // 点击选择文件，弹出文件选择框
        private void button选择文件_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Excel文件|*.xlsx";
            fileDialog.Title = "请选择需要导入的Excel文件";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                label选择文件全称.Text = filePath;

                try
                {
                    DataTable dt = ReadExcelData(filePath);// 读取文件数据

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.dataGridView预览数据.DataSource = dt;

                        // 表格样式设置
                        this.dataGridView预览数据.ReadOnly = true;                          // 禁止编辑
                        this.dataGridView预览数据.ColumnHeadersDefaultCellStyle.Font =
                            new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Bold); // 列头加粗
                        this.dataGridView预览数据.ColumnHeadersDefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleCenter;                         // 列头居中
                        this.dataGridView预览数据.AutoSizeColumnsMode =
                            DataGridViewAutoSizeColumnsMode.AllCells;                          // 自动适应列宽
                        this.dataGridView预览数据.AllowUserToAddRows = false;                   // 禁止添加行

                        this.label数据概况详细.Text = string.Format("共 {0} 行数据 ", dt.Rows.Count);

                        this.button确认导入.Visible = true;
                        this.button确认导入.Enabled = true;
                        this.IsRepeat = false;
                        this.InitProgressBar(0);
                    }
                    else
                    {
                        MessageBox.Show("Excel 文件中没有数据", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.label数据概况详细.Text = "暂无数据";
                        this.dataGridView预览数据.DataSource = null;
                        this.button确认导入.Visible = false;
                        this.button确认导入.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("===== 读取 Excel 异常详情 =====");
                    Console.Error.WriteLine(ex.ToString());
                    if (ex.InnerException != null)
                    {
                        Console.Error.WriteLine("--- 内部异常 ---");
                        Console.Error.WriteLine(ex.InnerException.ToString());
                    }
                    Console.Error.WriteLine("================================");

                    MessageBox.Show("读取 Excel 失败：" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.label数据概况详细.Text = "读取失败";
                    this.dataGridView预览数据.DataSource = null;
                }
            }
        }

        /// <summary>
        /// 读取 Excel 数据
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>读取并处理后的数据</returns>
        private DataTable ReadExcelData(string filePath)
        {
            // 检查文件是否存在
            if (!File.Exists(filePath))
            {
                MessageBox.Show("文件不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            DataTable dt = new DataTable();

            using (OfficeOpenXml.ExcelPackage pkg = new OfficeOpenXml.ExcelPackage(new FileInfo(filePath)))
            {
                // 检查是否有工作表
                if (pkg.Workbook.Worksheets.Count == 0)
                {
                    MessageBox.Show("Excel 文件中没有工作表", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                OfficeOpenXml.ExcelWorksheet ws = pkg.Workbook.Worksheets.FirstOrDefault();// 读取第一张工作表数据
                // 检查是否有数据
                if (ws.Dimension == null)
                {
                    MessageBox.Show("工作表中没有数据", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                int rowCount = ws.Dimension.Rows;
                int colCount = ws.Dimension.Columns;

                // 第1行：读取 Excel 列头，建立 [列名 → 列索引] 的字典
                Dictionary<string, int> excelColMap = new Dictionary<string, int>();
                for (int col = 1; col <= colCount; col++)
                {
                    string colName = ws.Cells[1, col].Text.Trim();
                    if (!string.IsNullOrEmpty(colName) && !excelColMap.ContainsKey(colName))
                    {
                        excelColMap[colName] = col;
                    }
                }

                // 按模板 ExcelTemplates 创建 DataTable 列（多余的忽略，缺失的补空）
                foreach (var template in this.ExcelTemplates)
                {
                    dt.Columns.Add(template.FieldName);
                }

                // 第2行开始作为数据行
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow dr = dt.NewRow();
                    for (int c = 0; c < this.ExcelTemplates.Count; c++)
                    {
                        ExcelTemplate template = this.ExcelTemplates[c];
                        string fieldName = template.FieldName;

                        if(fieldName == null || string.IsNullOrEmpty(fieldName))
                        {
                            throw new Exception("导入模版中第"+ (c+1) + "项存在文件字段名为空的情况");
                        }

                        if (excelColMap.TryGetValue(fieldName, out int excelCol))
                        {
                            string cellValue = ws.Cells[row, excelCol].Text;
                            if (string.IsNullOrEmpty(cellValue) && !template.NullEnabled)
                            {
                                Console.Error.WriteLine(template.FieldName + "   "+ template.NullEnabled);
                                throw new Exception($"字段{c} \"{fieldName}\" 的值不能为空，请检查第 {row} 行数据。");
                            }
                            dr[c] = cellValue;
                        }
                    }
                    // 跳过所有字段都为空的空行
                    if (dr.ItemArray.All(v => v == null || v == DBNull.Value || string.IsNullOrEmpty(v?.ToString())))
                        continue;
                    dt.Rows.Add(dr);
                }
            }
            this.DataSource = dt.Copy();
            return dt;
        }

        // 模版下载
        private void button模板下载_Click(object sender, EventArgs e)
        {
            if (ExcelTemplates == null || ExcelTemplates.Count == 0)
            {
                MessageBox.Show("没有可用的模板数据，请先配置导入模板", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 文件|*.xlsx";
            sfd.FileName = this.TableName + "导入模版.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (OfficeOpenXml.ExcelPackage pkg = new OfficeOpenXml.ExcelPackage())
                    {
                        OfficeOpenXml.ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("导入模板");

                        // 列头生成
                        for (int i = 0; i < ExcelTemplates.Count; i++)
                        {
                            ws.Cells[1, i + 1].Value = ExcelTemplates[i].FieldName;
                        }

                        // 设置列头样式
                        var headerRange = ws.Cells[1, 1, 1, ExcelTemplates.Count];
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                        // 示例数据生成（Example不为null时填入  ）
                        bool hasExample = ExcelTemplates.Any(t => !string.IsNullOrEmpty(t.Example));
                        if (hasExample)
                        {
                            for (int i = 0; i < ExcelTemplates.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(ExcelTemplates[i].Example))
                                {
                                    ws.Cells[2, i + 1].Value = ExcelTemplates[i].Example;
                                }
                            }
                        }

                        // 给列头添加批注（Description作为说明）
                        for (int i = 0; i < ExcelTemplates.Count; i++)
                        {
                            string description = ExcelTemplates[i].Description;
                            if (!string.IsNullOrEmpty(description))
                            {
                                var cell = ws.Cells[1, i + 1];
                                string prefix = ExcelTemplates[i].NullEnabled ? "" : "[必填] ";
                                var note = cell.AddComment(prefix + description, "系统");
                            }
                        }

                        ws.Cells.AutoFitColumns();
                        pkg.SaveAs(new FileInfo(sfd.FileName));
                    }

                    MessageBox.Show("模板下载成功！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("模板下载失败：" + ex.Message, "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 初始化进度条
        /// </summary>
        private void InitProgressBar(int allCount)
        {
            if (allCount <= 0)
            {
                this.label具体进度.Text = "";
            }
            else
            {
                this.label具体进度.Text = "0%";
            }
            
            this.progressBar导入进度条.Minimum = 0;
            this.progressBar导入进度条.Maximum = allCount;
            this.progressBar导入进度条.Value = 0;
        }
        // 确认导入数据
        private void button确认导入_Click(object sender, EventArgs e)
        {
            //判断是否重复导入相同数据
            if (this.IsRepeat)
            {
                DialogResult result = MessageBox.Show("您即将导入相同数据，是否继续！", "提示",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return;
            }

            // 触发导入前事件
            if (BeforeImport != null)
            {
                bool proceed = BeforeImport(this.DataSource);
                if (!proceed) return;
            }

            if (string.IsNullOrEmpty(this.TableName))
            {
                MessageBox.Show("目标表名为空，请先设置目标表名", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.DataSource == null || this.DataSource.Rows.Count == 0)
            {
                MessageBox.Show("没有可导入的数据，请先选择并预览 Excel 文件", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 初始化进度条
            int totalRows = this.DataSource.Rows.Count;
            this.InitProgressBar(totalRows);

            try
            {
                this.button确认导入.Enabled = false;//关闭确认按钮，防止重复点击

                int successCount = 0;
                var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;

                for (int i = 0; i < this.DataSource.Rows.Count; i++)
                {
                    DataRow row = this.DataSource.Rows[i];
                    List<string> fields = new List<string>();
                    List<string> values = new List<string>();

                    foreach (ExcelTemplate template in ExcelTemplates)
                    {

                        StoreInfo storeInfo = template.DatabaseStoreInfo;
                        if (storeInfo == null) 
                            continue;

                        string storeField = storeInfo.MainTableStoreField;// 主表存储字段名
                        if (string.IsNullOrEmpty(storeField))
                            continue;
                        string rawValue = row[template.FieldName]?.ToString();// Excel中读取的值
                        if (string.IsNullOrEmpty(rawValue)) 
                            continue;
                        object finalValue;// 最后存储值


                        if (storeInfo.ValueResolver != null)
                        {// 优先执行自定义值获取逻辑
                            finalValue = storeInfo.ValueResolver(rawValue, row); // 自定义委托
                        }
                        else if (!string.IsNullOrEmpty(storeInfo.ForeignTable))
                        {// 如果外表有值，说明该字段需要去其他表查询数据 
                            object conditionValue = SqlCommonUtil.ConvertRawValueByType(rawValue, storeInfo.ConditionFieldType);
                            string formattedCondition = SqlCommonUtil.FormatSqlValue(conditionValue);
                            string sql = string.Format("select {0} from {1} where {2} = {3}",
                                storeInfo.ForeignTableStoreField,
                                storeInfo.ForeignTable,
                                storeInfo.ConditionField,
                                formattedCondition);
                            finalValue = services.ExecuteScalar(sql);
                        }
                        else
                        { //直接存储值
                            finalValue = SqlCommonUtil.ConvertRawValueByType(rawValue, storeInfo.FieldType);
                        }
                        fields.Add(storeField);
                        values.Add(SqlCommonUtil.FormatSqlValue(finalValue));
                    }

                    string insertSql = $"insert into {this.TableName} ({string.Join(",", fields)}) " +
                                       $"values ({string.Join(",", values)})";


                    int rowsAffected = services.ExecuteSql(insertSql);
                    if (rowsAffected > 0)
                        successCount++;
                    else
                    {
                        MessageBox.Show($"第{i + 1}行数据导入失败，请检查数据格式和完整性。");
                        return;
                    }

                    // 更新进度
                    this.progressBar导入进度条.Value = successCount;
                    this.label具体进度.Text = $"{successCount * 100 / totalRows}%";
                    Application.DoEvents(); // 强制刷新UI

                }
                // 导入完成，进度置为100%
                this.progressBar导入进度条.Value = totalRows;
                this.label具体进度.Text = "100%";
                this.IsRepeat = true;
                MessageBox.Show($"导入完成！共成功导入 {successCount} 行数据。",
                    "导入成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"导入失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.button确认导入.Enabled = true;//打开确认按钮
        }

    }
}