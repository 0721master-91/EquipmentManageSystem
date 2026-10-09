
namespace EquipmentManageSystem.设备巡检
{
    partial class uc巡检任务标准
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
            this.panel巡检任务标准操作区 = new System.Windows.Forms.Panel();
            this.button巡检标注全部删除 = new System.Windows.Forms.Button();
            this.button巡检标准删除 = new System.Windows.Forms.Button();
            this.button巡检标准新增 = new System.Windows.Forms.Button();
            this.panel巡检任务标准数据区 = new System.Windows.Forms.Panel();
            this.dataGridView巡检任务标准数据 = new System.Windows.Forms.DataGridView();
            this.panel巡检任务标准操作区.SuspendLayout();
            this.panel巡检任务标准数据区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView巡检任务标准数据)).BeginInit();
            this.SuspendLayout();
            // 
            // panel巡检任务标准操作区
            // 
            this.panel巡检任务标准操作区.Controls.Add(this.button巡检标注全部删除);
            this.panel巡检任务标准操作区.Controls.Add(this.button巡检标准删除);
            this.panel巡检任务标准操作区.Controls.Add(this.button巡检标准新增);
            this.panel巡检任务标准操作区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel巡检任务标准操作区.Font = new System.Drawing.Font("宋体", 11F);
            this.panel巡检任务标准操作区.Location = new System.Drawing.Point(0, 0);
            this.panel巡检任务标准操作区.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel巡检任务标准操作区.Name = "panel巡检任务标准操作区";
            this.panel巡检任务标准操作区.Size = new System.Drawing.Size(1317, 55);
            this.panel巡检任务标准操作区.TabIndex = 1;
            // 
            // button巡检标注全部删除
            // 
            this.button巡检标注全部删除.Location = new System.Drawing.Point(259, 12);
            this.button巡检标注全部删除.Name = "button巡检标注全部删除";
            this.button巡检标注全部删除.Size = new System.Drawing.Size(107, 33);
            this.button巡检标注全部删除.TabIndex = 2;
            this.button巡检标注全部删除.Text = "全部删除";
            this.button巡检标注全部删除.UseVisualStyleBackColor = true;
            this.button巡检标注全部删除.Click += new System.EventHandler(this.DeleteAll);
            // 
            // button巡检标准删除
            // 
            this.button巡检标准删除.Location = new System.Drawing.Point(134, 12);
            this.button巡检标准删除.Name = "button巡检标准删除";
            this.button巡检标准删除.Size = new System.Drawing.Size(107, 33);
            this.button巡检标准删除.TabIndex = 1;
            this.button巡检标准删除.Text = "删除";
            this.button巡检标准删除.UseVisualStyleBackColor = true;
            this.button巡检标准删除.Click += new System.EventHandler(this.DeleteSelectedRow);
            // 
            // button巡检标准新增
            // 
            this.button巡检标准新增.Location = new System.Drawing.Point(6, 12);
            this.button巡检标准新增.Name = "button巡检标准新增";
            this.button巡检标准新增.Size = new System.Drawing.Size(107, 33);
            this.button巡检标准新增.TabIndex = 0;
            this.button巡检标准新增.Text = "新增";
            this.button巡检标准新增.UseVisualStyleBackColor = true;
            this.button巡检标准新增.Click += new System.EventHandler(this.AddNewRow);
            // 
            // panel巡检任务标准数据区
            // 
            this.panel巡检任务标准数据区.AutoSize = true;
            this.panel巡检任务标准数据区.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel巡检任务标准数据区.Controls.Add(this.dataGridView巡检任务标准数据);
            this.panel巡检任务标准数据区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel巡检任务标准数据区.Location = new System.Drawing.Point(0, 55);
            this.panel巡检任务标准数据区.Name = "panel巡检任务标准数据区";
            this.panel巡检任务标准数据区.Size = new System.Drawing.Size(1317, 151);
            this.panel巡检任务标准数据区.TabIndex = 2;
            // 
            // dataGridView巡检任务标准数据
            // 
            this.dataGridView巡检任务标准数据.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView巡检任务标准数据.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView巡检任务标准数据.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView巡检任务标准数据.Location = new System.Drawing.Point(0, 0);
            this.dataGridView巡检任务标准数据.Name = "dataGridView巡检任务标准数据";
            this.dataGridView巡检任务标准数据.RowHeadersWidth = 51;
            this.dataGridView巡检任务标准数据.RowTemplate.Height = 27;
            this.dataGridView巡检任务标准数据.Size = new System.Drawing.Size(1317, 151);
            this.dataGridView巡检任务标准数据.TabIndex = 0;
            this.dataGridView巡检任务标准数据.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView巡检任务标准数据_CellClick);
            // 
            // uc巡检任务标准
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel巡检任务标准数据区);
            this.Controls.Add(this.panel巡检任务标准操作区);
            this.Name = "uc巡检任务标准";
            this.Size = new System.Drawing.Size(1317, 206);
            this.Load += new System.EventHandler(this.uc巡检任务标准_Load);
            this.panel巡检任务标准操作区.ResumeLayout(false);
            this.panel巡检任务标准数据区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView巡检任务标准数据)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel巡检任务标准操作区;
        private System.Windows.Forms.Button button巡检标注全部删除;
        private System.Windows.Forms.Button button巡检标准删除;
        private System.Windows.Forms.Button button巡检标准新增;
        private System.Windows.Forms.Panel panel巡检任务标准数据区;
        private System.Windows.Forms.DataGridView dataGridView巡检任务标准数据;
    }
}
