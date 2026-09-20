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
            /*this.slDevGridControlMain.MainGridView.OptionsView.ColumnAutoWidth = true;*/
            this.Type编辑窗口 = typeof(dlg功能主设备档案编辑);
            this.slDevGridControlMain.ShowFooter = true;

            this.LoadFilter();

            this.BeforeChangeDataSource += () =>
            {
                string sql = "select e.ID,e.设备编码,e.设备名称,t.类型名称 as 设备类型,m.模块名称 as 设备模块,  " +
                                "case when e.IsEnabled = 1 then '启用' else '停用' end as 状态 " +
                              "from 设备档案 as e " +
                              "join 设备类型 as t on e.设备类型编码 = t.类型编码 " +
                              "join 设备模块 as m on e.设备模块编码 = m.模块编码 " +
                              "where 1 = 1 ";

                string name = this.textBox设备名称.Text;
                if (!string.IsNullOrEmpty(name))
                {
                    sql += " and e.设备名称 like '%" + name + "%'";
                }

                string code = this.textBox设备编码.Text;
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

                sql += "and IsDelete = 0";
                this.Sql查询 = sql;

                return true;
            };

        }

        private void LoadFilter()
        {
            string sql = "select 类型编码,类型名称 from 设备类型";
            DataTable dtType = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            // 插入"全部"选项
            DataRow rowAll = dtType.NewRow();
            rowAll["类型编码"] = "";
            rowAll["类型名称"] = "全部";
            dtType.Rows.InsertAt(rowAll, 0);

            this.slComboBox设备类型.DisplayMember = "类型名称";
            this.slComboBox设备类型.SelectedValue = "";
            this.slComboBox设备类型.ValueMember = "类型编码";
            this.slComboBox设备类型.DataSource = dtType;

            // 设置设备状态下拉框选项
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("状态", typeof(string));
            dtStatus.Columns.Add("状态值", typeof(object));
            DataRow row1 = dtStatus.NewRow();
            row1["状态"] = "全部";
            row1["状态值"] = null;
            dtStatus.Rows.Add(row1);
            DataRow row2 = dtStatus.NewRow();
            row2["状态"] = "启用";
            row2["状态值"] = 1;
            dtStatus.Rows.Add(row2);
            DataRow row3 = dtStatus.NewRow();
            row3["状态"] = "停用";
            row3["状态值"] = 0;
            dtStatus.Rows.Add(row3);
            this.slComboBox启用状态.DisplayMember = "状态";
            this.slComboBox启用状态.ValueMember = "状态值";
            this.slComboBox启用状态.SelectedValue = null;
            this.slComboBox启用状态.DataSource = dtStatus;
        }

        private DataTable CurrentDataSource;
        private void ctn功能主设备档案_AfterChangeDataSource(DataTable newTable)
        {
            this.slTextBox模糊查询.Text = string.Empty;
            var colEnabled = slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("IsEnabled");
            if (colEnabled != null)
            {
                colEnabled.Visible = false;
            }
            this.CurrentDataSource = newTable;
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
            this.RefreshData();
        }
    }
}