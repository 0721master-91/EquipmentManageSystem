
namespace EquipmentManageSystem.模板.选择窗口模版
{
    partial class temp选择窗口
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the Code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel主区域 = new System.Windows.Forms.Panel();
            this.panel操作区 = new System.Windows.Forms.Panel();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确认 = new System.Windows.Forms.Button();
            this.panel数据区 = new System.Windows.Forms.Panel();
            this.dataGridView数据表 = new System.Windows.Forms.DataGridView();
            this.panel条件筛选区 = new System.Windows.Forms.Panel();
            this.button重置条件 = new System.Windows.Forms.Button();
            this.textBox二级筛选 = new System.Windows.Forms.TextBox();
            this.label二级筛选 = new System.Windows.Forms.Label();
            this.textBox一级筛选 = new System.Windows.Forms.TextBox();
            this.label一级筛选 = new System.Windows.Forms.Label();
            this.panel主区域.SuspendLayout();
            this.panel操作区.SuspendLayout();
            this.panel数据区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView数据表)).BeginInit();
            this.panel条件筛选区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel主区域
            // 
            this.panel主区域.Controls.Add(this.panel操作区);
            this.panel主区域.Controls.Add(this.panel数据区);
            this.panel主区域.Controls.Add(this.panel条件筛选区);
            this.panel主区域.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel主区域.Location = new System.Drawing.Point(0, 0);
            this.panel主区域.Name = "panel主区域";
            this.panel主区域.Size = new System.Drawing.Size(1004, 522);
            this.panel主区域.TabIndex = 0;
            // 
            // panel操作区
            // 
            this.panel操作区.Controls.Add(this.button取消);
            this.panel操作区.Controls.Add(this.button确认);
            this.panel操作区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel操作区.Location = new System.Drawing.Point(0, 455);
            this.panel操作区.Name = "panel操作区";
            this.panel操作区.Size = new System.Drawing.Size(1004, 67);
            this.panel操作区.TabIndex = 2;
            // 
            // button取消
            // 
            this.button取消.Font = new System.Drawing.Font("宋体", 11F);
            this.button取消.Location = new System.Drawing.Point(513, 20);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(88, 32);
            this.button取消.TabIndex = 1;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = true;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // button确认
            // 
            this.button确认.Font = new System.Drawing.Font("宋体", 11F);
            this.button确认.Location = new System.Drawing.Point(362, 20);
            this.button确认.Name = "button确认";
            this.button确认.Size = new System.Drawing.Size(88, 32);
            this.button确认.TabIndex = 0;
            this.button确认.Text = "确认";
            this.button确认.UseVisualStyleBackColor = true;
            this.button确认.Click += new System.EventHandler(this.button确认_Click);
            // 
            // panel数据区
            // 
            this.panel数据区.Controls.Add(this.dataGridView数据表);
            this.panel数据区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel数据区.Location = new System.Drawing.Point(0, 73);
            this.panel数据区.Name = "panel数据区";
            this.panel数据区.Size = new System.Drawing.Size(1004, 382);
            this.panel数据区.TabIndex = 1;
            // 
            // dataGridView数据表
            // 
            this.dataGridView数据表.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView数据表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView数据表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView数据表.Location = new System.Drawing.Point(0, 0);
            this.dataGridView数据表.Name = "dataGridView数据表";
            this.dataGridView数据表.ReadOnly = true;
            this.dataGridView数据表.RowHeadersWidth = 51;
            this.dataGridView数据表.RowTemplate.Height = 27;
            this.dataGridView数据表.Size = new System.Drawing.Size(1004, 382);
            this.dataGridView数据表.TabIndex = 0;
            // 
            // panel条件筛选区
            // 
            this.panel条件筛选区.BackColor = System.Drawing.SystemColors.Control;
            this.panel条件筛选区.Controls.Add(this.button重置条件);
            this.panel条件筛选区.Controls.Add(this.textBox二级筛选);
            this.panel条件筛选区.Controls.Add(this.label二级筛选);
            this.panel条件筛选区.Controls.Add(this.textBox一级筛选);
            this.panel条件筛选区.Controls.Add(this.label一级筛选);
            this.panel条件筛选区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel条件筛选区.Location = new System.Drawing.Point(0, 0);
            this.panel条件筛选区.Name = "panel条件筛选区";
            this.panel条件筛选区.Size = new System.Drawing.Size(1004, 73);
            this.panel条件筛选区.TabIndex = 0;
            // 
            // button重置条件
            // 
            this.button重置条件.BackColor = System.Drawing.Color.Silver;
            this.button重置条件.Font = new System.Drawing.Font("宋体", 11F);
            this.button重置条件.Location = new System.Drawing.Point(719, 18);
            this.button重置条件.Name = "button重置条件";
            this.button重置条件.Size = new System.Drawing.Size(86, 29);
            this.button重置条件.TabIndex = 4;
            this.button重置条件.Text = "重置";
            this.button重置条件.UseVisualStyleBackColor = false;
            this.button重置条件.Click += new System.EventHandler(this.button重置条件_Click);
            // 
            // textBox二级筛选
            // 
            this.textBox二级筛选.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox二级筛选.Location = new System.Drawing.Point(452, 18);
            this.textBox二级筛选.Name = "textBox二级筛选";
            this.textBox二级筛选.Size = new System.Drawing.Size(201, 28);
            this.textBox二级筛选.TabIndex = 3;
            this.textBox二级筛选.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label二级筛选
            // 
            this.label二级筛选.AutoSize = true;
            this.label二级筛选.Font = new System.Drawing.Font("宋体", 11F);
            this.label二级筛选.Location = new System.Drawing.Point(358, 23);
            this.label二级筛选.Name = "label二级筛选";
            this.label二级筛选.Size = new System.Drawing.Size(104, 19);
            this.label二级筛选.TabIndex = 2;
            this.label二级筛选.Text = "二级筛选：";
            // 
            // textBox一级筛选
            // 
            this.textBox一级筛选.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox一级筛选.Location = new System.Drawing.Point(107, 18);
            this.textBox一级筛选.Name = "textBox一级筛选";
            this.textBox一级筛选.Size = new System.Drawing.Size(201, 28);
            this.textBox一级筛选.TabIndex = 1;
            this.textBox一级筛选.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label一级筛选
            // 
            this.label一级筛选.AutoSize = true;
            this.label一级筛选.Font = new System.Drawing.Font("宋体", 11F);
            this.label一级筛选.Location = new System.Drawing.Point(13, 23);
            this.label一级筛选.Name = "label一级筛选";
            this.label一级筛选.Size = new System.Drawing.Size(104, 19);
            this.label一级筛选.TabIndex = 0;
            this.label一级筛选.Text = "一级筛选：";
            // 
            // temp选择窗口
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 522);
            this.Controls.Add(this.panel主区域);
            this.Name = "temp选择窗口";
            this.Text = "temp选择窗口";
            this.Load += new System.EventHandler(this.temp选择窗口_Load);
            this.panel主区域.ResumeLayout(false);
            this.panel操作区.ResumeLayout(false);
            this.panel数据区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView数据表)).EndInit();
            this.panel条件筛选区.ResumeLayout(false);
            this.panel条件筛选区.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel主区域;
        protected System.Windows.Forms.Label label一级筛选;
        protected System.Windows.Forms.TextBox textBox二级筛选;
        protected System.Windows.Forms.Label label二级筛选;
        protected System.Windows.Forms.TextBox textBox一级筛选;
        protected System.Windows.Forms.Button button重置条件;
        protected System.Windows.Forms.DataGridView dataGridView数据表;
        protected System.Windows.Forms.Panel panel数据区;
        protected System.Windows.Forms.Panel panel条件筛选区;
        protected System.Windows.Forms.Panel panel操作区;
        protected System.Windows.Forms.Button button确认;
        protected System.Windows.Forms.Button button取消;
    }
}