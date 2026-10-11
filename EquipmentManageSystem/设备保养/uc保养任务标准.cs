using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备保养
{
    public partial class uc保养任务标准 : UserControl
    {
        private string PositionCode; // 功能位置编码

        public uc保养任务标准()
        {
            InitializeComponent();
        }

        private void uc保养任务标准_Load(object sender, EventArgs e)
        {
            // 初始化保养任务标准表格
            GridInit.InitMaintenanceTaskStandardGrid(this.dataGridView保养任务标准数据);
        }

        // 新增一行
        private void AddNewRow(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            if(this.dataGridView保养任务标准数据.Rows.Count > 0)
                this.dataGridView保养任务标准数据.CurrentCell = this.dataGridView保养任务标准数据.Rows[dataGridView保养任务标准数据.Rows.Count - 1].Cells[0];
        }

        // 删除指定行
        private void DeleteSelectedRow(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            if (dt == null) return;

            if(this.dataGridView保养任务标准数据.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请先选择要删除的行！");

            }

            if (PopUpUtil.ShowConfirm("确认删除选中行吗？"))
            {
                List<DataRow> rowsToDelete = new List<DataRow>();
                foreach(DataGridViewRow row in this.dataGridView保养任务标准数据.SelectedRows)
                {
                    if (row.DataBoundItem is DataRowView view)
                        rowsToDelete.Add(view.Row);
                }

                foreach (DataRow row in rowsToDelete)
                {
                    dt.Rows.Remove(row);
                }
            }
        }

        /// <summary>
        /// 删除所有行
        /// </summary>
        private void DeleteAll(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            if (dt == null) return;

            if (this.dataGridView保养任务标准数据.Rows.Count == 0)
                return;

            if (PopUpUtil.ShowConfirm("确认删除所有行吗？"))
            {
                dt.Rows.Clear();
            }
        }

        /// <summary>
        /// 禁用弹出选择界面
        /// </summary>
        private void ForbiddenOpenDialog()
        {
            this.dataGridView保养任务标准数据.CellClick -= dataGridView保养任务标准数据_CellClick;
        }

        private void dataGridView保养任务标准数据_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (string.IsNullOrEmpty(this.PositionCode))
            {
                PopUpUtil.ShowInfo("请先选择设备功能位置！");
                return;
            }

            using(dlg保养任务编辑保养标准选择 dlg = new dlg保养任务编辑保养标准选择(this.PositionCode))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewRow row = this.dataGridView保养任务标准数据.Rows[e.RowIndex];

                    row.Cells["保养内容"].Value = dlg.Content;
                    row.Cells["给油类型"].Value = dlg.GiveOilType;
                    row.Cells["润换类型"].Value = dlg.LubricantChangeType;
                    row.Cells["润滑脂型号"].Value = dlg.LubricantModel;
                    if (decimal.TryParse(dlg.Cycle, out decimal cycVal))
                        row.Cells["执行周期"].Value = cycVal;
                    row.Cells["周期单位"].Value = dlg.Unit;
                    row.Cells["保养开始日期"].Value = dlg.StartDate;
                    row.Cells["下次保养日期"].Value = CalculateUtil.CalculateNextDateTime(dlg.StartDate,cycVal,dlg.Unit);
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 设置功能位置编码
        /// </summary>
        /// <param name="positionCode"></param>
        public void SetPositionCode(string positionCode)
        {
            this.PositionCode = positionCode;
        }
    }
}
