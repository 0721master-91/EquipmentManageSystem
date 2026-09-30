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

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能位置档案编辑 : SLAomTmpForm
    {
        public dlg功能位置档案编辑()
        {
            InitializeComponent();
            this.slComboBox所属组织.KeyPress += (s, args) => args.Handled = true;
        }

        private void dlg功能位置档案编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox单据号.Text = SqlCommonUtil.GenerateCode("WZDA", "设备功能位置档案", "单据号");
            }


            RemoveVerticalLines();
        }

        /// <summary>
        /// 用于去除只读输入框中选中时出现的输入提示竖线。
        /// 用取消选中状态的方式来去除无法输入的单据号控件，尽可能避免一闪一闪的竖线给用户造成操作困扰。
        /// </summary>
        private void RemoveVerticalLines()
        {
            this.slTextBox单据号.Enter += (s, args) => this.ActiveControl = null;// 去除单据号输入框选中状态
        }

        // 点击展开组织选择框
        private void slComboBox所属组织_MouseDown(object sender, MouseEventArgs e)
        {

            dlg功能位置档案编辑组织选择 dlg = new dlg功能位置档案编辑组织选择();
            dlg.ShowDialog();
            if(dlg.DialogResult == DialogResult.OK)
            {
                // 这里感觉有点多此一举，直接使用selectRow其实也可以，这样写感觉方便理解。
                this.slComboBox所属组织.SelectedValue = dlg.OrganizationId;
                this.slComboBox所属组织.Text = dlg.OrganizationName;
                this.textBox一级编码.Text = dlg.Code;
                this.textBox公司名称.Text = dlg.CompanyName;
                GeneratePositionCode();
            }
            this.ActiveControl = null;// 关闭选择弹窗后取消选中状态，防止slComboBox控件的输入事件
        }

        // 点击展开功能主设备选择框
        private void slComboBox功能主设备_MouseDown(object sender, MouseEventArgs e)
        {
            using(dlg功能位置档案编辑主设备选择 dlg = new dlg功能位置档案编辑主设备选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.slComboBox功能主设备.SelectedValue = dlg.ID;
                    this.slComboBox功能主设备.Text = dlg.Name;
                    this.textBox二级编码.Text = dlg.ModuleCode;
                    this.textBox模块名称.Text = dlg.ModuleName;
                    this.textBox三级编码.Text = dlg.Code;

                    GeneratePositionCode();
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 组合生成功能位置编码
        /// </summary>
        private void GeneratePositionCode()
        {
            string organizationID = this.slComboBox所属组织.Text;
            string deviceID = this.slComboBox功能主设备.Text;
            if(!string.IsNullOrEmpty(organizationID) && !string.IsNullOrEmpty(deviceID)){
                string level1Code = this.textBox一级编码.Text;
                string level2Code = this.textBox二级编码.Text;
                string level3Code = this.textBox三级编码.Text;

                this.textBox功能位置编码.Text = level3Code + level2Code + level1Code;
            }
        }
    }
}
