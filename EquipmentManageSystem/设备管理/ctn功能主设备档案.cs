using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板.导入导出模板;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Global;
using DevExpress.Data;

namespace EquipmentManageSystem.设备管理
{
    public partial class ctn功能主设备档案 : SLQLControls.模板.temp标准基本信息GridControl
    {
        public ctn功能主设备档案()
        {
            InitializeComponent();
        }
        private void ctn功能主设备档案_Load(object sender, EventArgs e)
        {
            this.TableName = "设备档案";
            this.slDevGridControlMain.RowFont = new System.Drawing.Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new System.Drawing.Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg功能主设备档案编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString();
            this.slDevGridControlMain.ShowFooter = true;

            this.LoadFilter();

            this.BeforeChangeDataSource += () =>
            {
                string sql = "select e.ID,e.设备编码,e.设备名称,t.类型名称 as 设备类型,m.模块名称 as 设备模块,  " +
                                "case when e.IsEnabled = 1 then '启用' else '停用' end as 状态 " +
                              "from 设备档案 as e " +
                              "join 设备类型 as t on e.设备类型编码 = t.类型编码 " +
                              "join 设备模块 as m on e.设备模块编码 = m.模块编码 " +
                              "where IsDelete = 0 ";

                string name = this.textBox设备名称.Text.Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    sql += " and e.设备名称 like '%" + name + "%'";
                }

                string code = this.textBox设备编码.Text.Trim();
                if (!string.IsNullOrEmpty(code))
                {
                    sql += " and e.设备编码 like '%" + code + "%'";
                }

                object typeCodeObject = this.slComboBox设备类型.SelectedValue;
                string typeCode = typeCodeObject == null ? "" : typeCodeObject.ToString();
                if (!string.IsNullOrEmpty(typeCode))
                {
                    sql += " and e.设备类型编码 = '" + typeCode + "'";
                }
                
                object statusObject = this.slComboBox启用状态.SelectedValue;
                string status = statusObject == null ? "" : statusObject.ToString();
                if (!string.IsNullOrEmpty(status))
                {
                    sql += " and e.IsEnabled = " + Convert.ToInt32(status);
                }

                this.Sql查询 = sql;

                return true;
            };

        }

        private void LoadFilter()
        {
            CommonFilter.InitCombox(this.slComboBox设备类型,"类型名称","类型编码","设备类型");

            // 设置设备状态下拉框选项
            this.slComboBox启用状态.DisplayMember = "状态";
            this.slComboBox启用状态.ValueMember = "状态值";
            this.slComboBox启用状态.SelectedValue = null;
            this.slComboBox启用状态.DataSource = CommonFilter.GetEnabledStatusFilter();
        }

        private DataTable CurrentDataSource;//保存当前数据集
        private void ctn功能主设备档案_AfterChangeDataSource(DataTable newTable)
        {
            this.slTextBox模糊查询.Text = string.Empty;
            var colEnabled = slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("IsEnabled");
            if (colEnabled != null)
            {
                colEnabled.Visible = false;
            }

            this.slDevGridControlMain.SetSummaryItem("设备编码", "合计：{0}", SummaryItemType.Count);
            this.CurrentDataSource = newTable;//将数据的地址保存，以便在模糊查询时使用
            // 数据加载后，根据内容自动调整列宽
            this.slDevGridControlMain.MainGridView.BestFitColumns();

            FuzzyQuery(null,null);
        }

        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.slTextBox模糊查询.Text.Trim();
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
                    "设备编码 LIKE '%{0}%' OR 设备名称 LIKE '%{0}%' OR 设备类型 LIKE '%{0}%' OR 设备模块 LIKE '%{0}%' OR 状态 LIKE '%{0}%'",
                    keyword);
            }   
        }

        private void OpenImportOutDialog(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            dlg功能主设备档案导入导出 dialog = new dlg功能主设备档案导入导出(outData);
            dialog.ShowDialog();
            this.button刷新.PerformClick();
        }

        private void ctn功能主设备档案_After操作(object sender, SLQLControls.控件.控件公用类.AfterEventArgs e)
        {
            this.button刷新.PerformClick();
        }

        private void button查看详细_Click(object sender, EventArgs e)
        {
            using(dlg功能主设备档案编辑 dlg = SLEditDialogUtil.GetDetaisDialogObj(this, typeof(dlg功能主设备档案编辑)) as dlg功能主设备档案编辑)
            {
                dlg.IsCloseModify = true;
                dlg.ShowDialog();
            }
        }
    }
}