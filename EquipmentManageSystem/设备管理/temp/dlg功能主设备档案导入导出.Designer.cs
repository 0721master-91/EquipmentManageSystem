﻿
namespace EquipmentManageSystem.设备管理
{
    partial class dlg功能主设备档案导入导出
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg功能主设备档案导入导出));
            this.SuspendLayout();
            // 
            // dlg功能主设备档案导入导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 738);
            this.ExcelTemplates.Add(((EquipmentManageSystem.模板.导入导出模板.ExcelTemplate)(resources.GetObject("$this.ExcelTemplates"))));
            this.ExtraFields.Add(((EquipmentManageSystem.模板.导入导出模板.ExportField)(resources.GetObject("$this.ExtraFields"))));
            this.Name = "dlg功能主设备档案导入导出";
            this.OutEnabled = true;
            this.ShowInTaskbar = false;
            this.TableName = "设备档案";
            this.Text = "功能主设备档案导入导出";
            this.ResumeLayout(false);

        }

        #endregion
    }
}