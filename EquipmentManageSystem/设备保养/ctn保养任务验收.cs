﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备保养
{
    public partial class ctn保养任务验收 : temp标准报表GridControl
    {
        public ctn保养任务验收()
        {
            InitializeComponent();
        }

        private void ctn保养任务验收_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ShowFooter = true;

        }

        private bool ctn保养任务验收_BeforeChangeDataSource()
        {
            TaskStatusManager.UpdateMaintenanceTaskExpiredStatus();
            string sql = "select m.ID,m.保养任务编码,m.设备功能位置编码,p.功能位置描述,p.位置简称,m.计划执行日期,m.过期时间,m.保养开始时间,m.保养结束时间,dbo.fn_GetMemberNamesByIds(m.保养人员IDs) as 保养人员," +
                            "dbo.fn_GetMemberNamesByIds(m.任务接取人ID) as 任务接取人,m.创建时间 " +
                         "from 保养任务 as m " +
                         "left join 设备功能位置档案 as p on m.设备功能位置编码 = p.功能位置编码 " +
                         "where m.IsDelete = 0 " +
                            "and m.保养状态编码 = 'PENDING' ";
            long currentMemberId = UserSession.CurrentUser.MemberID;
            if (currentMemberId != 0)
            {
                sql += " and CHARINDEX(',' + '" + currentMemberId + "' + ',', ',' + p.检验人员IDs + ',') > 0";
            }
            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn保养任务验收_AfterChangeDataSource(DataTable newTable)
        {
            var colCreateTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            var colStartTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("保养开始时间");
            colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            var colEndTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("保养结束时间");
            colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEndTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            var colExpiredTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("过期时间");
            colExpiredTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colExpiredTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
            this.slDevGridControlMain.SetSummaryItem("保养任务编码", "合计：{0}", SummaryItemType.Count);
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
                string safeKeyword = keyword.Replace("'", "''");
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "保养任务编码 LIKE '%{0}%' OR 设备功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' " +
                    "OR 保养人员 LIKE '%{0}%' OR 任务接取人 LIKE '%{0}%'",
                    safeKeyword);
            }
        }

        private void button验收任务_Click(object sender, EventArgs e)
        {
            var gv = this.slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要接取的任务");
                return;
            }

            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row == null) return;

            long id = Convert.ToInt64(row["ID"]);
            using(dlg保养任务编辑 dlg = new dlg保养任务编辑(OperationType.AcceptanceSubmit))
            {
                dlg.OperFlag = SLControls.SLGlobal.SleOperFlag.Modify;
                dlg.TableName = "保养任务";
                dlg.PrimaryKey = new SLControls.SLGlobal.SlcFieldInfo()
                {
                    OperatorMode = SLControls.SLGlobal.SleOperatorMode.ReadWrite,
                    KeyName = "ID",
                    KeyValue = id,
                    KeyType = SLControls.SLGlobal.SleDataType.Digit
                };
                dlg.ShowDialog();
            }

            this.button刷新.PerformClick();
        }
    }
}