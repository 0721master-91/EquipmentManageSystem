﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.模板.选择窗口模版;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能位置档案编辑主设备选择 : temp选择窗口
    {
        public long ID; // 设备ID
        public string Code; // 设备编码
        public string Name; // 设备名称
        public string TypeCode; // 设备类型编码
        public string TypeName; // 设备类型名称
        public string ModuleCode; // 设备模块编码
        public string ModuleName; // 设备模块名称

        public dlg功能位置档案编辑主设备选择()
        {
            InitializeComponent();
        }

        private bool dlg功能位置档案编辑主设备选择_BeforeQuery()
        {
            this.Sql = "select d.ID,d.设备编码,d.设备名称,d.设备类型编码,t.类型名称 as 设备类型,d.设备模块编码, m.模块名称 as 设备模块 " +
                "from 设备档案 as d " +
                "left join 设备类型 as t on d.设备类型编码 = t.类型编码 " +
                "left join 设备模块 as m on d.设备模块编码 = m.模块编码 " +
                "where d.IsDelete = 0 and d.IsEnabled = 1";
            return true;
        }

        private void dlg功能位置档案编辑主设备选择_AfterFillControls()
        {
            this.dataGridView数据表.Columns["设备类型编码"].Visible = false;
            this.dataGridView数据表.Columns["设备模块编码"].Visible = false;
        }

        private bool dlg功能位置档案编辑主设备选择_PreOK()
        {
            if (this.dataGridView数据表.SelectedRows.Count == 0) return false;

            this.ID = Convert.ToInt64(this.dataGridView数据表.SelectedRows[0].Cells["ID"].Value);
            this.Code = this.dataGridView数据表.SelectedRows[0].Cells["设备编码"].Value.ToString().Substring(4);
            this.Name = this.dataGridView数据表.SelectedRows[0].Cells["设备名称"].Value.ToString();
            this.TypeCode = this.dataGridView数据表.SelectedRows[0].Cells["设备类型编码"].Value.ToString();
            this.TypeName = this.dataGridView数据表.SelectedRows[0].Cells["设备类型"].Value.ToString();
            this.ModuleCode = this.dataGridView数据表.SelectedRows[0].Cells["设备模块编码"].Value.ToString().Substring(2);
            this.ModuleName = this.dataGridView数据表.SelectedRows[0].Cells["设备模块"].Value.ToString();

            return true;
        }
    }
}