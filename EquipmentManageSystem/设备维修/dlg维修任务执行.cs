using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.设备维修
{
    public partial class dlg维修任务执行 : Form
    {
        private string BillCode; //单据编号
        private TaskExecuteStatus status; //任务状态

        public dlg维修任务执行(string billCode, TaskExecuteStatus status)
        {
            InitializeComponent();
            this.BillCode = billCode;
            this.status = status;
        }

        private void dlg维修任务接取与提交_Load(object sender, EventArgs e)
        {
            if (status == TaskExecuteStatus.Receive)
            {
                this.uc维修任务执行.Visible = false;    
                this.Text = "维修任务接取";
                this.button确认.Text = "接取";
            }
            else if (status == TaskExecuteStatus.Submit)
            {
                this.uc维修任务执行.Visible = true;
                this.Text = "维修任务提交";
                this.button确认.Text = "提交";
            }
            else if(status == TaskExecuteStatus.CheckAndAccept)
            {
                this.uc维修任务执行.Visible = true;
                this.Text = "维修任务验收";
                this.button确认.Text = "验收";
                this.uc维修任务执行.LoadRepairdInfo(this.BillCode);
                this.uc维修任务执行.ShowCheckAndAccept();
            }

            this.FillData();
        }

        private void button取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void button确认_Click(object sender, EventArgs e)
        {
            this.button确认.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            if(this.status == TaskExecuteStatus.Receive)
            {
                if (this.RecieveTask()) this.DialogResult = DialogResult.OK;
            }
            else if(this.status == TaskExecuteStatus.Submit)
            {
                if (this.SubmitTask()) this.DialogResult = DialogResult.OK;
            }
            else if(this.status == TaskExecuteStatus.CheckAndAccept)
            {
                if (this.CheckAndAcceptTask()) this.DialogResult = DialogResult.OK;
            }


            this.button确认.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        private void FillData()
        {
            this.uc维修工单基本信息.LoadRepairdOrderBaseData(this.BillCode);
        }

        private bool RecieveTask()
        {
            SLControls.SLDbService.SLOnlyInstOleDb.Services.BeginTran(); // 开启事务
            try
            {
                string sql = "update 维修记录 " +
                             "set 维修人ID = " + UserSession.CurrentUser.MemberID + ", " +
                                "维修开始时间 = getDate() " +
                             "where ID = (select top 1 ID from dbo.fn_GetDirectiveRepairRecord('" + this.BillCode + "')) " +
                                   "and (维修人ID is null or 维修人ID = " + UserSession.CurrentUser.MemberID + ")";
                int num = 0;
                num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql); // 更新维修记录状态
                if (num <= 0) throw new Exception("接取任务失败！");

                sql = "update 维修工单 " +
                      "set 维修状态编码 = 'REPAIRING', " +
                          "执行状态编码 = 'EXECUTING', " +
                          "最后修改人 = " + UserSession.CurrentUser.MemberID + ", " +
                          "最后修改时间 = getDate() " +
                      "where 维修工单编码 = '" + this.BillCode + "'";
                num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql); // 更新维修工单状态
                if (num <= 0) throw new Exception("接取任务失败！");

                SLControls.SLDbService.SLOnlyInstOleDb.Services.Commit(); // 提交事务
                return true;
            }
            catch(Exception ex)
            {
                PopUpUtil.ShowWarning(ex.Message);
                SLControls.SLDbService.SLOnlyInstOleDb.Services.RollBack();
                return false;
            }
        }

        /// <summary>
        /// 提交维修任务
        /// </summary>
        private bool SubmitTask()
        {
            // 接取维修任务后只能由接取人看见任务（amdin除外）,不需要进行状态验证直接修改
            // 数据都在控件中，这里直接在控件中执行更新
            return this.uc维修任务执行.SubmitTask(this.BillCode);
        }

        /// <summary>
        /// 验收维修任务
        /// </summary>
        private bool CheckAndAcceptTask()
        {
            return this.uc维修任务执行.CheckAndAcceptTask(this.BillCode);
        }
    }
}
