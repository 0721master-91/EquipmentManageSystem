using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备管理
{
    public partial class uc标准信息 : UserControl
    {
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

        private void button巡检标准新增_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView巡检标准.DataSource as DataTable;

            DataRow newRow = dt.NewRow();

            // 默认开始执行时间为当天
            newRow["开始执行日期"] = DateTime.Today;

            dt.Rows.Add(newRow);

            this.dataGridView巡检标准.CurrentCell = this.dataGridView巡检标准.Rows[dataGridView巡检标准.Rows.Count - 1].Cells[0];
        }

        // 删除巡检标准选中行
        private void button巡检标准删除_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridView巡检标准.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
                return;

            // 没有选中任何行
            if (dataGridView巡检标准.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 确认删除
            if (MessageBox.Show("确定删除选中的行吗？", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            List<DataRow> rowsToDelete = new List<DataRow>();
            foreach (DataGridViewRow row in dataGridView巡检标准.SelectedRows)
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

        private void dataGridView巡检标准_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (this.dataGridView巡检标准.Columns[e.ColumnIndex].Name != "巡检部位")
                return;

            using (dlg功能位置档案编辑巡检标准选择 dlg = new dlg功能位置档案编辑巡检标准选择())
            {

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                var row = this.dataGridView巡检标准.Rows[e.RowIndex];
                row.Cells["巡检部位"].Value = dlg.Part;
                row.Cells["巡检内容"].Value = dlg.Content;
                row.Cells["巡检类型"].Value = dlg.Type;
                row.Cells["判断标准"].Value = dlg.JudgeStandard;
                row.Cells["巡检周期"].Value = dlg.Cycle;
                row.Cells["周期单位编码"].Value = dlg.CycleUnitCode;
                row.Cells["提前提醒天数"].Value = dlg.PreNoticeDays;
            }
        }

        // 禁用巡检部位内容输入
        private void dataGridView巡检标准_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this.dataGridView巡检标准.Columns[e.ColumnIndex].Name == "巡检部位")
                e.Cancel = true;
        }

        // 删除巡检标准全部标准
        private void button巡检标准全部删除_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView巡检标准.DataSource as DataTable;
            if (dt == null) return;
            dt.Rows.Clear();
        }
    }
}
