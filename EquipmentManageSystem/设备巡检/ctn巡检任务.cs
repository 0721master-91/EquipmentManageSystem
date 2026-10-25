﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;
using EquipmentManageSystem.Global;
using DevExpress.Data;

namespace EquipmentManageSystem.设备巡检
{
    public partial class ctn巡检任务 : temp标准基本信息GridControl
    {
        public ctn巡检任务()
        {
            InitializeComponent();
        }


        private void ctn巡检任务_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg巡检任务编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;

            CommonFilter.InitCombox(this.comboBox执行状态,"状态","编码","执行状态");
            CommonFilter.InitCombox(this.comboBox过期状态, "状态", "编码", "过期状态");

            DateTime startDate = DateTime.Today.AddDays(-7);
            DateTime endDate = DateTime.Today;

            this.dateTimePicker计划执行日期开始日期.Value = startDate;
            this.dateTimePicker计划执行日期结束日期.Value = endDate;
            this.dateTimePicker巡检开始时间起始时间.Value = startDate;
            this.dateTimePicker巡检开始时间结束时间.Value = endDate.AddHours(23).AddMinutes(59).AddSeconds(59);
            this.dateTimePicker创建时间起始时间.Value = startDate;
            this.dateTimePicker创建时间结束时间.Value = endDate.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private bool ctn巡检任务_BeforeChangeDataSource()
        {
            TaskStatusManager.UpdateInspectionTaskExpiredStatus(); // 每次查询前先更新一下过期状态

            string sql = "select t.ID,t.巡检任务编码,p.功能位置编码,p.功能位置描述,p.位置简称,d.部门名称 as 设备管理部门,m.姓名 as 设备负责人,dbo.fn_GetMemberNamesByIds(t.巡检人员IDs) as 巡检人员," +
                         "dbo.fn_GetMemberNamesByIds(t.任务接取人ID) as 任务接取人员,t.计划执行日期,t.巡检开始时间,t.巡检结束时间,t.故障现象,es.状态 as 执行状态,os.状态 as 过期状态,t.创建时间 " +
                         "from 巡检任务 as t " + 
                         "left join 设备功能位置档案 as p on t.设备功能位置编码 = p.功能位置编码 " +
                         "left join 部门 as d on p.管理部门编码 = d.部门编码 " + 
                         "left join 成员 as m on p.责任人ID = m.ID " +
                         "left join 执行状态 as es on t.执行状态编码 = es.编码 " +
                         "left join 过期状态 as os on t.过期状态编码 = os.编码 " +
                         "where t.IsDelete = 0";

            object orgCodeObj = this.comboBox所属组织.Tag;
            string orgCode = orgCodeObj == null ? "" : orgCodeObj.ToString();
            if (!string.IsNullOrEmpty(orgCode))
            {
                sql += " and p.组织编码 = '" + orgCode + "'";
            }
            
            string positionSimpleName = this.textBox位置简称.Text.Trim();
            if (!string.IsNullOrEmpty(positionSimpleName))
            {
                sql += " and p.位置简称 like '%" + positionSimpleName + "%'";
            }

            sql += GetTimeRangeSql(this.dateTimePicker计划执行日期开始日期, this.dateTimePicker计划执行日期结束日期, "计划执行日期");

            object executeStatusObj = this.comboBox执行状态.SelectedValue;
            string executeStatus = executeStatusObj == null ? "" : executeStatusObj.ToString();
            if (!string.IsNullOrEmpty(executeStatus))
            {
                sql += " and t.执行状态编码 = '" + executeStatus + "'";
            }

            object overStatusObj = this.comboBox过期状态.SelectedValue;
            string overStatus = overStatusObj == null ? "" : overStatusObj.ToString();
            if (!string.IsNullOrEmpty(overStatus))
            {
                sql += " and t.过期状态编码 = '" + overStatus + "'";
            }

            object inspectorIDsObj = this.comboBox巡检人员.Tag;
            string inspectorIDs = inspectorIDsObj == null ? "" : inspectorIDsObj.ToString();
            if (!string.IsNullOrEmpty(inspectorIDs))
            {
                sql += GetMemberQuerySql(inspectorIDs.Split(','), "巡检人员IDs");
            }

            sql += GetTimeRangeSql(this.dateTimePicker巡检开始时间起始时间, this.dateTimePicker巡检开始时间结束时间, "巡检开始时间");
            sql += GetTimeRangeSql(this.dateTimePicker创建时间起始时间, this.dateTimePicker创建时间结束时间, "创建时间");

            sql += " order by t.创建时间 desc";

            Console.WriteLine(sql);
            this.Sql查询 = sql;
            return true;
        }

