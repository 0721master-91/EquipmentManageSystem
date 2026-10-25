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
using DevExpress.Data;

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
            this.Type编辑窗口 = typeof(dlg保养标准编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;
            this.LodeFilter();

        }

        private void button查看详细_Click(object sender, EventArgs e)
        {
            using(dlg保养标准编辑 dlg = SLEditDialogUtil.GetDetaisDialogObj(this,typeof(dlg保养标准编辑)) as dlg保养标准编辑)
            {
                dlg.IsCloseModify = true;
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 加载过滤条件
        /// </summary>
        private void LodeFilter()
        {
            var severe = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            // 加载给油类型选项
            CommonFilter.InitCombox(this.comboBox给油类型, "类型", "编码", "给油类型");

            //加载润换方式选项
            CommonFilter.InitCombox(this.comboBox润换方式, "方式", "编码", "润换方式");

            //加载启用选项
            this.comboBox启用状态.DisplayMember = "状态";
            this.comboBox启用状态.ValueMember = "状态值";
            this.comboBox启用状态.SelectedValue = null;
            this.comboBox启用状态.DataSource = CommonFilter.GetEnabledStatusFilter();
        }

        private bool ctn保养标准_BeforeChangeDataSource()
        {
            string sql = "select b.ID,b.保养标准编码,b.保养内容,g.类型 as 给油类型,b.润滑脂型号,r.方式 as 润换方式,b.执行周期,z.单位名称 as 周期单位, " +
                            "case when b.IsEnabled = 1 then '启用' else '停用' end as 启用状态,b.创建时间 " +
                         "from 保养标准 as b " +
                         "left join 给油类型 as g on b.给油类型编码 = g.编码 " +
                         "left join 润换方式 as r on b.润换方式编码 = r.编码 " +
                         "join 周期单位 as z on b.周期单位编码 = z.单位编码 " +
                         "where b.IsDelete = 0 ";

            if(this.textBox保养标准编码.Text.Trim() != "")
            {
                sql += " and b.保养标准编码 like '%" + this.textBox保养标准编码.Text.Trim() + "%'";
            }

            object giveOilType = this.comboBox给油类型.SelectedValue;
            string giveOilTypeStr = giveOilType == null ? "" : giveOilType.ToString();
            if(!string.IsNullOrEmpty(giveOilTypeStr))
            {
                sql += " and b.给油类型编码 = '" + giveOilTypeStr + "'";
            }

            if(this.textBox润滑脂型号.Text.Trim() != "")
            {
                sql += " and b.润滑脂型号 like '%" + this.textBox润滑脂型号.Text.Trim() + "%'";
            }
            
            object replaceType = this.comboBox润换方式.SelectedValue;
            string replaceTypeStr = replaceType == null ? "" : replaceType.ToString();
            if(!string.IsNullOrEmpty(replaceTypeStr))
            {
                sql += " and b.润换方式编码 = '" + replaceTypeStr + "'";
            }

            object enabledStatus = this.comboBox启用状态.SelectedValue;
            string enabledStatusStr = enabledStatus == null ? "" : enabledStatus.ToString();
            if(!string.IsNullOrEmpty(enabledStatusStr))
            {
                sql += " and b.IsEnabled = " + enabledStatusStr;
            }

            this.Sql查询 = sql;
            return true;
        }


        private DataTable CurrentDataSource;//当前数据集
        // 数据改变后修改表格显示
        private void ctn保养标准_AfterChangeDataSource(DataTable newTable)
        {
            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;

            // 设置日期列显示格式，先于自动调整列宽
            var col = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            if (col != null)
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            col.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            this.slDevGridControlMain.MainGridView.BestFitColumns();

            var colContent = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("保养内容");
            colContent.Width = 200;

            this.slDevGridControlMain.SetSummaryItem("保养标准编码", "合计：{0}", SummaryItemType.Count);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();
            if (this.CurrentDataSource == null)
            {
                MessageBox.Show("数据为空，无法进行模糊查询", "提示",
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
                    "保养标准编码 LIKE '%{0}%' " +
                    "OR 保养内容 LIKE '%{0}%' " +
                    "OR 给油类型 LIKE '%{0}%' " +
                    "OR 润滑脂型号 LIKE '%{0}%' " +
                    "OR 润换方式 LIKE '%{0}%' " +
                    "OR 执行周期 LIKE '%{0}%' " +
                    "OR 周期单位 LIKE '%{0}%' " +
                    "OR 启用状态 LIKE '%{0}%' " +
                    "OR 创建时间 LIKE '%{0}%' ",
                    keyword);
            }

        }

        private void slFlatButton导入_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            dlg保养标准导出 dlg = new dlg保养标准导出(outData);
            dlg.ShowDialog();
            this.button刷新.PerformClick();
        }

        private void ctn保养标准_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }
    }
}
