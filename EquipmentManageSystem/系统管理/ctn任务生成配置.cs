﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;
using EquipmentManageSystem.Global;
using DevExpress.Data;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.系统管理
{
    public partial class ctn任务生成配置 : temp标准基本信息GridControl
    {
        public ctn任务生成配置()
        {
            InitializeComponent();
        }

        private void ctn任务生成配置_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg任务生成配置编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;

            CommonFilter.InitCombox(this.comboBox数据源,"数据源","编码","配置数据源");
            CommonFilter.InitCombox(this.comboBox日期类型,"类型","编码","日期类型");
            CommonFilter.InitCombox(this.comboBox适用范围, "范围", "编码", "配置适用范围");
        }

        private bool ctn任务生成配置_BeforeChangeDataSource()
        {
            string sql = "select tgc.ID,tgc.配置编码,tgc.配置名称,tgc.执行日期,dt.类型 as 日期类型,ds.数据源,ar.范围 as 适用范围,tgc.备注, " +
                            "case tgc.IsEnabled when 1 then '启用' else '禁用' end as 是否启用,tgc.创建时间 " +
                         "from 任务生成配置 as tgc " +
                         "left join 日期类型 as dt on dt.编码 = tgc.日期类型编码 " +
                         "left join 配置数据源 as ds on ds.编码 = tgc.数据源编码 " +
                         "left join 配置适用范围 as ar on ar.编码 = tgc.适用范围编码 " +
                         "where tgc.IsDelete = 0 ";


            string source = this.comboBox数据源.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(source))
            {
                sql += "and tgc.数据源编码 = '" + source + "' ";
            }

            string type = this.comboBox日期类型.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(type))
            {
                sql += "and tgc.日期类型编码 = '" + type + "' ";
            }

            string range = this.comboBox适用范围.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(range))
            {
                sql += "and tgc.适用范围编码 = '" + range + "' ";
            }

            sql += "order by tgc.创建时间 desc";
            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn任务生成配置_AfterChangeDataSource(DataTable newTable)
        {
            this.textBox模糊查询.Text = string.Empty;
            var colExecuteDate = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("执行日期");
            if (colExecuteDate != null)
            {
                colExecuteDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                colExecuteDate.DisplayFormat.FormatString = "yyyy-MM-dd";
            }

            var colCreateTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            if (colCreateTime != null)
            {
                colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            }

            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
            this.slDevGridControlMain.SetSummaryItem("配置编码", "合计：{0}", SummaryItemType.Count);
        }

        private void ctn任务生成配置_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }

        private void button生成任务_Click(object sender, EventArgs e)
        {
            TaskAutoGenerate.Execute();
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();

            if (this.CurrentDataSource == null)
            {
                PopUpUtil.ShowWarning("请先加载数据");
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
                    "配置编码 LIKE '%{0}%' OR 配置名称 LIKE '%{0}%' OR 日期类型 LIKE '%{0}%' OR 数据源 LIKE '%{0}%' OR " +
                    "适用范围 LIKE '%{0}%' OR 备注 LIKE '%{0}%' OR 是否启用 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void button查看详细_Click(object sender, EventArgs e)
        {
            using(dlg任务生成配置编辑 dlg = SLEditDialogUtil.GetDetaisDialogObj(this,typeof(dlg任务生成配置编辑)) as dlg任务生成配置编辑)
            {
                dlg.IsCloseModify = true;
                dlg.ShowDialog();
            }
        }
    }
}