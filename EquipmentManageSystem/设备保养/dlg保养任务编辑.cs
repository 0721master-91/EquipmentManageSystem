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

namespace EquipmentManageSystem.设备保养
{
    public partial class dlg保养任务编辑 : SLAomTmpForm
    {
        private OperationType OperType; // 当前操作类型
        private string TaskCode; // 当前任务编码
        private string PicturePathBeforeMaintenance = string.Empty; // 保养前照片路径
        private string PicturePathAfterMaintenance = string.Empty; // 保养后照片路径

        public dlg保养任务编辑()
        {
            InitializeComponent();
            this.OperType = OperationType.Common;
        }

        public dlg保养任务编辑(OperationType operType)
        {
            InitializeComponent();
            this.OperType = operType;
        }

        // 自动填充前初始化部分控件
        private bool dlg保养任务编辑_PreFillControls(FieldArray aryFields)
        {
            DataTable IsInvalidBill = new DataTable();
            IsInvalidBill.Columns.Add("是否无效");
            IsInvalidBill.Rows.Add("否");
            IsInvalidBill.Rows.Add("是");
            this.comboBox无效单据.DataSource = IsInvalidBill;
            this.comboBox无效单据.DisplayMember = "是否无效";
            this.comboBox无效单据.ValueMember = "是否无效";

            if (this.OperType == OperationType.Common && (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew))
            {
                // 新增或复制新增时验收状态不需要显示，由创建时自动赋值为待验收
                this.slComboBox验收状态.SelectedIndex = -1;
                this.comboBox无效单据.SelectedIndex = -1;
            }


            return true;
        }

        // 自动填充后对部分控件进行赋值
        private void dlg保养任务编辑_AfterFillControls()
        {
            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox保养任务编码.Text = SqlCommonUtil.GenerateCode("BYRW", "保养任务", "保养任务编码");
                this.slTextBox单据来源.Text = "自建";
                this.slTextBox执行状态.Text = "待执行";
                this.slTextBox过期状态.Text = "未过期";
                this.slDateTimePicker计划执行日期.Value = DateTime.Now.Date;

                // 过期时间默认初始值为下午17:30，根据当前时间是否超过当天下午17:30，则默认过期时间为次日下午17:30
                if (DateTime.Now.Hour >= 17 && DateTime.Now.Minute >= 30)
                {
                    this.slDateTimePicker过期时间.Value = DateTime.Now.AddDays(1).Date.AddHours(17).AddMinutes(30);
                }
                else
                {
                    this.slDateTimePicker过期时间.Value = DateTime.Today.AddHours(17).AddMinutes(30);
                }
            }
            else if (this.OperFlag == SleOperFlag.Modify)
            {
                this.FillOtherControls(this.slTextBox保养任务编码.Text);
            }
            this.TaskCode = this.slTextBox保养任务编码.Text;

            this.ChangeApplicationScene(this.OperType);
        }

        // 点击确认前为额外字段添加值
        private bool dlg保养任务编辑_PreOK(FieldArray aryFields)
        {
            if(this.VerifyData() == false)
            {
                return false;
            }

            // 验收设计多个状态变更，执行前先查看任务状态
            if (this.OperType == OperationType.AcceptanceSubmit)
            {
                DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select * from 保养任务 where 保养任务编码 = '" + this.TaskCode + "' ");
                string maintenanceStatusCode = dt.Rows[0]["保养状态编码"].ToString();
                string executeStatusCode = dt.Rows[0]["执行状态编码"].ToString();
                string acceptStatusCode = dt.Rows[0]["验收状态编码"].ToString();
                if (maintenanceStatusCode == "PASSED" || executeStatusCode == "COMPLETED" || acceptStatusCode != "PENDING")
                {
                    PopUpUtil.ShowWarning("该保养任务已验收，无法修改！");
                    return false;
                }
            }

            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox保养任务编码.Text = SqlCommonUtil.GenerateCode("BYRW", "保养任务", "保养任务编码"); // 重新获取一次最新保养任务编码，减少重复概率
            }

            this.OtherFields.Clear();