        /// <summary>
        /// / 获取时间范围查询条件
        /// </summary>
        private string GetTimeRangeSql(DateTimePicker startTimePicker, DateTimePicker endTimePicker,string fileName)
        {
            DateTime startTime = startTimePicker.Value;
            DateTime endTime = endTimePicker.Value;

            return " and t." + fileName + " between '" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and  '" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        /// <summary>
        /// 将成员ID组合成SQL语句，用于查询
        /// </summary>

        private string GetMemberQuerySql(string[] memberIDList, string fileName)
        {
            List<string> conditions = new List<string>();
            foreach (string id in memberIDList)
            {
                conditions.Add("charindex(',' + '" + id + "' + ',' , ',' + t." + fileName + " + ',') > 0");
            }
            string sqlCondition = "(" + string.Join(" and ", conditions) + ")";
            return " and " + sqlCondition;
        }

        private DataTable CurrentDataSource;
        private void ctn巡检任务_AfterChangeDataSource(DataTable newTable)
        {
            var colStartDate =  this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检开始时间");
            colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            var colEndDate = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检结束时间");
            colEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEndDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();

            this.slDevGridControlMain.SetSummaryItem("巡检任务编码", "合计：{0}", SummaryItemType.Count);
        }

        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();
            if (this.CurrentDataSource == null)
            {
                PopUpUtil.ShowInfo("请先点击「刷新」加载数据");
                return;
            }
            if (string.IsNullOrEmpty(keyword))
            {
                // 关键词为空就显示全部数据
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "巡检任务编码 LIKE '%{0}%' OR 功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' OR 设备管理部门 LIKE '%{0}%' " +
                    "OR 设备负责人 LIKE '%{0}%' OR 巡检人员 LIKE '%{0}%' OR 任务接取人员 LIKE '%{0}%' OR 故障现象 LIKE '%{0}%' OR 执行状态 LIKE '%{0}%' OR 过期状态 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void slFlatButton导入_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            using(dlg巡检任务导出 dlg = new dlg巡检任务导出(outData))
            {
                dlg.ShowDialog();
            }
            this.button刷新.PerformClick();
        }

        private void ctn巡检任务_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }

        private void button查看详细_Click(object sender, EventArgs e)
        {
            using(dlg巡检任务编辑 dlg = SLEditDialogUtil.GetDetaisDialogObj(this,typeof(dlg巡检任务编辑)) as dlg巡检任务编辑)
            {
                dlg.IsCloseModify = true;
                dlg.ShowDialog();
            }
        }

        private void comboBox所属组织_MouseDown(object sender, MouseEventArgs e)
        {
            using(dlg组织选择 dlg = new dlg组织选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox所属组织.Text = dlg.OrgName;
                    this.comboBox所属组织.Tag = dlg.OrgCode;
                }
            }
        }

        private void VerifyPlanExecuteDate(object sender, EventArgs e)
        {
            DateTime start = this.dateTimePicker计划执行日期开始日期.Value;
            DateTime end = this.dateTimePicker计划执行日期结束日期.Value;
            if (start > end)
            {
                PopUpUtil.ShowInfo("计划执行日期开始日期不能大于结束日期");
                this.dateTimePicker计划执行日期开始日期.Value = end.AddDays(-7);
            }
        }

        private void VerifyInspectStartTime(object sender, EventArgs e)
        {
            DateTime start = this.dateTimePicker巡检开始时间起始时间.Value;
            DateTime end = this.dateTimePicker巡检开始时间结束时间.Value;
            if (start > end)
            {
                PopUpUtil.ShowInfo("巡检开始时间起始时间不能大于结束时间");
                this.dateTimePicker巡检开始时间起始时间.Value = end.AddDays(-7);
            }
        }

        private void VerifyCreateTime(object sender, EventArgs e)
        {
            DateTime start = this.dateTimePicker创建时间起始时间.Value;
            DateTime end = this.dateTimePicker创建时间结束时间.Value;
            if (start > end)
            {
                PopUpUtil.ShowInfo("创建时间起始时间不能大于结束时间");
                this.dateTimePicker创建时间起始时间.Value = end.AddDays(-7);
            }
        }

        private void comboBox巡检人员_MouseDown(object sender, MouseEventArgs e)
        {
            using (dlg人员选择 dlg = new dlg人员选择("选择巡检人员") { IsMultiSelect = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox巡检人员.Text = dlg.SelectedMemberNames;
                    this.comboBox巡检人员.Tag = dlg.SelectedMemberIDs;
                }
            }
        }
    }
}