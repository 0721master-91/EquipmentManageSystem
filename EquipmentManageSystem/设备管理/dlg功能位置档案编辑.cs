﻿using System;
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
            this.comboBox所属组织.KeyPress += (s, args) => args.Handled = true;
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
        private void comboBox所属组织_MouseDown(object sender, MouseEventArgs e)
        {

            dlg功能位置档案编辑组织选择 dlg = new dlg功能位置档案编辑组织选择();
            dlg.ShowDialog();
            if(dlg.DialogResult == DialogResult.OK)
            {
                // 这里感觉有点多此一举，直接使用selectRow其实也可以，这样写感觉方便理解。
                this.comboBox所属组织.Tag = dlg.OrganizationCode;
                this.comboBox所属组织.Text = dlg.OrganizationName;
                this.textBox一级编码.Text = dlg.Code;
                this.textBox公司名称.Text = dlg.CompanyName;
                GeneratePositionCode();
            }
            this.ActiveControl = null;// 关闭选择弹窗后取消选中状态，防止slComboBox控件的输入事件
        }

        // 点击展开功能主设备选择框
        private void comboBox功能主设备_MouseDown(object sender, MouseEventArgs e)
        {
            using(dlg功能位置档案编辑主设备选择 dlg = new dlg功能位置档案编辑主设备选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox功能主设备.Tag = dlg.ID;
                    this.comboBox功能主设备.Text = dlg.Name;
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
            string organizationID = this.comboBox所属组织.Tag as string;
            string deviceID = this.comboBox功能主设备.Tag?.ToString() ?? "";
            if(!string.IsNullOrEmpty(organizationID) && !string.IsNullOrEmpty(deviceID)){
                string level1Code = this.textBox一级编码.Text;
                string level2Code = this.textBox二级编码.Text;
                string level3Code = this.textBox三级编码.Text;

                this.slTextBox功能位置编码.Text = level3Code + level2Code + level1Code;
            }
        }

        /// <summary>
        /// 打开人员选择弹窗界面
        /// </summary>
        private void OpenMemberSelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string name = comboBox.Name.Replace("comboBox", "");

            using (dlg功能位置档案编辑成员选择 dlg = new dlg功能位置档案编辑成员选择(name + "选择"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Tag = dlg.SelectedMemberIDs;
                    comboBox.Text = dlg.SelectedMemberNames;
                }
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 打开部门选择框
        /// </summary>
        private void OpenDepartmentSelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string name = comboBox.Name.Replace("comboBox", "");

            using (dlg功能位置档案编辑部门选择 dlg = new dlg功能位置档案编辑部门选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Tag = dlg.Code;
                    comboBox.Text = dlg.Name;
                }
                this.ActiveControl = null;
            }
        }

        private bool dlg功能位置档案编辑_PreOK(FieldArray aryFields)
        {
            string organizationCode = this.comboBox所属组织.Tag as string;
            if (!string.IsNullOrEmpty(organizationCode))
            {
                this.OtherFields["组织编码"] = organizationCode;
            }

            long equipmentID = Convert.ToInt64(this.comboBox功能主设备.Tag);
            if (equipmentID > 0)
            {
                this.OtherFields["绑定主设备ID"] = equipmentID;
            }

            string ManageDepartment = this.comboBox管理部门.Tag as string;
            if (!string.IsNullOrEmpty(ManageDepartment))
            {
                this.OtherFields["管理部门编码"] = ManageDepartment;
            }

            string UseDepartment = this.comboBox使用部门.Tag as string;
            if (!string.IsNullOrEmpty(UseDepartment))
            {
                this.OtherFields["使用部门编码"] = UseDepartment;
            }

            long responsiblePerson = Convert.ToInt64(this.comboBox责任人.Tag);
            if (responsiblePerson > 0)
            {
                this.OtherFields["责任人ID"] = responsiblePerson.ToString();
            }

            string inspectors = this.comboBox巡检人员.Tag as string;
            if (!string.IsNullOrEmpty(inspectors))
            {
                this.OtherFields["巡检人员IDs"] = inspectors;
            }

            string maintainers = this.comboBox维保人员.Tag as string;
            if (!string.IsNullOrEmpty(maintainers))
            {
                this.OtherFields["维保人员IDs"] = maintainers;
            }

            string checkers = this.comboBox检验人员.Tag as string;
            if (!string.IsNullOrEmpty(checkers))
            {
                this.OtherFields["检验人员IDs"] = checkers;
            }

            return true;
        }

        private void dlg功能位置档案编辑_AfterFillControls()
        {
            if(this.OperFlag == SleOperFlag.Modify)
            {

            }

            
        }

        /// <summary>
        /// 填充自定义选择框数据
        /// </summary>
        private void FillComBox()
        {
            string billCode = this.slTextBox单据号.Text;
            var service = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            string sql = "select 组织编码,绑定主设备ID,责任人ID,巡检人员IDs,维保人员IDs,检验人员IDs,管理部门编码，使用部门编码 from 功能位置档案 where 单据号='" + billCode + "'";
            DataTable dt = service.ExecuteForDataTable(sql);
            DataRow dr = dt.Rows[0];

            // 所属组织
            string organizationCode = dr["组织编码"].ToString();
            sql = "select 组织名称, from 组织 where 组织编码='" + organizationCode + "'";
            

            // 功能主设备
            long equipmentID = Convert.ToInt64(dr["绑定主设备ID"]);
    
        }
    }
}