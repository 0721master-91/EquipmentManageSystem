using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.模板.导入导出模板;

namespace EquipmentManageSystem.标准管理
{
    public partial class dlg巡检标准导入导出 : temp导入导出模版 
    {

        public dlg巡检标准导入导出(DataTable outData) : base()
        {
            this.OutData = outData;
            InitializeComponent();
        }

    }
}
