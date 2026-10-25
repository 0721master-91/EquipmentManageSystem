using EquipmentManageSystem.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.模板.导入导出模板
{
    public partial class uc数据导出 : UserControl
    {

        /// <summary>
        /// 导出的数据
        /// </summary>
        private DataTable OutDataSource;

        /// <summary>
        /// 可选导出字段集合
        /// </summary>
        private List<ExportField> ExportFields = new List<ExportField>();

        /// <summary>
        /// 额外的导出字段
        /// 生成页面时传入
        /// </summary>
        private List<ExportField> ExtraFields;

        /// <summary>
        /// 用户选择的导出字段
        /// </summary>
        private List<ExportField> SelectedFields = new List<ExportField>();

        /// <summary>
        /// 主表表名
        /// </summary>
        private string MainTable;

        public uc数据导出()
        {
            InitializeComponent();
        }

        public uc数据导出(DataTable outData, List<ExportField> extraFields, string mainTable)
        {
            InitializeComponent();
            this.OutDataSource = outData;
            this.ExtraFields = extraFields;
            this.MainTable = mainTable;
        }

        private void UserControl数据导出_Load(object sender, EventArgs e)
        {
           this.InitOptionDataGridView();
           this.InitSelectedDataGridView();
        }

        /// <summary>
        /// 初始化可选字段数据表格
        /// </summary>
        private void InitOptionDataGridView()
        {
            if (this.OutDataSource == null) return;

            // 清空左侧表格
            this.dataGridView可选字段.Columns.Clear();
            this.dataGridView可选字段.Rows.Clear();

            // 添加一列
            this.dataGridView可选字段.Columns.Add("字段名称", "字段名称");

            this.ExportFields = this.GenerateExportField(this.OutDataSource.Columns);
            if (this.ExtraFields != null && this.ExtraFields.Count > 0)
            {
                foreach(ExportField field in this.ExtraFields)
                {
                    field.OptionName = "[附加]" + field.OptionName;
                }

                this.ExportFields.AddRange(this.ExtraFields);// 将额外字段拼接到导出字段中
            }
                

            foreach (ExportField field in this.ExportFields)
            {
                int rowIndex = this.dataGridView可选字段.Rows.Add(field.OptionName);
                this.dataGridView可选字段.Rows[rowIndex].Tag = field;// 导出字段对象存入行对象中
            }

            if (this.dataGridView可选字段.Rows.Count > 0)
            {
                this.dataGridView可选字段.Rows[0].Selected = true;
            }

            this.InitDataGridViewStyle(this.dataGridView可选字段);
        }

        /// <summary>
        /// 初始化已选字段数据表格
        /// </summary>
        private void InitSelectedDataGridView()
        {
            this.dataGridView导出字段.Columns.Clear();
            this.dataGridView导出字段.Rows.Clear();
            this.dataGridView导出字段.Columns.Add("字段名称", "字段名称");

            this.InitDataGridViewStyle(this.dataGridView导出字段);
        }

        /// <summary>
        /// 初始化展示表格的样式
        /// </summary>
        /// <param Name="dataGridView"></param>
        private void InitDataGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.RowHeadersVisible = false;  // 隐藏最左边的行标题列
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 将主表可导出字段生成导出字段对象
        /// </summary>
        /// <param Name="cloumnName">列名</param>
        /// <returns>导出字段对象列表</returns>
        private List<ExportField> GenerateExportField(DataColumnCollection columns)
        {
            List<ExportField> fields = new List<ExportField>();

            foreach(DataColumn col in columns)
            {
                ExportField field = new ExportField
                {
                    ExcelFieldName = col.ColumnName,
                    OptionName = "[主表]" + col.ColumnName
                };
                fields.Add(field);
            }

            return fields;
        }

        /// <summary>
        /// 双击可选字段事件
        /// 将选中的字段添加到已选字段中
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void DataGridView可选字段_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            DataGridViewRow row = this.dataGridView可选字段.Rows[e.RowIndex];// 获取选中的行
            if (row == null) return;

            ExportField field = (ExportField)row.Tag;// 获取导出字段对象

            // 添加到已选字段列表（避免重复添加）
            if (!this.SelectedFields.Exists(f => f.OptionName == field.OptionName))
            {
                this.SelectedFields.Add(field);

                // 复制到右边选择项
                int rowIndex = this.dataGridView导出字段.Rows.Add(field.OptionName);
                this.dataGridView导出字段.Rows[rowIndex].Tag = field;
            }
            else
            {
                return;
            }  

        }

        /// <summary>
        /// 双击已选字段事件
        /// 删除已选项
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void dataGridView导出字段_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            this.DeleteRow(e.RowIndex);
        }

        /// <summary>
        /// 已选字段键盘操作
        /// ← 左方向键：删除当前项
        /// ↑ 上方向键：上移一行
        /// ↓ 下方向键：下移一行
        /// </summary>
        private void dataGridView导出字段_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.dataGridView导出字段.SelectedRows.Count == 0) return;

            DataGridViewRow currentRow = this.dataGridView导出字段.SelectedRows[0];
            int currentIndex = currentRow.Index;
            ExportField field = (ExportField)currentRow.Tag;
            if (field == null) return;

            if (e.KeyCode == Keys.Left)
            {
                // 左方向键 → 删除
                this.DeleteRow(currentIndex);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (currentIndex > 0)
                {
                    // 上方向键 → 上移
                    SwapRow(currentIndex, currentIndex - 1, field);
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (currentIndex < this.dataGridView导出字段.Rows.Count - 1)
                {
                    // 下方向键 → 下移
                    SwapRow(currentIndex, currentIndex + 1, field);
                }
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 删除选中字段中某一行数据
        /// </summary>
        private void DeleteRow(int index)
        {
            DataGridViewRow row = this.dataGridView导出字段.Rows[index];
            ExportField field = (ExportField)row.Tag;

            // 先从 SelectedFields 移除（在删除行之前取 field）
            if (field != null)
                this.SelectedFields.Remove(field);

            // 从表格移除行
            this.dataGridView导出字段.Rows.RemoveAt(index);

            // 选中相邻行
            int rowCount = this.dataGridView导出字段.Rows.Count;
            if (rowCount > 0)
            {
                int selectIndex = Math.Min(index, rowCount - 1);
                this.dataGridView导出字段.Rows[selectIndex].Selected = true;
            }
        }

        /// <summary>
        /// 交换两行内容（表格和列表同步交换）
        /// </summary>
        private void SwapRow(int fromIndex, int toIndex, ExportField fromField)
        {

            // 1. 同步 SelectedFields 列表
            this.SelectedFields.RemoveAt(fromIndex);
            this.SelectedFields.Insert(toIndex, fromField);

            // 2. 获取目标行的 ExportField
            DataGridViewRow sourceRow = this.dataGridView导出字段.Rows[fromIndex];
            DataGridViewRow targetRow = this.dataGridView导出字段.Rows[toIndex];
            ExportField targetField = (ExportField)targetRow.Tag;

            // 3. 交换两行的值和 Tag（不动行本身，只交换内容）
            sourceRow.Cells[0].Value = targetField.OptionName;
            sourceRow.Tag = targetField;

            targetRow.Cells[0].Value = fromField.OptionName;
            targetRow.Tag = fromField;
            
            // 4. 选中移动后的行
            sourceRow.Selected = false;
            targetRow.Selected = true;
        }

        private void button导出_Click(object sender, EventArgs e)
        {
            if (this.OutDataSource == null)
            {
                MessageBox.Show("导出数据为空，请前往主窗口查询需要导出的数据","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            // 选择保存位置
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 文件|*.xlsx";
            sfd.FileName = this.MainTable + "导出数据";
            sfd.Title = "选择导出文件保存位置";
            if (sfd.ShowDialog() != DialogResult.OK)
                return;
            string filePath = sfd.FileName;

            try
            {
                DataTable data = this.GenerateExportData();
                
                using(ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("导出数据");

                    // 写入表头
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = data.Columns[i].ColumnName;
                        ws.Cells[1, i + 1].Style.Font.Bold = true;
                    }

                    // 预先设置日期时间列的单元格格式，避免 EPPlus 将 DateTime 存为日期序列号(如46287.69)而显示为数字
                    for (int col = 0; col < data.Columns.Count; col++)
                    {
                        if (data.Columns[col].DataType == typeof(DateTime))
                        {
                            ws.Cells[2, col + 1, data.Rows.Count + 1, col + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                        }
                    }

                    // 写入数据行
                    for (int row = 0; row < data.Rows.Count; row++)
                    {
                        for (int col = 0; col < data.Columns.Count; col++)
                        {
                            ws.Cells[row + 2, col + 1].Value = data.Rows[row][col];
                        }
                    }

                    // 自动调整列宽
                    ws.Cells[1, 1, data.Rows.Count + 1, data.Columns.Count].AutoFitColumns();
                    // 保存文件
                    pkg.SaveAs(new System.IO.FileInfo(filePath));
                }
                MessageBox.Show($"导出成功！\n文件已保存至：{filePath}", "导出完成",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("导出失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("导出失败" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 生成导出数据
        /// </summary>
        /// <returns>完整的导出数据</returns>
        private DataTable GenerateExportData()
        {
            // 这里复制一份数据，因为后面想要添加列、删除列，直接用原表数据可能有问题
            DataTable MainData = this.OutDataSource.Copy();

            if (this.ExtraFields != null && this.ExtraFields.Count > 0)
            {//判断是否有额外字段，有额外字段需要查询数据
                foreach(ExportField field in this.SelectedFields)
                {
                    if(field.ForeignTable != null && field.OptionName.StartsWith("[附加]"))
                    {
                        DataTable dt = new DataTable();
                        if (field.ValueResolver != null)
                        {
                            dt = field.ValueResolver(this.OutDataSource);
                        }
                        else
                        {
                            List<Object> keys = new List<object>();
                            foreach (DataRow row in this.OutDataSource.Rows)
                            {
                                if (row[field.ConditionField] != null)
                                {
                                    keys.Add(row[field.ConditionField]);
                                }
                            }

                            dt = this.QueryExtraData(field, keys);
                        }
                        //处理数据，转换为将查询到的数据转换为字典，key为conditionField的值，value为查询到的数据
                        Dictionary<string,string> dic = SqlCommonUtil.DataTableToDict(dt, field.ConditionField, field.ForeignTableField);
                        //使用选项名作为新列名，用条件字段进行匹配
                        SqlCommonUtil.MergeDictToTable(MainData, dic, field.ExcelFieldName, field.ConditionField);
                    }
                }
            }

 /*           foreach(ExportField field in this.SelectedFields)
            {
                MessageBox.Show(field.ExcelFieldName);
            };*/


            // 生成最终导出数据
            string[] columnNames = this.SelectedFields
                .Select(f => f.ExcelFieldName)
                .Where(name => MainData.Columns.Contains(name))
                .ToArray();
            DataTable finalData = MainData.DefaultView.ToTable(false, columnNames);
            return finalData;
        }

        

        /// <summary>
        /// 查询额外字段的数据
        /// </summary>
        /// <param Name="field"></param>
        /// <returns></returns>
        private DataTable QueryExtraData(ExportField field, List<Object> keys)
        {
            string sql = null;
            if (field.IsMainTableField)
            {
                sql = string.Format("select {0},{1} from {2} where {3} in ({4}) ",
                    field.ConditionField,
                    field.ForeignTableField,
                    field.ForeignTable,
                    field.ConditionField,
                    SqlCommonUtil.FormatSqlValueList(keys));
            }
            else
            {
                sql = string.Format("select s.{0},t.{1} from {2} as s left join {3} as t on ", 
                    field.ConditionField,
                    field.ForeignTableField,
                    this.MainTable,
                    field.ForeignTable);


                for(int i = 0; i < field.Relationships.Count; i++)
                {
                    FieldRelationship rls = field.Relationships[i];
                    if(i == 0)
                    {
                        sql += string.Format("s.{0} = t.{1} ",rls.MainTableField, rls.ForeignTableField);
                    }
                    else
                    {
                        sql += string.Format("and s.{0} = t.{1} ", rls.MainTableField, rls.ForeignTableField);
                    }
                }

                sql += string.Format("where s.{0} in ({1}) ", field.ConditionField, SqlCommonUtil.FormatSqlValueList(keys));
            }
            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            DataTable dt = services.ExecuteForDataTable(sql);
            return dt;
        }
    }
}