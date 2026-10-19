﻿﻿﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备维修
{
    public static class GridInit
    {
        /// <summary>
        /// 初始化维修记录表格
        /// </summary>
        /// <param name="dataGridView">显示数据的网格对象</param>
        public static void InitRepairRecordGrid(DataGridView dataGridView)
        {
            dataGridView.AutoGenerateColumns = false;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ScrollBars = ScrollBars.Both;
            dataGridView.ReadOnly = true;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.MultiSelect = false;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = GetRepairRecordDataTable();
            SetRepairRecordStyle(dataGridView);

            // 选中后立即取消，避免高亮，仅作展示
            bool suppressing = false;
            dataGridView.SelectionChanged += (sender, args) =>
            {
                if (suppressing)
                    return;
                if (dataGridView.SelectedCells.Count > 0)
                {
                    suppressing = true;
                    dataGridView.ClearSelection();
                    suppressing = false;
                }
            };
        }

        /// <summary>
        /// 获取维修记录数据结构
        /// </summary>
        /// <returns>维修记录表格结构</returns>
        private static DataTable GetRepairRecordDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("维修人", typeof(string));
            dt.Columns.Add("维修结果", typeof(string));
            dt.Columns.Add("维修开始时间", typeof(DateTime));
            dt.Columns.Add("维修结束时间", typeof(DateTime));
            dt.Columns.Add("维修备注信息", typeof(string));
            dt.Columns.Add("故障原因", typeof(string));
            dt.Columns.Add("处理方案", typeof(string));
            dt.Columns.Add("验收人", typeof(string));
            dt.Columns.Add("验收时间", typeof(DateTime));
            dt.Columns.Add("验收结果", typeof(string));
            dt.Columns.Add("重新维修原因", typeof(string));

            return dt;
        }

        /// <summary>
        /// 设置维修记录表格样式
        /// </summary>
        /// <param name="dataGridView">显示数据的网格对象</param>
        private static void SetRepairRecordStyle(DataGridView dataGridView)
        {
            // 维修人
            DataGridViewTextBoxColumn colRepairPerson = new DataGridViewTextBoxColumn();
            colRepairPerson.Name = "维修人";
            colRepairPerson.HeaderText = "维修人";
            colRepairPerson.DataPropertyName = "维修人";
            colRepairPerson.Width = 120;
            dataGridView.Columns.Add(colRepairPerson);

            // 维修结果
            DataGridViewTextBoxColumn colRepairResult = new DataGridViewTextBoxColumn();
            colRepairResult.Name = "维修结果";
            colRepairResult.HeaderText = "维修结果";
            colRepairResult.DataPropertyName = "维修结果";
            colRepairResult.Width = 120;
            dataGridView.Columns.Add(colRepairResult);

            // 维修开始时间
            DataGridViewTextBoxColumn colStartTime = new DataGridViewTextBoxColumn();
            colStartTime.Name = "维修开始时间";
            colStartTime.HeaderText = "维修开始时间";
            colStartTime.DataPropertyName = "维修开始时间";
            colStartTime.Width = 200;
            colStartTime.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView.Columns.Add(colStartTime);

            // 维修结束时间
            DataGridViewTextBoxColumn colEndTime = new DataGridViewTextBoxColumn();
            colEndTime.Name = "维修结束时间";
            colEndTime.HeaderText = "维修结束时间";
            colEndTime.DataPropertyName = "维修结束时间";
            colEndTime.Width = 200;
            colEndTime.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView.Columns.Add(colEndTime);

            // 维修备注信息
            DataGridViewTextBoxColumn colRemark = new DataGridViewTextBoxColumn();
            colRemark.Name = "维修备注信息";
            colRemark.HeaderText = "维修备注信息";
            colRemark.DataPropertyName = "维修备注信息";
            colRemark.Width = 150;
            dataGridView.Columns.Add(colRemark);

            // 故障原因
            DataGridViewTextBoxColumn colFault = new DataGridViewTextBoxColumn();
            colFault.Name = "故障原因";
            colFault.HeaderText = "故障原因";
            colFault.DataPropertyName = "故障原因";
            colFault.Width = 150;
            dataGridView.Columns.Add(colFault);

            // 处理方案
            DataGridViewTextBoxColumn colSolution = new DataGridViewTextBoxColumn();
            colSolution.Name = "处理方案";
            colSolution.HeaderText = "处理方案";
            colSolution.DataPropertyName = "处理方案";
            colSolution.Width = 150;
            dataGridView.Columns.Add(colSolution);

            // 验收人
            DataGridViewTextBoxColumn colAcceptPerson = new DataGridViewTextBoxColumn();
            colAcceptPerson.Name = "验收人";
            colAcceptPerson.HeaderText = "验收人";
            colAcceptPerson.DataPropertyName = "验收人";
            colAcceptPerson.Width = 120;
            dataGridView.Columns.Add(colAcceptPerson);

            // 验收时间
            DataGridViewTextBoxColumn colAcceptTime = new DataGridViewTextBoxColumn();
            colAcceptTime.Name = "验收时间";
            colAcceptTime.HeaderText = "验收时间";
            colAcceptTime.DataPropertyName = "验收时间";
            colAcceptTime.Width = 200;
            colAcceptTime.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView.Columns.Add(colAcceptTime);

            // 验收结果
            DataGridViewTextBoxColumn colAcceptResult = new DataGridViewTextBoxColumn();
            colAcceptResult.Name = "验收结果";
            colAcceptResult.HeaderText = "验收结果";
            colAcceptResult.DataPropertyName = "验收结果";
            colAcceptResult.Width = 120;
            dataGridView.Columns.Add(colAcceptResult);

            // 重新维修原因
            DataGridViewTextBoxColumn colReRepair = new DataGridViewTextBoxColumn();
            colReRepair.Name = "重新维修原因";
            colReRepair.HeaderText = "重新维修原因";
            colReRepair.DataPropertyName = "重新维修原因";
            colReRepair.Width = 150;
            dataGridView.Columns.Add(colReRepair);
        }
    }
}