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
    public partial class dlg人员选择 : temp选择窗口
    {
        public string SelectedMemberIDs; // 选中的成员ID
        public string SelectedMemberNames; // 选中的成员名称

        public dlg人员选择()
        {
            InitializeComponent();
        }

        public dlg人员选择(string title)
        {
            InitializeComponent();
            this.Text = title;
        }


        private bool dlg人员选择_BeforeQuery()
        {
            this.Sql = "select c.ID,z.组织名称,b.部门名称,c.姓名,c.手机号,c.岗位 " +
           "from 成员 as c " +
           "left join 部门 as b on c.部门编码 = b.部门编码 " +
           "left join 组织 as z on b.组织编码 = z.组织编码 " +
           "where c.IsDelete = 0 " +
           "and c.ID <> 0 ";

            return true;
        }

        private bool dlg人员选择_PreOK()
        {
            if (this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowWarning("请选择成员");
                return false;
            }

            this.SelectedMemberIDs = string.Join(",", this.SelectedRows.Select(row => row["ID"]?.ToString()));
            this.SelectedMemberNames = string.Join(",", this.SelectedRows.Select(row => row["姓名"]?.ToString()));
            return true;
        }
    }
}
