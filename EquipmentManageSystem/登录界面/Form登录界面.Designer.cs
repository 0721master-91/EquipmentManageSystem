
namespace EquipmentManageSystem.登录界面
{
    partial class Form登录界面
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
            this.label1 = new System.Windows.Forms.Label();
            this.密码 = new System.Windows.Forms.Label();
            this.textBox用户名输入框 = new System.Windows.Forms.TextBox();
            this.textBox密码输入框 = new System.Windows.Forms.TextBox();
            this.button登录 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(45, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // 密码
            // 
            this.密码.AutoSize = true;
            this.密码.Font = new System.Drawing.Font("宋体", 14F);
            this.密码.Location = new System.Drawing.Point(69, 161);
            this.密码.Name = "密码";
            this.密码.Size = new System.Drawing.Size(82, 24);
            this.密码.TabIndex = 1;
            this.密码.Text = "密码：";
            // 
            // textBox用户名输入框
            // 
            this.textBox用户名输入框.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox用户名输入框.Location = new System.Drawing.Point(145, 98);
            this.textBox用户名输入框.Name = "textBox用户名输入框";
            this.textBox用户名输入框.Size = new System.Drawing.Size(183, 27);
            this.textBox用户名输入框.TabIndex = 2;
            // 
            // textBox密码输入框
            // 
            this.textBox密码输入框.Font = new System.Drawing.Font("宋体", 10F);
            this.textBox密码输入框.Location = new System.Drawing.Point(145, 160);
            this.textBox密码输入框.Name = "textBox密码输入框";
            this.textBox密码输入框.PasswordChar = '*';
            this.textBox密码输入框.Size = new System.Drawing.Size(183, 27);
            this.textBox密码输入框.TabIndex = 3;
            // 
            // button登录
            // 
            this.button登录.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button登录.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button登录.Font = new System.Drawing.Font("宋体", 11F);
            this.button登录.Location = new System.Drawing.Point(150, 245);
            this.button登录.Name = "button登录";
            this.button登录.Size = new System.Drawing.Size(85, 30);
            this.button登录.TabIndex = 4;
            this.button登录.Text = "登录";
            this.button登录.UseVisualStyleBackColor = true;
            this.button登录.Click += new System.EventHandler(this.button登录_Click);
            // 
            // Form登录界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 359);
            this.Controls.Add(this.button登录);
            this.Controls.Add(this.textBox密码输入框);
            this.Controls.Add(this.textBox用户名输入框);
            this.Controls.Add(this.密码);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form登录界面";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label 密码;
        private System.Windows.Forms.TextBox textBox用户名输入框;
        private System.Windows.Forms.TextBox textBox密码输入框;
        private System.Windows.Forms.Button button登录;
    }
}