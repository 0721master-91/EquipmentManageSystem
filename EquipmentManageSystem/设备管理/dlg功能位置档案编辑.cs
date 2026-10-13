﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLControls;
using SLControls.SLGlobal;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能位置档案编辑 : SLAomTmpForm
    {
        private string TempBillCode; // 临时单据号

        public dlg功能位置档案编辑()
        {
            InitializeComponent();
            this.comboBox所属组织.KeyPress += (s, args) => args.Handled = true;
        }

        private void dlg功能位置档案编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                string billCode = SqlCommonUtil.GenerateCode("WZDA", "设备功能位置档案", "单据号");
                this.slTextBox单据号.Text = billCode;
            }

            RemoveVerticalLines();
        }

        /// <summary>
        /// 用于去除只读输入框中选中时出现的输入提示竖线。
        /// 用取消选中状态的方式来去除无法输入的单据号控件，尽可能避免一闪一闪的竖线给用户造成操作困扰。
        /// </summary>
        private void RemoveVerticalLines()
        {
            this.slTextBox单据号.Enter += (s, args) => this.ActiveControl = null;// 去除单据号输入框选中状态
        }

        // 点击展开组织选择框
        private void comboBox所属组织_MouseDown(object sender, MouseEventArgs e)
        {

            dlg功能位置档案编辑组织选择 dlg = new dlg功能位置档案编辑组织选择();
            dlg.ShowDialog();
            if(dlg.DialogResult == DialogResult.OK)
            {
                // 这里感觉有点多此一举，直接使用selectRow其实也可以，这样写感觉方便理解。
                this.comboBox所属组织.Tag = dlg.OrganizationCode;
                this.comboBox所属组织.Text = dlg.OrganizationName;
                this.textBox一级编码.Text = dlg.Code;
                this.textBox公司名称.Text = dlg.CompanyName;
                GeneratePositionCode();
            }
            this.ActiveControl = null;// 关闭选择弹窗后取消选中状态，防止slComboBox控件的输入事件
        }

        // 点击展开功能主设备选择框
        private void comboBox功能主设备_MouseDown(object sender, MouseEventArgs e)
        {
            using(dlg功能位置档案编辑主设备选择 dlg = new dlg功能位置档案编辑主设备选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox功能主设备.Tag = dlg.ID;
                    this.comboBox功能主设备.Text = dlg.Name;
                    this.textBox二级编码.Text = dlg.ModuleCode;
                    this.textBox模块名称.Text = dlg.ModuleName;
                    this.textBox三级编码.Text = dlg.Code;

                    GeneratePositionCode();
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 组合生成功能位置编码
        /// </summary>
        private void GeneratePositionCode()
        {
            string organizationID = this.comboBox所属组织.Tag as string;
            string deviceID = this.comboBox功能主设备.Tag?.ToString() ?? "";
            if(!string.IsNullOrEmpty(organizationID) && !string.IsNullOrEmpty(deviceID)){
                string level1Code = this.textBox一级编码.Text;
                string level2Code = this.textBox二级编码.Text;
                string level3Code = this.textBox三级编码.Text;

                this.slTextBox功能位置编码.Text = level3Code + level2Code + level1Code;
            }
        }

        /// <summary>
        /// 打开人员选择弹窗界面
        /// </summary>
        private void OpenMemberSelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string name = comboBox.Name.Replace("comboBox", "");

            using (dlg功能位置档案编辑成员选择 dlg = new dlg功能位置档案编辑成员选择(name + "选择"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Tag = dlg.SelectedMemberIDs;
                    comboBox.Text = dlg.SelectedMemberNames;
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 打开部门选择框
        /// </summary>
        private void OpenDepartmentSelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string name = comboBox.Name.Replace("comboBox", "");

            using (dlg功能位置档案编辑部门选择 dlg = new dlg功能位置档案编辑部门选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Tag = dlg.Code;
                    comboBox.Text = dlg.Name;
                }
                this.ActiveControl = null;
            }
        }

        private bool dlg功能位置档案编辑_PreOK(FieldArray aryFields)
        {
            BandExtraFields();// 将额外添加的字段交于控件管理



            return true;
        }

        /// <summary>
        /// 绑定额外字段
        /// </summary>
        private void BandExtraFields()
        {
            string organizationCode = this.comboBox所属组织.Tag as string;
            if (!string.IsNullOrEmpty(organizationCode))
            {
                this.OtherFields["组织编码"] = organizationCode;
            }

            long equipmentID = Convert.ToInt64(this.comboBox功能主设备.Tag);
            if (equipmentID > 0)
            {
                this.OtherFields["绑定主设备ID"] = equipmentID;
            }

            string ManageDepartment = this.comboBox管理部门.Tag as string;
            if (!string.IsNullOrEmpty(ManageDepartment))
            {
                this.OtherFields["管理部门编码"] = ManageDepartment;
            }

            string UseDepartment = this.comboBox使用部门.Tag as string;
            if (!string.IsNullOrEmpty(UseDepartment))
            {
                this.OtherFields["使用部门编码"] = UseDepartment;
            }

            object person = this.comboBox责任人.Tag;
            if (person != null)
            {
                long responsiblePerson = Convert.ToInt64(person);
                if (responsiblePerson > 0)
                {
                    this.OtherFields["责任人ID"] = responsiblePerson.ToString();
                }
            }


            string inspectors = this.comboBox巡检人员.Tag as string;
            if (!string.IsNullOrEmpty(inspectors))
            {
                this.OtherFields["巡检人员IDs"] = inspectors;
            }

            string maintainers = this.comboBox维保人员.Tag as string;
            if (!string.IsNullOrEmpty(maintainers))
            {
                this.OtherFields["维保人员IDs"] = maintainers;
            }

            string checkers = this.comboBox检验人员.Tag as string;
            if (!string.IsNullOrEmpty(checkers))
            {
                this.OtherFields["检验人员IDs"] = checkers;
            }
        }


        private void dlg功能位置档案编辑_AfterFillControls()
        {
            this.TempBillCode = this.slTextBox单据号.Text;
            if (this.OperFlag == SleOperFlag.Modify)
            {
                FillComBox();
                FillStandardData();
            } 
        }

        /// <summary>
        /// 填充自定义选择框数据
        /// </summary>
        private void FillComBox()
        {
            string billCode = this.slTextBox单据号.Text;
            var service = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            string sql = "select 组织编码,绑定主设备ID,责任人ID,巡检人员IDs,维保人员IDs,检验人员IDs,管理部门编码,使用部门编码 from 设备功能位置档案 where 单据号 ='" + billCode + "'";
            DataTable dt = service.ExecuteForDataTable(sql);
            DataRow dr = dt.Rows[0];

            // 所属组织
            string organizationCode = dr["组织编码"].ToString();
            sql = "select 组织名称,公司地址,组织名称 from 组织 where 组织编码='" + organizationCode + "'";
            DataTable dtOrg = service.ExecuteForDataTable(sql);
            DataRow drOrg = dtOrg.Rows[0];
            this.comboBox所属组织.Tag = organizationCode;
            this.comboBox所属组织.Text = drOrg["公司地址"].ToString();
            this.textBox一级编码.Text = organizationCode;
            this.textBox公司名称.Text = drOrg["组织名称"].ToString();

            // 功能主设备
            long equipmentID = Convert.ToInt64(dr["绑定主设备ID"]);
            sql = "select s.设备编码,s.设备名称,s.设备模块编码,m.模块名称 " +
                  "from 设备档案 as s " +
                  "left join 设备模块 as m on s.设备模块编码 = m.模块编码 " + 
                  "where s.ID = '" + equipmentID + "'";
            DataTable dtEquipment = service.ExecuteForDataTable(sql);
            DataRow drEquipment = dtEquipment.Rows[0];
            this.comboBox功能主设备.Tag = equipmentID;
            this.comboBox功能主设备.Text = drEquipment["设备名称"].ToString();
            this.textBox三级编码.Text = drEquipment["设备编码"].ToString().Substring(4);
            this.textBox二级编码.Text = drEquipment["设备模块编码"].ToString().Substring(2);
            this.textBox模块名称.Text = drEquipment["模块名称"].ToString();

            // 责任人，巡检人员，维保人员，检验人员
            string responsiblePersonID = dr["责任人ID"].ToString();
            string inspectorsIDs = dr["巡检人员IDs"].ToString();
            string maintainersIDs = dr["维保人员IDs"].ToString();
            string checkersIDs = dr["检验人员IDs"].ToString();
            sql = "select m.姓名 as 责任人," +
                    "dbo.fn_GetMemberNamesByIds(sp.巡检人员IDs) as 巡检人员," +
                    "dbo.fn_GetMemberNamesByIds(sp.维保人员IDs) as 维保人员," +
                    "dbo.fn_GetMemberNamesByIds(sp.检验人员IDs) as 检验人员 " +
                  "from 设备功能位置档案 as sp " +
                  "left join 成员 as m on sp.责任人ID = m.ID " +
                  "where sp.单据号 = '" + billCode + "'";
            DataTable dtPerson = service.ExecuteForDataTable(sql);
            DataRow drPerson = dtPerson.Rows[0];
            this.comboBox责任人.Tag = responsiblePersonID;
            this.comboBox责任人.Text = drPerson["责任人"].ToString();
            this.comboBox巡检人员.Tag = inspectorsIDs;
            this.comboBox巡检人员.Text = drPerson["巡检人员"].ToString();
            this.comboBox维保人员.Tag = maintainersIDs;
            this.comboBox维保人员.Text = drPerson["维保人员"].ToString();
            this.comboBox检验人员.Tag = checkersIDs;
            this.comboBox检验人员.Text = drPerson["检验人员"].ToString();

            // 管理部门，使用部门
            string manageDeptCode = dr["管理部门编码"].ToString();
            string useDeptCode = dr["使用部门编码"].ToString();
            sql = "select d1.部门名称 as 管理部门名称,d2.部门名称 as 使用部门名称 " +
                  "from 设备功能位置档案 as s " +
                  "left join 部门 as d1 on s.管理部门编码 = d1.部门编码 " +
                  "left join 部门 as d2 on s.使用部门编码 = d2.部门编码 " +
                  "where s.单据号 = '" + billCode + "'";
            DataTable dtDept = service.ExecuteForDataTable(sql);
            DataRow drDept = dtDept.Rows[0];
            this.comboBox管理部门.Tag = manageDeptCode;
            this.comboBox管理部门.Text = drDept["管理部门名称"].ToString();
            this.comboBox使用部门.Tag = useDeptCode;
            this.comboBox使用部门.Text = drDept["使用部门名称"].ToString();
        }

        /// <summary>
        /// 填充设备标准数据
        /// </summary>
        private void FillStandardData()
        {
            var service = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            string billCode = this.TempBillCode;
            if (string.IsNullOrEmpty(billCode))
                return;

            // 加载巡检标准
            DataTable dtInspection = this.uc标准信息.InspectionStandardsTable;
            if (dtInspection != null)
            {
                string sqlInspection =
                    "select ID,巡检部位,巡检内容,巡检类型,判断标准,提前提醒天数,巡检周期,周期单位编码,开始执行日期 " +
                    "from 设备巡检计划 where 功能位置单据号='" + billCode + "' and IsDelete = 0";
                DataTable resultInspection = service.ExecuteForDataTable(sqlInspection);
                dtInspection.Rows.Clear();
                foreach (DataRow r in resultInspection.Rows)
                {
                    dtInspection.Rows.Add(
                        r["巡检部位"], r["巡检内容"], r["巡检类型"], r["判断标准"],
                        r["提前提醒天数"], r["巡检周期"], r["周期单位编码"], r["开始执行日期"],
                        r["ID"]);
                }
            }

            // 加载保养标准
            DataTable dtMaintenance = this.uc标准信息.MaintenanceStandardsTable;
            if (dtMaintenance != null)
            {
                string sqlMaintenance =
                    "select ID,保养内容,给油类型编码,润滑脂型号,润换方式编码,执行周期,周期单位编码,提前提醒天数,开始执行日期 " +
                    "from 设备保养计划 where 功能位置单据号='" + billCode + "' and IsDelete = 0";
                DataTable resultMaintenance = service.ExecuteForDataTable(sqlMaintenance);
                dtMaintenance.Rows.Clear();
                foreach (DataRow r in resultMaintenance.Rows)
                {
                    dtMaintenance.Rows.Add(
                        r["保养内容"], r["给油类型编码"], r["润滑脂型号"], r["润换方式编码"],
                        r["执行周期"], r["周期单位编码"], r["提前提醒天数"], r["开始执行日期"],
                        r["ID"]);
                }
            }
        }

        private bool dlg功能位置档案编辑_PreExecuteOKSql(object sender, PreOKSqlEventArgs e)
        {
            SLControls.SLDbService.SLOnlyInstOleDb.Services.BeginTran();//开启事务
            return true;
        }

        private void dlg功能位置档案编辑_AfterExecuteOKSql(object sender, AfterOKSqlEventArgs e)
        {
            // 主表语句是否插入成功，如果成功则添加子表数据
            if (e.Successful)
            {
                try
                {
                    // 增量保存：已有行UPDATE(保留创建时间)，新行INSERT(GETDATE)，被移除的行反向DELETE
                    DataTable dtInspection = this.uc标准信息.InspectionStandardsTable;
                    if (dtInspection != null)
                        UpdateStandardData(dtInspection, "设备巡检计划");

                    DataTable dtMaintenance = this.uc标准信息.MaintenanceStandardsTable;
                    if (dtMaintenance != null)
                        UpdateStandardData(dtMaintenance, "设备保养计划");

                    SLControls.SLDbService.SLOnlyInstOleDb.Services.Commit();//提交
                }
                catch (Exception ex)
                {
                    e.LastError = ex.Message;
                    e.Successful = false;
                    SLControls.SLDbService.SLOnlyInstOleDb.Services.RollBack();//回滚
                    PopUpUtil.ShowError("插入标准信息失败");
                }
            }
            else
            {
                SLControls.SLDbService.SLOnlyInstOleDb.Services.RollBack();//回滚
            }
        }

        /// <summary>
        /// 增量保存标准数据：有ID则UPDATE(保留创建时间)，无ID则INSERT(GETDATE)，被移除的行反向DELETE
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="tableName">表名</param>
        private void UpdateStandardData(DataTable dt, string tableName)
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            string billCode = this.TempBillCode;

            if (string.IsNullOrEmpty(billCode))
            {
                throw new Exception("单据号不能为空");
            };

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
                ? "update " + tableName + " set IsDelete = 1 where 功能位置单据号='" + billCode + "'"
                : "update " + tableName + " set IsDelete = 1 where 功能位置单据号='" + billCode +
                  "' and ID not in (" + string.Join(",", ids) + ")";
            services.ExecuteSql(deleteSql);

            // 逐行保存：已有行UPDATE，新行INSERT
            foreach (DataRow row in dt.Rows)
            {
                object idv = row["ID"];
                bool hasId = idv != null && idv != DBNull.Value && Convert.ToInt64(idv) > 0;

                if (hasId)
                {
                    List<string> sets = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                            continue;
                        sets.Add(col.ColumnName + "=" + SqlCommonUtil.FormatSqlValue(row[col]));
                    }
                    int num = services.ExecuteSql("update " + tableName + " set " + string.Join(",", sets) + " where ID=" + idv);
                    if (num <= 0) throw new Exception();
                }
                else
                {
                    List<string> colNames = new List<string> { "功能位置单据号"};
                    List<string> vals = new List<string> { SqlCommonUtil.FormatSqlValue(billCode) };
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "ID")
                            continue;
                        colNames.Add(col.ColumnName);
                        vals.Add(SqlCommonUtil.FormatSqlValue(row[col]));
                    }
                    int num = services.ExecuteSql("insert into " + tableName + " (" + string.Join(",", colNames) + ") values (" + string.Join(",", vals) + ")");
                    if (num <= 0) throw new Exception();
                }
            }
        }
    }
}