﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.Global;
using DevExpress.Data;

namespace EquipmentManageSystem.设备维修
{
    public partial class ctn维修任务 : temp标准基本信息GridControl
    {
        public ctn维修任务()
        {
            InitializeComponent();
        }

        private void ctn维修任务_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg维修任务编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;

            CommonFilter.InitCombox(this.comboBox维修结果,"结果","编码","维修结果");
            CommonFilter.InitCombox(this.comboBox验收状态, "状态", "编码", "验收状态");

            DateTime startDate = DateTime.Today.AddDays(-7);
            DateTime endDate = DateTime.Today;
            this.dateTimePicker创建时间起始时间.Value = startDate;
            this.dateTimePicker创建时间结束时间.Value = endDate.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private bool ctn维修任务_BeforeChangeDataSource()
        {
            string sql = "select rwo.ID,rwo.维修工单编码 as 单据号,p.功能位置编码,p.功能位置描述,p.位置简称,ul.程度 as 紧急程度,es.状态 as 执行状态, " +
                         "dbo.fn_CountRepairRecords(rwo.维修工单编码) as 维修次数,rwo.故障现象,dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,rs.状态 as 维修状态, " +
                            "r.维修人,r.维修结果,r.验收人,r.验收状态,r.验收时间,rwo.创建时间 " +
                         "from 维修工单 as rwo " +
                         "left join 设备功能位置档案 as p on rwo.功能位置编码=p.功能位置编码 " + 
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "left join 执行状态 as es on rwo.执行状态编码 = es.编码 " +
                         "left join 维修状态 as rs on rwo.维修状态编码 = rs.编码 " +
                         "outer apply dbo.fn_GetDirectiveRepairRecord(rwo.维修工单编码) as r " +
                         "where rwo.IsDelete = 0 ";

            string positionAbbreviation = this.textBox位置简称.Text;
            if (!string.IsNullOrEmpty(positionAbbreviation))
            {
                sql += " and p.位置简称 like '%" + positionAbbreviation + "%' ";
            }

            object organizationCodeObj = this.comboBox所属组织.Tag;
            string organizationCode = organizationCodeObj == null ? "" : organizationCodeObj.ToString();
            if (!string.IsNullOrEmpty(organizationCode))
            {
                sql += " and p.组织编码 = '" + organizationCode + "' ";
            }

            object reportPersonIDObj = this.comboBox报修人.Tag;
            string reportPersonID = reportPersonIDObj == null ? "" : reportPersonIDObj.ToString();
            if (!string.IsNullOrEmpty(reportPersonID))
            {
                sql += " and rwo.报修人ID = '" + reportPersonID + "' ";
            }

            string checkAndAcceptStatusCode = this.comboBox验收状态.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(checkAndAcceptStatusCode))
            {
                sql += " and r.验收状态编码 = '" + checkAndAcceptStatusCode + "' ";
            }

            string repairdResultCode = this.comboBox维修结果.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(repairdResultCode))
            {
                sql += " and r.维修结果编码 = '" + repairdResultCode + "' ";
            }

            sql += GetTimeRangeSql(this.dateTimePicker创建时间起始时间, this.dateTimePicker创建时间结束时间, "创建时间");

            sql += " order by rwo.创建时间 desc";
            this.Sql查询 = sql;
            return true;
        }

        /// <summary>
        /// / 获取时间范围查询条件
        /// </summary>
        private string GetTimeRangeSql(DateTimePicker startTimePicker, DateTimePicker endTimePicker, string fileName)
        {
            DateTime startTime = startTimePicker.Value;
            DateTime endTime = endTimePicker.Value;

            return " and rwo." + fileName + " between '" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and  '" + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        }

        private DataTable CurrentDataSource;
        private void ctn维修任务_AfterChangeDataSource(DataTable newTable)
        {
            var colCreateTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            var colAcceptTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("验收时间");
            colAcceptTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colAcceptTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            this.CurrentDataSource = newTable;
            this.textBox模糊查询.Text = string.Empty;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
            this.slDevGridControlMain.SetSummaryItem("单据号", "合计：{0}", SummaryItemType.Count);
        }


        private void button查看详细_Click(object sender, EventArgs e)
        {
            var gv = slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要查看的维修任务！");
                return;
            }
            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            string billCode = row["单据号"].ToString();

            using (dlg维修工单详细信息 dlg = new dlg维修工单详细信息(billCode))
            {
                dlg.ShowDialog();
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
        private void button查看维修过程_Click(object sender, EventArgs e)
        {
            var gv = slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要查看的维修任务！");
                return;
            }
            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            string billCode = row["单据号"].ToString();

            using(dlg维修工单维修过程 dlg = new dlg维修工单维修过程(billCode))
            {
                dlg.ShowDialog();
            }
        }

        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();

            if (this.CurrentDataSource == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(keyword))
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                keyword = keyword.Replace("'", "''");
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "单据号 LIKE '%{0}%' OR 功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' OR " +
                    "紧急程度 LIKE '%{0}%' OR 故障现象 LIKE '%{0}%' OR 维修人员 LIKE '%{0}%' OR 维修状态 LIKE '%{0}%' OR " +
                    "维修人 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void OpenOrganizationSelectDialog(object sender, MouseEventArgs e)
        {
            using(dlg组织选择 dlg = new dlg组织选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox所属组织.Text = dlg.OrgName;
                    this.comboBox所属组织.Tag = dlg.OrgCode;
                }
                this.ActiveControl = null;
            }
        }

        private void OpenMemberSelectDialog(object sender, MouseEventArgs e)
        {
            using (dlg人员选择 dlg = new dlg人员选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox报修人.Text = dlg.SelectedMemberNames;
                    this.comboBox报修人.Tag = dlg.SelectedMemberIDs;
                }
                this.ActiveControl = null;
            }
        }

        private void slFlatButton导出_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            if (outData == null || outData.Rows.Count == 0)
            {
                PopUpUtil.ShowInfo("没有数据可以导出！");
                return;
            }

            using(dlg维修工单导出 dlg = new dlg维修工单导出(outData))
            {
                dlg.ShowDialog();
            }
        }

        private void ctn维修任务_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }
    }
}