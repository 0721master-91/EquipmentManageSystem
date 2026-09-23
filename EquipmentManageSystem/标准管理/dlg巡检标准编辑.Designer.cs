
namespace EquipmentManageSystem.标准管理
{
    partial class dlg巡检标准编辑
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
            this.groupBox巡检信息 = new System.Windows.Forms.GroupBox();
            this.checkBox启用状态 = new System.Windows.Forms.CheckBox();
            this.label启用状态 = new System.Windows.Forms.Label();
            this.slDateTimePicker开始执行日期 = new SLControls.SLDateTimePicker();
            this.label开始执行日期 = new System.Windows.Forms.Label();
            this.slComboBox周期单位 = new SLControls.SLComboBox();
            this.label周期单位 = new System.Windows.Forms.Label();
            this.slTextBox巡检周期 = new SLControls.SLTextBox();
            this.label巡检周期 = new System.Windows.Forms.Label();
            this.slTextBox提前提醒天数 = new SLControls.SLTextBox();
            this.label提前提醒天数 = new System.Windows.Forms.Label();
            this.slTextBox判断标准 = new SLControls.SLTextBox();
            this.label判断标准 = new System.Windows.Forms.Label();
            this.slTextBox巡检类型 = new SLControls.SLTextBox();
            this.label巡检类型 = new System.Windows.Forms.Label();
            this.slTextBox巡检内容 = new SLControls.SLTextBox();
            this.label巡检内容 = new System.Windows.Forms.Label();
            this.slTextBox巡检部位 = new SLControls.SLTextBox();
            this.label巡检部位 = new System.Windows.Forms.Label();
            this.slTextBox巡检部位编码 = new SLControls.SLTextBox();
            this.label巡检部位编码 = new System.Windows.Forms.Label();
            this.groupBox巡检信息.SuspendLayout();
            this.SuspendLayout();
            // 
            // button确定
            // 
            this.button确定.Location = new System.Drawing.Point(270, 329);
            // 
            // button取消
            // 
            this.button取消.Location = new System.Drawing.Point(408, 329);
            // 
            // groupBox巡检信息
            // 
            this.groupBox巡检信息.Controls.Add(this.checkBox启用状态);
            this.groupBox巡检信息.Controls.Add(this.label启用状态);
            this.groupBox巡检信息.Controls.Add(this.slDateTimePicker开始执行日期);
            this.groupBox巡检信息.Controls.Add(this.label开始执行日期);
            this.groupBox巡检信息.Controls.Add(this.slComboBox周期单位);
            this.groupBox巡检信息.Controls.Add(this.label周期单位);
            this.groupBox巡检信息.Controls.Add(this.slTextBox巡检周期);
            this.groupBox巡检信息.Controls.Add(this.label巡检周期);
            this.groupBox巡检信息.Controls.Add(this.slTextBox提前提醒天数);
            this.groupBox巡检信息.Controls.Add(this.label提前提醒天数);
            this.groupBox巡检信息.Controls.Add(this.slTextBox判断标准);
            this.groupBox巡检信息.Controls.Add(this.label判断标准);
            this.groupBox巡检信息.Controls.Add(this.slTextBox巡检类型);
            this.groupBox巡检信息.Controls.Add(this.label巡检类型);
            this.groupBox巡检信息.Controls.Add(this.slTextBox巡检内容);
            this.groupBox巡检信息.Controls.Add(this.label巡检内容);
            this.groupBox巡检信息.Controls.Add(this.slTextBox巡检部位);
            this.groupBox巡检信息.Controls.Add(this.label巡检部位);
            this.groupBox巡检信息.Controls.Add(this.slTextBox巡检部位编码);
            this.groupBox巡检信息.Controls.Add(this.label巡检部位编码);
            this.groupBox巡检信息.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox巡检信息.Location = new System.Drawing.Point(12, 12);
            this.groupBox巡检信息.Name = "groupBox巡检信息";
            this.groupBox巡检信息.Size = new System.Drawing.Size(741, 301);
            this.groupBox巡检信息.TabIndex = 1;
            this.groupBox巡检信息.TabStop = false;
            this.groupBox巡检信息.Text = "巡检信息";
            // 
            // checkBox启用状态
            // 
            this.checkBox启用状态.AutoSize = true;
            this.checkBox启用状态.Location = new System.Drawing.Point(507, 251);
            this.checkBox启用状态.Name = "checkBox启用状态";
            this.checkBox启用状态.Size = new System.Drawing.Size(69, 23);
            this.checkBox启用状态.TabIndex = 22;
            this.checkBox启用状态.Text = "启用";
            this.checkBox启用状态.UseVisualStyleBackColor = true;
            // 
            // label启用状态
            // 
            this.label启用状态.AutoSize = true;
            this.label启用状态.Location = new System.Drawing.Point(413, 253);
            this.label启用状态.Name = "label启用状态";
            this.label启用状态.Size = new System.Drawing.Size(104, 19);
            this.label启用状态.TabIndex = 21;
            this.label启用状态.Text = "启用状态：";
            // 
            // slDateTimePicker开始执行日期
            // 
            this.slDateTimePicker开始执行日期.CustomFormat = "yyyy-MM-dd";
            this.slDateTimePicker开始执行日期.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slDateTimePicker开始执行日期.FieldName = "开始执行日期";
            this.slDateTimePicker开始执行日期.FindCondition = SLControls.SLGlobal.SleFindCondition.MoreThanOrEqual;
            this.slDateTimePicker开始执行日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.slDateTimePicker开始执行日期.FormatForStore = "yyyy-MM-dd";
            this.slDateTimePicker开始执行日期.Location = new System.Drawing.Point(152, 248);
            this.slDateTimePicker开始执行日期.Name = "slDateTimePicker开始执行日期";
            this.slDateTimePicker开始执行日期.Size = new System.Drawing.Size(204, 28);
            this.slDateTimePicker开始执行日期.TabIndex = 20;
            this.slDateTimePicker开始执行日期.Value = new System.DateTime(2026, 9, 22, 0, 0, 0, 0);
            // 
            // label开始执行日期
            // 
            this.label开始执行日期.AutoSize = true;
            this.label开始执行日期.Location = new System.Drawing.Point(21, 253);
            this.label开始执行日期.Name = "label开始执行日期";
            this.label开始执行日期.Size = new System.Drawing.Size(142, 19);
            this.label开始执行日期.TabIndex = 19;
            this.label开始执行日期.Text = "开始执行日期：";
            // 
            // slComboBox周期单位
            // 
            this.slComboBox周期单位.AllowEmpty = false;
            this.slComboBox周期单位.BeforeFormatControlTextHandler = null;
            this.slComboBox周期单位.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slComboBox周期单位.DispField = "单位名称";
            this.slComboBox周期单位.FieldName = "周期单位编码";
            this.slComboBox周期单位.ForeignKey = "单位编码";
            this.slComboBox周期单位.ForeignTable = "周期单位";
            this.slComboBox周期单位.FormattingEnabled = true;
            this.slComboBox周期单位.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slComboBox周期单位.Location = new System.Drawing.Point(506, 208);
            this.slComboBox周期单位.Name = "slComboBox周期单位";
            this.slComboBox周期单位.Size = new System.Drawing.Size(99, 26);
            this.slComboBox周期单位.TabIndex = 18;
            this.slComboBox周期单位.TextStyle = SLControls.SLStyle.INVALID;
            this.slComboBox周期单位.ValueFrom = SLControls.SLGlobal.SleValueFrom.ForeignKey;
            // 
            // label周期单位
            // 
            this.label周期单位.AutoSize = true;
            this.label周期单位.Location = new System.Drawing.Point(413, 211);
            this.label周期单位.Name = "label周期单位";
            this.label周期单位.Size = new System.Drawing.Size(104, 19);
            this.label周期单位.TabIndex = 17;
            this.label周期单位.Text = "周期单位：";
            // 
            // slTextBox巡检周期
            // 
            this.slTextBox巡检周期.AllowEmpty = false;
            this.slTextBox巡检周期.BeforeFormatControlTextHandler = null;
            this.slTextBox巡检周期.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox巡检周期.FieldName = "巡检周期";
            this.slTextBox巡检周期.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox巡检周期.Location = new System.Drawing.Point(152, 206);
            this.slTextBox巡检周期.Name = "slTextBox巡检周期";
            this.slTextBox巡检周期.Size = new System.Drawing.Size(204, 28);
            this.slTextBox巡检周期.TabIndex = 16;
            this.slTextBox巡检周期.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label巡检周期
            // 
            this.label巡检周期.AutoSize = true;
            this.label巡检周期.Location = new System.Drawing.Point(59, 211);
            this.label巡检周期.Name = "label巡检周期";
            this.label巡检周期.Size = new System.Drawing.Size(104, 19);
            this.label巡检周期.TabIndex = 15;
            this.label巡检周期.Text = "巡检周期：";
            // 
            // slTextBox提前提醒天数
            // 
            this.slTextBox提前提醒天数.BeforeFormatControlTextHandler = null;
            this.slTextBox提前提醒天数.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox提前提醒天数.FieldName = "提前提醒天数";
            this.slTextBox提前提醒天数.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox提前提醒天数.Location = new System.Drawing.Point(506, 161);
            this.slTextBox提前提醒天数.Name = "slTextBox提前提醒天数";
            this.slTextBox提前提醒天数.Size = new System.Drawing.Size(204, 28);
            this.slTextBox提前提醒天数.TabIndex = 14;
            this.slTextBox提前提醒天数.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label提前提醒天数
            // 
            this.label提前提醒天数.AutoSize = true;
            this.label提前提醒天数.Location = new System.Drawing.Point(375, 166);
            this.label提前提醒天数.Name = "label提前提醒天数";
            this.label提前提醒天数.Size = new System.Drawing.Size(142, 19);
            this.label提前提醒天数.TabIndex = 13;
            this.label提前提醒天数.Text = "提前提醒天数：";
            // 
            // slTextBox判断标准
            // 
            this.slTextBox判断标准.BeforeFormatControlTextHandler = null;
            this.slTextBox判断标准.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox判断标准.FieldName = "判断标准";
            this.slTextBox判断标准.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox判断标准.Location = new System.Drawing.Point(507, 70);
            this.slTextBox判断标准.Multiline = true;
            this.slTextBox判断标准.Name = "slTextBox判断标准";
            this.slTextBox判断标准.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.slTextBox判断标准.Size = new System.Drawing.Size(204, 76);
            this.slTextBox判断标准.TabIndex = 12;
            this.slTextBox判断标准.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label判断标准
            // 
            this.label判断标准.AutoSize = true;
            this.label判断标准.Location = new System.Drawing.Point(413, 75);
            this.label判断标准.Name = "label判断标准";
            this.label判断标准.Size = new System.Drawing.Size(104, 19);
            this.label判断标准.TabIndex = 11;
            this.label判断标准.Text = "判断标准：";
            // 
            // slTextBox巡检类型
            // 
            this.slTextBox巡检类型.BeforeFormatControlTextHandler = null;
            this.slTextBox巡检类型.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox巡检类型.FieldName = "巡检类型";
            this.slTextBox巡检类型.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox巡检类型.Location = new System.Drawing.Point(152, 161);
            this.slTextBox巡检类型.Name = "slTextBox巡检类型";
            this.slTextBox巡检类型.Size = new System.Drawing.Size(204, 28);
            this.slTextBox巡检类型.TabIndex = 8;
            this.slTextBox巡检类型.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label巡检类型
            // 
            this.label巡检类型.AutoSize = true;
            this.label巡检类型.Location = new System.Drawing.Point(59, 166);
            this.label巡检类型.Name = "label巡检类型";
            this.label巡检类型.Size = new System.Drawing.Size(104, 19);
            this.label巡检类型.TabIndex = 7;
            this.label巡检类型.Text = "巡检类型：";
            // 
            // slTextBox巡检内容
            // 
            this.slTextBox巡检内容.BeforeFormatControlTextHandler = null;
            this.slTextBox巡检内容.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox巡检内容.FieldName = "巡检内容";
            this.slTextBox巡检内容.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox巡检内容.Location = new System.Drawing.Point(152, 70);
            this.slTextBox巡检内容.Multiline = true;
            this.slTextBox巡检内容.Name = "slTextBox巡检内容";
            this.slTextBox巡检内容.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.slTextBox巡检内容.Size = new System.Drawing.Size(204, 76);
            this.slTextBox巡检内容.TabIndex = 5;
            this.slTextBox巡检内容.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label巡检内容
            // 
            this.label巡检内容.AutoSize = true;
            this.label巡检内容.Location = new System.Drawing.Point(59, 75);
            this.label巡检内容.Name = "label巡检内容";
            this.label巡检内容.Size = new System.Drawing.Size(104, 19);
            this.label巡检内容.TabIndex = 4;
            this.label巡检内容.Text = "巡检内容：";
            // 
            // slTextBox巡检部位
            // 
            this.slTextBox巡检部位.BeforeFormatControlTextHandler = null;
            this.slTextBox巡检部位.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox巡检部位.FieldName = "巡检部位";
            this.slTextBox巡检部位.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox巡检部位.Location = new System.Drawing.Point(507, 28);
            this.slTextBox巡检部位.Name = "slTextBox巡检部位";
            this.slTextBox巡检部位.Size = new System.Drawing.Size(204, 28);
            this.slTextBox巡检部位.TabIndex = 3;
            this.slTextBox巡检部位.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label巡检部位
            // 
            this.label巡检部位.AutoSize = true;
            this.label巡检部位.Location = new System.Drawing.Point(413, 33);
            this.label巡检部位.Name = "label巡检部位";
            this.label巡检部位.Size = new System.Drawing.Size(104, 19);
            this.label巡检部位.TabIndex = 2;
            this.label巡检部位.Text = "巡检部位：";
            // 
            // slTextBox巡检部位编码
            // 
            this.slTextBox巡检部位编码.BeforeFormatControlTextHandler = null;
            this.slTextBox巡检部位编码.DataType = SLControls.SLGlobal.SleDataType.String;
            this.slTextBox巡检部位编码.FieldName = "巡检部位编码";
            this.slTextBox巡检部位编码.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.slTextBox巡检部位编码.Location = new System.Drawing.Point(152, 28);
            this.slTextBox巡检部位编码.Name = "slTextBox巡检部位编码";
            this.slTextBox巡检部位编码.ReadOnly = true;
            this.slTextBox巡检部位编码.Size = new System.Drawing.Size(204, 28);
            this.slTextBox巡检部位编码.TabIndex = 1;
            this.slTextBox巡检部位编码.TextStyle = SLControls.SLStyle.INVALID;
            // 
            // label巡检部位编码
            // 
            this.label巡检部位编码.AutoSize = true;
            this.label巡检部位编码.Location = new System.Drawing.Point(21, 33);
            this.label巡检部位编码.Name = "label巡检部位编码";
            this.label巡检部位编码.Size = new System.Drawing.Size(142, 19);
            this.label巡检部位编码.TabIndex = 0;
            this.label巡检部位编码.Text = "巡检部位编码：";
            // 
            // dlg巡检标准编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 373);
            this.CloseFormAfterNew = true;
            this.Controls.Add(this.groupBox巡检信息);
            this.Name = "dlg巡检标准编辑";
            slcFieldInfo1.KeyName = "IsEnabled";
            slcFieldInfo1.KeyType = SLControls.SLGlobal.SleDataType.Digit;
            slcFieldInfo1.KeyValue = null;
            slcFieldInfo1.OperatorMode = SLControls.SLGlobal.SleOperatorMode.ReadWrite;
            this.OtherFields.Add(slcFieldInfo1);
            this.Text = "巡检标准";
            this.AfterFillControls += new SLControls.AfterFillControlsHandler(this.dlg巡检标准编辑_AfterFillControls);
            this.PreOK += new SLControls.PreOKHandler(this.dlg巡检标准编辑_PreOK);
            this.Load += new System.EventHandler(this.dlg巡检标准编辑_Load);
            this.Controls.SetChildIndex(this.groupBox巡检信息, 0);
            this.Controls.SetChildIndex(this.button确定, 0);
            this.Controls.SetChildIndex(this.button取消, 0);
            this.groupBox巡检信息.ResumeLayout(false);
            this.groupBox巡检信息.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox巡检信息;
        private System.Windows.Forms.Label label巡检部位;
        private SLControls.SLTextBox slTextBox巡检部位编码;
        private System.Windows.Forms.Label label巡检部位编码;
        private SLControls.SLTextBox slTextBox巡检类型;
        private System.Windows.Forms.Label label巡检类型;
        private SLControls.SLTextBox slTextBox巡检内容;
        private System.Windows.Forms.Label label巡检内容;
        private SLControls.SLTextBox slTextBox巡检部位;
        private SLControls.SLComboBox slComboBox周期单位;
        private System.Windows.Forms.Label label周期单位;
        private SLControls.SLTextBox slTextBox巡检周期;
        private System.Windows.Forms.Label label巡检周期;
        private SLControls.SLTextBox slTextBox提前提醒天数;
        private System.Windows.Forms.Label label提前提醒天数;
        private SLControls.SLTextBox slTextBox判断标准;
        private System.Windows.Forms.Label label判断标准;
        private SLControls.SLDateTimePicker slDateTimePicker开始执行日期;
        private System.Windows.Forms.Label label开始执行日期;
        private System.Windows.Forms.Label label启用状态;
        private System.Windows.Forms.CheckBox checkBox启用状态;
    }
}