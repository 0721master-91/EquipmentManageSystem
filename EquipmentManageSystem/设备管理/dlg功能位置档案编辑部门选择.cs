using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板.选择窗口模版;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能位置档案编辑部门选择 : temp选择窗口
    {
        public string DepCode;//部门编码
        public string DepName;//部门名称

        public dlg功能位置档案编辑部门选择()
        {
            InitializeComponent();
        }

        private bool dlg功能位置档案编辑部门选择_BeforeQuery()
        {
            this.Sql = "select d.ID,o.组织名称 as 组织,d.部门名称 as 部门,d.部门编码 " +
                       "from 部门 as d " +
                       "left join 组织 as o on d.组织编码 = o.组织编码 " +
                       "where d.IsEnabled = 1";

            return true;
        }

        private void dlg功能位置档案编辑部门选择_AfterFillControls()
        {
            this.dataGridView数据表.Columns["部门编码"].Visible = false;
        }

        private bool dlg功能位置档案编辑部门选择_PreOK()
        {
            if(this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowWarning("请选择部门！");
                return false;
            }

            this.DepCode = this.SelectedRows[0]["部门编码"].ToString();
            this.DepName = this.SelectedRows[0]["部门"].ToString();

            return true;
        }
    }
}
