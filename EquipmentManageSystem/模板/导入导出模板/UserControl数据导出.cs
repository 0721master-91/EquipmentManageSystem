using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.模板.导入导出模板
{
    public partial class UserControl数据导出 : UserControl
    {

        /// <summary>
        /// 导出的数据
        /// </summary>
        private DataTable OutDataSource;

        /// <summary>
        /// 导出字段
        /// </summary>
        private List<ExportField> ExportFields = new List<ExportField>();

        /// <summary>
        /// 主表表名
        /// </summary>
        private string MainTable;

        public UserControl数据导出()
        {
            InitializeComponent();
        }

        public UserControl数据导出(DataTable outData, ,string mainTable)
        {
            InitializeComponent();
            this.OutDataSource = outData;
            this.MainTable = mainTable;
        }

        //加载字段
        private void UserControl数据导出_Load(object sender, EventArgs e)
        {
           this.initdataGridView();
           
        }

        /// <summary>
        /// 初始化可选字段数据表格
        /// </summary>
        private void initdataGridView()
        {
            if (this.OutDataSource == null) return;

            // 清空左侧表格
            this.dataGridView可选字段.Columns.Clear();
            this.dataGridView可选字段.Rows.Clear();

            // 添加一列
            this.dataGridView可选字段.Columns.Add("字段名称", "字段名称");

            // 遍历 OutData 的列名，逐行添加
            foreach (DataColumn column in this.OutDataSource.Columns)
            {
                ExportField field = this.GenerateExportField(column.ColumnName);
                this.dataGridView可选字段.Rows.Add(field.OptionName);
            }

            if (this.dataGridView可选字段.Rows.Count > 0)
            {
                this.dataGridView可选字段.Rows[0].Selected = true;
            }

            this.dataGridView可选字段.RowHeadersVisible = false;  // 隐藏最左边的行标题列
            this.dataGridView可选字段.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView可选字段.ColumnHeadersVisible = false;
            this.dataGridView可选字段.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView可选字段.ReadOnly = true;
            this.dataGridView可选字段.AllowUserToAddRows = false;
            this.dataGridView可选字段.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private ExportField GenerateExportField(string cloumnName)
        {
            ExportField field = new ExportField
            {
                ExcelFieldName = cloumnName,
                OptionName = "[主表]" + cloumnName,
                IsMainTableField = true
            };
            this.ExportFields.Add(field);
            return field;
        }
    }
}
