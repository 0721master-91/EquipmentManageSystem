﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.模板.选择窗口模版
{
    public partial class temp选择窗口 : Form
    {
        [Category("选择窗口配置")]
        [DisplayName("查询sql")]
        [Description("提供数据查询语句")]
        public string Sql { get; set; }

        [Category("选择窗口配置")]
        [DisplayName("是否多选")]
        [Description("该窗口数据是否支持多选")]
        public bool IsMultiSelect { get; set; }

        /// <summary>
        /// 查询结果数据表
        /// </summary>
        protected DataTable SourceData;

        protected List<DataRow> SelectedRows = new List<DataRow>();

        public temp选择窗口()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询前：返回 false 取消查询
        /// </summary>
        public delegate bool BeforeQueryEventHandler();
        [Category("选择窗口行为")]
        [Description("查询数据前触发，返回 false 可取消本次查询")]
        public event BeforeQueryEventHandler BeforeQuery;
        private bool OnBeforeQuery()
        {
            if (BeforeQuery == null) return false;

            return BeforeQuery();
        }

        /// <summary>
        /// 填充数据后，可以选择某些列
        /// </summary>
        public delegate void AfterFillControlsHandler();
        [Category("选择窗口行为")]
        [Description("数据填充后触发")]
        public event AfterFillControlsHandler AfterFillControls;
        private void OnAfterFillControls() 
        {
            if (AfterFillControls == null) return;

            AfterFillControls();
        }

        /// <summary>
        /// 点击ok关闭界面之前操作
        /// </summary>
        public delegate bool PreOKHandler();
        [Category("选择窗口行为")]
        [Description("关闭页面前操作")]
        public event PreOKHandler PreOK;
        private bool OnPreOK()
        {
            if (PreOK == null) return true;

            return PreOK();
        }

        // 加载数据并显示
        private void temp选择窗口_Load(object sender, EventArgs e)
        {
            var server = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            if (!OnBeforeQuery()) return;

            if (string.IsNullOrEmpty(Sql))
            {
                Utils.PopUpUtil.ShowWarning("sql未赋值");
                return;
            }

            this.SourceData = server.ExecuteForDataTable(Sql);

            // 绑定数据到表格
            this.SetSelectionMode();
            InitDataGridViewStyle();
            this.dataGridView数据表.DataSource = new DataView(SourceData);

            // 隐藏ID列（不区分大小写）
            foreach (DataGridViewColumn col in this.dataGridView数据表.Columns)
            {
                if (string.Equals(col.HeaderText, "ID", StringComparison.OrdinalIgnoreCase))
                {
                    col.Visible = false;
                }
            }

            this.dataGridView数据表.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dataGridView数据表.ClearSelection();

            // 数据绑定会触发 RowEnter，导致单选时第一行被加入选中集合，这里同步清空
            this.SelectedRows.Clear();

            OnAfterFillControls();
        }

        /// <summary>
        /// 初始化 DataGridView 样式
        /// </summary>
        private void InitDataGridViewStyle()
        {
            // ============ 表头样式 ============
            this.dataGridView数据表.EnableHeadersVisualStyles = false;
            this.dataGridView数据表.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 10F, FontStyle.Bold);
            this.dataGridView数据表.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            this.dataGridView数据表.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridView数据表.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView数据表.ColumnHeadersHeight = 35;
            this.dataGridView数据表.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ============ 行样式 ============
            this.dataGridView数据表.RowTemplate.Height = 30;
            this.dataGridView数据表.RowsDefaultCellStyle.BackColor = Color.White;
            this.dataGridView数据表.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 250);

            // ============ 选中高亮 ============
            this.dataGridView数据表.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            this.dataGridView数据表.DefaultCellStyle.SelectionForeColor = Color.White;

            // ============ 禁用用户调整大小 ============
            this.dataGridView数据表.AllowUserToAddRows = false;
            this.dataGridView数据表.AllowUserToResizeColumns = false;
            this.dataGridView数据表.AllowUserToResizeRows = false;
            this.dataGridView数据表.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        /// <summary>
        /// 设置选择模式
        /// </summary>
        private void SetSelectionMode()
        {
            this.dataGridView数据表.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (this.IsMultiSelect)
            {
                // 开启多选
                this.dataGridView数据表.MultiSelect = true;

                // 在最前面插入一列复选框
                DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
                checkCol.HeaderText = "选择";
                checkCol.Name = "col选择";
                checkCol.Width = 50;
                checkCol.Frozen = true;
                checkCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView数据表.Columns.Insert(0, checkCol);

                // 表头排序完成后，非绑定复选框列会被重置，需根据 SelectedRows 恢复勾选状态
                this.dataGridView数据表.Sorted += (s, e) => RestoreCheckBoxState();

                // 点击行任意位置时切换复选框状态
                this.dataGridView数据表.CellDoubleClick += (s, e) =>
                {
                    if (e.RowIndex < 0) return;

                    DataGridViewCheckBoxCell checkCell = this.dataGridView数据表.Rows[e.RowIndex].Cells["col选择"] as DataGridViewCheckBoxCell;
                    if (checkCell != null)
                    {
                        bool newValue = !((bool)(checkCell.Value ?? false));
                        checkCell.Value = newValue;
                    }

                    foreach (DataGridViewRow row in this.dataGridView数据表.Rows)
                    {
                        DataGridViewCheckBoxCell cell = row.Cells["col选择"] as DataGridViewCheckBoxCell;
                        if (cell != null)
                        {
                            row.Selected = (bool)(cell.Value ?? false);
                        }
                    }
                };

                // 根据复选框状态更新选中行列表
                this.dataGridView数据表.CellValueChanged += (s, e) =>
                {
                    if (e.ColumnIndex == this.dataGridView数据表.Columns["col选择"].Index)
                    {
                        DataRow row = (this.dataGridView数据表.Rows[e.RowIndex].DataBoundItem as DataRowView)?.Row;
                        if (row == null) return;
                        bool isChecked = (bool)(this.dataGridView数据表.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? false);
                        if (isChecked)
                        {
                            if (!this.SelectedRows.Contains(row))
                                this.SelectedRows.Add(row);
                        }
                        else
                        {
                            this.SelectedRows.Remove(row);
                        }
                    }
                };
            }
            else
            {
                this.dataGridView数据表.MultiSelect = false;

                this.dataGridView数据表.RowEnter += (s, e) =>
                {
                    DataRow row = (this.dataGridView数据表.Rows[e.RowIndex].DataBoundItem as DataRowView)?.Row;
                    if (row != null)
                    {
                        this.SelectedRows.Clear();
                        this.SelectedRows.Add(row);
                    }
                };
            }
        }

        /// <summary>
        /// 排序/重置后根据 SelectedRows 重新恢复复选框勾选状态
        /// </summary>
        private void RestoreCheckBoxState()
        {
            if (!this.IsMultiSelect) return;

            foreach (DataGridViewRow row in this.dataGridView数据表.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells["col选择"] as DataGridViewCheckBoxCell;
                if (cell == null) continue;

                DataRow r = (row.DataBoundItem as DataRowView)?.Row;
                bool shouldCheck = r != null && this.SelectedRows.Contains(r);
                cell.Value = shouldCheck;
                row.Selected = shouldCheck;
            }
        }


        private void button取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button确认_Click(object sender, EventArgs e)
        {
            if(!OnPreOK()) return;

            this.DialogResult = DialogResult.OK;
        }


        // 筛选条件输入框统一事件，筛选框中内容改变时触发

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // 如果是一级框内容变了，自动清空二级，重新从原始数据筛选
            if (sender == this.textBox一级筛选)
            {
                this.textBox二级筛选.TextChanged -= textBox_TextChanged;
                this.textBox二级筛选.Text = "";
                this.textBox二级筛选.TextChanged += textBox_TextChanged;
            }

            ApplyFilter();
        }

        /// <summary>
        /// 执行级联全文筛选
        /// </summary>
        private void ApplyFilter()
        {
            DataView dv = this.dataGridView数据表.DataSource as DataView;
            if (dv == null) return;

            string keyword1 = this.textBox一级筛选.Text.Trim();
            string keyword2 = this.textBox二级筛选.Text.Trim();

            string condition1 = BuildFullTextCondition(keyword1);
            string condition2 = BuildFullTextCondition(keyword2);

            if (!string.IsNullOrEmpty(condition1) && !string.IsNullOrEmpty(condition2))
                dv.RowFilter = $"({condition1}) AND ({condition2})";
            else if (!string.IsNullOrEmpty(condition1))
                dv.RowFilter = condition1;
            else if (!string.IsNullOrEmpty(condition2))
                dv.RowFilter = condition2;
            else
                dv.RowFilter = "";
        }

        /// <summary>
        /// 构建全文搜索条件
        /// </summary>
        private string BuildFullTextCondition(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return "";

            List<string> conditions = new List<string>();

            foreach (DataColumn col in this.SourceData.Columns)
            {
                if (col.DataType == typeof(string) || col.DataType == typeof(int) || col.DataType == typeof(long) ||
                    col.DataType == typeof(short) || col.DataType == typeof(decimal) ||
                    col.DataType == typeof(double) || col.DataType == typeof(float) ||
                    col.DataType == typeof(DateTime))
                {
                    conditions.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{keyword}%'");
                }
            }

            return string.Join(" OR ", conditions);
        }

        private void button重置条件_Click(object sender, EventArgs e)
        {
            this.textBox一级筛选.Text = "";
            this.textBox二级筛选.Text = "";

            // 重置列排序
            DataView dv = this.dataGridView数据表.DataSource as DataView;
            if (dv != null) 
                dv.Sort = "";
        }
    }
}