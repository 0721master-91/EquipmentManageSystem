using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;

namespace EquipmentManageSystem.标准管理
{
    public partial class ctn保养标准 : temp标准基本信息GridControl
    {
        public ctn保养标准()
        {
            InitializeComponent();
        }

        private void ctn保养标准_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ShowFooter = true;
            this.LodeFilter();

        }

        /// <summary>
        /// 加载过滤条件
        /// </summary>
        private void LodeFilter()
        {
            var severe = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            // 加载给油类型选项
            DataTable dt1 = severe.ExecuteForDataTable("select 编码,类型 FROM 给油类型");
            DataRow dr1 = dt1.NewRow();
            dr1["编码"] = null;
            dr1["类型"] = "全部";
            dt1.Rows.InsertAt(dr1, 0);
            DataRow dr2 = dt1.NewRow();
            dr2["编码"] = "";
            dr2["类型"] = "空";
            dt1.Rows.InsertAt(dr2, 1);
            this.comboBox给油类型.DisplayMember = "类型";
            this.comboBox给油类型.ValueMember = "编码";
            this.comboBox给油类型.SelectedValue = null;
            this.comboBox给油类型.DataSource = dt1;

            //加载润换方式选项
            DataTable dt2 = severe.ExecuteForDataTable("select 编码,方式 from 润换方式");
            DataRow dr3 = dt2.NewRow();
            dr3["编码"] = null;
            dr3["方式"] = "全部";
            dt2.Rows.InsertAt(dr3, 0);
            DataRow dr4 = dt2.NewRow();
            dr4["编码"] = "";
            dr4["方式"] = "空";
            dt2.Rows.InsertAt(dr4, 1);
            this.comboBox润换方式.DisplayMember = "方式";
            this.comboBox润换方式.ValueMember = "编码";
            this.comboBox润换方式.SelectedValue = null;
            this.comboBox润换方式.DataSource = dt2;

            //加载启用选项
            this.comboBox启用状态.DisplayMember = "状态";
            this.comboBox启用状态.ValueMember = "状态值";
            this.comboBox启用状态.SelectedValue = null;
            this.comboBox启用状态.DataSource = CommonFilter.GetEnabledStatusFilter();
        }

        private bool ctn保养标准_BeforeChangeDataSource()
        {
            MessageBox.Show("测试");
            return true;
        }
    }
}
