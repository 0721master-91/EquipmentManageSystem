using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;

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
        }

        private bool ctn巡检任务_BeforeChangeDataSource()
        {
            string sql = "select t.ID,t.巡检任务编码,p.功能位置编码,p.功能位置描述,p.位置简称,d.部门名称 as 设备管理部门,m.姓名 as 设备负责人,dbo.fn_GetMemberNamesByIds(t.巡检人员IDs) as 巡检人员," +
                         "dbo.fn_GetMemberNamesByIds(t.任务接取人ID) as 任务接取人员,t.计划执行日期,t.巡检开始时间,t.巡检结束时间,t.故障现象,es.状态 as 执行状态,os.状态 as 过期状态,t.创建时间 " +
                         "from 巡检任务 as t " + 
                         "left join 设备功能位置档案 as p on t.设备功能位置编码 = p.功能位置编码 " +
                         "left join 部门 as d on p.管理部门编码 = d.部门编码 " + 
                         "left join 成员 as m on p.责任人ID = m.ID " +
                         "left join 执行状态 as es on t.执行状态编码 = es.编码 " +
                         "left join 过期状态 as os on t.过期状态编码 = os.编码 " +
                         "where t.IsDelete = 0";


            this.Sql查询 = sql;
            return true;
        }

        private void ctn巡检任务_AfterChangeDataSource(DataTable newTable)
        {
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }
    }
}
