using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;

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
        }

        private bool ctn维修任务_BeforeChangeDataSource()
        {
            string sql = "select rwo.ID,rwo.维修工单编码,ul.程度 as 紧急程度,dbo.fn_CountRepairRecords(rwo.维修工单编码) as 维修次数,rwo.故障现象,dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,rs.状态 as 维修状态,rwo.创建时间, " +
                            "p.功能位置编码,p.功能位置描述,p.位置简称, " +
                            "r.维修人,r.维修结果,r.验收人,r.验收状态,r.验收时间 " +
                         "from 维修工单 as rwo " +
                         "left join 设备功能位置档案 as p on rwo.功能位置编码=p.功能位置编码 " + 
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "left join 维修状态 as rs on rwo.维修状态编码 = rs.编码 " +
                         "outer apply dbo.fn_GetDirectiveRepairRecord(rwo.维修工单编码) as r " +
                         "where rwo.IsDelete = 0 ";

            this.Sql查询 = sql;
            return true;
        }

        private void ctn维修任务_AfterChangeDataSource(DataTable newTable)
        {
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }


    }
}
