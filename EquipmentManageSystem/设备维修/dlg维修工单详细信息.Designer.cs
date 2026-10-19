
namespace EquipmentManageSystem.设备维修
{
    partial class dlg维修工单详细信息
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
            this.uc维修工单维修信息 = new EquipmentManageSystem.设备维修.uc维修工单维修信息();
            this.uc维修工单基本信息 = new EquipmentManageSystem.设备维修.uc维修工单基本信息();
            this.panel内容区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel内容区
            // 
            this.panel内容区.AutoScroll = true;
            this.panel内容区.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel内容区.Controls.Add(this.uc维修工单维修信息);
            this.panel内容区.Controls.Add(this.uc维修工单基本信息);
            this.panel内容区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel内容区.Location = new System.Drawing.Point(0, 0);
            this.panel内容区.Name = "panel内容区";
            this.panel内容区.Size = new System.Drawing.Size(1305, 869);
            this.panel内容区.TabIndex = 0;
            // 
            // uc维修工单维修信息
            // 
            this.uc维修工单维修信息.AutoSize = true;
            this.uc维修工单维修信息.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uc维修工单维修信息.Location = new System.Drawing.Point(3, 464);
            this.uc维修工单维修信息.MinimumSize = new System.Drawing.Size(1281, 0);
            this.uc维修工单维修信息.Name = "uc维修工单维修信息";
            this.uc维修工单维修信息.Size = new System.Drawing.Size(1281, 399);
            this.uc维修工单维修信息.TabIndex = 1;
            // 
            // uc维修工单基本信息
            // 
            this.uc维修工单基本信息.Location = new System.Drawing.Point(3, 3);
            this.uc维修工单基本信息.Name = "uc维修工单基本信息";
            this.uc维修工单基本信息.Size = new System.Drawing.Size(1281, 465);
            this.uc维修工单基本信息.TabIndex = 0;
            // 
            // dlg维修工单详细信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1305, 866);
            this.Controls.Add(this.panel内容区);
            this.MinimumSize = new System.Drawing.Size(1323, 913);
            this.Name = "dlg维修工单详细信息";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "维修工单详细信息";
            this.Load += new System.EventHandler(this.dlg维修工单详细信息_Load);
            this.panel内容区.ResumeLayout(false);
            this.panel内容区.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel内容区;
        private uc维修工单基本信息 uc维修工单基本信息;
        private uc维修工单维修信息 uc维修工单维修信息;
    }
}