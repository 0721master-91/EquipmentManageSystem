
namespace EquipmentManageSystem.设备保养
{
    partial class dlg保养任务编辑保养标准选择
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
            this.panel数据区.Size = new System.Drawing.Size(953, 382);
            // 
            // panel条件筛选区
            // 
            this.panel条件筛选区.Size = new System.Drawing.Size(953, 73);
            // 
            // panel操作区
            // 
            this.panel操作区.Size = new System.Drawing.Size(953, 78);
            // 
            // dlg保养任务编辑保养标准选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 533);
            this.Name = "dlg保养任务编辑保养标准选择";
            this.Text = "保养标准选择";
            this.BeforeQuery += new EquipmentManageSystem.模板.选择窗口模版.temp选择窗口.BeforeQueryEventHandler(this.dlg保养任务编辑保养标准选择_BeforeQuery);
            this.PreOK += new EquipmentManageSystem.模板.选择窗口模版.temp选择窗口.PreOKHandler(this.dlg保养任务编辑保养标准选择_PreOK);
            this.panel条件筛选区.ResumeLayout(false);
            this.panel条件筛选区.PerformLayout();
            this.panel操作区.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}