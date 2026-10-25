using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.数据报表
{

    public partial class dlg导出 : Form
    {
        public QueryData QueryDataInfo;
        public ExportDataType Type;
        public DataTable Data;
        public string OutFileName;

        public dlg导出()
        {
            InitializeComponent();
        }

        private void dlg导出_Load(object sender, EventArgs e)
        {
            this.radioButton选项1.Checked = true;
        }

        private void button确认_Click(object sender, EventArgs e)
        {
            bool isExportNull;
            if (radioButton选项1.Checked)
                isExportNull = false;
            else
                isExportNull = true;

            ExportEntrance entrance = new ExportEntrance();
            entrance.ExportData(this.QueryDataInfo, this.Type, isExportNull, this.Data, this.OutFileName);
            this.DialogResult = DialogResult.OK;
        }

        private void button取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
