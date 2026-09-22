using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLControls;
using SLControls.SLGlobal;

namespace EquipmentManageSystem.标准管理
{
    public partial class dlg巡检标准编辑 : SLAomTmpForm
    {
        public dlg巡检标准编辑()
        {
            InitializeComponent();
        }

        //加载窗口的时候就自动获取编码值
        private void dlg巡检标准编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox巡检部位编码.Text = SqlCommonUtil.GenerateCode("XJBZ", "巡检标准", "巡检部位编码");
                this.checkBox启用状态.Checked = true; // 默认启用
            }
                


        }

        // 检查值是否合法
        private bool dlg巡检标准编辑_PreOK(FieldArray aryFields)
        {
            string cycle = this.slTextBox巡检周期.Text;
            if(!decimal.TryParse(cycle, out decimal cycleValue))
            {
                MessageBox.Show("巡检周期必须为数字","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if(cycleValue <= 0)
                {
                    MessageBox.Show("巡检周期必须大于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            string preDays = this.slTextBox提前提醒天数.Text;
            if (!int.TryParse(preDays, out int preDaysValue))
            {
                MessageBox.Show("提前提醒天数必须为整数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (preDaysValue < 0)
                {
                    MessageBox.Show("提前提醒天数必须大于等于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;
            return true;

        }
    }
}
