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
            this.TableName = "设备档案";
            this.slDevGridControlMain.RowFont = new System.Drawing.Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new System.Drawing.Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg功能位置档案编辑);
            this.slDevGridControlMain.ShowFooter = true;
        }

        private bool ctn功能位置档案_BeforeChangeDataSource()
        {

            return true;
        }
    }
}
