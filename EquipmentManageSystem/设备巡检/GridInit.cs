﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备巡检
{
    public static class GridInit
    {
        /// <summary>
        /// 初始化巡检任务标准表格
        /// </summary>InspectionStandards
        public static void InitInspectionTaskStandardGrid(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.Columns.Clear();

            dataGridView.DataSource = GetInspectionTaskStandardDataTable();
            SetInspectionTaskStandardStyle(dataGridView);
        }

        private static DataTable GetInspectionTaskStandardDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("巡检部位", typeof(string));
            dt.Columns.Add("巡检内容", typeof(string));
            dt.Columns.Add("判断标准", typeof(string));
            dt.Columns.Add("巡检类型", typeof(string));
            dt.Columns.Add("巡检周期", typeof(decimal));
            dt.Columns.Add("周期单位", typeof(string));
            dt.Columns.Add("提前提醒天数", typeof(int));
            dt.Columns.Add("开始执行日期", typeof(DateTime));
            dt.Columns.Add("下次执行日期", typeof(DateTime));
            dt.Columns.Add("ID", typeof(long));
            return dt;
        }

        private static void SetInspectionTaskStandardStyle(DataGridView dtv)
        {
            // 巡检部位
            DataGridViewTextBoxColumn colPart = new DataGridViewTextBoxColumn();
            colPart.Name = "巡检部位";
            colPart.HeaderText = "巡检部位";
            colPart.DataPropertyName = "巡检部位";
            colPart.Width = 150;  
            dtv.Columns.Add(colPart);

            // 巡检内容
            DataGridViewTextBoxColumn colContent = new DataGridViewTextBoxColumn();
            colContent.Name = "巡检内容";
            colContent.HeaderText = "巡检内容";
            colContent.DataPropertyName = "巡检内容";
            colContent.Width = 200;
            dtv.Columns.Add(colContent);

            // 判断标准
            DataGridViewTextBoxColumn colJudge = new DataGridViewTextBoxColumn();
            colJudge.Name = "判断标准";
            colJudge.HeaderText = "判断标准";
            colJudge.DataPropertyName = "判断标准";
            colJudge.Width = 200;
            dtv.Columns.Add(colJudge);

            // 巡检类型
            DataGridViewTextBoxColumn colType = new DataGridViewTextBoxColumn();
            colType.Name = "巡检类型"; 
            colType.HeaderText = "巡检类型";
            colType.DataPropertyName = "巡检类型"; 
            colType.Width = 120; 
            colType.ReadOnly = true;
            dtv.Columns.Add(colType);

            // 巡检周期
            DataGridViewTextBoxColumn colCycle = new DataGridViewTextBoxColumn();
            colCycle.Name = "巡检周期";
            colCycle.HeaderText = "巡检周期";
            colCycle.DataPropertyName = "巡检周期";
            colCycle.Width = 120;
            colCycle.ReadOnly = true;
            colCycle.DefaultCellStyle.Format = "0.00";
            dtv.Columns.Add(colCycle);

            // 周期单位
            DataGridViewTextBoxColumn colUnit = new DataGridViewTextBoxColumn();
            colUnit.Name = "周期单位"; 
            colUnit.HeaderText = "周期单位";
            colUnit.DataPropertyName = "周期单位";
            colUnit.Width = 120; 
            colUnit.ReadOnly = true;
            dtv.Columns.Add(colUnit);

            // 提前提醒天数
            DataGridViewTextBoxColumn colRemind = new DataGridViewTextBoxColumn();
            colRemind.Name = "提前提醒天数"; 
            colRemind.HeaderText = "提前提醒天数";
            colRemind.DataPropertyName = "提前提醒天数"; 
            colRemind.Width = 160; 
            colRemind.ReadOnly = true;
            colRemind.DefaultCellStyle.Format = "0"; 
            dtv.Columns.Add(colRemind);

            // 开始执行日期
            DataGridViewTextBoxColumn colStart = new DataGridViewTextBoxColumn();
            colStart.Name = "开始执行日期"; 
            colStart.HeaderText = "开始执行日期";
            colStart.DataPropertyName = "开始执行日期"; 
            colStart.Width = 150;
            colStart.DefaultCellStyle.Format = "yyyy-MM-dd"; 
            colStart.ReadOnly = true;
            dtv.Columns.Add(colStart);

            DataGridViewTextBoxColumn colNext = new DataGridViewTextBoxColumn();
            colNext.Name = "下次执行日期";
            colNext.HeaderText = "下次执行日期";
            colNext.DataPropertyName = "下次执行日期";
            colNext.Width = 150;
            colNext.DefaultCellStyle.Format = "yyyy-MM-dd";
            colNext.ReadOnly = true;
            dtv.Columns.Add(colNext);
        }
    }
}