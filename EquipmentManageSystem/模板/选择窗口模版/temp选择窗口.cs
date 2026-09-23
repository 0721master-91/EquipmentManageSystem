using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.模板.选择窗口模版
{
    public partial class temp选择窗口 : Form
    {
        [Category("窗口配置")]
        [DisplayName("查询sql")]
        [Description("提供数据查询语句")]
        public string Sql { get; set; }

        [Category("窗口配置")]
        [DisplayName("是否多选")]
        [Description("该窗口数据是否支持多选")]
        public bool IsMultiSelect { get; set; }

        /// <summary>
        /// 查询结果数据表
        /// </summary>
        private DataTable SourceData;

        private List<DataRow> selectedRows = new List<DataRow>();

        public temp选择窗口()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询前操作
        /// 用于赋值sql等操作
        /// </summary>
        /// <returns></returns>
        protected virtual bool BeforeQueryData()
        {
            return true;
        }

        /// <summary>
        /// 查询后操作
        /// </summary>
        protected virtual void AfterQueryData(DataTable dt){}

        /// <summary>
        /// 选择数据后操作
        /// </summary>
        /// <param name="rows"></param>
        protected virtual void AfterSelectData(List<DataRow> rows){}

        // 加载数据并显示
        private void temp选择窗口_Load(object sender, EventArgs e)
        {
            var server = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            if (!BeforeQueryData()) return;

            if (string.IsNullOrEmpty(Sql))
            {
                Utils.PopUpUtil.ShowWarning("sql未赋值");
                return;
            }

            this.SourceData = server.ExecuteForDataTable(Sql);

            AfterQueryData(this.SourceData);

            // 绑定数据到表格
            this.dataGridView数据表.AutoGenerateColumns = true;
            this.dataGridView数据表.DataSource = new DataView(SourceData);
            this.dataGridView数据表.ClearSelection();


        }

        /// <summary>
        /// 设置选择模式
        /// </summary>
        private void SetSelectionMode()
        {
            this.dataGridView数据表.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (this.IsMultiSelect)
            {
                // 开启多选
                this.dataGridView数据表.MultiSelect = true;

                // 在最前面插入一列复选框
                DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
                checkCol.HeaderText = "选择";
                checkCol.Name = "col选择";
                this.dataGridView数据表.CurrentCellDirtyStateChanged += (s, e) =>
                {
                    if (this.dataGridView数据表.CurrentCell is DataGridViewCheckBoxCell)
                        this.dataGridView数据表.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
            }
            else
            {

            }
        }


        private void button取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button确认_Click(object sender, EventArgs e)
        {
            this.AfterSelectData(this.selectedRows);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
