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
    public partial class dlg巡检标准编辑 : SLAomTmpForm
    {
        public dlg巡检标准编辑()
        {
            InitializeComponent();
        }

        public bool IsCloseModify = false;
        private void CloseModify()
        {
            if (IsCloseModify)
            {
                this.Text = "查看巡检标准";
                this.button确定.Visible = false;
                this.button取消.Visible = false;
            }
        }

        //加载窗口的时候就自动获取编码值
        private void dlg巡检标准编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox巡检标准编码.Text = SqlCommonUtil.GenerateCode("XJBZ", "巡检标准", "巡检标准编码");
                this.checkBox启用状态.Checked = true; // 默认启用
                this.slDateTimePicker开始执行日期.Value = DateTime.Now.Date;
            }

            this.CloseModify();
        }

        // 检查值是否合法
        private bool dlg巡检标准编辑_PreOK(FieldArray aryFields)
        {
            if (!this.VerifyData()) return false;

            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox巡检标准编码.Text = SqlCommonUtil.GenerateCode("XJBZ", "巡检标准", "巡检标准编码");
            }

            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;
            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;

        }

        private void dlg巡检标准编辑_AfterFillControls()
        {
            object val = this.OtherFields["IsEnabled"];
            if (val != null)
            {
                this.checkBox启用状态.Checked = Convert.ToBoolean(val);
            }
        }

        /// <summary>
        /// 验证数据合法性
        /// </summary>
        /// <returns>是否通过验证</returns>
        private bool VerifyData()
        {
            // 巡检部位
            string part = this.slTextBox巡检部位.Text;
            if (string.IsNullOrEmpty(part))
            {
                PopUpUtil.ShowWarning("巡检部位不能为空");
                return false;
            }

            // 巡检内容
            string content = this.slTextBox巡检内容.Text;
            if (string.IsNullOrEmpty(content))
            {
                PopUpUtil.ShowWarning("巡检内容不能为空");
                return false;
            }

            // 判断标准
            string judgeStandard = this.slTextBox判断标准.Text;
            if (string.IsNullOrEmpty(judgeStandard))
            {
                PopUpUtil.ShowWarning("判断标准不能为空");
                return false;
            }

            // 巡检周期
            string cycle = this.slTextBox巡检周期.Text;
            if (!decimal.TryParse(cycle, out decimal cycleValue))
            {
                PopUpUtil.ShowWarning("巡检周期必须为数字");
                return false;
            }
            else
            {
                if (cycleValue <= 0)
                {
                    PopUpUtil.ShowWarning("巡检周期必须大于0");
                    return false;
                }
            }

            // 提前提醒天数
            string preDays = this.slTextBox提前提醒天数.Text;
            if (!string.IsNullOrEmpty(preDays))
            {
                if (!int.TryParse(preDays, out int preDaysValue))
                {
                    PopUpUtil.ShowWarning("提前提醒天数必须为整数");
                    return false;
                }
                else
                {
                    if (preDaysValue < 0)
                    {
                        PopUpUtil.ShowWarning("提前提醒天数必须大于等于0");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
