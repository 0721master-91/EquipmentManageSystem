
namespace EquipmentManageSystem.Global
{
    partial class dlg组织选择
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
            this.panel条件筛选区.SuspendLayout();
            this.panel操作区.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel数据区
            // 
            this.panel数据区.Size = new System.Drawing.Size(951, 382);
            // 
            // panel条件筛选区
            // 
            this.panel条件筛选区.Size = new System.Drawing.Size(951, 73);
            // 
            // panel操作区
            // 
            this.panel操作区.Size = new System.Drawing.Size(951, 85);
            // 
            // dlg组织选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 540);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "dlg组织选择";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "组织选择";
            this.BeforeQuery += new EquipmentManageSystem.模板.选择窗口模版.temp选择窗口.BeforeQueryEventHandler(this.dlg组织选择_BeforeQuery);
            this.PreOK += new EquipmentManageSystem.模板.选择窗口模版.temp选择窗口.PreOKHandler(this.dlg组织选择_PreOK);
            this.panel条件筛选区.ResumeLayout(false);
            this.panel条件筛选区.PerformLayout();
            this.panel操作区.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}