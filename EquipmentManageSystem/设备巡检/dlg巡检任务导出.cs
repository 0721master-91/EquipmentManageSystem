using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.模板.导入导出模板;

namespace EquipmentManageSystem.设备巡检
{
    public partial class dlg巡检任务导出 : temp导入导出模版
    {
        public dlg巡检任务导出(DataTable outData)
        {
            InitializeComponent();
            this.OutData = outData;
        }
    }
}
