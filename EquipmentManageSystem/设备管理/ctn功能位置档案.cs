using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备管理
{
    public partial class ctn功能位置档案 : temp标准基本信息GridControl
    {
        public ctn功能位置档案()
        {
            InitializeComponent();
        }

        private void ctn功能位置档案_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new System.Drawing.Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new System.Drawing.Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg功能位置档案编辑);
            this.slDevGridControlMain.ShowFooter = true;
        }

        private bool ctn功能位置档案_BeforeChangeDataSource()
        {
            string sql = "select s.ID,s.功能位置编码,s.功能位置描述,s.位置简称,t.类型名称 as 设备类型,o.组织名称 as 组织,d.部门名称 as 管理部门,m.姓名 as 责任人,st.状态 as 设备状态," +
                            "dbo.fn_GetMemberNamesByIds(s.巡检人员IDs) as 巡检人员," +
                            "dbo.fn_GetMemberNamesByIds(s.维保人员IDs) as 维保人员," +
                            "dbo.fn_GetMemberNamesByIds(s.检验人员IDs) as 检验人员 " +
                           "from 设备功能位置档案 as s " + 
                           "left join 设备类型 as t on s.设备类型编码 = t.类型编码 " +
                           "left join 组织 as o on s.组织编码 = o.组织编码 " +
                           "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                           "left join 成员 as m on s.责任人ID = m.ID " +
                           "left join 设备状态 as st on s.设备状态编码 = st.编码 " +
                           "where 1 = 1 ";


            sql += "and s.IsDelete = 0 ";
            this.Sql查询 = sql;

            return true;
        }


        private DataTable CurrentDataSource;
        private void ctn功能位置档案_AfterChangeDataSource(DataTable newTable)
        {
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }
    }
}
