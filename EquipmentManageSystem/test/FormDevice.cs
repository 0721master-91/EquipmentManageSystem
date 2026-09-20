using SLControls.SLDbService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManagementSystem
{
    public partial class FormDevice : SLQLControls.模板.temp标准基本信息GridControl
    {
        public FormDevice()
        {
            InitializeComponent();
        }

        private void FormDevice_Load(object sender, EventArgs e)
        {

            this.TableName = "设备清单";

            this.Type编辑窗口 = typeof(FormEdit);

            this.slDevGridControlMain.ShowFooter = true;
            slDateSeler1.Mark = "设备清单";

            this.BeforeChangeDataSource += () =>
            {
                string sql = "select * from 设备清单";

                if (!string.IsNullOrEmpty(textBox设备名称.Text))
                {
                    sql += string.Format(" where 名称='{0}'", textBox设备名称.Text);
                }

                this.Sql查询 = sql;

                return true;
            };

        }

        private void FormDevice_AfterChangeDataSource(DataTable newTable)
        {
            this.slDevGridControlMain.SetSummaryItem("名称", "数量：{0}", DevExpress.Data.SummaryItemType.Count);
            return;
        }

        private bool FormDevice_BeforeSetDataSource(ref DataTable table)
        {
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = slDevGridControlMain.MainGridView.GetFocusedDataRow();
            FormEdit formEdit = new FormEdit();

            formEdit.TableName = "设备清单";

            formEdit.OperFlag = SLControls.SLGlobal.SleOperFlag.Modify;
            formEdit.PrimaryKey.KeyValue = row["ID"];
            DialogResult result = formEdit.ShowDialog();

            if (result == DialogResult.OK)
            {
                RefreshData();
            }
        }
    }
}
