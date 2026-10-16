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
using SLControls;
using SLControls.SLGlobal;

namespace EquipmentManageSystem.设备维修
{
    public partial class dlg维修任务编辑 : SLAomTmpForm
    {
        private string OldPicturePath; // 保存照片的旧路径
        private string NewPicturePath; // 保存照片的新路径

        public dlg维修任务编辑()
        {
            InitializeComponent();
        }

        private void dlg维修任务编辑_AfterFillControls()
        {
            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox单据号.Text = SqlCommonUtil.GenerateCode("WXGD", "维修工单", "维修工单编码");
            }
            this.FillOtherControls();
        }

        private bool dlg维修任务编辑_PreOK(FieldArray aryFields)
        {
            this.OtherFields.Clear();

            object repairPeopleIDsObj = this.textBox维修人员.Tag;
            string repairPeopleIDs = repairPeopleIDsObj == null ? "" : repairPeopleIDsObj.ToString();
            this.OtherFields.Add(new SlcFieldInfo
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "维修人员IDs",
                KeyValue = repairPeopleIDs,
                KeyType = SleDataType.String
            });

            this.NewPicturePath = this.HandlePictureData();
            this.OtherFields.Add(new SlcFieldInfo
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "故障照片路径",
                KeyValue = this.NewPicturePath,
                KeyType = SleDataType.String
            });

            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.OtherFields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "报修人ID",
                    KeyValue = UserSession.CurrentUser.MemberID.ToString(),
                    KeyType = SleDataType.String
                });
            }

            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;
        }

        private bool dlg维修任务编辑_PreExecuteOKSql(object sender, PreOKSqlEventArgs e)
        {
            SLControls.SLDbService.SLOnlyInstOleDb.Services.BeginTran(); // 开启事务
            return true;
        }

        private void dlg维修任务编辑_AfterExecuteOKSql(object sender, AfterOKSqlEventArgs e)
        {
            try
            {
                if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
                {
                    this.GenerateRepairdOrder();
                }
                SLControls.SLDbService.SLOnlyInstOleDb.Services.Commit(); // 提交事务
            }
            catch (Exception ex)
            {
                PopUpUtil.ShowError("保存失败：" + ex.Message);
                SLControls.SLDbService.SLOnlyInstOleDb.Services.RollBack(); // 回滚事务
            }
        }

        /// <summary>
        /// 填充其他控件
        /// </summary>
        private void FillOtherControls()
        {
            // 填充组织、部门信息
            long memberID;
            string memberIDStr = this.slTextBox报修人.Text == null ? "" : this.slTextBox报修人.Text.Trim();
            if (long.TryParse(memberIDStr, out memberID) == false)
            {
                memberID = UserSession.CurrentUser.MemberID;
            }

            string sql = "select o.公司地址,d.部门名称,m.姓名 " +
                         "from 成员 as m " +
                         "left join 部门 as d on m.部门编码 = d.部门编码 " +
                         "left join 组织 as o on d.组织编码 = o.组织编码 " +
                         "where m.ID = " + memberID;
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            this.slTextBox报修人.Text = dt.Rows[0]["姓名"].ToString();
            this.textBox流程组织.Text = dt.Rows[0]["公司地址"].ToString();
            this.textBox流程部门.Text = dt.Rows[0]["部门名称"].ToString();

            if (this.OperFlag == SleOperFlag.Modify)
            {
                string billCode = this.slTextBox单据号.Text.Trim();
                sql = "select s.功能位置编码,s.功能位置描述,s.位置简称,r.名称 as 所属区域,d.部门名称 as 管理部门,m.姓名 as 设备责任人, " +
                             "dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员, rwo.维修人员IDs, " +
                             "rwo.故障照片路径 " +
                             "from 设备功能位置档案 as s " +
                             "left join 区域 as r on s.所属区域编码 = r.编码 " +
                             "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                             "left join 成员 as m on s.责任人ID = m.ID " +
                             "join 维修工单 rwo on rwo.功能位置编码 = s.功能位置编码 " +
                             "where rwo.维修工单编码 = '" + billCode + "'";
                dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);


                // 填充功能位置信息
                this.textBox功能位置描述.Text = dt.Rows[0]["功能位置描述"].ToString();
                this.textBox位置简称.Text = dt.Rows[0]["位置简称"].ToString();
                this.textBox所属区域.Text = dt.Rows[0]["所属区域"].ToString();
                this.textBox设备管理部门.Text = dt.Rows[0]["管理部门"].ToString();
                this.textBox设备负责人.Text = dt.Rows[0]["设备责任人"].ToString();
                this.textBox维修人员.Text = dt.Rows[0]["维修人员"].ToString();
                this.textBox维修人员.Tag = dt.Rows[0]["维修人员IDs"].ToString();

                // 填充照片信息
                string faultPicturePath = dt.Rows[0]["故障照片路径"].ToString();
                this.OldPicturePath = faultPicturePath;
                PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel故障照片, faultPicturePath);
            }
        }

        /// <summary>
        /// 保存照片数据并返回保存路径
        /// </summary>
        /// <returns>保存路径</returns>
        private string HandlePictureData()
        {
            List<string> paths = this.flowLayoutPanel故障照片.Controls
                          .OfType<PictureBox>()
                          .Where(p => p.Tag != null)
                          .Select(p => p.Tag.ToString())
                          .ToList();
            List<string> oldPathList = string.IsNullOrEmpty(this.OldPicturePath) ? new List<string>() : this.OldPicturePath.Split(',').ToList();
            if (PictureHandleUtil.IsSamePictures(paths, oldPathList))
            {
                return this.OldPicturePath;
            }
            else
            {
                if (this.OperFlag == SleOperFlag.Modify)
                {
                    PictureHandleUtil.DeletePictures(this.OldPicturePath.Split(','));
                }
                return PictureHandleUtil.SavePicturesAndGetSavePath(paths, "故障照片");
            }

        }

        /// <summary>
        /// 打开功能位置选择对话框
        /// </summary>
        private void OpenFunctionPositionDialog(object sender, EventArgs e)
        {
            string positionCode = this.slTextBox功能位置编码.Text;
            using (dlg设备功能位置选择 dlg = new dlg设备功能位置选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.PositionCode == positionCode)
                        return;

                    this.slTextBox功能位置编码.Text = dlg.PositionCode;
                    this.textBox功能位置描述.Text = dlg.PositionDescription;
                    this.textBox位置简称.Text = dlg.PositionShortName;
                    this.textBox所属区域.Text = dlg.Area;
                    this.textBox设备管理部门.Text = dlg.Department;
                    this.textBox设备负责人.Text = dlg.ResponsiblePerson;
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 点击选择成员
        /// </summary>
        private void OpenMemberSelectedDialog(object sender, EventArgs e)
        {
            using (dlg人员选择 dlg = new dlg人员选择("保养人员选择") { IsMultiSelect = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.textBox维修人员.Text = dlg.SelectedMemberNames;
                    this.textBox维修人员.Tag = dlg.SelectedMemberIDs;
                }

                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 打开照片选择弹窗
        /// </summary>
        private void OpenPictureSelectedDialog(object sender, EventArgs e)
        {
            PictureHandleUtil.SelectPicturesToPanel(this.flowLayoutPanel故障照片);
        }

        /// <summary>
        /// 创建维修单时自生成一条维修记录
        /// </summary>
        private void GenerateRepairdOrder()
        {
            string repairdOrderCode = this.slTextBox单据号.Text;
            string sql = "insert into 维修记录(维修工单编码) values ('" + repairdOrderCode + "') ";
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);

            if (num <= 0) throw new Exception("创建维修记录失败！");
        }
    }
}