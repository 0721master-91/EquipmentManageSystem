
namespace EquipmentManageSystem.数据报表
{
    partial class dlg导出
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
            this.groupBox导出选项 = new System.Windows.Forms.GroupBox();
            this.radioButton选项1 = new System.Windows.Forms.RadioButton();
            this.radioButton选项2 = new System.Windows.Forms.RadioButton();
            this.button确认 = new System.Windows.Forms.Button();
            this.button取消 = new System.Windows.Forms.Button();
            this.groupBox导出选项.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox导出选项
            // 
            this.groupBox导出选项.Controls.Add(this.radioButton选项2);
            this.groupBox导出选项.Controls.Add(this.radioButton选项1);
            this.groupBox导出选项.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox导出选项.Location = new System.Drawing.Point(3, 20);
            this.groupBox导出选项.Name = "groupBox导出选项";
            this.groupBox导出选项.Size = new System.Drawing.Size(358, 162);
            this.groupBox导出选项.TabIndex = 0;
            this.groupBox导出选项.TabStop = false;
            this.groupBox导出选项.Text = "导出选项";
            // 
            // radioButton选项1
            // 
            this.radioButton选项1.AutoSize = true;
            this.radioButton选项1.Location = new System.Drawing.Point(9, 38);
            this.radioButton选项1.Name = "radioButton选项1";
            this.radioButton选项1.Size = new System.Drawing.Size(258, 23);
            this.radioButton选项1.TabIndex = 0;
            this.radioButton选项1.TabStop = true;
            this.radioButton选项1.Text = "只导出有数据的组织和部门";
            this.radioButton选项1.UseVisualStyleBackColor = true;
            // 
            // radioButton选项2
            // 
            this.radioButton选项2.AutoSize = true;
            this.radioButton选项2.Location = new System.Drawing.Point(9, 86);
            this.radioButton选项2.Name = "radioButton选项2";
            this.radioButton选项2.Size = new System.Drawing.Size(334, 23);
            this.radioButton选项2.TabIndex = 1;
            this.radioButton选项2.TabStop = true;
            this.radioButton选项2.Text = "导出所有组织和部门（包括无数据）";
            this.radioButton选项2.UseVisualStyleBackColor = true;
            // 
            // button确认
            // 
            this.button确认.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button确认.BackColor = System.Drawing.SystemColors.Highlight;
            this.button确认.Font = new System.Drawing.Font("宋体", 11F);
            this.button确认.ForeColor = System.Drawing.Color.White;
            this.button确认.Location = new System.Drawing.Point(70, 239);
            this.button确认.Name = "button确认";
            this.button确认.Size = new System.Drawing.Size(75, 28);
            this.button确认.TabIndex = 1;
            this.button确认.Text = "确认";
            this.button确认.UseVisualStyleBackColor = false;
            this.button确认.Click += new System.EventHandler(this.button确认_Click);
            // 
            // button取消
            // 
            this.button取消.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button取消.BackColor = System.Drawing.SystemColors.Control;
            this.button取消.Font = new System.Drawing.Font("宋体", 11F);
            this.button取消.ForeColor = System.Drawing.Color.Black;
            this.button取消.Location = new System.Drawing.Point(195, 239);
            this.button取消.Name = "button取消";
            this.button取消.Size = new System.Drawing.Size(75, 28);
            this.button取消.TabIndex = 2;
            this.button取消.Text = "取消";
            this.button取消.UseVisualStyleBackColor = false;
            this.button取消.Click += new System.EventHandler(this.button取消_Click);
            // 
            // dlg导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 284);
            this.Controls.Add(this.button取消);
            this.Controls.Add(this.button确认);
            this.Controls.Add(this.groupBox导出选项);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlg导出";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据导出";
            this.Load += new System.EventHandler(this.dlg导出_Load);
            this.groupBox导出选项.ResumeLayout(false);
            this.groupBox导出选项.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox导出选项;
        private System.Windows.Forms.RadioButton radioButton选项2;
        private System.Windows.Forms.RadioButton radioButton选项1;
        private System.Windows.Forms.Button button确认;
        private System.Windows.Forms.Button button取消;
    }
}