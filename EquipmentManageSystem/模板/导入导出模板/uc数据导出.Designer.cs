
namespace EquipmentManageSystem.模板.导入导出模板
{
    partial class uc数据导出
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.panel字段选择区 = new System.Windows.Forms.Panel();
            this.button导出 = new System.Windows.Forms.Button();
            this.panel字段选择内容区 = new System.Windows.Forms.Panel();
            this.panel导出字段排序区 = new System.Windows.Forms.Panel();
            this.panel导出字段区 = new System.Windows.Forms.Panel();
            this.dataGridView导出字段 = new System.Windows.Forms.DataGridView();
            this.panel字段选择操作区 = new System.Windows.Forms.Panel();
            this.panel原字段选择区 = new System.Windows.Forms.Panel();
            this.dataGridView可选字段 = new System.Windows.Forms.DataGridView();
            this.panel字段选择标题区 = new System.Windows.Forms.Panel();
            this.label选择字段 = new System.Windows.Forms.Label();
            this.panel字段选择区.SuspendLayout();
            this.panel字段选择内容区.SuspendLayout();
            this.panel导出字段区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView导出字段)).BeginInit();
            this.panel原字段选择区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView可选字段)).BeginInit();
            this.panel字段选择标题区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel字段选择区
            // 
            this.panel字段选择区.Controls.Add(this.button导出);
            this.panel字段选择区.Controls.Add(this.panel字段选择内容区);
            this.panel字段选择区.Controls.Add(this.panel字段选择标题区);
            this.panel字段选择区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel字段选择区.Location = new System.Drawing.Point(0, 0);
            this.panel字段选择区.Name = "panel字段选择区";
            this.panel字段选择区.Size = new System.Drawing.Size(1153, 551);
            this.panel字段选择区.TabIndex = 0;
            // 
            // button导出
            // 
            this.button导出.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button导出.Location = new System.Drawing.Point(915, 508);
            this.button导出.Name = "button导出";
            this.button导出.Size = new System.Drawing.Size(112, 40);
            this.button导出.TabIndex = 2;
            this.button导出.Text = "导出";
            this.button导出.UseVisualStyleBackColor = false;
            this.button导出.Click += new System.EventHandler(this.button导出_Click);
            // 
            // panel字段选择内容区
            // 
            this.panel字段选择内容区.Controls.Add(this.panel导出字段排序区);
            this.panel字段选择内容区.Controls.Add(this.panel导出字段区);
            this.panel字段选择内容区.Controls.Add(this.panel字段选择操作区);
            this.panel字段选择内容区.Controls.Add(this.panel原字段选择区);
            this.panel字段选择内容区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel字段选择内容区.Location = new System.Drawing.Point(0, 66);
            this.panel字段选择内容区.Name = "panel字段选择内容区";
            this.panel字段选择内容区.Size = new System.Drawing.Size(1153, 436);
            this.panel字段选择内容区.TabIndex = 1;
            // 
            // panel导出字段排序区
            // 
            this.panel导出字段排序区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel导出字段排序区.Location = new System.Drawing.Point(1027, 0);
            this.panel导出字段排序区.Name = "panel导出字段排序区";
            this.panel导出字段排序区.Size = new System.Drawing.Size(126, 436);
            this.panel导出字段排序区.TabIndex = 3;
            // 
            // panel导出字段区
            // 
            this.panel导出字段区.Controls.Add(this.dataGridView导出字段);
            this.panel导出字段区.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel导出字段区.Location = new System.Drawing.Point(563, 0);
            this.panel导出字段区.Name = "panel导出字段区";
            this.panel导出字段区.Size = new System.Drawing.Size(464, 436);
            this.panel导出字段区.TabIndex = 2;
            // 
            // dataGridView导出字段
            // 
            this.dataGridView导出字段.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView导出字段.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView导出字段.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView导出字段.Location = new System.Drawing.Point(0, 0);
            this.dataGridView导出字段.Name = "dataGridView导出字段";
            this.dataGridView导出字段.RowHeadersWidth = 51;
            this.dataGridView导出字段.RowTemplate.Height = 27;
            this.dataGridView导出字段.Size = new System.Drawing.Size(464, 436);
            this.dataGridView导出字段.TabIndex = 1;
            this.dataGridView导出字段.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView导出字段_CellDoubleClick);
            this.dataGridView导出字段.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView导出字段_KeyDown);
            // 
            // panel字段选择操作区
            // 
            this.panel字段选择操作区.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel字段选择操作区.Location = new System.Drawing.Point(445, 0);
            this.panel字段选择操作区.Name = "panel字段选择操作区";
            this.panel字段选择操作区.Size = new System.Drawing.Size(118, 436);
            this.panel字段选择操作区.TabIndex = 1;
            // 
            // panel原字段选择区
            // 
            this.panel原字段选择区.Controls.Add(this.dataGridView可选字段);
            this.panel原字段选择区.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel原字段选择区.Location = new System.Drawing.Point(0, 0);
            this.panel原字段选择区.Name = "panel原字段选择区";
            this.panel原字段选择区.Size = new System.Drawing.Size(445, 436);
            this.panel原字段选择区.TabIndex = 0;
            // 
            // dataGridView可选字段
            // 
            this.dataGridView可选字段.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView可选字段.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView可选字段.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView可选字段.Location = new System.Drawing.Point(0, 0);
            this.dataGridView可选字段.Name = "dataGridView可选字段";
            this.dataGridView可选字段.RowHeadersWidth = 51;
            this.dataGridView可选字段.RowTemplate.Height = 27;
            this.dataGridView可选字段.Size = new System.Drawing.Size(445, 436);
            this.dataGridView可选字段.TabIndex = 0;
            this.dataGridView可选字段.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView可选字段_CellDoubleClick);
            // 
            // panel字段选择标题区
            // 
            this.panel字段选择标题区.Controls.Add(this.label选择字段);
            this.panel字段选择标题区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel字段选择标题区.Location = new System.Drawing.Point(0, 0);
            this.panel字段选择标题区.Name = "panel字段选择标题区";
            this.panel字段选择标题区.Size = new System.Drawing.Size(1153, 66);
            this.panel字段选择标题区.TabIndex = 0;
            // 
            // label选择字段
            // 
            this.label选择字段.AutoSize = true;
            this.label选择字段.Font = new System.Drawing.Font("宋体", 18F);
            this.label选择字段.Location = new System.Drawing.Point(3, 16);
            this.label选择字段.Name = "label选择字段";
            this.label选择字段.Size = new System.Drawing.Size(193, 30);
            this.label选择字段.TabIndex = 1;
            this.label选择字段.Text = "选择导出字段";
            // 
            // UserControl数据导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel字段选择区);
            this.Name = "UserControl数据导出";
            this.Size = new System.Drawing.Size(1153, 800);
            this.Load += new System.EventHandler(this.UserControl数据导出_Load);
            this.panel字段选择区.ResumeLayout(false);
            this.panel字段选择内容区.ResumeLayout(false);
            this.panel导出字段区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView导出字段)).EndInit();
            this.panel原字段选择区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView可选字段)).EndInit();
            this.panel字段选择标题区.ResumeLayout(false);
            this.panel字段选择标题区.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel字段选择区;
        private System.Windows.Forms.Panel panel字段选择标题区;
        private System.Windows.Forms.Label label选择字段;
        private System.Windows.Forms.Panel panel字段选择内容区;
        private System.Windows.Forms.Panel panel导出字段排序区;
        private System.Windows.Forms.Panel panel导出字段区;
        private System.Windows.Forms.Panel panel字段选择操作区;
        private System.Windows.Forms.Panel panel原字段选择区;
        private System.Windows.Forms.DataGridView dataGridView导出字段;
        private System.Windows.Forms.DataGridView dataGridView可选字段;
        private System.Windows.Forms.Button button导出;
    }
}
