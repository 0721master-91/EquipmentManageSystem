﻿﻿using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备巡检
{
    public partial class uc巡检任务标准 : UserControl
    {
        public string positionCode; // 设备功能位置编码

        /// <summary>
        /// 巡检任务标准表格数据表
        /// </summary>
        public DataTable 巡检任务标准表
        {
            get { return this.dataGridView巡检任务标准数据.DataSource as DataTable; }
        }

        public uc巡检任务标准()
        {
            InitializeComponent();
        }

        private void uc巡检任务标准_Load(object sender, EventArgs e)
        {
            // 设计模式状态下不初始化
            if (DesignMode)
                return;


            GridInit.InitInspectionTaskStandardGrid(this.dataGridView巡检任务标准数据);
        }

        /// <summary>
        /// 新增一行
        /// </summary>
        private void AddNewRow(object sender, EventArgs e)
        {
            DataTable dt = dataGridView巡检任务标准数据.DataSource as DataTable;
            if (dt == null) return;

            DataRow newRow = dt.NewRow();
            dt.Rows.Add(newRow);

            if (dataGridView巡检任务标准数据.Rows.Count > 0)
                dataGridView巡检任务标准数据.CurrentCell =
                    dataGridView巡检任务标准数据.Rows[dataGridView巡检任务标准数据.Rows.Count - 1].Cells[0];
        }

        /// <summary>
        /// 删除选中的行
        /// </summary>
        private void DeleteSelectedRow(object sender, EventArgs e)
        {
            DataTable dt = dataGridView巡检任务标准数据.DataSource as DataTable;
            if (dt == null) return;

            if (dataGridView巡检任务标准数据.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请先选择要删除的行");
                return;
            }

            if (PopUpUtil.ShowConfirm("确定删除选中的行吗？"))
            {
                List<DataRow> rowsToDelete = new List<DataRow>();
                foreach (DataGridViewRow row in dataGridView巡检任务标准数据.SelectedRows)
                {
                    if (row.DataBoundItem is DataRowView view)
                        rowsToDelete.Add(view.Row);
                }
                foreach (DataRow r in rowsToDelete)
                    dt.Rows.Remove(r);
            }
        }

        /// <summary>
        /// 全部删除
        /// </summary>
        private void DeleteAll(object sender, EventArgs e)
        {
            DataTable dt = dataGridView巡检任务标准数据.DataSource as DataTable;
            if (dt == null) return;

            if (dt.Rows.Count == 0) return;

            if (PopUpUtil.ShowConfirm("确定删除全部行吗？"))
                dt.Rows.Clear();
        }

        // 点击展开选择界面
        private void dataGridView巡检任务标准数据_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dataGridView巡检任务标准数据.Columns[e.ColumnIndex].Name != "巡检部位")
                return;
            if (string.IsNullOrEmpty(this.positionCode))
            {
                PopUpUtil.ShowInfo("请先选择设备功能位置");
                return;
            }

            using(dlg巡检任务编辑巡检标准选择 dlg = new dlg巡检任务编辑巡检标准选择(this.positionCode))
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewRow row = dataGridView巡检任务标准数据.Rows[e.RowIndex];

                    row.Cells["巡检部位"].Value = dlg.part;
                    row.Cells["巡检内容"].Value = dlg.content;
                    row.Cells["巡检类型"].Value = dlg.type;
                    row.Cells["判断标准"].Value = dlg.standard;
                    if (decimal.TryParse(dlg.cycle, out decimal cycVal))
                        row.Cells["巡检周期"].Value = cycVal;
                    row.Cells["周期单位"].Value = dlg.unit;
                    if (int.TryParse(dlg.remind, out int remindVal))
                        row.Cells["提前提醒天数"].Value = remindVal;
                    if (DateTime.TryParse(dlg.start, out DateTime startDate))
                        row.Cells["开始执行日期"].Value = startDate;

                    row.Cells["下次执行日期"].Value = CalculateUtil.CalculateNextDateTime(startDate, cycVal, dlg.unit);
                }
                this.ActiveControl = null;
            }
        }
    }
}