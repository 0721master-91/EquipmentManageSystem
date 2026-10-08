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

        private bool ctn巡检任务_BeforeChangeDataSource()
        {
            this.Sql查询 = "select ID,";

            return true;
        }
    }
}
