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
    public partial class dlg功能位置档案编辑组织选择 : temp选择窗口
    {
        /// <summary>
        /// 选择的组织ID
        /// </summary>
        public object OrganizationId { get; set; }

        /// <summary>
        /// 选择的组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        public dlg功能位置档案编辑组织选择()
        {
            InitializeComponent();
        }

        private bool dlg功能位置档案编辑组织选择_BeforeQuery()
        {
            string sql = "select ID,组织编码,组织名称,公司地址 from 组织 where IsDelete = 0 and IsEnabled = 1";
            this.Sql = sql;

            return true;
        }

        private bool dlg功能位置档案编辑组织选择_PreOK()
        {
            if(this.selectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请选择组织");
                return false;
            }

            if (this.selectedRows.Count >= 1)
            {
                this.OrganizationId = this.selectedRows[0]["ID"];
                this.OrganizationName = this.selectedRows[0]["公司地址"].ToString();
            }
            else
            {
                PopUpUtil.ShowWarning("选择组织数量为0");
            }

            return true;
        }
    }
}
