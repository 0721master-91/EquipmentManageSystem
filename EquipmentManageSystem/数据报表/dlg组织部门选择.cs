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

namespace EquipmentManageSystem.数据报表
{
    public partial class dlg组织部门选择 : temp选择窗口
    {
        /// <summary>
        /// 选择的组织名称
        /// </summary>
        public string SelectOrgName;

        /// <summary>
        /// 选择的组织编码
        /// </summary>
        public string SelectOrgCode;

        /// <summary>
        /// 选择的部门名称
        /// </summary>
        public string SelectDepName;

        /// <summary>
        /// 选择的部门编码
        /// </summary>
        public string SelectDepCode;

        private string OrgCode;
        public dlg组织部门选择(string orgCode = null)
        {
            InitializeComponent();
            this.OrgCode = orgCode;
        }

        private bool dlg组织部门选择_BeforeQuery()
        {
            string sql;
            if (string.IsNullOrEmpty(this.OrgCode))
            {
                sql = "select 组织编码,组织名称,公司地址 " +
                      "from 组织 " +
                      "where IsEnabled = 1 ";
            }
            else
            {
                sql = "select d.部门编码,o.组织名称,d.部门名称 " +
                      "from 部门 as d " +
                      "join 组织 as o on o.组织编码 = d.组织编码 " +
                      "where d.IsEnabled = 1 " + 
                        "and d.组织编码 = '" + this.OrgCode + "' ";
            }
            this.Sql = sql;
            return true;
        }

        private void dlg组织部门选择_AfterFillControls()
        {
            DataView dv = this.dataGridView数据表.DataSource as DataView;
            DataTable dt = dv.Table;
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row[dt.Columns[0]] = null;
                row[dt.Columns[1]] = "全部";
                row[dt.Columns[2]] = "全部";
                dt.Rows.InsertAt(row, 0);
            }

            if(this.dataGridView数据表.Columns["组织编码"] != null)
            {
                this.dataGridView数据表.Columns["组织编码"].Visible = false;
            }

            if (this.dataGridView数据表.Columns["部门编码"] != null)
            {
                this.dataGridView数据表.Columns["部门编码"].Visible = false;
            }
            
            this.dataGridView数据表.ClearSelection();
            this.SelectedRows.Clear();
        }

        private bool dlg组织部门选择_PreOK()
        {
            if(this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请选择组织部门");
                return false;
            }

            if (this.dataGridView数据表.Columns["组织编码"] != null)
            {
                this.SelectOrgName = this.SelectedRows[0]["组织名称"].ToString();
                this.SelectOrgCode = this.SelectedRows[0]["组织编码"].ToString();
            }

            if (this.dataGridView数据表.Columns["部门编码"] != null)
            {
                this.SelectDepName = this.SelectedRows[0]["部门名称"].ToString();
                this.SelectDepCode = this.SelectedRows[0]["部门编码"].ToString();
            }

                return true;
        }
    }
}