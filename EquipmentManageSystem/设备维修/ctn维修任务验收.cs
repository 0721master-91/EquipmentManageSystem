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
using SLQLControls.模板;

namespace EquipmentManageSystem.设备维修
{
    public partial class ctn维修任务验收 : temp标准报表GridControl
    {
        public ctn维修任务验收()
        {
            InitializeComponent();
        }

        private bool ctn维修任务验收_BeforeChangeDataSource()
        {
            string sql = "select rwo.ID,rwo.维修工单编码 as 单据号,p.功能位置编码,p.功能位置描述,p.位置简称,ul.程度 as 紧急程度,dbo.fn_CountRepairRecords(rwo.维修工单编码) as 维修次数,rwo.故障现象, " +
                         "dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,rs.状态 as 维修状态, " +
                         "r.维修人,rwo.创建时间, " +
                         "p.检验人员IDs " +
                         "from 维修工单 as rwo " +
                         "left join 设备功能位置档案 as p on rwo.功能位置编码=p.功能位置编码 " +
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "left join 维修状态 as rs on rwo.维修状态编码 = rs.编码 " +
                         "outer apply dbo.fn_GetDirectiveRepairRecord(rwo.维修工单编码) as r " +
                         "where rwo.IsDelete = 0 " +
                            "and rwo.维修状态编码 = 'PENDING'";

            long memberID = UserSession.CurrentUser.MemberID;
            if (memberID != 0)
            {
                sql += "and ( " +
                            "p.检验人员IDs is null " +
                            "or p.检验人员IDs = '' " +
                            "or (',' + p.检验人员IDs + ',' like '%,' + '" + memberID + "' + ',%') " +
                        ") ";
            }

            this.Sql查询 = sql;
            return true;
        }

        private void ctn维修任务验收_AfterChangeDataSource(DataTable newTable)
        {
            var colCheckPerson = this.slDevGridControlMain.MainGridView.Columns["检验人员IDs"];
            colCheckPerson.Visible = false;

            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }

        private void ctn维修任务验收_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
        }

        private void button验收任务_Click(object sender, EventArgs e)
        {
            var gv = slDevGridControlMain.MainGridView;
            if(gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要验收的维修任务！");
                return;
            }

            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            string billCode = row["单据号"].ToString();

            if (!this.VerifyAcceptTask(billCode)) return;

            using(dlg维修任务执行 dlg = new dlg维修任务执行(billCode, TaskExecuteStatus.CheckAndAccept))
            {
                dlg.ShowDialog();
                this.RefreshData();
            }

        }

        /// <summary>
        /// 验证是否可以验收
        /// </summary>
        /// <param name="billCode">单据号</param>
        /// <returns>是否能验收</returns>
        private bool VerifyAcceptTask(string billCode)
        {
            string sql = "select 维修状态编码 from 维修工单 where 维修工单编码 = '" + billCode + "' and IsDelete = 0";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            if (dt.Rows.Count == 0)
            {
                PopUpUtil.ShowInfo("该维修任务不存在！");
                return false;
            }

            if (dt.Rows[0]["维修状态编码"].ToString() != "PENDING")
            {
                PopUpUtil.ShowInfo("该维修任务未处于待验收状态！");
                return false;
            }

            return true;
        }
    }
}
