using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static EquipmentManageSystem.设备管理.dlg功能位置档案编辑标准选择;

namespace EquipmentManageSystem.设备管理
{
    public partial class uc标准信息 : UserControl
    {

        /// <summary>
        /// 巡检标准表格数据表
        /// </summary>
        public DataTable InspectionStandardsTable
        {
            get { return this.dataGridView巡检标准.DataSource as DataTable; }
        }
        /// <summary>
        /// 保养标准表格数据表
        /// </summary>
        public DataTable MaintenanceStandardsTable
        {
            get { return this.dataGridView保养标准.DataSource as DataTable; }
        }

        public uc标准信息()
        {
            InitializeComponent();
        }

        private void uc标准信息_Load(object sender, EventArgs e)
        {
            // 设计模式状态下不初始化
            if (DesignMode)
                return;

            // 初始化巡检标准表格
            GridInit.InitInspectionStandardsGrid(this.dataGridView巡检标准);
            GridInit.InitmaintenanceStandardsGrid(this.dataGridView保养标准);
        }

        /// <summary>
        /// 新增按钮点击事件
        /// </summary>
        private void AddNewRow(object sender, EventArgs e)
        {
            DataTable dt = null;
            DataGridView dataGridView = null;

            string name = ((Button)sender).Name;
            if (name == "button巡检标准新增")
            {
                dt = this.dataGridView巡检标准.DataSource as DataTable;
                dataGridView = this.dataGridView巡检标准;
            }
            else if (name == "button保养标准新增")
            {
                dt = this.dataGridView保养标准.DataSource as DataTable;
                dataGridView = this.dataGridView保养标准;
            }
            
            if (dt != null)
            {
                DataRow newRow = dt.NewRow();
                // 默认开始执行时间为当天
                newRow["开始执行日期"] = DateTime.Today;
                dt.Rows.Add(newRow);

                dataGridView.CurrentCell = dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[0];
            }
        }

        /// <summary>
        /// 删除选中的行
        /// </summary>
        private void DeleteSleectedRows(object sender, EventArgs e)
        {
            DataTable dt = null;
            DataGridView dataGridView = null;

            string name = ((Button)sender).Name;
            if (name == "button巡检标准删除")
            {
                dt = this.dataGridView巡检标准.DataSource as DataTable;
                dataGridView = this.dataGridView巡检标准;
            }
            else if( name == "button保养标准删除")
            {
                dt = this.dataGridView保养标准.DataSource as DataTable;
                dataGridView = this.dataGridView保养标准;
            }

            if (dt == null) return;

            if (dataGridView.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请先选择要删除的行");
                return;
            }

            if (PopUpUtil.ShowConfirm("确定删除选中的行吗？"))
            {
                List<DataRow> rowsToDelete = new List<DataRow>();
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    DataRowView view = row.DataBoundItem as DataRowView;
                    if (view != null)
                        rowsToDelete.Add(view.Row);
                }

                foreach (DataRow r in rowsToDelete)
                {
                    dt.Rows.Remove(r);
                }
            }
        }

        // 删除全部标准
        private void DeleteAll(object sender, EventArgs e)
        {
            DataTable dt = null;

            string name = ((Button)sender).Name;
            if (name == "button巡检标准全部删除")
            {
                dt = this.dataGridView巡检标准.DataSource as DataTable;
            }
            else if (name == "button保养标准全部删除")
            {
                dt = this.dataGridView保养标准.DataSource as DataTable;
            }

            if (dt == null) return;
            dt.Rows.Clear();
        }

        // 打开巡检部位选择窗口
        private void dataGridView巡检标准_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (this.dataGridView巡检标准.Columns[e.ColumnIndex].Name != "巡检部位")
                return;

            using (dlg功能位置档案编辑标准选择 dlg = new dlg功能位置档案编辑标准选择(Standard.Inspection,"巡检标准选择"))
            {

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                var row = this.dataGridView巡检标准.Rows[e.RowIndex];
                row.Cells["巡检部位"].Value = dlg.ChosenInspectionStandard.Part;
                row.Cells["巡检内容"].Value = dlg.ChosenInspectionStandard.Content;
                row.Cells["巡检类型"].Value = dlg.ChosenInspectionStandard.Type;
                row.Cells["判断标准"].Value = dlg.ChosenInspectionStandard.JudgeStandard;
                row.Cells["巡检周期"].Value = dlg.ChosenInspectionStandard.Cycle;
                row.Cells["周期单位编码"].Value = dlg.ChosenInspectionStandard.CycleUnitCode;
                row.Cells["提前提醒天数"].Value = dlg.ChosenInspectionStandard.PreNoticeDays;
            }
        }

        // 打开保养标准选择窗口
        private void dataGridView保养标准_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (this.dataGridView保养标准.Columns[e.ColumnIndex].Name != "保养内容")
                return;

            using (dlg功能位置档案编辑标准选择 dlg = new dlg功能位置档案编辑标准选择(Standard.Maintenance, "保养标准选择"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var  row = this.dataGridView保养标准.Rows[e.RowIndex];

                    row.Cells["保养内容"].Value = dlg.ChosenMaintenanceStandard.Content;
                    row.Cells["给油类型编码"].Value = dlg.ChosenMaintenanceStandard.GiveOilTypeCode;
                    row.Cells["润滑脂型号"].Value = dlg.ChosenMaintenanceStandard.LubricantModel;
                    row.Cells["润换方式编码"].Value = dlg.ChosenMaintenanceStandard.LubricantChangeTypeCode;
                    row.Cells["执行周期"].Value = dlg.ChosenMaintenanceStandard.Cycle;
                    row.Cells["周期单位编码"].Value = dlg.ChosenMaintenanceStandard.CycleUnitCode;
                    row.Cells["提前提醒天数"].Value = dlg.ChosenMaintenanceStandard.PreNoticeDays;
                }

            }
        }

        // 禁用内容输入
        private void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            switch (dgv.Name)
            {
                case "dataGridView巡检标准":
                    if (dgv.Columns[e.ColumnIndex].Name == "巡检部位")
                        e.Cancel = true;
                    break;

                case "dataGridView保养标准":
                    if (dgv.Columns[e.ColumnIndex].Name == "保养内容")
                        e.Cancel = true;
                    break;
            }
        }

    }
}