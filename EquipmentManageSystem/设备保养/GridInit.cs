﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备保养
{
    public static class GridInit
    {
        
        /// <summary>
        /// 初始化设备保养标准表格
        /// </summary>
        /// <param name="dataGridView">显示数据的网格对象</param>
        public static void InitMaintenanceTaskStandardGrid(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = GetMaintenanceTaskStandardDataTable();
            SetMaintenanceTaskStandardStyle(dataGridView);
        }

        /// <summary>
        /// 初始化保养任务标准表格
        /// </summary>
        /// <returns>表格</returns>
        private static DataTable GetMaintenanceTaskStandardDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("保养内容", typeof(string));
            dt.Columns.Add("给油类型", typeof(string));
            dt.Columns.Add("润换方式", typeof(string));
            dt.Columns.Add("润滑脂型号", typeof(string));
            dt.Columns.Add("执行周期", typeof(decimal));
            dt.Columns.Add("周期单位", typeof(string));
            dt.Columns.Add("保养开始日期", typeof(DateTime));
            dt.Columns.Add("下次保养日期", typeof(DateTime));
            dt.Columns.Add("ID", typeof(long));

            return dt;
        }

        /// <summary>
        /// 设置保养任务标准表格样式
        /// </summary>
        /// <param name="dataGridView">内容显示对象</param>
        private static void SetMaintenanceTaskStandardStyle(DataGridView dataGridView)
        {
            // 保养内容
            DataGridViewTextBoxColumn colContent = new DataGridViewTextBoxColumn();
            colContent.Name = "保养内容";
            colContent.HeaderText = "保养内容";
            colContent.DataPropertyName = "保养内容";
            colContent.Width = 200;
            dataGridView.Columns.Add(colContent);

            // 给油类型
            DataGridViewTextBoxColumn colOilType = new DataGridViewTextBoxColumn();
            colOilType.Name = "给油类型";
            colOilType.HeaderText = "给油类型";
            colOilType.DataPropertyName = "给油类型";
            colOilType.Width = 120;
            dataGridView.Columns.Add(colOilType);

            // 润换类型
            DataGridViewTextBoxColumn colLubType = new DataGridViewTextBoxColumn();
            colLubType.Name = "润换方式";
            colLubType.HeaderText = "润换方式";
            colLubType.DataPropertyName = "润换方式";
            colLubType.Width = 120;
            dataGridView.Columns.Add(colLubType);

            // 润滑脂型号
            DataGridViewTextBoxColumn colGrease = new DataGridViewTextBoxColumn();
            colGrease.Name = "润滑脂型号";
            colGrease.HeaderText = "润滑脂型号";
            colGrease.DataPropertyName = "润滑脂型号";
            colGrease.Width = 150;
            dataGridView.Columns.Add(colGrease);

            // 巡检周期
            DataGridViewTextBoxColumn colCycle = new DataGridViewTextBoxColumn();
            colCycle.Name = "执行周期";
            colCycle.HeaderText = "执行周期";
            colCycle.DataPropertyName = "执行周期";
            colCycle.Width = 120;
            colCycle.ReadOnly = true;
            colCycle.DefaultCellStyle.Format = "0.00";
            dataGridView.Columns.Add(colCycle);

            // 周期单位
            DataGridViewTextBoxColumn colUnit = new DataGridViewTextBoxColumn();
            colUnit.Name = "周期单位";
            colUnit.HeaderText = "周期单位";
            colUnit.DataPropertyName = "周期单位";
            colUnit.Width = 120;
            colUnit.ReadOnly = true;
            dataGridView.Columns.Add(colUnit);

            // 保养开始日期
            DataGridViewTextBoxColumn colStart = new DataGridViewTextBoxColumn();
            colStart.Name = "保养开始日期";
            colStart.HeaderText = "保养开始日期";
            colStart.DataPropertyName = "保养开始日期";
            colStart.Width = 150;
            colStart.DefaultCellStyle.Format = "yyyy-MM-dd";
            colStart.ReadOnly = true;
            dataGridView.Columns.Add(colStart);

            // 下次保养日期
            DataGridViewTextBoxColumn colNext = new DataGridViewTextBoxColumn();
            colNext.Name = "下次保养日期";
            colNext.HeaderText = "下次保养日期";
            colNext.DataPropertyName = "下次保养日期";
            colNext.Width = 150;
            colNext.DefaultCellStyle.Format = "yyyy-MM-dd";
            colNext.ReadOnly = true;
            dataGridView.Columns.Add(colNext);
        }
    }
}