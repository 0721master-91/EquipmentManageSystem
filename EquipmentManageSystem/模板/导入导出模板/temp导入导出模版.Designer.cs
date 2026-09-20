
namespace EquipmentManageSystem.模板.导入导出模板
{
    partial class temp导入导出模版
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
            this.panel容器 = new System.Windows.Forms.Panel();
            this.panel内容区 = new System.Windows.Forms.Panel();
            this.panel操作选择区 = new System.Windows.Forms.Panel();
            this.button导出 = new System.Windows.Forms.Button();
            this.button导入 = new System.Windows.Forms.Button();
            this.panel容器.SuspendLayout();
            this.panel操作选择区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel容器
            // 
            this.panel容器.AutoScroll = true;
            this.panel容器.Controls.Add(this.panel内容区);
            this.panel容器.Controls.Add(this.panel操作选择区);
            this.panel容器.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel容器.Location = new System.Drawing.Point(0, 0);
            this.panel容器.Name = "panel容器";
            this.panel容器.Size = new System.Drawing.Size(1135, 763);
            this.panel容器.TabIndex = 0;
            // 
            // panel内容区
            // 
            this.panel内容区.AutoScroll = true;
            this.panel内容区.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel内容区.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel内容区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel内容区.Location = new System.Drawing.Point(0, 49);
            this.panel内容区.Name = "panel内容区";
            this.panel内容区.Size = new System.Drawing.Size(1135, 714);
            this.panel内容区.TabIndex = 1;
            // 
            // panel操作选择区
            // 
            this.panel操作选择区.Controls.Add(this.button导出);
            this.panel操作选择区.Controls.Add(this.button导入);
            this.panel操作选择区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel操作选择区.Location = new System.Drawing.Point(0, 0);
            this.panel操作选择区.Name = "panel操作选择区";
            this.panel操作选择区.Size = new System.Drawing.Size(1135, 49);
            this.panel操作选择区.TabIndex = 0;
            // 
            // button导出
            // 
            this.button导出.Location = new System.Drawing.Point(636, 0);
            this.button导出.Name = "button导出";
            this.button导出.Size = new System.Drawing.Size(400, 48);
            this.button导出.TabIndex = 1;
            this.button导出.Text = "导出数据";
            this.button导出.UseVisualStyleBackColor = true;
            this.button导出.Visible = false;
            this.button导出.Click += new System.EventHandler(this.button导出_Click);
            // 
            // button导入
            // 
            this.button导入.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button导入.Location = new System.Drawing.Point(101, 0);
            this.button导入.Name = "button导入";
            this.button导入.Size = new System.Drawing.Size(400, 48);
            this.button导入.TabIndex = 0;
            this.button导入.Text = "导入数据";
            this.button导入.UseVisualStyleBackColor = true;
            this.button导入.Visible = false;
            this.button导入.Click += new System.EventHandler(this.button导入_Click);
            // 
            // temp导入导出模版
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 763);
            this.Controls.Add(this.panel容器);
            this.Name = "temp导入导出模版";
            this.Text = "temp导入导出模版";
            this.Load += new System.EventHandler(this.temp导入导出模版_Load);
            this.panel容器.ResumeLayout(false);
            this.panel操作选择区.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel容器;
        private System.Windows.Forms.Panel panel操作选择区;
        private System.Windows.Forms.Panel panel内容区;
        protected System.Windows.Forms.Button button导入;
        protected System.Windows.Forms.Button button导出;
    }
}