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

namespace EquipmentManageSystem.Global
{
    public partial class dlg组织选择 : temp选择窗口
    {
        /// <summary>
        /// 是否允许选择为空
        /// </summary>
        public bool IsAlowEmpty;

        public string OrgCode = string.Empty; // 组织编码
        public string OrgName = string.Empty; // 组织名称
        public string OrgLocation = string.Empty; // 公式地址

        public dlg组织选择(bool isAlowEmpty = true)
        {
            InitializeComponent();
            this.IsAlowEmpty = isAlowEmpty;
        }

        private bool dlg组织选择_BeforeQuery()
        {
            this.Sql = "select 组织编码,组织名称,公司地址,创建时间 from 组织 where IsDelete = 0 and IsEnabled = 1";
            return true;

        }

        private bool dlg组织选择_PreOK()
        {
            if (IsAlowEmpty)
            {
                if(this.SelectedRows.Count == 0)
                {
                    return true;
                }
            }
            else
            {
                if (this.SelectedRows.Count == 0)
                {
                    PopUpUtil.ShowInfo("请选择组织");
                    return false;
                }

            }

            this.OrgCode = this.SelectedRows[0]["组织编码"].ToString();
            this.OrgName = this.SelectedRows[0]["组织名称"].ToString();
            this.OrgLocation = this.SelectedRows[0]["公司地址"].ToString();

            return true;
        }
    }
}
