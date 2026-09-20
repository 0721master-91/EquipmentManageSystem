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
    public partial class temp导入导出模版 : Form
    {
        
        /// <summary>
        /// 当前显示页面
        /// </summary>
        private UserControl currentPage;

        /// <summary>
        /// 导入页面对象
        /// </summary>
        private UserControl page导入页面;

        /// <summary>
        /// 导出界面对象
        /// </summary>
        private UserControl page导出页面;

        /// <summary>
        /// 导出数据
        /// </summary>
        public DataTable OutData { get; set; }

        [Category("导入导出")]
        [Description("数据插入数据库表名（目标表名）")]
        public string TableName { get; set; }

        [Category("导入")]
        [DisplayName("导入模版")]
        [Description("Excel导入模版")]
        public List<ExcelTemplate> ExcelTemplates { get; set; }

        [Category("导入")]
        [DisplayName("是否启用")]
        [Description("是否开启导入功能")]
        public bool ImportEnabled { get; set; } = true;

        [Category("导出")]
        [DisplayName("是否启用")]
        [Description("是否开启导出功能")]
        public bool OutEnabled { get; set; } = false;


        /// <summary>
        /// 数据导入数据库前子类可重写此方法修改即将插入的数据集
        /// </summary>
        /// <param name="dataSource">即将导入的数据集</param>
        /// <returns>返回false取消导入</returns>
        protected virtual bool BeforeImport(DataTable dataSource)
        {
            return true; // 默认不处理，继续导入
        }

        public temp导入导出模版()
        {
            InitializeComponent();
        }

        private void button导入_Click(object sender, EventArgs e)
        {
            if(page导入页面 == null)
            {
                this.page导入页面 = new UserControl数据导入(this.ExcelTemplates, this.TableName);
                ((UserControl数据导入)this.page导入页面).BeforeImport += (dataTable) =>
                {
                    return this.BeforeImport(dataTable); 
                };
                this.page导入页面.Dock = DockStyle.Fill;
                this.panel内容区.Controls.Add(this.page导入页面);
            }
            ChangePage(this.page导入页面);
        }

        private void button导出_Click(object sender, EventArgs e)
        {
            if(this.page导出页面 == null)
            {
                this.page导出页面 = new UserControl数据导出(this.OutData,this.TableName);
                this.page导出页面.Dock = DockStyle.Fill;
                this.panel内容区.Controls.Add(this.page导出页面);
            }
            ChangePage(this.page导出页面);
        }

        /// <summary>
        /// 切换显示页面
        /// </summary>
        /// <param name="targetPage">目标页面</param>
        private void ChangePage(UserControl targetPage)
        {

            if (this.currentPage != null)
            {
                this.currentPage.Visible = false;
            }
            targetPage.Visible = true;
            this.currentPage = targetPage;
        }

        private void temp导入导出模版_Load(object sender, EventArgs e)
        {
            if (this.ImportEnabled)
            {
                if (this.ExcelTemplates == null || this.ExcelTemplates.Count == 0)
                {
                    MessageBox.Show("请先设置导入模版","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                }
                this.button导入.Visible = true;

                if (this.OutEnabled )
                {
                    if (this.OutData == null)
                    {
                        MessageBox.Show("导出数据为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.Cancel;
                    }
                    this.button导出.Visible = true;
                }
                button导入_Click(null, null);// 默认先打开导入界面
            }            
            else if (this.OutEnabled)
            {
                if(this.OutData == null)
                {
                    MessageBox.Show("导出数据为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                }
                this.button导出.Visible = true;
                button导出_Click(null, null);// 如果导入页面没有启用，再打开导出页面
            }
                
        }
    }
}
