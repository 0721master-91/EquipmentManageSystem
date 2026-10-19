﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备维修
{
    public partial class ctn维修任务接取与提交 : temp标准报表GridControl
    {
        public ctn维修任务接取与提交()
        {
            InitializeComponent();
        }

        private void ctn维修任务接取与提交_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
        }

        private bool ctn维修任务接取与提交_BeforeChangeDataSource()
        {
            string sql = "select rwo.ID,rwo.维修工单编码 as 单据号,p.功能位置编码,p.功能位置描述,p.位置简称,ul.程度 as 紧急程度,dbo.fn_CountRepairRecords(rwo.维修工单编码) as 维修次数,rwo.故障现象, " +
                         "dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,rs.状态 as 维修状态, " +
                         "r.维修人,rwo.创建时间 " +
                         "from 维修工单 as rwo " +
                         "left join 设备功能位置档案 as p on rwo.功能位置编码=p.功能位置编码 " +
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "left join 维修状态 as rs on rwo.维修状态编码 = rs.编码 " +
                         "outer apply dbo.fn_GetDirectiveRepairRecord(rwo.维修工单编码) as r " +
                         "where rwo.IsDelete = 0 " +
                            "and rwo.维修状态编码 in ('REPAIR','REWORK','REPAIRING')";

            long memberID = UserSession.CurrentUser.MemberID;
            if (memberID != 0)
            {
                // 第一层可见条件（任务接取）：
                //   a) 维修人员IDs有值：含当前用户，
                //   b) 维修人员IDs为空(null/'')：去设备功能位置档案的维保人员IDs认证是否包含当前用户
                //   c) 维修人ID有值：等于当前用户（兜底，驳回情况下没有更换维修人仍然指定前维修人，如果此时修改了设备功能位置与维修工单的人员信息，会让这个人查不到记录）
                // 第二层可见条件（任务提交）：只能看见维修人是当前用户的或还没有维修人信息的数据，保证接取与提交的人是同一个
                sql += "and (" +
                            "( " +
                                "(rwo.维修人员IDs is not null and rwo.维修人员IDs <> '' and (CHARINDEX(',' + '" + memberID + "' + ',', ',' + rwo.维修人员IDs + ',') > 0 )) " +
                                "or " +
                                "((rwo.维修人员IDs is null or rwo.维修人员IDs = '') and CHARINDEX(',' + '" + memberID + "' + ',', ',' + p.维保人员IDs + ',') > 0) " +
                                "or " +
                                "r.维修人ID = " + memberID + " " +
                            ") " +
                            "and (r.维修人ID = " + memberID + " or r.维修人ID is null) " +
                       ") ";
            }

            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn维修任务接取与提交_AfterChangeDataSource(DataTable newTable)
        {
            this.textBox模糊查询.Text = string.Empty;
            this .CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }

        private void button接取任务_Click(object sender, EventArgs e)
        {
            var gv = this.slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要接取的任务");
                return;
            }

            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row == null) return;

            string billCode = row["单据号"].ToString();

            if (!this.VerifyRecieveTask(billCode))
            {
                PopUpUtil.ShowWarning("该任务已被接取或删除，请重新选择！");
                return;
            }

            using (dlg维修任务执行 dlg = new dlg维修任务执行(billCode, TaskExecuteStatus.Receive))
            {
                dlg.ShowDialog();
                this.button刷新.PerformClick();
            }
        }

        private void button提交任务_Click(object sender, EventArgs e)
        {
            var gv = this.slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要提交的任务");
                return;
            }

            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row == null) return;

            string billCode = row["单据号"].ToString();

            if (!this.VerifySubmitTask(billCode)) return;

            using (dlg维修任务执行 dlg = new dlg维修任务执行(billCode, TaskExecuteStatus.Submit))
            {
                dlg.ShowDialog();
                this.button刷新.PerformClick();
            }
        }

        private void textBox模糊查询_TextChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 验证接取任务状态
        /// </summary>
        /// <returns>是否可以接取任务</returns>
        private bool VerifyRecieveTask(string billCode)
        {
            string sql = "select 维修状态编码 from 维修工单 where 维修工单编码 = '" + billCode + "' and IsDelete = 0";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt == null || dt.Rows.Count == 0) return false;

            string status = dt.Rows[0]["维修状态编码"].ToString();
            if (status == "REPAIR" || status == "REWORK")
                return true;
            else
                return false;
        }

        private bool VerifySubmitTask(string billCode)
        {
            string sql = "select 维修状态编码 from 维修工单 where 维修工单编码 = '" + billCode + "' and IsDelete = 0";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                PopUpUtil.ShowWarning("该任务已删除，请刷新后重试");
                return false;
            }

            string status = dt.Rows[0]["维修状态编码"].ToString();

            if (status != "REPAIRING")
            {
                PopUpUtil.ShowWarning("请先接取任务再提交");
                return false;
            }

            return true;
        }
    }
}