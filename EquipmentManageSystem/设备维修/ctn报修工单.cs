﻿using System;
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
    public partial class ctn报修工单 : temp标准基本信息GridControl
    {
        public ctn报修工单()
        {
            InitializeComponent();
        }

        private void ctn报修工单_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg报修工单编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;

            CommonFilter.InitCombox(this.comboBox执行状态, "状态", "编码", "执行状态");
            CommonFilter.InitCombox(this.comboBox维修状态, "状态", "编码", "维修状态");
            CommonFilter.InitCombox(this.comboBox维修结果, "结果", "编码", "维修结果");
            CommonFilter.InitCombox(this.comboBox设备类型, "类型名称", "类型编码", "设备类型");
            CommonFilter.InitCombox(this.comboBox验收状态, "状态", "编码", "验收状态");
        }

        private bool ctn报修工单_BeforeChangeDataSource()
        {
            string sql = "select rro.ID,rro.报修工单编码 as 单据号,p.功能位置编码,p.功能位置描述,p.位置简称,et.类型名称 as 设备类型,es.状态 as 执行状态,r.维修结果," +
                            "r.验收状态,rws.状态 as 单据流程状态,rro.创建时间 " +
                         "from 报修工单 as rro " +
                         "left join 设备功能位置档案 as p on rro.功能位置编码=p.功能位置编码 " +
                         "left join 设备类型 as et on p.设备类型编码=et.类型编码 " +
                         "left join 维修工单 as rwo on rro.报修工单编码 = rwo.上游单据号 " +
                         "left join 执行状态 as es on rwo.执行状态编码 = es.编码 " +
                         "left join 维修状态 as rws on rwo.维修状态编码 = rws.编码 " +
                         "outer apply dbo.fn_GetDirectiveRepairRecord(rwo.维修工单编码) as r " +
                         "where rro.IsDelete = 0";

            string equTypeCode = this.comboBox设备类型.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(equTypeCode))
            {
                sql += " and p.设备类型编码 = '" + equTypeCode + "'";
            }

            string executeStatusCode = this.comboBox执行状态.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(executeStatusCode))
            {
                sql += " and rwo.执行状态编码 = '" + executeStatusCode + "'";
            }

            string repairdResultCode = this.comboBox维修结果.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(repairdResultCode))
            {
                sql += " and r.维修结果编码 = '" + repairdResultCode + "'";
            }

            string acceptResultCode = this.comboBox验收状态.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(acceptResultCode))
            {
                sql += " and r.验收结果编码 = '" + acceptResultCode + "'";
            }

            string repairdStatusCode = this.comboBox维修状态.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(repairdStatusCode))
            {
                sql += " and rwo.维修状态编码 = '" + repairdStatusCode + "'";
            }

            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn报修工单_AfterChangeDataSource(DataTable newTable)
        {
            var colCreateTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();

            this.slDevGridControlMain.SetSummaryItem("单据号", "合计：{0}", SummaryItemType.Count);
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
                    "设备类型 LIKE '%{0}%' OR 执行状态 LIKE '%{0}%' OR 维修结果 LIKE '%{0}%' OR 验收状态 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void slFlatButton导出_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            if (outData.Rows.Count == 0)
            {
                PopUpUtil.ShowInfo("没有数据可导出！");
            }

            using(dlg报修工单导出 dlg = new dlg报修工单导出(outData))
            {
                dlg.ShowDialog();
                this.RefreshData();
            }
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
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 维修工单编码 from 报修工单 where 报修工单编码 = '" + billCode + "'");
            string repairdBillCode = dt.Rows[0]["维修工单编码"].ToString();

            using (dlg维修工单详细信息 dlg = new dlg维修工单详细信息(repairdBillCode))
            {
                dlg.ShowDialog();
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

            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 维修工单编码 from 报修工单 where 报修工单编码 = '" + billCode + "'");
            string repairdBillCode = dt.Rows[0]["维修工单编码"].ToString();

            using (dlg维修工单维修过程 dlg = new dlg维修工单维修过程(repairdBillCode))
            {
                dlg.ShowDialog();
            }
        }

        private void ctn报修工单_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }
    }
}