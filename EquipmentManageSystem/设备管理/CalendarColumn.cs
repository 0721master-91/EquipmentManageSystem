using System;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备管理
{
    /// <summary>
    /// DataGridView 日期选择列
    /// </summary>
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell()) { }
    }

    /// <summary>
    /// 日期单元格
    /// </summary>
    public class CalendarCell : DataGridViewTextBoxCell
    {
        public override Type EditType => typeof(CalendarEditingControl);
        public override Type ValueType => typeof(DateTime);
        public override object DefaultNewRowValue => DateTime.Now;
    }

    /// <summary>
    /// 日期编辑控件（DateTimePicker）
    /// </summary>
    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        int rowIndex;
        bool valueChanged;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "yyyy-MM-dd";   // 只显示年月日，不显示时间
            this.ShowUpDown = false;            // 保持下拉日历模式
        }

        public object EditingControlFormattedValue
        {
            get => this.Value.ToShortDateString();
            set { if (value is string s) this.Value = DateTime.Parse(s); }
        }
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
            => this.Value.ToShortDateString();

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get => dataGridView;
            set => dataGridView = value;
        }
        public int EditingControlRowIndex
        {
            get => rowIndex;
            set => rowIndex = value;
        }
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
            => key == Keys.Left || key == Keys.Right || key == Keys.Up || key == Keys.Down ||
               key == Keys.Home || key == Keys.End || key == Keys.PageDown || key == Keys.PageUp;

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange => false;

        public bool EditingControlValueChanged
        {
            get => valueChanged;
            set => valueChanged = value;
        }

        public Cursor EditingPanelCursor => throw new NotImplementedException();

        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueChanged = true;
            this.EditingControlDataGridView?.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}