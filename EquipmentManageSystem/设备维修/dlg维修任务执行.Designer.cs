
namespace EquipmentManageSystem.设备维修
{
    partial class dlg维修任务执行
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel内容区 = new System.Windows.Forms.Panel();
            this.button取消 = new System.Windows.Forms.Button();
            this.button确认 = new System.Windows.Forms.Button();
            this.panel操作区 = new System.Windows.Forms.Panel();
            this.uc维修任务执行 = new EquipmentManageSystem.设备维修.uc维修任务执行();
            this.uc维修工单基本信息 = new EquipmentManageSystem.设备维修.uc维修工单基本信息();
            this.panel内容区.SuspendLayout();
            this.panel操作区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel内容区
            // 
            this.panel内容区.AutoScroll = true;
            this.panel内容区.AutoSize = true;
            this.panel内容区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel内容区.Controls.Add(this.uc维修任务执行);
            this.panel内容区.Controls.Add(this.uc维修工单基本信息);
            this.panel内容区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel内容区.Location = new System.Drawing.Point(0, 0);
            this.panel内容区.MaximumSize = new System.Drawing.Size(1312, 734);
            this.panel内容区.MinimumSize = new System.Drawing.Size(1306, 467);
            this.panel内容区.Name = "panel内容区";
            this.panel内容区.Size = new System.Drawing.Size(1312, 688);
            this.panel内容区.TabIndex = 0;
            // 
            // button取消
            // 
            this.button取消.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button取消.BackColor = System.Drawing.SystemColors.Control;
            this.button取消.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button取消.Font = new System.Drawing.Font("宋体", 11F);
            this.button取消.ForeColor = System.Drawing.Color.Black;
            this.button取消.Location = new System.Drawing.Point(707, 12);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(143, 40);
            this.button取消.TabIndex = 2;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = false;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // button确认
            // 
            this.button确认.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button确认.BackColor = System.Drawing.Color.DodgerBlue;
            this.button确认.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button确认.Font = new System.Drawing.Font("宋体", 11F);
            this.button确认.ForeColor = System.Drawing.Color.White;
            this.button确认.Location = new System.Drawing.Point(526, 12);
            this.button确认.Name = "button确认";
            this.button确认.Size = new System.Drawing.Size(143, 40);
            this.button确认.TabIndex = 1;
            this.button确认.Text = "确认";
            this.button确认.UseVisualStyleBackColor = false;
            this.button确认.Click += new System.EventHandler(this.button确认_Click);
            // 
            // panel操作区
            // 
            this.panel操作区.Controls.Add(this.button确认);
            this.panel操作区.Controls.Add(this.button取消);
            this.panel操作区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel操作区.Location = new System.Drawing.Point(0, 688);
            this.panel操作区.Name = "panel操作区";
            this.panel操作区.Size = new System.Drawing.Size(1312, 62);
            this.panel操作区.TabIndex = 3;
            // 
            // uc维修任务执行
            // 
            this.uc维修任务执行.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc维修任务执行.AutoSize = true;
            this.uc维修任务执行.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uc维修任务执行.Location = new System.Drawing.Point(0, 465);
            this.uc维修任务执行.Name = "uc维修任务执行";
            this.uc维修任务执行.Size = new System.Drawing.Size(1283, 220);
            this.uc维修任务执行.TabIndex = 1;
            // 
            // uc维修工单基本信息
            // 
            this.uc维修工单基本信息.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc维修工单基本信息.Location = new System.Drawing.Point(0, 0);
            this.uc维修工单基本信息.Name = "uc维修工单基本信息";
            this.uc维修工单基本信息.Size = new System.Drawing.Size(1302, 465);
            this.uc维修工单基本信息.TabIndex = 0;
            // 
            // dlg维修任务执行
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1312, 754);
            this.Controls.Add(this.panel操作区);
            this.Controls.Add(this.panel内容区);
            this.MinimumSize = new System.Drawing.Size(1330, 47);
            this.Name = "dlg维修任务执行";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "维修任务接取与提交";
            this.Load += new System.EventHandler(this.dlg维修任务接取与提交_Load);
            this.panel内容区.ResumeLayout(false);
            this.panel内容区.PerformLayout();
            this.panel操作区.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel内容区;
        private uc维修任务执行 uc维修任务执行;
        private uc维修工单基本信息 uc维修工单基本信息;
        private System.Windows.Forms.Button button取消;
        private System.Windows.Forms.Button button确认;
        private System.Windows.Forms.Panel panel操作区;
    }
}