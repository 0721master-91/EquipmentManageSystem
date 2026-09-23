
namespace EquipmentManageSystem.设备管理
{
    partial class dlg功能位置档案编辑
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
            this.groupBox单据信息 = new System.Windows.Forms.GroupBox();
            this.label单据号 = new System.Windows.Forms.Label();
            this.slTextBox单据号 = new SLControls.SLTextBox();
            this.label所属组织 = new System.Windows.Forms.Label();
            this.slComboBox所属组织 = new SLControls.SLComboBox();
            this.groupBox单据信息.SuspendLayout();
            this.SuspendLayout();
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(219, 737);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(815, 737);
            // 
            // groupBox单据信息
            // 
            this.groupBox单据信息.Controls.Add(this.slComboBox所属组织);
            this.groupBox单据信息.Controls.Add(this.label所属组织);
            this.groupBox单据信息.Controls.Add(this.slTextBox单据号);
            this.groupBox单据信息.Controls.Add(this.label单据号);
            this.groupBox单据信息.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox单据信息.Location = new System.Drawing.Point(6, 5);
            this.groupBox单据信息.Name = "groupBox单据信息";
            this.groupBox单据信息.Size = new System.Drawing.Size(1337, 140);
            this.groupBox单据信息.TabIndex = 1;
            this.groupBox单据信息.TabStop = false;
            this.groupBox单据信息.Text = "单据信息";
            // 
            // label单据号
            // 
            this.label单据号.AutoSize = true;
            this.label单据号.Location = new System.Drawing.Point(22, 24);
            this.label单据号.Name = "label单据号";
            this.label单据号.Size = new System.Drawing.Size(85, 19);
            this.label单据号.TabIndex = 0;
            this.label单据号.Text = "单据号：";
            // 
            // slTextBox单据号
            // 
            this.slTextBox单据号.BeforeFormatControlTextHandler = null;
            this.slTextBox单据号.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox单据号.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox单据号.Location = new System.Drawing.Point(97, 19);
            this.slTextBox单据号.Name = "slTextBox单据号";
            this.slTextBox单据号.ReadOnly = true;
            this.slTextBox单据号.Size = new System.Drawing.Size(215, 28);
            this.slTextBox单据号.TabIndex = 1;
            this.slTextBox单据号.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label所属组织
            // 
            this.label所属组织.AutoSize = true;
            this.label所属组织.Location = new System.Drawing.Point(350, 24);
            this.label所属组织.Name = "label所属组织";
            this.label所属组织.Size = new System.Drawing.Size(104, 19);
            this.label所属组织.TabIndex = 2;
            this.label所属组织.Text = "所属组织：";
            // 
            // slComboBox所属组织
            // 
            this.slComboBox所属组织.BeforeFormatControlTextHandler = null;
            this.slComboBox所属组织.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox所属组织.FieldName = "所属组织ID";
            this.slComboBox所属组织.ForeignTable = "组织";
            this.slComboBox所属组织.FormattingEnabled = true;
            this.slComboBox所属组织.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox所属组织.Location = new System.Drawing.Point(445, 20);
            this.slComboBox所属组织.Name = "slComboBox所属组织";
            this.slComboBox所属组织.Size = new System.Drawing.Size(526, 26);
            this.slComboBox所属组织.TabIndex = 3;
            this.slComboBox所属组织.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // dlg功能位置档案编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 779);
            this.Controls.Add(this.groupBox单据信息);
            this.Name = "dlg功能位置档案编辑";
            this.Text = "功能位置档案";
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.button取消, 0);
            this.Controls.SetChildIndex(this.groupBox单据信息, 0);
            this.groupBox单据信息.ResumeLayout(false);
            this.groupBox单据信息.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox单据信息;
        private System.Windows.Forms.Label label单据号;
        private SLControls.SLTextBox slTextBox单据号;
        private System.Windows.Forms.Label label所属组织;
        private SLControls.SLComboBox slComboBox所属组织;
    }
}