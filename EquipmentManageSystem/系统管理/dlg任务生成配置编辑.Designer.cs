
namespace EquipmentManageSystem.系统管理
{
    partial class dlg任务生成配置编辑
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
            SLControls.SLGlobal.SlcFieldInfo slcFieldInfo1 = new SLControls.SLGlobal.SlcFieldInfo();
            this.groupBox配置信息 = new System.Windows.Forms.GroupBox();
            this.slTextBox数据源 = new SLControls.SLTextBox();
            this.label数据源 = new System.Windows.Forms.Label();
            this.checkBox是否启用 = new System.Windows.Forms.CheckBox();
            this.slComboBox适用范围 = new SLControls.SLComboBox();
            this.label适用范围 = new System.Windows.Forms.Label();
            this.slComboBox日期类型 = new SLControls.SLComboBox();
            this.label日期类型 = new System.Windows.Forms.Label();
            this.slTextBox备注 = new SLControls.SLTextBox();
            this.label备注 = new System.Windows.Forms.Label();
            this.slDateTimePicker执行日期 = new SLControls.SLDateTimePicker();
            this.label执行日期 = new System.Windows.Forms.Label();
            this.slTextBox配置名称 = new SLControls.SLTextBox();
            this.label配置名称 = new System.Windows.Forms.Label();
            this.slTextBox配置编码 = new SLControls.SLTextBox();
            this.label配置编码 = new System.Windows.Forms.Label();
            this.groupBox配置信息.SuspendLayout();
            this.SuspendLayout();
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(245, 238);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(401, 238);
            // 
            // groupBox配置信息
            // 
            this.groupBox配置信息.Controls.Add(this.slTextBox数据源);
            this.groupBox配置信息.Controls.Add(this.label数据源);
            this.groupBox配置信息.Controls.Add(this.checkBox是否启用);
            this.groupBox配置信息.Controls.Add(this.slComboBox适用范围);
            this.groupBox配置信息.Controls.Add(this.label适用范围);
            this.groupBox配置信息.Controls.Add(this.slComboBox日期类型);
            this.groupBox配置信息.Controls.Add(this.label日期类型);
            this.groupBox配置信息.Controls.Add(this.slTextBox备注);
            this.groupBox配置信息.Controls.Add(this.label备注);
            this.groupBox配置信息.Controls.Add(this.slDateTimePicker执行日期);
            this.groupBox配置信息.Controls.Add(this.label执行日期);
            this.groupBox配置信息.Controls.Add(this.slTextBox配置名称);
            this.groupBox配置信息.Controls.Add(this.label配置名称);
            this.groupBox配置信息.Controls.Add(this.slTextBox配置编码);
            this.groupBox配置信息.Controls.Add(this.label配置编码);
            this.groupBox配置信息.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox配置信息.Location = new System.Drawing.Point(8, 7);
            this.groupBox配置信息.Name = "groupBox配置信息";
            this.groupBox配置信息.Size = new System.Drawing.Size(719, 218);
            this.groupBox配置信息.TabIndex = 1;
            this.groupBox配置信息.TabStop = false;
            this.groupBox配置信息.Text = "配置信息";
            // 
            // slTextBox数据源
            // 
            this.slTextBox数据源.BeforeFormatControlTextHandler = null;
            this.slTextBox数据源.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox数据源.DispField = "数据源";
            this.slTextBox数据源.FieldName = "数据源编码";
            this.slTextBox数据源.ForeignKey = "编码";
            this.slTextBox数据源.ForeignTable = "配置数据源";
            this.slTextBox数据源.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox数据源.Location = new System.Drawing.Point(484, 69);
            this.slTextBox数据源.Name = "slTextBox数据源";
            this.slTextBox数据源.OperatorMode = SLControls.SLGlobal.SleOperatorMode.Read;
            this.slTextBox数据源.ReadOnly = true;
            this.slTextBox数据源.Size = new System.Drawing.Size(217, 28);
            this.slTextBox数据源.TabIndex = 14;
            this.slTextBox数据源.TextStyle = SLControls.SLStyle.INVALID;
            this.slTextBox数据源.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label数据源
            // 
            this.label数据源.AutoSize = true;
            this.label数据源.Location = new System.Drawing.Point(408, 74);
            this.label数据源.Name = "label数据源";
            this.label数据源.Size = new System.Drawing.Size(85, 19);
            this.label数据源.TabIndex = 13;
            this.label数据源.Text = "数据源：";
            // 
            // checkBox是否启用
            // 
            this.checkBox是否启用.AutoSize = true;
            this.checkBox是否启用.Checked = true;
            this.checkBox是否启用.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox是否启用.Location = new System.Drawing.Point(393, 171);
            this.checkBox是否启用.Name = "checkBox是否启用";
            this.checkBox是否启用.Size = new System.Drawing.Size(107, 23);
            this.checkBox是否启用.TabIndex = 12;
            this.checkBox是否启用.Text = "是否启用";
            this.checkBox是否启用.UseVisualStyleBackColor = true;
            // 
            // slComboBox适用范围
            // 
            this.slComboBox适用范围.AllowEmpty = false;
            this.slComboBox适用范围.BeforeFormatControlTextHandler = null;
            this.slComboBox适用范围.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox适用范围.DispField = "范围";
            this.slComboBox适用范围.FieldName = "适用范围编码";
            this.slComboBox适用范围.ForeignKey = "编码";
            this.slComboBox适用范围.ForeignTable = "配置适用范围";
            this.slComboBox适用范围.FormattingEnabled = true;
            this.slComboBox适用范围.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox适用范围.Location = new System.Drawing.Point(120, 140);
            this.slComboBox适用范围.Name = "slComboBox适用范围";
            this.slComboBox适用范围.Size = new System.Drawing.Size(149, 26);
            this.slComboBox适用范围.TabIndex = 11;
            this.slComboBox适用范围.TextStyle = SLControls.SLStyle.INVALID;
            this.slComboBox适用范围.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label适用范围
            // 
            this.label适用范围.AutoSize = true;
            this.label适用范围.Location = new System.Drawing.Point(26, 144);
            this.label适用范围.Name = "label适用范围";
            this.label适用范围.Size = new System.Drawing.Size(104, 19);
            this.label适用范围.TabIndex = 10;
            this.label适用范围.Text = "适用范围：";
            // 
            // slComboBox日期类型
            // 
            this.slComboBox日期类型.AllowEmpty = false;
            this.slComboBox日期类型.BeforeFormatControlTextHandler = null;
            this.slComboBox日期类型.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox日期类型.DispField = "类型";
            this.slComboBox日期类型.FieldName = "日期类型编码";
            this.slComboBox日期类型.ForeignKey = "编码";
            this.slComboBox日期类型.ForeignTable = "日期类型";
            this.slComboBox日期类型.FormattingEnabled = true;
            this.slComboBox日期类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox日期类型.Location = new System.Drawing.Point(120, 105);
            this.slComboBox日期类型.Name = "slComboBox日期类型";
            this.slComboBox日期类型.Size = new System.Drawing.Size(149, 26);
            this.slComboBox日期类型.TabIndex = 9;
            this.slComboBox日期类型.TextStyle = SLControls.SLStyle.INVALID;
            this.slComboBox日期类型.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label日期类型
            // 
            this.label日期类型.AutoSize = true;
            this.label日期类型.Location = new System.Drawing.Point(26, 109);
            this.label日期类型.Name = "label日期类型";
            this.label日期类型.Size = new System.Drawing.Size(104, 19);
            this.label日期类型.TabIndex = 8;
            this.label日期类型.Text = "日期类型：";
            // 
            // slTextBox备注
            // 
            this.slTextBox备注.BeforeFormatControlTextHandler = null;
            this.slTextBox备注.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox备注.FieldName = "备注";
            this.slTextBox备注.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox备注.Location = new System.Drawing.Point(484, 108);
            this.slTextBox备注.Multiline = true;
            this.slTextBox备注.Name = "slTextBox备注";
            this.slTextBox备注.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.slTextBox备注.Size = new System.Drawing.Size(217, 50);
            this.slTextBox备注.TabIndex = 7;
            this.slTextBox备注.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label备注
            // 
            this.label备注.AutoSize = true;
            this.label备注.Location = new System.Drawing.Point(427, 115);
            this.label备注.Name = "label备注";
            this.label备注.Size = new System.Drawing.Size(66, 19);
            this.label备注.TabIndex = 6;
            this.label备注.Text = "备注：";
            // 
            // slDateTimePicker执行日期
            // 
            this.slDateTimePicker执行日期.CustomFormat = "yyyy-MM-dd";
            this.slDateTimePicker执行日期.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slDateTimePicker执行日期.FieldName = "执行日期";
            this.slDateTimePicker执行日期.FindCondition = SLControls.SLGlobal.SleFindCondition.MoreThanOrEqual;
            this.slDateTimePicker执行日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.slDateTimePicker执行日期.FormatForStore = "yyyy-MM-dd";
            this.slDateTimePicker执行日期.Location = new System.Drawing.Point(120, 67);
            this.slDateTimePicker执行日期.Name = "slDateTimePicker执行日期";
            this.slDateTimePicker执行日期.Size = new System.Drawing.Size(149, 28);
            this.slDateTimePicker执行日期.TabIndex = 5;
            // 
            // label执行日期
            // 
            this.label执行日期.AutoSize = true;
            this.label执行日期.Location = new System.Drawing.Point(26, 74);
            this.label执行日期.Name = "label执行日期";
            this.label执行日期.Size = new System.Drawing.Size(104, 19);
            this.label执行日期.TabIndex = 4;
            this.label执行日期.Text = "执行日期：";
            // 
            // slTextBox配置名称
            // 
            this.slTextBox配置名称.BeforeFormatControlTextHandler = null;
            this.slTextBox配置名称.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox配置名称.FieldName = "配置名称";
            this.slTextBox配置名称.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox配置名称.Location = new System.Drawing.Point(484, 28);
            this.slTextBox配置名称.Name = "slTextBox配置名称";
            this.slTextBox配置名称.Size = new System.Drawing.Size(217, 28);
            this.slTextBox配置名称.TabIndex = 3;
            this.slTextBox配置名称.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label配置名称
            // 
            this.label配置名称.AutoSize = true;
            this.label配置名称.Location = new System.Drawing.Point(389, 33);
            this.label配置名称.Name = "label配置名称";
            this.label配置名称.Size = new System.Drawing.Size(104, 19);
            this.label配置名称.TabIndex = 2;
            this.label配置名称.Text = "配置名称：";
            // 
            // slTextBox配置编码
            // 
            this.slTextBox配置编码.BeforeFormatControlTextHandler = null;
            this.slTextBox配置编码.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox配置编码.FieldName = "配置编码";
            this.slTextBox配置编码.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox配置编码.Location = new System.Drawing.Point(120, 28);
            this.slTextBox配置编码.Name = "slTextBox配置编码";
            this.slTextBox配置编码.ReadOnly = true;
            this.slTextBox配置编码.Size = new System.Drawing.Size(217, 28);
            this.slTextBox配置编码.TabIndex = 1;
            this.slTextBox配置编码.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label配置编码
            // 
            this.label配置编码.AutoSize = true;
            this.label配置编码.Location = new System.Drawing.Point(26, 33);
            this.label配置编码.Name = "label配置编码";
            this.label配置编码.Size = new System.Drawing.Size(104, 19);
            this.label配置编码.TabIndex = 0;
            this.label配置编码.Text = "配置编码：";
            // 
            // dlg任务生成配置编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 283);
            this.CloseFormAfterNew = true;
            this.Controls.Add(this.groupBox配置信息);
            this.Name = "dlg任务生成配置编辑";
            slcFieldInfo1.KeyName = "IsEnabled";
            slcFieldInfo1.KeyType = SLControls.SLGlobal.SleDataType.Digit;
            slcFieldInfo1.KeyValue = null;
            slcFieldInfo1.OperatorMode = SLControls.SLGlobal.SleOperatorMode.ReadWrite;
            this.OtherFields.Add(slcFieldInfo1);
            this.TableName = "任务生成配置";
            this.Text = "任务生成配置";
            this.AfterFillControls += new SLControls.AfterFillControlsHandler(this.dlg任务生成配置编辑_AfterFillControls);
            this.PreOK += new SLControls.PreOKHandler(this.dlg任务生成配置编辑_PreOK);
            this.AfterExecuteOKSql += new SLControls.AfterExecuteOKSqlHandler(this.dlg任务生成配置编辑_AfterExecuteOKSql);
            this.Load += new System.EventHandler(this.dlg任务生成配置编辑_Load);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.button取消, 0);
            this.Controls.SetChildIndex(this.groupBox配置信息, 0);
            this.groupBox配置信息.ResumeLayout(false);
            this.groupBox配置信息.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox配置信息;
        private System.Windows.Forms.Label label配置编码;
        private System.Windows.Forms.Label label配置名称;
        private SLControls.SLTextBox slTextBox配置编码;
        private SLControls.SLTextBox slTextBox配置名称;
        private System.Windows.Forms.Label label执行日期;
        private SLControls.SLDateTimePicker slDateTimePicker执行日期;
        private SLControls.SLTextBox slTextBox备注;
        private System.Windows.Forms.Label label备注;
        private SLControls.SLComboBox slComboBox日期类型;
        private System.Windows.Forms.Label label日期类型;
        private System.Windows.Forms.Label label适用范围;
        private System.Windows.Forms.CheckBox checkBox是否启用;
        private SLControls.SLComboBox slComboBox适用范围;
        private SLControls.SLTextBox slTextBox数据源;
        private System.Windows.Forms.Label label数据源;
    }
}