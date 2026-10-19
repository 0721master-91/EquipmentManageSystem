using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备维修
{
    public partial class dlg维修工单详细信息 : Form
    {
        private string BillCode;
        public dlg维修工单详细信息(string billCode)
        {
            InitializeComponent();
            this.BillCode = billCode;
        }

        private void dlg维修工单详细信息_Load(object sender, EventArgs e)
        {
            this.uc维修工单基本信息.LoadRepairdOrderBaseData(this.BillCode);
            this.uc维修工单维修信息.LoadRepairInfo(this.BillCode);
        }
    }
}
