using EquipmentManageSystem.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLControls.SLDbService;

namespace EquipmentManageSystem.设备维修
{
    public partial class uc维修任务执行 : UserControl
    {
        public uc维修任务执行()
        {
            InitializeComponent();
        }

        private void uc维修任务执行_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            CommonFilter.InitCombox(this.comboBox维修结果, "结果", "编码", "维修结果", false);
            CommonFilter.InitCombox(this.comboBox验收状态, "状态", "编码", "验收状态", false);
        }

        private void comboBox验收状态_SelectedValueChanged(object sender, EventArgs e)
        {
            object statusCodeObj = this.comboBox验收状态.SelectedValue;
            string statusCode = statusCodeObj == null ? "" : statusCodeObj.ToString();
            if (statusCode == "REJECTED")
            {
                this.panel操作区.Visible = true;
            }
            else
            {
                this.panel操作区.Visible = false;
            }
        }

        private void checkBox重新选择维修人员_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox重新选择维修人员.Checked)
            {
                this.textBox重新维修人员.Visible = true;
                this.label重新维修人员.Visible = true;
                this.label维修人员图标.Visible = true;
            }
            else
            {
                this.textBox重新维修人员.Visible = false;
                this.label重新维修人员.Visible = false;
                this.label维修人员图标.Visible = false;
            }

            this.textBox重新维修人员.Text = string.Empty;
            this.textBox重新维修人员.Tag = null;
        }


        private void OpenPictureSelectedDialog(object sender, EventArgs e)
        {
            PictureHandleUtil.SelectPicturesToPanel(this.flowLayoutPanel维修完成照片);
        }

        private void OpenMemberSelectedDialog(object sender, EventArgs e)
        {
            using(dlg人员选择 dlg = new dlg人员选择() { IsMultiSelect = true})
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.textBox重新维修人员.Text = dlg.SelectedMemberNames;
                    this.textBox重新维修人员.Tag = dlg.SelectedMemberIDs;
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 显示验收环节(开启验收板块，关闭维修提交板块)
        /// </summary>
        public void ShowCheckAndAccept()
        {
            // 开启验收信息板块
            this.groupBox验收信息.Visible = true;

            // 禁用维修提交板块编辑
            this.comboBox维修结果.Enabled = false;
            this.textBox备注说明.ReadOnly = true;
            this.textBox故障原因.ReadOnly = true;
            this.textBox影响说明.ReadOnly = true;
            this.textBox处理方案.ReadOnly = true;
            this.textBox预防措施.ReadOnly = true;
            this.flowLayoutPanel维修完成照片.BackColor = SystemColors.Control;
            this.label维修完成照片图标.Visible = false;
        }

        /// <summary>
        /// 加载维修信息
        /// </summary>
        /// <param name="billCode"></param>
        public void LoadRepairdInfo(string billCode)
        {
            string sql = "select 维修结果编码,维修备注信息,故障原因,影响说明,处理方案,预防措施,维修照片路径 " +
                         "from 维修记录 " +
                         "where ID = (select ID from dbo.fn_GetDirectiveRepairRecord('" + billCode + "')) ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            this.comboBox维修结果.SelectedValue = dt.Rows[0]["维修结果编码"];
            this.textBox备注说明.Text = dt.Rows[0]["维修备注信息"].ToString();
            this.textBox故障原因.Text = dt.Rows[0]["故障原因"].ToString();
            this.textBox影响说明.Text = dt.Rows[0]["影响说明"].ToString();
            this.textBox处理方案.Text = dt.Rows[0]["处理方案"].ToString();
            this.textBox预防措施.Text = dt.Rows[0]["预防措施"].ToString();
            PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel维修完成照片, dt.Rows[0]["维修照片路径"].ToString());
        }

        /// <summary>
        /// 提交维修结果
        /// </summary>
        public bool SubmitTask(string billCode)
        {
            if (!this.VerifySubmitData()) return false;

            string repairdResultCode = this.comboBox维修结果.SelectedValue.ToString();
            string remark = this.textBox备注说明.Text;
            string faultReason = this.textBox故障原因.Text;
            string impactStatement = this.textBox影响说明.Text;
            string solution = this.textBox处理方案.Text;
            string preventMeasure = this.textBox预防措施.Text;

            List<string> picturePathList = this.flowLayoutPanel维修完成照片.Controls
                                               .OfType<PictureBox>()
                                               .Where(p => p.Tag != null)
                                               .Select(p => p.Tag.ToString())
                                               .ToList();
            string picturePaths = PictureHandleUtil.SavePicturesAndGetSavePath(picturePathList,"维修完成照片");

            string updateRecordSql = string.Format("update 维修记录 " +
                                       "set 维修结果编码 = '{0}', " +
                                           "维修备注信息 = '{1}', " +
                                           "故障原因 = '{2}', " +
                                           "影响说明 = '{3}', " +
                                           "处理方案 = '{4}', " +
                                           "预防措施 = '{5}', " +
                                           "维修照片路径 = '{6}', " +
                                           "维修结束时间 = getDate(), " +
                                           "验收状态编码 = 'PENDING' " +
                                       "where ID = (select ID from dbo.fn_GetDirectiveRepairRecord('{7}')) ",
                                        repairdResultCode, remark, faultReason, impactStatement, solution, preventMeasure, picturePaths, billCode);
            string updateOrderSql = "update 维修工单 set 维修状态编码 = 'PENDING' where 维修工单编码 = '" + billCode + "' and 维修状态编码 = 'REPAIRING'";
            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            try
            {
                services.BeginTran();

                int num = 0;
                num = services.ExecuteSql(updateRecordSql);
                if(num <= 0) throw new Exception("更新维修记录失败");

                num = 0;
                num = services.ExecuteSql(updateOrderSql);
                if (num <= 0) throw new Exception("更新维修工单失败");

                services.Commit();
                return true;
            }
            catch(Exception ex)
            {
                PopUpUtil.ShowInfo(ex.Message);
                services.RollBack();
                return false;
            }

        }

        /// <summary>
        /// 验证维修任务提交时数据合法性
        /// </summary>
        /// <returns>是否通过验证</returns>
        private bool VerifySubmitData()
        {
            // 维修结果不能为空
            object repairResultCode = this.comboBox维修结果.SelectedValue;
            if (repairResultCode == null || repairResultCode.ToString() == "")
            {
                PopUpUtil.ShowWarning("维修结果不能为空");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验收维修结果
        /// </summary>
        /// <param name="billCode"></param>
        /// <returns></returns>
        public bool CheckAndAcceptTask(string billCode)
        {
            if(this.VerifyCheckAndAcceptTaskData() == false) return false;

            var service = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            try
            {
                service.BeginTran();

                string checkAndAcceptStatus = this.comboBox验收状态.SelectedValue.ToString();
                if (checkAndAcceptStatus == "PASSED")
                {   
                    this.UpdateOfPassedStatus(billCode, service);
                }
                else if(checkAndAcceptStatus == "REJECTED")
                {
                    this.UpdateOfRejectedStatus(billCode, service);
                }
                service.Commit();
                return true;
            }
            catch(Exception ex)
            {
                PopUpUtil.ShowWarning(ex.Message);
                service.RollBack();
                return false;
            }
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns>是否通过</returns>

        private bool VerifyCheckAndAcceptTaskData()
        {
            object checkAndAcceptStatusObj = this.comboBox验收状态.SelectedValue;
            string checkAndAcceptStatus = checkAndAcceptStatusObj == null ? "" : checkAndAcceptStatusObj.ToString();
            if (string.IsNullOrEmpty(checkAndAcceptStatus))
            {
                PopUpUtil.ShowWarning("验收状态不能为空");
                return false;
            }

            if (checkAndAcceptStatus == "REJECTED")
            {
                string reason = this.textBox重新维修原因.Text;
                if (string.IsNullOrEmpty(reason))
                {
                    PopUpUtil.ShowWarning("驳回状态下重新维修原因不能为空");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 验收通过
        /// </summary>
        private void UpdateOfPassedStatus(string billCode, SLOnlyInstOleDb services)
        {
            // 更新记录表
            string sql  = "update 维修记录 " +
                          "set 验收状态编码 = 'PASSED', " +
                              "验收人ID = " + UserSession.CurrentUser.MemberID + ", " +
                              "验收时间 = getDate() " +
                          "where ID = (select ID from dbo.fn_GetDirectiveRepairRecord('" + billCode + "')) " +
                              "and 验收状态编码 = 'PENDING' ";
            int num = services.ExecuteSql(sql);
            if(num <= 0) throw new Exception("更新维修记录失败");

            sql = "update 维修工单 " +
                  "set 执行状态编码 = 'COMPLETED', " +
                      "维修状态编码 = 'ACCEPTED', " +
                      "最后修改人 = " + UserSession.CurrentUser.MemberID + ", " +
                      "最后修改时间 = getDate() " +
                  "where 维修工单编码 = '" + billCode + "' " +
                    "and 执行状态编码 = 'EXECUTING' " +
                    "and 维修状态编码 = 'PENDING' ";
            num = 0;
            num = services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("更新维修工单失败");

            sql = "update 设备功能位置档案 " +
                  "set 设备状态编码 = 'NORMAL', " + // 设备状态为正常状态
                      "最后修改时间 = getDate(), " +
                      "最后修改人 = " + UserSession.CurrentUser.MemberID + " " +
                      "where 功能位置编码 = (select 功能位置编码 from 维修工单 where 维修工单编码 = '" + billCode + "')";
            num = services.ExecuteSql(sql); // 更新设备状态
            if (num <= 0) throw new Exception("更新设备状态失败");
        }

        /// <summary>
        /// 验收不通过,驳回
        /// </summary>
        private void UpdateOfRejectedStatus(string billCode, SLOnlyInstOleDb services)
        {
            string sql = "update 维修记录 " +
                          "set 验收状态编码 = 'REJECTED', " +
                              "重新维修原因 = '" + this.textBox重新维修原因.Text + "', " +
                              "验收人ID = " + UserSession.CurrentUser.MemberID + ", " +
                              "验收时间 = getDate() " +
                          "where ID = (select ID from dbo.fn_GetDirectiveRepairRecord('" + billCode + "')) " +
                              "and 验收状态编码 = 'PENDING' ";
            int num = services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("更新维修记录失败");

            sql = "update 维修工单 " +
                "set 维修状态编码 = 'REWORK', " +
                    "最后修改人 = " + UserSession.CurrentUser.MemberID + ", " +
                    "最后修改时间 = getDate() " +
                "where 维修工单编码 = '" + billCode + "' " +
                    "and 执行状态编码 = 'EXECUTING' " +
                    "and 维修状态编码 = 'PENDING' ";
            num = 0;
            num = services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("更新维修工单失败");

            // 创建新的维修记录
            this.CreateNewRepairRecord(billCode, services);

        }

        /// <summary>
        /// 创建新的维修记录
        /// </summary>
        private void CreateNewRepairRecord(string billCode, SLOnlyInstOleDb services)
        {
          if (this.checkBox重新选择维修人员.Checked)
            {
                var repairdPersonIDs = this.textBox重新维修人员.Tag;

                string sql = "update 维修工单 set 维修人员IDs = '" + repairdPersonIDs + "' where 维修工单编码 = '" + billCode + "' ";
                int num = services.ExecuteSql(sql);
                if (num <= 0) throw new Exception("更新维修工单失败");

                sql = "insert into 维修记录 (维修工单编码) " +
                      "values ('" + billCode + "') ";
                num = services.ExecuteSql(sql);
                if (num <= 0) throw new Exception("创建新的维修记录失败");

            }
            else
            {

                // 使用前维修信息
                string sql = "insert into 维修记录 (维修工单编码,维修人ID) " +
                             "select 维修工单编码, 维修人ID " +
                             "from 维修记录 " +
                             "where ID = (select ID from dbo.fn_GetDirectiveRepairRecord('" + billCode + "')) ";
                int num = services.ExecuteSql(sql);
                if (num <= 0) throw new Exception("创建新的维修记录失败");
            }
        }
    }

}
