﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备管理
{

    /// <summary>
    /// 表格配置类
    /// </summary>
    public static class GridInit
    {

        /// <summary>
        /// 初始化巡检标准表格
        /// </summary>
        /// <param Name="dataGridView"></param>
        public static void InitInspectionStandardsGrid(DataGridView dataGridView)
        {

            // 设置DataGridView
            dataGridView.AutoGenerateColumns = false; // 禁用自动生成列
            dataGridView.AllowUserToAddRows = false;   // 禁止底部自动出现"新行"
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter; // 立刻进入编辑模式
            dataGridView.Columns.Clear();

            // 创建数据源并绑定
            DataTable dt = GetInspectionStandardsDataTable();
            dataGridView.DataSource = dt;

            // 设置列样式
            SetInspectionStandardsStyle(dataGridView);
        }

        /// <summary>
        /// 设置巡检标准表格样式
        /// </summary>
        /// <returns></returns>
        private static void SetInspectionStandardsStyle(DataGridView dtv)
        {

            // 巡检部位（这里采用弹窗选择的方式，方便填充数据）
            DataGridViewTextBoxColumn colInspectionPart = new DataGridViewTextBoxColumn();
            colInspectionPart.Name = "巡检部位";
            colInspectionPart.HeaderText = "巡检部位";
            colInspectionPart.DataPropertyName = "巡检部位";
            colInspectionPart.Width = 150;
            dtv.Columns.Add(colInspectionPart);

            // 巡检内容
            DataGridViewTextBoxColumn colInspectionContent = new DataGridViewTextBoxColumn();
            colInspectionContent.Name = "巡检内容";
            colInspectionContent.HeaderText = "巡检内容";
            colInspectionContent.DataPropertyName = "巡检内容";
            colInspectionContent.Width = 200;
            dtv.Columns.Add(colInspectionContent);

            // 巡检类型
            DataGridViewTextBoxColumn colInspectionType = new DataGridViewTextBoxColumn();
            colInspectionType.Name = "巡检类型";
            colInspectionType.HeaderText = "巡检类型";
            colInspectionType.DataPropertyName = "巡检类型";
            colInspectionType.Width = 120;
            dtv.Columns.Add(colInspectionType);

            // 判断标准
            DataGridViewTextBoxColumn colJudgeMark = new DataGridViewTextBoxColumn();
            colJudgeMark.Name = "判断标准";
            colJudgeMark.HeaderText = "判断标准";
            colJudgeMark.DataPropertyName = "判断标准";
            colJudgeMark.Width = 200;
            dtv.Columns.Add(colJudgeMark);

            // 提前提醒天数
            DataGridViewTextBoxColumn colRemindDays = new DataGridViewTextBoxColumn();
            colRemindDays.Name = "提前提醒天数";
            colRemindDays.HeaderText = "提前提醒天数";
            colRemindDays.DataPropertyName = "提前提醒天数";
            colRemindDays.Width = 160;
            dtv.Columns.Add(colRemindDays);

            // 巡检周期
            DataGridViewTextBoxColumn colInspectionCycle = new DataGridViewTextBoxColumn();
            colInspectionCycle.Name = "巡检周期";
            colInspectionCycle.HeaderText = "巡检周期";
            colInspectionCycle.DataPropertyName = "巡检周期";
            colInspectionCycle.Width = 120;
            dtv.Columns.Add(colInspectionCycle);

            // 周期单位
            // 目前来说有很bug，点击周期单位选择的时候会直接赋值，但不影响选择后的结果。后续考虑使用弹窗解决。
            DataGridViewComboBoxColumn colInspectionCycleUnit = new DataGridViewComboBoxColumn();
            DataTable dtCycle = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 单位编码, 单位名称 from 周期单位 where IsEnabled = 1");
            colInspectionCycleUnit.Name = "周期单位编码";
            colInspectionCycleUnit.DataPropertyName = "周期单位编码";
            colInspectionCycleUnit.HeaderText = "周期单位";
            colInspectionCycleUnit.DataSource = dtCycle;
            colInspectionCycleUnit.DisplayMember = "单位名称";
            colInspectionCycleUnit.ValueMember = "单位编码";
            colInspectionCycleUnit.Width = 100;
            dtv.Columns.Add(colInspectionCycleUnit);

            // 巡检开始日期
            CalendarColumn colInspectionStartDate = new CalendarColumn();
            colInspectionStartDate.Name = "开始执行日期";
            colInspectionStartDate.HeaderText = "开始执行日期";
            colInspectionStartDate.DataPropertyName = "开始执行日期";
            colInspectionStartDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            colInspectionStartDate.Width = 150;
            dtv.Columns.Add(colInspectionStartDate);

        }

        /// <summary>
        /// 获取巡检标准表格配置
        /// </summary>
        /// <returns></returns>
        private static DataTable GetInspectionStandardsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("巡检部位", typeof(string));
            dt.Columns.Add("巡检内容", typeof(string));
            dt.Columns.Add("巡检类型", typeof(string));
            dt.Columns.Add("判断标准", typeof(string));
            dt.Columns.Add("提前提醒天数", typeof(int));        // 整数
            dt.Columns.Add("巡检周期", typeof(decimal));        // 数字
            dt.Columns.Add("周期单位编码", typeof(string));     // 存编码
            dt.Columns.Add("开始执行日期", typeof(DateTime));   // 日期
            return dt;
        }

        /// <summary>
        /// 初始化保养标准表格
        /// </summary>
        public static void InitmaintenanceStandardsGrid(DataGridView dataGridView)
        {
            // 设置DataGridView
            dataGridView.AutoGenerateColumns = false; // 禁用自动生成列
            dataGridView.AllowUserToAddRows = false;   // 禁止底部自动出现"新行"
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter; // 立刻进入编辑模式
            dataGridView.Columns.Clear();

            // 创建数据源并绑定
            dataGridView.DataSource = GetMaintenanceStandardsDataTable();

            // 设置列样式
            IniMaintenanceStandardsGrid(dataGridView);

        }

        /// <summary>
        /// 获取保养标准表格配置
        /// </summary>
        /// <returns></returns>
        private static DataTable GetMaintenanceStandardsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("保养内容", typeof(string));
            dt.Columns.Add("给油类型编码", typeof(string));
            dt.Columns.Add("润滑脂型号", typeof(string));
            dt.Columns.Add("润换方式编码", typeof(string));
            dt.Columns.Add("执行周期", typeof(decimal));   // 改成 decimal，跟数据库实际类型一致
            dt.Columns.Add("周期单位编码", typeof(string));
            dt.Columns.Add("提前提醒天数", typeof(int));
            dt.Columns.Add("开始执行日期", typeof(DateTime));

            return dt;
        }

        /// <summary>
        /// 初始化保养标准表格
        /// </summary>
        /// <param Name="dataGridView"></param>
        private static void IniMaintenanceStandardsGrid(DataGridView dataGridView)
        {
            // 保养内容
            DataGridViewTextBoxColumn colMaintenanceContent = new DataGridViewTextBoxColumn();
            colMaintenanceContent.Name = "保养内容";
            colMaintenanceContent.HeaderText = "保养内容";
            colMaintenanceContent.DataPropertyName = "保养内容";
            colMaintenanceContent.Width = 185;
            dataGridView.Columns.Add(colMaintenanceContent);

            // 给油类型编码
            DataGridViewComboBoxColumn colOilType = new DataGridViewComboBoxColumn();
            DataTable dtOilType = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 编码,类型 from 给油类型 where IsEnabled = 1");
            colOilType.Name = "给油类型编码";
            colOilType.DataPropertyName = "给油类型编码";
            colOilType.HeaderText = "给油类型";
            colOilType.DataSource = dtOilType;
            colOilType.DisplayMember = "类型";
            colOilType.ValueMember = "编码";
            colOilType.Width = 100;
            dataGridView.Columns.Add(colOilType);

            // 润滑脂型号
            DataGridViewTextBoxColumn colLubricantModel = new DataGridViewTextBoxColumn();
            colLubricantModel.Name = "润滑脂型号";
            colLubricantModel.HeaderText = "润滑脂型号";
            colLubricantModel.DataPropertyName = "润滑脂型号";
            colLubricantModel.Width = 140;
            dataGridView.Columns.Add(colLubricantModel);

            // 润换方式编码
            DataGridViewComboBoxColumn colLubricantChangeType = new DataGridViewComboBoxColumn();
            DataTable dtLubricantChangeType = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 编码,方式  from 润换方式 where IsEnabled = 1");
            colLubricantChangeType.Name = "润换方式编码";
            colLubricantChangeType.DataPropertyName = "润换方式编码";
            colLubricantChangeType.HeaderText = "润换方式";
            colLubricantChangeType.DataSource = dtLubricantChangeType;
            colLubricantChangeType.DisplayMember = "方式";
            colLubricantChangeType.ValueMember = "编码";
            colLubricantChangeType.Width = 100;
            dataGridView.Columns.Add(colLubricantChangeType);

            // 执行周期
            DataGridViewTextBoxColumn colExecuteCycle = new DataGridViewTextBoxColumn();
            colExecuteCycle.Name = "执行周期";
            colExecuteCycle.HeaderText = "执行周期";
            colExecuteCycle.DataPropertyName = "执行周期";
            colExecuteCycle.Width = 120;
            dataGridView.Columns.Add(colExecuteCycle);

            // 周期单位编码
            DataGridViewComboBoxColumn colCycleUnit = new DataGridViewComboBoxColumn();
            DataTable dtCycleUnit = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable("select 单位编码, 单位名称 from 周期单位 where IsEnabled = 1");
            colCycleUnit.Name = "周期单位编码";
            colCycleUnit.DataPropertyName = "周期单位编码";
            colCycleUnit.HeaderText = "周期单位";
            colCycleUnit.DataSource = dtCycleUnit;
            colCycleUnit.DisplayMember = "单位名称";
            colCycleUnit.ValueMember = "单位编码";
            colCycleUnit.Width = 100;
            dataGridView.Columns.Add(colCycleUnit);

            // 提前提醒天数
            DataGridViewTextBoxColumn colRemindDays = new DataGridViewTextBoxColumn();
            colRemindDays.Name = "提前提醒天数";
            colRemindDays.HeaderText = "提前提醒天数";
            colRemindDays.DataPropertyName = "提前提醒天数";
            colRemindDays.Width = 160;
            dataGridView.Columns.Add(colRemindDays);

            // 开始执行日期
            CalendarColumn colMaintenanceStartDate = new CalendarColumn();
            colMaintenanceStartDate.Name = "开始执行日期";
            colMaintenanceStartDate.HeaderText = "开始执行日期";
            colMaintenanceStartDate.DataPropertyName = "开始执行日期";
            colMaintenanceStartDate.DefaultCellStyle.Format = "yyyy-MM-dd";
            colMaintenanceStartDate.Width = 150;
            dataGridView.Columns.Add(colMaintenanceStartDate);

        }
    }
}