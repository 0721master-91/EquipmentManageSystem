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

namespace EquipmentManageSystem.标准管理
{
    public partial class dlg保养标准编辑 : SLAomTmpForm
    {
        public dlg保养标准编辑()
        {
            InitializeComponent();
        }

        private void dlg保养标准编辑_Load(object sender, EventArgs e)
        {
            //新增与复制新增的时候自动添加编码值
            if(this.OperFlag == SLControls.SLGlobal.SleOperFlag.New || this.OperFlag == SLControls.SLGlobal.SleOperFlag.CopyNew)
            {
                this.slTextBox保养标准编码.Text = SqlCommonUtil.GenerateCode("BYBZ","保养标准","保养标准编码");
                this.checkBox启用状态.Checked = true; // 默认启用
            }
        }

        // 保存前验证数据合法性
        private bool dlg保养标准编辑_PreOK(SLControls.SLGlobal.FieldArray aryFields)
        {
            string cycle = this.slTextBox执行周期.Text;
            if(decimal.TryParse(cycle,out decimal cycleValue))
            {
                if (cycleValue <= 0)
                {
                    PopUpUtil.ShowWarning("执行周期必须大于0");
                }
            }
            else
            {
                PopUpUtil.ShowWarning("执行周期必须为数字");
            }

            string preDays = this.slTextBox提前提醒天数.Text;
            if(int.TryParse(preDays,out int preDaysValue))
            {
                if (preDaysValue < 0)
                {
                    PopUpUtil.ShowWarning("提前提醒天数必须大于等于0");
                }
            }
            else
            {
                PopUpUtil.ShowWarning("提前提醒天数必须为数字");
            }

            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;
            return true;
        }

        private void dlg保养标准编辑_AfterFillControls()
        {
            //数据填充后把额外字段的值也补上
            object val = this.OtherFields["IsEnabled"];
            if (val != null)
            {
                this.checkBox启用状态.Checked = Convert.ToBoolean(val);
            }
        }
    }

}
