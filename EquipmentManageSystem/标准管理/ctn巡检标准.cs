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
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.标准管理
{
    public partial class ctn巡检标准 : temp标准基本信息GridControl
    {
        public ctn巡检标准()
        {
            InitializeComponent();
        }

        private void ctn巡检标准_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg巡检标准编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;
            LoadFilter();
        }

        private bool ctn巡检标准_BeforeChangeDataSource()
        {
            string sql = "select x.ID,x.巡检标准编码,x.巡检部位,x.巡检内容,x.巡检类型,x.判断标准,x.巡检周期,z.单位名称,x.提前提醒天数, " +
                             "case when x.IsEnabled = 1 then '启用' else '停用' end as 启用状态,x.创建时间 " +
                         "from 巡检标准 as x " +
                         "join 周期单位 as z on x.周期单位编码 = z.单位编码 " +
                         "where IsDelete = 0 ";

/*            string partCode = this.textBox巡检部位编码.Text.Trim();*/
            if (this.textBox巡检部位编码.Text.Trim() != "")
            {
                sql += " and x.巡检标准编码 like '%" + this.textBox巡检部位编码.Text.Trim() + "%' ";
            }

            if (this.textBox巡检部位.Text.Trim() != "")
            {
                sql += " and x.巡检部位 like '%" + this.textBox巡检部位.Text.Trim() + "%' ";
            }

            if (this.textBox巡检类型.Text.Trim() != "")
            {
                sql += " and x.巡检类型 like '%" + this.textBox巡检类型.Text.Trim() + "%' ";
            }

            Object statusObject = this.comboBox启用状态.SelectedValue;
            string status = statusObject == null ? "" : statusObject.ToString();
            if (!string.IsNullOrEmpty(status))
            {
                sql += " and x.IsEnabled = " + Convert.ToInt32(status);
            }

            sql += " order by x.创建时间 desc ";
            this.Sql查询 = sql;

            return true;
        }

        /// <summary>
        /// 加载过滤条件
        /// </summary>
        private void LoadFilter()
        {
            this.comboBox启用状态.DisplayMember = "状态";
            this.comboBox启用状态.ValueMember = "状态值";
            this.comboBox启用状态.SelectedValue = null;
            this.comboBox启用状态.DataSource = CommonFilter.GetEnabledStatusFilter();

        }

        private DataTable CurrentDataSource;//当前数据集
        private void ctn巡检标准_AfterChangeDataSource(DataTable newTable)
        {


            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;

            // 设置日期列显示格式，先于自动调整列宽
            var col = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            if (col != null)
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            this.slDevGridControlMain.MainGridView.BestFitColumns();

            // 这两个内容相对比较多，固定宽度保证显示。
            var colContent = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检内容");
            colContent.Width = 300;
            var colJudge = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("判断标准");
            colJudge.Width = 300;

        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();
            if (this.CurrentDataSource == null)
            {
                MessageBox.Show("请先点击「刷新」加载数据", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(keyword))
            {
                // 关键词为空就显示全部数据
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "巡检部位编码 LIKE '%{0}%' " +
                    "OR 巡检部位 LIKE '%{0}%' " +
                    "OR 巡检内容 LIKE '%{0}%' " +
                    "OR 巡检类型 LIKE '%{0}%' " +
                    "OR 判断标准 LIKE '%{0}%' " +
                    "OR 巡检周期 LIKE '%{0}%' " +
                    "OR 单位名称 LIKE '%{0}%' " +
                    "OR 提前提醒天数 LIKE '%{0}%' " +
                    "OR 是否启用 LIKE '%{0}%' " +
                    "OR 创建时间 LIKE '%{0}%' ", 
                    keyword);
            }

        }

        // 打开导入导出窗口
        private void slFlatButton导入_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            dlg巡检标准导入导出 dlg = new dlg巡检标准导入导出(outData);
            dlg.ShowDialog();
            this.RefreshData();
        }

        private void ctn巡检标准_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }
    }
}
