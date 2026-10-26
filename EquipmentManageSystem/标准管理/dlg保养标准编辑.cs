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
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.标准管理
{
    public partial class dlg保养标准编辑 : SLAomTmpForm
    {
        public dlg保养标准编辑()
        {
            InitializeComponent();
        }

        public bool IsCloseModify = false;
        private void CloseModify()
        {
            if (IsCloseModify)
            {
                this.Text = "查看保养标准";
                this.button确定.Visible = false;
                this.button取消.Visible = false;
            }
        }
        private void dlg保养标准编辑_Load(object sender, EventArgs e)
        {
            //新增与复制新增的时候自动添加编码值
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox保养标准编码.Text = SqlCommonUtil.GenerateCode("BYBZ","保养标准","保养标准编码");
                this.checkBox启用状态.Checked = true; // 默认启用
            }

            this.CloseModify();
        }

        // 保存前验证数据合法性
        private bool dlg保养标准编辑_PreOK(FieldArray aryFields)
        {
            if(!VerifyData()) return false;

            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox保养标准编码.Text = SqlCommonUtil.GenerateCode("BYBZ", "保养标准", "保养标准编码");
            }

            string preDays = this.slTextBox提前提醒天数.Text;
            if (string.IsNullOrEmpty(preDays))
            {
                this.slTextBox提前提醒天数.Text = "0";
            }

            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;
            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
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

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns>是否通过</returns>
        private bool VerifyData()
        {
            // 保养内容验证
            string content = this.slTextBox保养内容.Text;
            if (string.IsNullOrEmpty(content))
            {
                PopUpUtil.ShowWarning("保养内容不能为空");
                return false;
            }

            // 执行周期验证
            string cycle = this.slTextBox执行周期.Text;
            if (decimal.TryParse(cycle, out decimal cycleValue))
            {
                if (cycleValue <= 0)
                {
                    PopUpUtil.ShowWarning("执行周期必须大于0");
                    return false;
                }
            }
            else
            {
                PopUpUtil.ShowWarning("执行周期必须为数字");
                return false;
            }

            // 提前提醒天数验证
            string preDays = this.slTextBox提前提醒天数.Text;
            if (!string.IsNullOrEmpty(preDays))
            {
                if (int.TryParse(preDays, out int preDaysValue))
                {
                    if (preDaysValue < 0)
                    {
                        PopUpUtil.ShowWarning("提前提醒天数必须大于等于0");
                        return false;
                    }
                }
                else
                {
                    PopUpUtil.ShowWarning("提前提醒天数必须为整数");
                    return false;
                }
            } 
            

            return true;
        }

    }

}
