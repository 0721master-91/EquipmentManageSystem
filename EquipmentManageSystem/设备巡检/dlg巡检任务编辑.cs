﻿﻿﻿using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLControls;
using SLControls.SLGlobal;
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
    public partial class dlg巡检任务编辑 : SLAomTmpForm
    {

        private string InspectionPicturePaths; //巡检照片路径
        private string FaultPicturePaths; //故障照片路径
        private bool IsReceivingTask = false; //是否是接收任务
        private string TaskCode; //任务编码

        public dlg巡检任务编辑()
        {
            InitializeComponent();
        }
        public dlg巡检任务编辑(bool isReceivingTask)
        {
            InitializeComponent();
            this.IsReceivingTask = isReceivingTask;
        }

        public bool IsCloseModify = false;
        private void CloseModify()
        {
            if (IsCloseModify)
            {
                this.Text = "查看巡检任务";
                this.button确定.Visible = false;
                this.button取消.Visible = false;
                this.uc巡检任务标准.panel巡检任务标准操作区.Visible = false;
            }
        }
        private void dlg巡检任务编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox巡检任务编码.Text = SqlCommonUtil.GenerateCode("XJRW", "巡检任务", "巡检任务编码");
                this.slTextBox单据类型.Text = "巡检任务";
                this.slTextBox单据来源.Text = "自建";
                this.slTextBox执行状态.Text = "待执行";
                this.slTextBox过期状态.Text = "未过期";
                this.slDateTimePicker计划执行日期.Value = DateTime.Now.Date;
            }
            this.uc巡检任务标准.SetPlanStartTime(this.slDateTimePicker计划执行日期.Value);

            // 默认为添加页面，如果是任务提交界面，需要启用和禁用部分控件
            if (this.IsReceivingTask)
            {
                this.ChangeToReceivingTaskMode();
            }

            this.CloseModify();
        }

        /// <summary>
        /// 切换为任务接取提交模式，部分控件启用和禁用
        /// </summary>
        private void ChangeToReceivingTaskMode()
        {
            // 启用巡检备注、巡检图片上传按钮
            this.slTextBox备注信息.ReadOnly = false;
            this.button添加巡检照片.Visible = true;
            this.flowLayoutPanel巡检照片.BackColor = Color.White;

            // 启用故障现象，故障照片上传
            this.slComboBox是否故障.Enabled = true;
            if (this.slComboBox是否故障.SelectedValue.ToString() == "是")
            {
                this.slTextBox故障现象.ReadOnly = false;
                this.button添加故障照片.Visible = true;
                this.flowLayoutPanel故障照片.BackColor = Color.White;
            }

            // 禁用功能位置编码选择
            this.slTextBox功能位置编码.ReadOnly = true;
            this.slTextBox功能位置编码.Click -= new EventHandler(OpenFunctionPositionDialog);
            this.label功能位置编码图标.Click -= new EventHandler(OpenFunctionPositionDialog);

            // 禁用巡检人员选择
            this.textBox巡检人员.ReadOnly = true;
            this.textBox巡检人员.Click -= new EventHandler(OpenMemberSelectedDialog);
            this.label巡检人员图标.Click -= new EventHandler(OpenMemberSelectedDialog);

            // 其他项禁用
            this.slDateTimePicker计划执行日期.Enabled = false;
            this.slDateTimePicker过期时间.Enabled = false;
            this.slTextBox提前提醒天数.ReadOnly = true;
            this.uc巡检任务标准.panel巡检任务标准操作区.Visible = false;
            this.uc巡检任务标准.dataGridView巡检任务标准数据.ReadOnly = true;
            this.uc巡检任务标准.ForbiddenOpenDialog();
        }

        // 点击添加图片
        private void AddPictures(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string panelName = "flowLayoutPanel" + btn.Name.Substring(8);
            Control[] found = btn.Parent.Controls.Find(panelName, true);

            FlowLayoutPanel panel = found[0] as FlowLayoutPanel;
            PictureHandleUtil.SelectPicturesToPanel(panel);
        }

        private bool dlg巡检任务编辑_PreFillControls(FieldArray aryFields)
        {
            DataTable isFault = new DataTable();
            isFault.Columns.Add("值", typeof(string));
            isFault.Columns.Add("显示", typeof(string));
            isFault.Rows.Add("否", "否");
            isFault.Rows.Add("是", "是");
            this.slComboBox是否故障.DataSource = isFault;
            this.slComboBox是否故障.DisplayMember = "显示";
            this.slComboBox是否故障.ValueMember = "值";

            return true;
        }

        private void dlg巡检任务编辑_AfterFillControls()
        {
            this.TaskCode = this.slTextBox巡检任务编码.Text;
            string taskCode = this.slTextBox巡检任务编码.Text;
            
            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                // 新增时过期时间默认为当天17:30，如果当天已过17:30则默认为次日17:30
                DateTime expiredTime = DateTime.Now.Date.AddHours(17).AddMinutes(30);
                if(expiredTime < DateTime.Now)
                {
                    expiredTime = expiredTime.AddDays(1);
                }
                this.slDateTimePicker过期时间.Value = expiredTime;
            }
            else if(this.OperFlag == SleOperFlag.Modify)
            {
                string positionCode = this.slTextBox功能位置编码.Text;
                if (string.IsNullOrEmpty(positionCode))
                    this.uc巡检任务标准.PositionCode = positionCode;

                this.FillOtherControls(taskCode);
            }
        }

        private void slDateTimePicker计划执行日期_ValueChanged(object sender, EventArgs e)
        {
            this.uc巡检任务标准.SetPlanStartTime(this.slDateTimePicker计划执行日期.Value);
            this.uc巡检任务标准.UpdateDateTime();
        }

        /// <summary>
        /// 填充其他控件
        /// </summary>
        /// <param name="code">单据编码</param>
        private void FillOtherControls(string code)
        {

            string sql = "select s.功能位置编码,s.功能位置描述,s.位置简称,r.名称 as 所属区域,d.部门名称 as 管理部门,m.姓名 as 设备责任人, " +
                         "dbo.fn_GetMemberNamesByIds(xjrw.巡检人员IDs) as 巡检人员, xjrw.巡检人员IDs, " +
                         "xjrw.巡检照片路径,xjrw.故障照片路径,xjrw.巡检结束时间 " +
                         "from 设备功能位置档案 as s " +
                         "left join 区域 as r on s.所属区域编码 = r.编码 " +
                         "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                         "left join 成员 as m on s.责任人ID = m.ID " +
                         "join 巡检任务 xjrw on xjrw.设备功能位置编码 = s.功能位置编码 " +
                         "where xjrw.巡检任务编码 = '" + code + "'";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            this.uc巡检任务标准.PositionCode = dt.Rows[0]["功能位置编码"].ToString();
            this.textBox功能位置描述.Text = dt.Rows[0]["功能位置描述"].ToString();
            this.textBox位置简称.Text = dt.Rows[0]["位置简称"].ToString();
            this.textBox所属区域.Text = dt.Rows[0]["所属区域"].ToString();
            this.textBox设备管理部门.Text = dt.Rows[0]["管理部门"].ToString();
            this.textBox设备负责人.Text = dt.Rows[0]["设备责任人"].ToString();

            this.textBox巡检人员.Text = dt.Rows[0]["巡检人员"].ToString();
            this.textBox巡检人员.Tag = dt.Rows[0]["巡检人员IDs"].ToString();

            // 图片加载
            this.InspectionPicturePaths = dt.Rows[0]["巡检照片路径"]?.ToString();
            this.FaultPicturePaths = dt.Rows[0]["故障照片路径"]?.ToString();
            PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel巡检照片, dt.Rows[0]["巡检照片路径"].ToString());
            PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel故障照片, dt.Rows[0]["故障照片路径"].ToString());

            // 标准加载
            sql = "select s.ID,s.巡检部位,s.巡检内容,s.巡检类型,s.判断标准,s.巡检周期,s.周期单位,s.提前提醒天数,s.开始执行日期,s.下次执行日期 " +
                  "from 巡检任务标准 as s " +
                  "where s.所属巡检任务编码 = '" + code + "' and IsDelete = 0 ";
            DataTable sd = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            DataTable standardTable = this.uc巡检任务标准.StandardDataTable;
            standardTable.Rows.Clear();
            foreach(DataRow r in sd.Rows)
            {
                standardTable.Rows.Add(
                    r["巡检部位"],r["巡检内容"],r["判断标准"],r["巡检类型"],r["巡检周期"],r["周期单位"],r["提前提醒天数"],r["开始执行日期"],r["下次执行日期"], r["ID"]);

            }
        }

        /// <summary>
        /// 点击选择设备功能位置
        /// </summary>
        private void OpenFunctionPositionDialog(object sender, EventArgs e)
        {
            using (dlg设备功能位置选择 dlg = new dlg设备功能位置选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.slTextBox功能位置编码.Text = dlg.PositionCode;
                    this.textBox功能位置描述.Text = dlg.PositionDescription;
                    this.textBox位置简称.Text = dlg.PositionShortName;
                    this.textBox所属区域.Text = dlg.Area;
                    this.textBox设备管理部门.Text = dlg.Department;
                    this.textBox设备负责人.Text = dlg.ResponsiblePerson;
                }
                this.uc巡检任务标准.PositionCode = dlg.PositionCode;
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 点击选择成员
        /// </summary>
        private void OpenMemberSelectedDialog(object sender, EventArgs e)
        {
            using(dlg人员选择 dlg = new dlg人员选择("巡检人员选择") { IsMultiSelect = true })
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    this.textBox巡检人员.Text = dlg.SelectedMemberNames;
                    this.textBox巡检人员.Tag = dlg.SelectedMemberIDs;
                }
                this.ActiveControl = null;
            }
        }

        private bool dlg巡检任务编辑_PreExecuteOKSql(object sender, PreOKSqlEventArgs e)
        {
            SLControls.SLDbService.SLOnlyInstOleDb.Services.BeginTran(); // 开启事务
            return true;
        }

        /// <summary>
        /// 处理图片数据，将图片进行保存并返回保存位置（相对路径）
        /// </summary>
        /// <param name="panel">图片面板</param>
        /// <param name="pictureSubDir">保存子路径</param>
        /// <returns>保存地址</returns>
        private string HandlePictureData(FlowLayoutPanel panel,string pictureSubDir)
        {

            List<string> paths = panel.Controls
                .OfType<PictureBox>()
                .Where(p => p.Tag != null)
                .Select(p => p.Tag.ToString())
                .ToList();

            return PictureHandleUtil.SavePicturesAndGetSavePath(paths, pictureSubDir);
        }

        // 添加其他附属信息
        private void dlg巡检任务编辑_AfterExecuteOKSql(object sender, AfterOKSqlEventArgs e)
        {
            try
            {
                // 保存巡检任务标准
                this.UpdateInspectionTaskStandard();

                if (this.IsReceivingTask)
                {
                    // 接取任务时，更新巡检任务状态

                    string sql = "update 巡检任务 " +
                                 "set 执行状态编码 ='COMPLETED'," +
                                 "    任务接取人ID =" + UserSession.CurrentUser.MemberID + "," +
                                 "    巡检结束时间 = getDate() " +
                                 "where 巡检任务编码 ='" + this.TaskCode + "' " +
                                    "and IsDelete = 0 " +
                                    "and 执行状态编码 = 'WAITING' " +
                                    "and 过期时间 > getDate() ";
                    int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
                    if(num <= 0)
                        throw new Exception("更新巡检任务状态失败！");
                }

                SLControls.SLDbService.SLOnlyInstOleDb.Services.Commit(); // 提交事务
            }
            catch(Exception ex)
            {
                PopUpUtil.ShowError("保存失败：" + ex.Message);
                SLControls.SLDbService.SLOnlyInstOleDb.Services.RollBack(); // 回滚事务
            }


        }

        /// <summary>
        /// 增量保存巡检任务标准：有ID则UPDATE(保留创建时间)，无ID则INSERT，被移除的行反向DELETE
        /// </summary>
        private void UpdateInspectionTaskStandard()
        {
            DataTable dt = this.uc巡检任务标准.StandardDataTable;
            if (dt == null)
                return;

            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            string billCode = this.slTextBox巡检任务编码.Text;

            // 收集当前网格里还在的明细ID
            List<string> ids = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                object idv = row["ID"];
                if (idv != null && idv != DBNull.Value && Convert.ToInt64(idv) > 0)
                    ids.Add(idv.ToString());
            }

            // 反向删除：删掉该单据号下、ID 不在当前网格中的行
            string deleteSql = ids.Count == 0
                ? "update 巡检任务标准 set IsDelete = 1 where 所属巡检任务编码='" + billCode + "'"
                : "update 巡检任务标准 set IsDelete = 1 where 所属巡检任务编码='" + billCode +
                  "' and ID not in (" + string.Join(",", ids) + ")";
            services.ExecuteSql(deleteSql);

            // 逐行保存：已有行UPDATE，新行INSERT
            foreach (DataRow row in dt.Rows)
            {
                object idv = row["ID"];
                bool hasId = idv != null && idv != DBNull.Value && Convert.ToInt64(idv) > 0;

                int num = 0;

                if (hasId)
                {
                    List<string> sets = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                            continue;
                        sets.Add(col.ColumnName + "=" + SqlCommonUtil.FormatSqlValue(row[col]));
                    }
                    num = services.ExecuteSql("update 巡检任务标准 set " + string.Join(",", sets) + " where ID=" + idv);
                }
                else
                {
                    List<string> colNames = new List<string> { "所属巡检任务编码" };
                    List<string> vals = new List<string> { SqlCommonUtil.FormatSqlValue(billCode) };
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                            continue;
                        colNames.Add(col.ColumnName);
                        vals.Add(SqlCommonUtil.FormatSqlValue(row[col]));
                    }
                    num = services.ExecuteSql("insert into 巡检任务标准 (" + string.Join(",", colNames) + ") values (" + string.Join(",", vals) + ")");
                }

                if(num <= 0)
                {
                    PopUpUtil.ShowError(num.ToString());
                    throw new Exception("保存巡检任务标准失败");
                }
            }
        }

        private bool dlg巡检任务编辑_PreOK(FieldArray aryFields)
        {
            if (!this.VerifyData()) return false;

            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                // 尽可能减少重复的情况导致添加失败
                this.slTextBox巡检任务编码.Text = SqlCommonUtil.GenerateCode("XJRW", "巡检任务", "巡检任务编码");
            }



            // 添加额外字段信息
            object inspectPersonIDsObj = this.textBox巡检人员.Tag;
            string inspectPersonIDs = inspectPersonIDsObj == null ? "" : inspectPersonIDsObj.ToString();
            this.OtherFields["巡检人员IDs"] = inspectPersonIDs;

            // 添加巡检与结束时间
            DateTime planTime = this.slDateTimePicker计划执行日期.Value;
            DateTime startTime = DateTime.Parse(planTime.ToString("yyyy-MM-dd") + " 08:30:00");
            if(startTime < DateTime.Now)
            {
                startTime = DateTime.Now;
            }
            this.OtherFields["巡检开始时间"] = startTime;
            if (this.IsReceivingTask)
            {
                // 巡检结束时间
                this.OtherFields["巡检结束时间"] = this.slDateTimePicker过期时间.Value;

                // 添加图片信息
                this.OtherFields["巡检照片路径"] = this.InspectionPicturePaths;
                if (this.slComboBox是否故障.SelectedValue.ToString() == "是")
                {
                    this.OtherFields["故障照片路径"] = this.FaultPicturePaths;
                }
            }

            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;
        }

        // 控制故障信息填写以及故障照片的添加
        private void slComboBox是否故障_SelectedIndexChanged(object sender, EventArgs e)
        {
            string isFault = this.slComboBox是否故障.SelectedValue.ToString();
            if(isFault == "是")
            {
                this.slTextBox故障现象.ReadOnly = false;
                this.button添加故障照片.Visible = true;
                this.flowLayoutPanel故障照片.BackColor = Color.White;
            }
            else
            {
                this.slTextBox故障现象.ReadOnly = true;
                this.button添加故障照片.Visible = false;
                this.slTextBox故障现象.Text = string.Empty;
                this.flowLayoutPanel故障照片.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns></returns>
        private bool VerifyData()
        {
            if (this.IsReceivingTask)
            {
                this.InspectionPicturePaths = this.HandlePictureData(this.flowLayoutPanel巡检照片, "巡检任务");
                if (string.IsNullOrEmpty(this.InspectionPicturePaths))
                {
                    PopUpUtil.ShowError("请添加巡检照片");
                    return false;
                }
                this.FaultPicturePaths = this.HandlePictureData(this.flowLayoutPanel故障照片, "巡检任务故障");
                if(this.slComboBox是否故障.SelectedValue.ToString() == "是" && string.IsNullOrEmpty(this.FaultPicturePaths))
                {
                    PopUpUtil.ShowError("请添加故障照片");
                    if (!string.IsNullOrEmpty(this.InspectionPicturePaths)) PictureHandleUtil.DeletePictures(this.InspectionPicturePaths.Split(','));
                    return false;
                }
            }
            else
            {
                DateTime palnTime = this.slDateTimePicker计划执行日期.Value;
                DateTime endTime = this.slDateTimePicker过期时间.Value;
                if(palnTime.Date > endTime.Date)
                {
                    PopUpUtil.ShowError("计划执行日期不能大于过期时间");
                    return false;
                }
            }

            return true;
        }
    }
}