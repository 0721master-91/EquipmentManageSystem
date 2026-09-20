﻿using EquipmentManageSystem.模板;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能主设备档案编辑 : SLControls.SLAomTmpForm
    {
        public dlg功能主设备档案编辑()
        {
            InitializeComponent();
        }

        private bool dlg功能主设备档案编辑_PreOK(SLControls.SLGlobal.FieldArray aryFields)
        {
            this.OtherFields["IsEnabled"] = this.checkBox启用状态.Checked;

            return true;
        }

        private void dlg功能主设备档案编辑_AfterFillControls()
        {
            // 将数据库中的 IsEnabled 字段值回填到复选框
            object val = this.OtherFields["IsEnabled"];
            if (val != null)
            {
                this.checkBox启用状态.Checked = Convert.ToBoolean(val);
            }
        }
    }
}