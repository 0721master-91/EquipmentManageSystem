
namespace EquipmentManageSystem.设备管理
{
    partial class dlg功能主设备档案编辑
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
            SLControls.SLGlobal.SlcFieldInfo slcFieldInfo1 = new SLControls.SLGlobal.SlcFieldInfo();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.slTextBox设备名称 = new SLControls.SLTextBox();
            this.slTextBox设备编码 = new SLControls.SLTextBox();
            this.checkBox启用状态 = new System.Windows.Forms.CheckBox();
            this.slComboBox设备模块 = new SLControls.SLComboBox();
            this.label设备模块 = new System.Windows.Forms.Label();
            this.slComboBox设备类型 = new SLControls.SLComboBox();
            this.label设备类型 = new System.Windows.Forms.Label();
            this.label设备名称 = new System.Windows.Forms.Label();
            this.label设备编码 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(148, 329);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(270, 329);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.slTextBox设备名称);
            this.groupBox1.Controls.Add(this.slTextBox设备编码);
            this.groupBox1.Controls.Add(this.checkBox启用状态);
            this.groupBox1.Controls.Add(this.slComboBox设备模块);
            this.groupBox1.Controls.Add(this.label设备模块);
            this.groupBox1.Controls.Add(this.slComboBox设备类型);
            this.groupBox1.Controls.Add(this.label设备类型);
            this.groupBox1.Controls.Add(this.label设备名称);
            this.groupBox1.Controls.Add(this.label设备编码);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 279);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备信息";
            // 
            // slTextBox设备名称
            // 
            this.slTextBox设备名称.BeforeFormatControlTextHandler = null;
            this.slTextBox设备名称.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox设备名称.FieldName = "设备名称";
            this.slTextBox设备名称.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox设备名称.Location = new System.Drawing.Point(115, 90);
            this.slTextBox设备名称.Name = "slTextBox设备名称";
            this.slTextBox设备名称.Size = new System.Drawing.Size(163, 27);
            this.slTextBox设备名称.TabIndex = 10;
            this.slTextBox设备名称.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // slTextBox设备编码
            // 
            this.slTextBox设备编码.BeforeFormatControlTextHandler = null;
            this.slTextBox设备编码.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox设备编码.FieldName = "设备编码";
            this.slTextBox设备编码.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox设备编码.Location = new System.Drawing.Point(115, 36);
            this.slTextBox设备编码.Name = "slTextBox设备编码";
            this.slTextBox设备编码.Size = new System.Drawing.Size(163, 27);
            this.slTextBox设备编码.TabIndex = 9;
            this.slTextBox设备编码.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // checkBox启用状态
            // 
            this.checkBox启用状态.AutoSize = true;
            this.checkBox启用状态.Location = new System.Drawing.Point(115, 230);
            this.checkBox启用状态.Name = "checkBox启用状态";
            this.checkBox启用状态.Size = new System.Drawing.Size(64, 21);
            this.checkBox启用状态.TabIndex = 8;
            this.checkBox启用状态.Text = "启用";
            this.checkBox启用状态.UseVisualStyleBackColor = true;
            // 
            // slComboBox设备模块
            // 
            this.slComboBox设备模块.AllowEmpty = false;
            this.slComboBox设备模块.BeforeFormatControlTextHandler = null;
            this.slComboBox设备模块.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox设备模块.DispField = "模块名称";
            this.slComboBox设备模块.FieldName = "设备模块编码";
            this.slComboBox设备模块.ForeignKey = "模块编码";
            this.slComboBox设备模块.ForeignTable = "设备模块";
            this.slComboBox设备模块.FormattingEnabled = true;
            this.slComboBox设备模块.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox设备模块.Location = new System.Drawing.Point(115, 184);
            this.slComboBox设备模块.Name = "slComboBox设备模块";
            this.slComboBox设备模块.Size = new System.Drawing.Size(121, 25);
            this.slComboBox设备模块.TabIndex = 7;
            this.slComboBox设备模块.TextStyle = SLControls.SLStyle.INVALID;
            this.slComboBox设备模块.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label设备模块
            // 
            this.label设备模块.AutoSize = true;
            this.label设备模块.Location = new System.Drawing.Point(28, 188);
            this.label设备模块.Name = "label设备模块";
            this.label设备模块.Size = new System.Drawing.Size(93, 17);
            this.label设备模块.TabIndex = 6;
            this.label设备模块.Text = "设备模块：";
            // 
            // slComboBox设备类型
            // 
            this.slComboBox设备类型.AllowEmpty = false;
            this.slComboBox设备类型.BeforeFormatControlTextHandler = null;
            this.slComboBox设备类型.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox设备类型.DispField = "类型名称";
            this.slComboBox设备类型.FieldName = "设备类型编码";
            this.slComboBox设备类型.ForeignKey = "类型编码";
            this.slComboBox设备类型.ForeignTable = "设备类型";
            this.slComboBox设备类型.FormattingEnabled = true;
            this.slComboBox设备类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox设备类型.Location = new System.Drawing.Point(115, 141);
            this.slComboBox设备类型.Name = "slComboBox设备类型";
            this.slComboBox设备类型.Size = new System.Drawing.Size(121, 25);
            this.slComboBox设备类型.TabIndex = 5;
            this.slComboBox设备类型.TextStyle = SLControls.SLStyle.INVALID;
            this.slComboBox设备类型.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label设备类型
            // 
            this.label设备类型.AutoSize = true;
            this.label设备类型.Location = new System.Drawing.Point(28, 145);
            this.label设备类型.Name = "label设备类型";
            this.label设备类型.Size = new System.Drawing.Size(93, 17);
            this.label设备类型.TabIndex = 4;
            this.label设备类型.Text = "设备类型：";
            // 
            // label设备名称
            // 
            this.label设备名称.AutoSize = true;
            this.label设备名称.Location = new System.Drawing.Point(28, 95);
            this.label设备名称.Name = "label设备名称";
            this.label设备名称.Size = new System.Drawing.Size(93, 17);
            this.label设备名称.TabIndex = 2;
            this.label设备名称.Text = "设备名称：";
            // 
            // label设备编码
            // 
            this.label设备编码.AutoSize = true;
            this.label设备编码.Location = new System.Drawing.Point(28, 41);
            this.label设备编码.Name = "label设备编码";
            this.label设备编码.Size = new System.Drawing.Size(93, 17);
            this.label设备编码.TabIndex = 0;
            this.label设备编码.Text = "设备编码：";
            // 
            // dlg功能主设备档案编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 376);
            this.Controls.Add(this.groupBox1);
            this.Name = "dlg功能主设备档案编辑";
            slcFieldInfo1.KeyName = "IsEnabled";
            slcFieldInfo1.KeyType = SLControls.SLGlobal.SleDataType.Digit;
            slcFieldInfo1.KeyValue = null;
            slcFieldInfo1.OperatorMode = SLControls.SLGlobal.SleOperatorMode.ReadWrite;
            this.OtherFields.Add(slcFieldInfo1);
            this.Text = "功能主设备档案";
            this.AfterFillControls += new SLControls.AfterFillControlsHandler(this.dlg功能主设备档案编辑_AfterFillControls);
            this.PreOK += new SLControls.PreOKHandler(this.dlg功能主设备档案编辑_PreOK);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.button取消, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label设备编码;
        private SLControls.SLComboBox slComboBox设备类型;
        private System.Windows.Forms.Label label设备类型;
        private System.Windows.Forms.Label label设备名称;
        private System.Windows.Forms.CheckBox checkBox启用状态;
        private SLControls.SLComboBox slComboBox设备模块;
        private System.Windows.Forms.Label label设备模块;
        private SLControls.SLTextBox slTextBox设备名称;
        private SLControls.SLTextBox slTextBox设备编码;
    }
}