            if(this.OperType == OperationType.Common)
            {
                object maintenancePersonIDsObj = this.textBox保养人员.Tag;
                string maintenancePersonIDs = maintenancePersonIDsObj == null ? "" : maintenancePersonIDsObj.ToString();
                this.OtherFields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "保养人员IDs",
                    KeyValue = maintenancePersonIDs,
                    KeyType = SleDataType.String
                });

                DateTime planExecuteDate = this.slDateTimePicker计划执行日期.Value;
                DateTime startTime = DateTime.Parse(planExecuteDate.ToString("yyyy-MM-dd") + " 08:30:00");
                if(startTime < DateTime.Now)
                {
                    startTime = DateTime.Now;
                }
                this.OtherFields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "保养开始时间",
                    KeyValue = startTime,
                    KeyType = SleDataType.DateTime
                });
            }
            else if(this.OperType == OperationType.TaskSubmit)
            {
                this.OtherFields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "保养前照片路径",
                    KeyValue = this.HandlePictureData(this.flowLayoutPanel保养前照片,"保养前照片"),
                    KeyType = SleDataType.String
                });

                this.OtherFields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "保养后照片路径",
                    KeyValue = this.HandlePictureData(this.flowLayoutPanel保养后照片, "保养后照片"),
                    KeyType = SleDataType.String
                });
            }

            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;
        }

        // 指定主sql语句后进行的事件
        private void dlg保养任务编辑_AfterExecuteOKSql(object sender, AfterOKSqlEventArgs e)
        {
            if (e.Successful)
            {
                try
                {

                    if (this.OperType == OperationType.Common)
                    {
                        // 保存保养标准
                        this.UpdateMaintenanceTaskStandard();
                    }
                    else if (this.OperType == OperationType.TaskSubmit)
                    {
                        // 更新任务状态信息
                        this.UpdateMaintenanceTaskSubmitStatus();
                    }
                    else if (this.OperType == OperationType.AcceptanceSubmit)
                    {
                        // 更新验收状态
                        this.UpdateMaintenanceTaskAcceptStatus();
                    }
                }
                catch (Exception ex)
                {
                    e.LastError = ex.Message;
                    e.Successful = false;
                }
            }
            

        }

        public bool IsCloseModify = false;
        private void CloseModify()
        {
            if (IsCloseModify)
            {
                this.Text = "查看保养任务";
                this.button确定.Visible = false;
                this.button取消.Visible = false;
                this.CloseCommonControls();
            }
        }

        private void dlg保养任务编辑_Load(object sender, EventArgs e)
        {
            this.CloseModify();
        }

        // 计划时间改变时触发的事件
        private void slDateTimePicker计划执行日期_ValueChanged(object sender, EventArgs e)
        {
            this.uc保养任务标准.SetPlantStartTime(this.slDateTimePicker计划执行日期.Value);
            this.uc保养任务标准.UpdateDateTime();
        }

        /// <summary>
        /// 点击选择设备功能位置
        /// </summary>
        private void OpenFunctionPositionDialog(object sender, EventArgs e)
        {
            string positionCode = this.slTextBox功能位置编码.Text;
            List<string> equipmetStatusCodeList = new List<string>() { "NORMAL", "REPAIRING", "ABNORMAL"};
            using(dlg设备功能位置选择 dlg = new dlg设备功能位置选择(equipmetStatusCodeList))
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
                this.uc保养任务标准.ClearDataTable();
                this.uc保养任务标准.SetPositionCode(dlg.PositionCode);
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
                    this.textBox保养人员.Text = dlg.SelectedMemberNames;
                    this.textBox保养人员.Tag = dlg.SelectedMemberIDs;
                }
                
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 打开照片选择弹窗
        /// </summary>
        private void OpenPictureSelectedDialog(object sender, EventArgs e)
        {
            Label label = sender as Label;
            string panelName = "flowLayoutPanel" + label.Name.Substring(5).Replace("图标","");
            Control[] found = label.Parent.Controls.Find(panelName, true);

            FlowLayoutPanel panel = found[0] as FlowLayoutPanel;

            PictureHandleUtil.SelectPicturesToPanel(panel);
        }

        /// <summary>
        /// 更新保养任务标准
        /// </summary>
        private void UpdateMaintenanceTaskStandard()
        {
            DataTable dt = this.uc保养任务标准.MaintenanceTaskStandardData;
            if (dt == null)
                return;

            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            string billCode = this.slTextBox保养任务编码.Text;

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
                ? "update 保养任务标准 set IsDelete = 1 where 所属保养任务编码='" + billCode + "'"
                : "update 保养任务标准 set IsDelete = 1 where 所属保养任务编码='" + billCode +
                  "' and ID not in (" + string.Join(",", ids) + ")";
            services.ExecuteSql(deleteSql);


            // 逐行保存：已有行UPDATE，新行INSERT
            foreach (DataRow row in dt.Rows)
            {
                object idv = row["ID"];
                bool hasId = idv != null && idv != DBNull.Value && Convert.ToInt64(idv) > 0;

                // 整行都是空值（null 或空字符串）时跳过，不保存空记录
                bool rowEmpty = true;
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "ID")
                        continue;
                    object v = row[col];
                    if (v != null && v != DBNull.Value && v.ToString().Trim() != "")
                    {
                        rowEmpty = false;
                        break;
                    }
                }
                if (rowEmpty)
                    continue;

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
                    num = services.ExecuteSql("update 保养任务标准 set " + string.Join(",", sets) + " where ID=" + idv);
                }
                else
                {
                    List<string> colNames = new List<string> { "所属保养任务编码" };
                    List<string> vals = new List<string> { SqlCommonUtil.FormatSqlValue(billCode) };
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                            continue;
                        colNames.Add(col.ColumnName);
                        vals.Add(SqlCommonUtil.FormatSqlValue(row[col]));
                    }
                    num = services.ExecuteSql("insert into 保养任务标准 (" + string.Join(",", colNames) + ") values (" + string.Join(",", vals) + ")");
                }

                if (num <= 0)
                {
                    PopUpUtil.ShowError(num.ToString());
                    throw new Exception("保存保养任务标准失败");
                }
            }
        }

        /// <summary>
        /// 更新保养任务提交状态
        /// </summary>
        private void UpdateMaintenanceTaskSubmitStatus()
        {
            string maintenanceStatusCode;
            string executeStatusCode = "EXECUTING";
            string acceptStatusCode = "PENDING";
            if (this.comboBox无效单据.Text == "是")
            {
                maintenanceStatusCode = "VOID"; // 无效单据
                executeStatusCode = "COMPLETED";
                acceptStatusCode = string.Empty; // 无效单据不需要验收
            }
            else
            {
                maintenanceStatusCode = "PENDING"; // 待验收
            }

            string sql = "update 保养任务 " +
                         "set 执行状态编码 = '" + executeStatusCode + "', " +
                             "保养状态编码 = '" + maintenanceStatusCode + "', " +
                             "验收状态编码 = '" + acceptStatusCode + "', " +
                             "任务接取人ID = " + UserSession.CurrentUser.MemberID + ", " +
                             "保养结束时间 = getDate() " +
                             "where 保养任务编码 = '" + this.TaskCode + "' " +
                                 "and IsDelete = 0 " +
                                 "and 执行状态编码 != 'COMPLETED' " +
                                 "and 保养状态编码 in ('DUE', 'REDUE') " +
                                 "and 过期时间 >= getDate() ";

            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("更新保养任务提交状态失败");
        }

        /// <summary>
        /// 更新保养任务验收状态
        /// </summary>
        private void UpdateMaintenanceTaskAcceptStatus()
        {
            DataRow row = this.slComboBox验收状态.SelectedRow;
            string acceptCode = row["编码"].ToString();
            
            string executeStatusCode;
            string maintenanceStatusCode;
            if(acceptCode == "PASSED")
            {
                // 验收通过
                executeStatusCode = "COMPLETED";
                maintenanceStatusCode = "PASSED";
            }
            else if(acceptCode == "REJECTED")
            {
                // 驳回
                executeStatusCode = "EXECUTING";
                maintenanceStatusCode = "REDUE";
            }
            else
            {
                return;
            }

            string sql = "update 保养任务 " +
                         "set 执行状态编码 = '" + executeStatusCode + "', " +
                             "保养状态编码 = '" + maintenanceStatusCode + "', " +
                             "验收人ID = " + UserSession.CurrentUser.MemberID + ", " +
                             "验收时间 = getDate() " +
                             "where 保养任务编码 = '" + this.TaskCode + "' " +
                                 "and IsDelete = 0 " +
                                 "and 执行状态编码 != 'COMPLETED' " +
                                 "and 保养状态编码 = 'PENDING' ";
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            Console.WriteLine(sql);
            if (num <= 0) throw new Exception("更新保养任务验收状态失败");

            if (acceptCode == "REJECTED")
            {
                // 驳回情况下，需要重新设置过期时间（以保养任务标准最近时间为准，如果没有保养标准，默认以当天时间往后延长1天）
                sql = "update 保养任务 " +
                      "set 过期状态编码 = 'UNEXPIRED', " +
                          "过期时间 = convert(datetime, convert(varchar(10), dateAdd(day, 1, getDate()), 120) + ' 17:30:00') " +
                      "where 保养任务编码 = '" + this.TaskCode + "' " +
                          "and (过期时间 < getDate() or datediff(day, getDate(), 过期时间) < 1)";
                num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
                Console.WriteLine(sql);
                Console.WriteLine(num);
            }
        }

        /// <summary>
        /// 填充其他控件
        /// </summary>
        /// <param name="taskCode">保养任务编码</param>
        private void FillOtherControls(string taskCode)
        {
            string sql = "select s.功能位置编码,s.功能位置描述,s.位置简称,r.名称 as 所属区域,d.部门名称 as 管理部门,m.姓名 as 设备责任人, " +
                         "dbo.fn_GetMemberNamesByIds(byrw.保养人员IDs) as 保养人员, byrw.保养人员IDs, " +
                         "byrw.保养前照片路径,byrw.保养后照片路径 " +
                         "from 设备功能位置档案 as s " +
                         "left join 区域 as r on s.所属区域编码 = r.编码 " +
                         "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                         "left join 成员 as m on s.责任人ID = m.ID " +
                         "join 保养任务 as byrw on s.功能位置编码 = byrw.设备功能位置编码 " +
                         "where byrw.保养任务编码 = '" + taskCode + "' ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            this.uc保养任务标准.SetPositionCode(dt.Rows[0]["功能位置编码"].ToString());
            this.textBox功能位置描述.Text = dt.Rows[0]["功能位置描述"].ToString();
            this.textBox位置简称.Text = dt.Rows[0]["位置简称"].ToString();
            this.textBox所属区域.Text = dt.Rows[0]["所属区域"].ToString();
            this.textBox设备管理部门.Text = dt.Rows[0]["管理部门"].ToString();
            this.textBox设备负责人.Text = dt.Rows[0]["设备责任人"].ToString();

            this.textBox保养人员.Text = dt.Rows[0]["保养人员"].ToString();
            this.textBox保养人员.Tag = dt.Rows[0]["保养人员IDs"].ToString();

            // 标准加载
            this.uc保养任务标准.LoadData(taskCode);

            // 照片加载
            string beforePath = dt.Rows[0]["保养前照片路径"]?.ToString();
            string afterPath = dt.Rows[0]["保养后照片路径"]?.ToString();
            if(this.OperType != OperationType.TaskSubmit)
            {
                PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel保养前照片, beforePath);
                PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel保养后照片, afterPath);
            }


        }

        /// <summary>
        /// 切换应用场景
        /// </summary>
        private void ChangeApplicationScene(OperationType type)
        {
            if(type == OperationType.TaskSubmit)
            {
                // 保养任务提交

                // 关闭常规场景下的控件的操作权限
                this.CloseCommonControls();

                // 打开对应权限
                this.comboBox无效单据.Enabled = true;
                this.label保养前照片图标.Click += new EventHandler(this.OpenPictureSelectedDialog);
                this.flowLayoutPanel保养前照片.BackColor = Color.White;
                this.label保养后照片图标.Click += new EventHandler(this.OpenPictureSelectedDialog);
                this.flowLayoutPanel保养后照片.BackColor = Color.White;
                this.slTextBox备注信息.ReadOnly = false;
                this.slTextBox备注信息.Text = string.Empty;
            }
            else if(type == OperationType.AcceptanceSubmit)
            {
                // 保养任务验收
                this.CloseCommonControls();

                this.slComboBox验收状态.Enabled = true;
            }
        }
            
        /// <summary>
        /// 关闭常规场景下的部分控件操作权限
        /// </summary>
        private void CloseCommonControls()
        {
            // 关闭过期时间选择
            this.slDateTimePicker过期时间.Enabled = false;

            // 关闭执行日期选择
            this.slDateTimePicker计划执行日期.Enabled = false;

            // 关闭功能位置编码选择
            this.slTextBox功能位置编码.ReadOnly = true;
            this.slTextBox功能位置编码.Click -= OpenFunctionPositionDialog;
            this.label功能位置编码图标.Click -= OpenFunctionPositionDialog;

            // 关闭保养人员选择
            this.textBox保养人员.ReadOnly = true;
            this.textBox保养人员.Click -= OpenMemberSelectedDialog;
            this.label保养人员图标.Click -= OpenMemberSelectedDialog;

            // 关闭保养任务标准操作区
            this.uc保养任务标准.OperationPanel.Visible = false;

            // 关闭保养标准选择
            this.uc保养任务标准.ForbiddenOpenDialog();

        }

        /// <summary>
        /// 处理图片数据，将图片进行保存并返回保存位置（相对路径）
        /// </summary>
        /// <param name="panel">图片面板</param>
        /// <param name="pictureSubDir">保存子路径</param>
        /// <returns>保存地址</returns>
        private string HandlePictureData(FlowLayoutPanel panel, string pictureSubDir)
        {
            List<string> paths = panel.Controls
                                .OfType<PictureBox>()
                                .Where(p => p.Tag != null)
                                .Select(p => p.Tag.ToString())
                                .ToList();
            return PictureHandleUtil.SavePicturesAndGetSavePath(paths, pictureSubDir);
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns>是否通过</returns>
        private bool VerifyData()
        {
            DateTime expiredTime = this.slDateTimePicker过期时间.Value;

            if (this.OperType == OperationType.Common)
            {
                // 时间验证
                if (expiredTime < DateTime.Now) 
                {
                    PopUpUtil.ShowInfo("当前时间已超过期时间");
                    return false;
                };

                expiredTime = this.slDateTimePicker过期时间.Value;
                DateTime planTime = this.slDateTimePicker计划执行日期.Value;
                if (expiredTime.Date < planTime.Date)
                {
                    PopUpUtil.ShowWarning("过期时间不能早于计划执行时间");
                    return false;
                }

                // 功能位置编码
                string functionPositionCode = this.slTextBox功能位置编码.Text;
                if (string.IsNullOrEmpty(functionPositionCode))
                {
                    PopUpUtil.ShowWarning("功能位置编码不能为空");
                    return false;
                }

            }
            else if(this.OperType == OperationType.TaskSubmit)
            {
                if (expiredTime < DateTime.Now)
                {
                    PopUpUtil.ShowInfo("当前时间已超过期时间，无法提交任务");
                    return false;
                };

                // 照片路径验证，不能为空
                this.PicturePathBeforeMaintenance = this.HandlePictureData(this.flowLayoutPanel保养前照片, "保养前照片");
                if (string.IsNullOrEmpty(this.PicturePathBeforeMaintenance))
                {
                    PopUpUtil.ShowWarning("保养前照片不能为空");
                    return false;
                }

                this.PicturePathAfterMaintenance = this.HandlePictureData(this.flowLayoutPanel保养后照片, "保养后照片");
                if (string.IsNullOrEmpty(this.PicturePathAfterMaintenance))
                {
                    PopUpUtil.ShowWarning("保养后照片不能为空");
                    if (!string.IsNullOrEmpty(this.PicturePathBeforeMaintenance))
                    {
                        PictureHandleUtil.DeletePictures(this.PicturePathBeforeMaintenance.Split(','));
                    }
                    return false;
                }
            }
            else if(this.OperType == OperationType.AcceptanceSubmit)
            {
                // 验收状态验证
                if (this.slComboBox验收状态.SelectedIndex == -1)
                {
                    PopUpUtil.ShowWarning("验收状态不能为空");
                    return false;
                }
            }

            return true;
        }
    }
}
