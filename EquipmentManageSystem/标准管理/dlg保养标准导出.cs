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
    public partial class dlg保养标准导出 : temp导入导出模版
    {
        public dlg保养标准导出(DataTable dt):base()
        {
            this.OutData = dt;
            InitializeComponent();
        }
    }
}
