
namespace EquipmentManageSystem.主界面
{
    partial class MainForm
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
            this.panel菜单栏区 = new System.Windows.Forms.Panel();
            this.panel菜单选项区 = new System.Windows.Forms.Panel();
            this.panel标准管理菜单区 = new System.Windows.Forms.Panel();
            this.panel标准管理二级菜单区 = new System.Windows.Forms.Panel();
            this.button标准管理_保养标准 = new System.Windows.Forms.Button();
            this.button标准管理_巡检标准 = new System.Windows.Forms.Button();
            this.button标准管理 = new System.Windows.Forms.Button();
            this.panel设备管理菜单区 = new System.Windows.Forms.Panel();
            this.panel设备管理二级菜单区 = new System.Windows.Forms.Panel();
            this.button设备管理_功能位置档案 = new System.Windows.Forms.Button();
            this.button设备管理_功能主设备档案 = new System.Windows.Forms.Button();
            this.button设备管理 = new System.Windows.Forms.Button();
            this.panel菜单Logo区 = new System.Windows.Forms.Panel();
            this.panel内容显示区 = new System.Windows.Forms.Panel();
            this.panel菜单栏区.SuspendLayout();
            this.panel菜单选项区.SuspendLayout();
            this.panel标准管理菜单区.SuspendLayout();
            this.panel标准管理二级菜单区.SuspendLayout();
            this.panel设备管理菜单区.SuspendLayout();
            this.panel设备管理二级菜单区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel菜单栏区
            // 
            this.panel菜单栏区.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(254)))));
            this.panel菜单栏区.Controls.Add(this.panel菜单选项区);
            this.panel菜单栏区.Controls.Add(this.panel菜单Logo区);
            this.panel菜单栏区.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel菜单栏区.Location = new System.Drawing.Point(0, 0);
            this.panel菜单栏区.Name = "panel菜单栏区";
            this.panel菜单栏区.Size = new System.Drawing.Size(200, 791);
            this.panel菜单栏区.TabIndex = 0;
            // 
            // panel菜单选项区
            // 
            this.panel菜单选项区.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel菜单选项区.Controls.Add(this.panel标准管理菜单区);
            this.panel菜单选项区.Controls.Add(this.panel设备管理菜单区);
            this.panel菜单选项区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel菜单选项区.Location = new System.Drawing.Point(0, 189);
            this.panel菜单选项区.Name = "panel菜单选项区";
            this.panel菜单选项区.Size = new System.Drawing.Size(200, 602);
            this.panel菜单选项区.TabIndex = 1;
            // 
            // panel标准管理菜单区
            // 
            this.panel标准管理菜单区.AutoSize = true;
            this.panel标准管理菜单区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel标准管理菜单区.BackColor = System.Drawing.Color.Silver;
            this.panel标准管理菜单区.Controls.Add(this.panel标准管理二级菜单区);
            this.panel标准管理菜单区.Controls.Add(this.button标准管理);
            this.panel标准管理菜单区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel标准管理菜单区.Location = new System.Drawing.Point(0, 112);
            this.panel标准管理菜单区.Name = "panel标准管理菜单区";
            this.panel标准管理菜单区.Size = new System.Drawing.Size(200, 112);
            this.panel标准管理菜单区.TabIndex = 1;
            // 
            // panel标准管理二级菜单区
            // 
            this.panel标准管理二级菜单区.AutoSize = true;
            this.panel标准管理二级菜单区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel标准管理二级菜单区.BackColor = System.Drawing.Color.White;
            this.panel标准管理二级菜单区.Controls.Add(this.button标准管理_保养标准);
            this.panel标准管理二级菜单区.Controls.Add(this.button标准管理_巡检标准);
            this.panel标准管理二级菜单区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel标准管理二级菜单区.Location = new System.Drawing.Point(0, 38);
            this.panel标准管理二级菜单区.Name = "panel标准管理二级菜单区";
            this.panel标准管理二级菜单区.Size = new System.Drawing.Size(200, 74);
            this.panel标准管理二级菜单区.TabIndex = 2;
            this.panel标准管理二级菜单区.Visible = false;
            // 
            // button标准管理_保养标准
            // 
            this.button标准管理_保养标准.Dock = System.Windows.Forms.DockStyle.Top;
            this.button标准管理_保养标准.Location = new System.Drawing.Point(0, 37);
            this.button标准管理_保养标准.Name = "button标准管理_保养标准";
            this.button标准管理_保养标准.Size = new System.Drawing.Size(200, 37);
            this.button标准管理_保养标准.TabIndex = 1;
            this.button标准管理_保养标准.Text = "保养标准";
            this.button标准管理_保养标准.UseVisualStyleBackColor = true;
            this.button标准管理_保养标准.Click += new System.EventHandler(this.selectSubButton);
            // 
            // button标准管理_巡检标准
            // 
            this.button标准管理_巡检标准.Dock = System.Windows.Forms.DockStyle.Top;
            this.button标准管理_巡检标准.Location = new System.Drawing.Point(0, 0);
            this.button标准管理_巡检标准.Name = "button标准管理_巡检标准";
            this.button标准管理_巡检标准.Size = new System.Drawing.Size(200, 37);
            this.button标准管理_巡检标准.TabIndex = 0;
            this.button标准管理_巡检标准.Text = "巡检标准";
            this.button标准管理_巡检标准.UseVisualStyleBackColor = true;
            this.button标准管理_巡检标准.Click += new System.EventHandler(this.selectSubButton);
            // 
            // button标准管理
            // 
            this.button标准管理.BackColor = System.Drawing.Color.DodgerBlue;
            this.button标准管理.Dock = System.Windows.Forms.DockStyle.Top;
            this.button标准管理.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button标准管理.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button标准管理.ForeColor = System.Drawing.Color.White;
            this.button标准管理.Location = new System.Drawing.Point(0, 0);
            this.button标准管理.Name = "button标准管理";
            this.button标准管理.Size = new System.Drawing.Size(200, 38);
            this.button标准管理.TabIndex = 1;
            this.button标准管理.Text = "标准管理";
            this.button标准管理.UseVisualStyleBackColor = false;
            this.button标准管理.Click += new System.EventHandler(this.changeSubMenuShow);
            // 
            // panel设备管理菜单区
            // 
            this.panel设备管理菜单区.AutoSize = true;
            this.panel设备管理菜单区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel设备管理菜单区.BackColor = System.Drawing.Color.Gainsboro;
            this.panel设备管理菜单区.Controls.Add(this.panel设备管理二级菜单区);
            this.panel设备管理菜单区.Controls.Add(this.button设备管理);
            this.panel设备管理菜单区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel设备管理菜单区.Location = new System.Drawing.Point(0, 0);
            this.panel设备管理菜单区.Name = "panel设备管理菜单区";
            this.panel设备管理菜单区.Size = new System.Drawing.Size(200, 112);
            this.panel设备管理菜单区.TabIndex = 0;
            // 
            // panel设备管理二级菜单区
            // 
            this.panel设备管理二级菜单区.AutoSize = true;
            this.panel设备管理二级菜单区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel设备管理二级菜单区.Controls.Add(this.button设备管理_功能位置档案);
            this.panel设备管理二级菜单区.Controls.Add(this.button设备管理_功能主设备档案);
            this.panel设备管理二级菜单区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel设备管理二级菜单区.Location = new System.Drawing.Point(0, 38);
            this.panel设备管理二级菜单区.Name = "panel设备管理二级菜单区";
            this.panel设备管理二级菜单区.Size = new System.Drawing.Size(200, 74);
            this.panel设备管理二级菜单区.TabIndex = 1;
            this.panel设备管理二级菜单区.Visible = false;
            // 
            // button设备管理_功能位置档案
            // 
            this.button设备管理_功能位置档案.Dock = System.Windows.Forms.DockStyle.Top;
            this.button设备管理_功能位置档案.Location = new System.Drawing.Point(0, 37);
            this.button设备管理_功能位置档案.Margin = new System.Windows.Forms.Padding(0);
            this.button设备管理_功能位置档案.Name = "button设备管理_功能位置档案";
            this.button设备管理_功能位置档案.Size = new System.Drawing.Size(200, 37);
            this.button设备管理_功能位置档案.TabIndex = 1;
            this.button设备管理_功能位置档案.Text = "功能位置档案";
            this.button设备管理_功能位置档案.UseVisualStyleBackColor = true;
            this.button设备管理_功能位置档案.Click += new System.EventHandler(this.selectSubButton);
            // 
            // button设备管理_功能主设备档案
            // 
            this.button设备管理_功能主设备档案.Dock = System.Windows.Forms.DockStyle.Top;
            this.button设备管理_功能主设备档案.Location = new System.Drawing.Point(0, 0);
            this.button设备管理_功能主设备档案.Margin = new System.Windows.Forms.Padding(0);
            this.button设备管理_功能主设备档案.Name = "button设备管理_功能主设备档案";
            this.button设备管理_功能主设备档案.Size = new System.Drawing.Size(200, 37);
            this.button设备管理_功能主设备档案.TabIndex = 0;
            this.button设备管理_功能主设备档案.Text = "功能主设备档案";
            this.button设备管理_功能主设备档案.UseVisualStyleBackColor = true;
            this.button设备管理_功能主设备档案.Click += new System.EventHandler(this.selectSubButton);
            // 
            // button设备管理
            // 
            this.button设备管理.BackColor = System.Drawing.Color.DodgerBlue;
            this.button设备管理.Dock = System.Windows.Forms.DockStyle.Top;
            this.button设备管理.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button设备管理.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button设备管理.ForeColor = System.Drawing.Color.White;
            this.button设备管理.Location = new System.Drawing.Point(0, 0);
            this.button设备管理.Name = "button设备管理";
            this.button设备管理.Size = new System.Drawing.Size(200, 38);
            this.button设备管理.TabIndex = 0;
            this.button设备管理.Text = "设备管理";
            this.button设备管理.UseVisualStyleBackColor = false;
            this.button设备管理.Click += new System.EventHandler(this.changeSubMenuShow);
            // 
            // panel菜单Logo区
            // 
            this.panel菜单Logo区.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel菜单Logo区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel菜单Logo区.Location = new System.Drawing.Point(0, 0);
            this.panel菜单Logo区.Name = "panel菜单Logo区";
            this.panel菜单Logo区.Size = new System.Drawing.Size(200, 189);
            this.panel菜单Logo区.TabIndex = 0;
            // 
            // panel内容显示区
            // 
            this.panel内容显示区.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(200)))));
            this.panel内容显示区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel内容显示区.Location = new System.Drawing.Point(200, 0);
            this.panel内容显示区.Name = "panel内容显示区";
            this.panel内容显示区.Size = new System.Drawing.Size(1605, 791);
            this.panel内容显示区.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1805, 791);
            this.Controls.Add(this.panel内容显示区);
            this.Controls.Add(this.panel菜单栏区);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "设备管理系统-主页面";
            this.Load += new System.EventHandler(this.Form主界面_Load);
            this.panel菜单栏区.ResumeLayout(false);
            this.panel菜单选项区.ResumeLayout(false);
            this.panel菜单选项区.PerformLayout();
            this.panel标准管理菜单区.ResumeLayout(false);
            this.panel标准管理菜单区.PerformLayout();
            this.panel标准管理二级菜单区.ResumeLayout(false);
            this.panel设备管理菜单区.ResumeLayout(false);
            this.panel设备管理菜单区.PerformLayout();
            this.panel设备管理二级菜单区.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel菜单栏区;
        private System.Windows.Forms.Panel panel菜单Logo区;
        private System.Windows.Forms.Panel panel菜单选项区;
        private System.Windows.Forms.Panel panel内容显示区;
        private System.Windows.Forms.Panel panel设备管理菜单区;
        private System.Windows.Forms.Button button设备管理;
        private System.Windows.Forms.Panel panel设备管理二级菜单区;
        private System.Windows.Forms.Button button设备管理_功能位置档案;
        private System.Windows.Forms.Button button设备管理_功能主设备档案;
        private System.Windows.Forms.Panel panel标准管理菜单区;
        private System.Windows.Forms.Button button标准管理;
        private System.Windows.Forms.Panel panel标准管理二级菜单区;
        private System.Windows.Forms.Button button标准管理_保养标准;
        private System.Windows.Forms.Button button标准管理_巡检标准;
    }
}