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
        }

        private bool ctn报修工单_BeforeChangeDataSource()
        {
            string sql = "select rro.ID,rro.报修工单编码 as 单据号,p.功能位置编码,p.功能位置描述,p.位置简称,et.类型名称 as 设备类型 " +
                         "from 报修工单 as rro " +
                         "left join 设备功能位置档案 as p on rro.功能位置编码=p.功能位置编码 " +
                         "left join 设备类型 as et on p.设备类型编码=et.类型编码 " +
                         "where rro.IsDelete = 0";

            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn报修工单_AfterChangeDataSource(DataTable newTable)
        {
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }
    }
}
