﻿using EquipmentManageSystem.模板;
using SLControls.SLGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能主设备档案编辑 : SLControls.SLAomTmpForm
    {
        public dlg功能主设备档案编辑()
        {
            InitializeComponent();
        }

        private bool dlg功能主设备档案编辑_PreOK(FieldArray aryFields)
        {
            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox设备编码.Text = SqlCommonUtil.GenerateCode("SBDA", "设备档案", "设备编码");
            }

            string equipmentName = this.slTextBox设备名称.Text;
            if (string.IsNullOrEmpty(equipmentName))
            {
                PopUpUtil.ShowWarning("设备名称不能为空！");
                return false;
            }

            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;
            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;
        }

        private void dlg功能主设备档案编辑_AfterFillControls()
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox设备编码.Text = SqlCommonUtil.GenerateCode("SBDA","设备档案","设备编码");
            }

            // 将数据库中的 IsEnabled 字段值回填到复选框
            object val = this.OtherFields["IsEnabled"];
            if (val != null)
            {
                this.checkBox启用状态.Checked = Convert.ToBoolean(val);
            }
        }
    }
}