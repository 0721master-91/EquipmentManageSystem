
namespace EquipmentManageSystem.设备保养
{
    partial class uc保养任务标准
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel操作区 = new System.Windows.Forms.Panel();
            this.button全部 = new System.Windows.Forms.Button();
            this.button删除 = new System.Windows.Forms.Button();
            this.button新增 = new System.Windows.Forms.Button();
            this.panel数据区 = new System.Windows.Forms.Panel();
            this.dataGridView保养任务标准数据 = new System.Windows.Forms.DataGridView();
            this.panel操作区.SuspendLayout();
            this.panel数据区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView保养任务标准数据)).BeginInit();
            this.SuspendLayout();
            // 
            // panel操作区
            // 
            this.panel操作区.Controls.Add(this.button全部);
            this.panel操作区.Controls.Add(this.button删除);
            this.panel操作区.Controls.Add(this.button新增);
            this.panel操作区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel操作区.Font = new System.Drawing.Font("宋体", 11F);
            this.panel操作区.Location = new System.Drawing.Point(0, 0);
            this.panel操作区.Name = "panel操作区";
            this.panel操作区.Size = new System.Drawing.Size(1078, 64);
            this.panel操作区.TabIndex = 0;
            // 
            // button全部
            // 
            this.button全部.Font = new System.Drawing.Font("宋体", 11F);
            this.button全部.Location = new System.Drawing.Point(308, 15);
            this.button全部.Name = "button全部";
            this.button全部.Size = new System.Drawing.Size(119, 35);
            this.button全部.TabIndex = 2;
            this.button全部.Text = "全部删除";
            this.button全部.UseVisualStyleBackColor = true;
            this.button全部.Click += new System.EventHandler(this.DeleteAll);
            // 
            // button删除
            // 
            this.button删除.Font = new System.Drawing.Font("宋体", 11F);
            this.button删除.Location = new System.Drawing.Point(160, 15);
            this.button删除.Name = "button删除";
            this.button删除.Size = new System.Drawing.Size(119, 35);
            this.button删除.TabIndex = 1;
            this.button删除.Text = "删除";
            this.button删除.UseVisualStyleBackColor = true;
            this.button删除.Click += new System.EventHandler(this.DeleteSelectedRow);
            // 
            // button新增
            // 
            this.button新增.Font = new System.Drawing.Font("宋体", 11F);
            this.button新增.Location = new System.Drawing.Point(13, 15);
            this.button新增.Name = "button新增";
            this.button新增.Size = new System.Drawing.Size(119, 35);
            this.button新增.TabIndex = 0;
            this.button新增.Text = "新增";
            this.button新增.UseVisualStyleBackColor = true;
            this.button新增.Click += new System.EventHandler(this.AddNewRow);
            // 
            // panel数据区
            // 
            this.panel数据区.Controls.Add(this.dataGridView保养任务标准数据);
            this.panel数据区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel数据区.Location = new System.Drawing.Point(0, 64);
            this.panel数据区.Name = "panel数据区";
            this.panel数据区.Size = new System.Drawing.Size(1078, 195);
            this.panel数据区.TabIndex = 1;
            // 
            // dataGridView保养任务标准数据
            // 
            this.dataGridView保养任务标准数据.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView保养任务标准数据.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView保养任务标准数据.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView保养任务标准数据.Location = new System.Drawing.Point(3, 3);
            this.dataGridView保养任务标准数据.Name = "dataGridView保养任务标准数据";
            this.dataGridView保养任务标准数据.RowHeadersWidth = 51;
            this.dataGridView保养任务标准数据.RowTemplate.Height = 27;
            this.dataGridView保养任务标准数据.Size = new System.Drawing.Size(1072, 189);
            this.dataGridView保养任务标准数据.TabIndex = 0;
            this.dataGridView保养任务标准数据.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView保养任务标准数据_CellClick);
            // 
            // uc保养任务标准
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel数据区);
            this.Controls.Add(this.panel操作区);
            this.Name = "uc保养任务标准";
            this.Size = new System.Drawing.Size(1078, 259);
            this.Load += new System.EventHandler(this.uc保养任务标准_Load);
            this.panel操作区.ResumeLayout(false);
            this.panel数据区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView保养任务标准数据)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button新增;
        private System.Windows.Forms.Button button删除;
        private System.Windows.Forms.Button button全部;
        private System.Windows.Forms.Panel panel数据区;
        private System.Windows.Forms.Panel panel操作区;
        private System.Windows.Forms.DataGridView dataGridView保养任务标准数据;
    }
}
