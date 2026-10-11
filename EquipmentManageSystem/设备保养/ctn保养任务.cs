using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备保养
{
    public partial class ctn保养任务 : temp标准基本信息GridControl
    {
        public ctn保养任务()
        {
            InitializeComponent();
        }

        private void ctn保养任务_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg保养任务编辑);
        }

        private bool ctn保养任务_BeforeChangeDataSource()
        {
            string sql = "select m.ID,m.保养任务编码,m.设备功能位置编码,p.功能位置描述,p.位置简称,m.计划执行日期,et.状态 as 执行状态,dbo.fn_GetMemberNamesByIds(保养人员IDs) as 保养人员," +
             "dbo.fn_GetMemberNamesByIds(任务接取人ID) as 任务接取人,ms.状态 as 保养状态,es.状态 as 过期状态,ys.状态 as 验收状态,m.创建时间 " +
             "from 保养任务 as m " +
             "left join 设备功能位置档案 as p on m.设备功能位置编码 = p.功能位置编码 " +
             "left join 执行状态 as et on m.执行状态编码 = et.编码 " +
             "left join 保养状态 as ms on m.保养状态编码 = ms.编码 " +
             "left join 过期状态 as es on m.过期状态编码 = es.编码 " +
             "left join 验收状态 as ys on m.验收状态编码 = ys.编码 " +
             "where m.IsDelete = 0";


            this.Sql查询 = sql;
            return true;
        }

        private void ctn保养任务_AfterChangeDataSource(DataTable newTable)
        {
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }
    }
}
