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
    public partial class dlg维修工单维修过程 : Form
    {
        private string BillCode;
        public dlg维修工单维修过程(string billcode)
        {
            InitializeComponent();
            this.BillCode = billcode;
        }

        private void dlg维修工单维修过程_Load(object sender, EventArgs e)
        {
            this.uc维修工单基本信息.LoadRepairdOrderBaseData(this.BillCode);
            this.uc维修工单维修记录.LoadRepairRecorData(this.BillCode);
        }
    }
}
