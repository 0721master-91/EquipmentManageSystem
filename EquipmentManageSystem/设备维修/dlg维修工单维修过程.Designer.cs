
namespace EquipmentManageSystem.设备维修
{
    partial class dlg维修工单维修过程
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
            this.uc维修工单基本信息 = new EquipmentManageSystem.设备维修.uc维修工单基本信息();
            this.uc维修工单维修记录 = new EquipmentManageSystem.设备维修.uc维修工单维修记录();
            this.SuspendLayout();
            // 
            // uc维修工单基本信息
            // 
            this.uc维修工单基本信息.Location = new System.Drawing.Point(6, 2);
            this.uc维修工单基本信息.Name = "uc维修工单基本信息";
            this.uc维修工单基本信息.Size = new System.Drawing.Size(1281, 465);
            this.uc维修工单基本信息.TabIndex = 0;
            // 
            // uc维修工单维修记录
            // 
            this.uc维修工单维修记录.AutoSize = true;
            this.uc维修工单维修记录.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uc维修工单维修记录.Location = new System.Drawing.Point(6, 463);
            this.uc维修工单维修记录.Name = "uc维修工单维修记录";
            this.uc维修工单维修记录.Size = new System.Drawing.Size(1281, 309);
            this.uc维修工单维修记录.TabIndex = 1;
            // 
            // dlg维修工单维修过程
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 769);
            this.Controls.Add(this.uc维修工单维修记录);
            this.Controls.Add(this.uc维修工单基本信息);
            this.MaximizeBox = false;
            this.Name = "dlg维修工单维修过程";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "维修过程";
            this.Load += new System.EventHandler(this.dlg维修工单维修过程_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private uc维修工单基本信息 uc维修工单基本信息;
        private uc维修工单维修记录 uc维修工单维修记录;
    }
}