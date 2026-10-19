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
        private DateTime PlantStartTime; // 计划开始时间  

        // 获取保养任务标准数据
        public DataTable MaintenanceTaskStandardData 
        { 
            get { return this.dataGridView保养任务标准数据.DataSource as DataTable; }
        }

        public Panel OperationPanel
        {
            get { return this.panel操作区; }
        }

        public uc保养任务标准()
        {
            InitializeComponent();
        }

        private void uc保养任务标准_Load(object sender, EventArgs e)
        {
            // 初始化保养任务标准表格
            GridInit.InitMaintenanceTaskStandardGrid(this.dataGridView保养任务标准数据);
        }

        /// <summary>
        /// 新增一行
        /// </summary>
        private void AddNewRow(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            if(this.dataGridView保养任务标准数据.Rows.Count > 0)
                this.dataGridView保养任务标准数据.CurrentCell = this.dataGridView保养任务标准数据.Rows[dataGridView保养任务标准数据.Rows.Count - 1].Cells[0];
        }

        /// <summary>
        /// 删除指定行
        /// </summary>
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
                    row.Cells["润换方式"].Value = dlg.LubricantChangeType;
                    row.Cells["润滑脂型号"].Value = dlg.LubricantModel;
                    if (decimal.TryParse(dlg.Cycle, out decimal cycVal))
                        row.Cells["执行周期"].Value = cycVal;
                    row.Cells["周期单位"].Value = dlg.Unit;
                    row.Cells["保养开始日期"].Value = this.PlantStartTime;
                    row.Cells["下次保养日期"].Value = CalculateUtil.CalculateNextDateTime(this.PlantStartTime, cycVal,dlg.Unit);
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 更新保养任务标准表格中时间
        /// </summary>
        public void UpdateDateTime()
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            foreach(DataRow dr in dt.Rows)
            {
                dr["保养开始日期"] = this.PlantStartTime;
                decimal cycVal = Convert.ToDecimal(dr["执行周期"]);
                dr["下次保养日期"] = CalculateUtil.CalculateNextDateTime(this.PlantStartTime, cycVal, dr["周期单位"] as string);
            }
        }

        /// <summary>
        /// 设置功能位置编码
        /// </summary>
        public void SetPositionCode(string positionCode)
        {
            this.PositionCode = positionCode;
        }

        /// <summary>
        /// 设置计划开始时间
        /// </summary>
        public void SetPlantStartTime(DateTime plantStartTime)
        {
            this.PlantStartTime = plantStartTime;
        }

        /// <summary>
        ///  清空数据表
        /// </summary>
        public void ClearDataTable()
        {
            DataTable dt = this.dataGridView保养任务标准数据.DataSource as DataTable;
            dt.Clear();
        }

        /// <summary>
        /// 加载数据（用于填充数据时使用）
        ///     选择的时候使用功能位置编码方便获取对应功能位置绑定的标准
        ///     加载的时候使用保养任务编码获取改任务绑定的标准
        /// </summary>
        /// <param name="taskCode">保养任务编码</param>
        public void LoadData(string taskCode)
        {
            string sql = "select mts.保养内容,mts.给油类型,mts.润换方式,mts.润滑脂型号,mts.执行周期,mts.周期单位,mts.保养开始日期,mts.下次保养日期 " +
                         "from 保养任务标准 as mts " +
                         "where mts.所属保养任务编码 = '" + taskCode + "' and IsDelete = 0";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            DataTable standardDt = this.dataGridView保养任务标准数据.DataSource as DataTable;

            foreach (DataRow r in dt.Rows)
            {
                standardDt.Rows.Add(r["保养内容"], r["给油类型"],r["润换方式"],r["润滑脂型号"],r["执行周期"],r["周期单位"],r["保养开始日期"],r["下次保养日期"]);
            }
        }

        /// <summary>
        /// 禁用弹出选择界面
        /// </summary>
        public void ForbiddenOpenDialog()
        {
            this.dataGridView保养任务标准数据.CellClick -= dataGridView保养任务标准数据_CellClick;
        }
    }
}
