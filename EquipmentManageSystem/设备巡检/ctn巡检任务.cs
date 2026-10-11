﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备巡检
{
    public partial class ctn巡检任务 : temp标准基本信息GridControl
    {
        public ctn巡检任务()
        {
            InitializeComponent();
        }


        private void ctn巡检任务_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg巡检任务编辑);

            CommonFilter.InitCombox(this.comboBox执行状态,"状态","编码","执行状态");
            CommonFilter.InitCombox(this.comboBox过期状态, "状态", "编码", "过期状态");
        }

        private bool ctn巡检任务_BeforeChangeDataSource()
        {
            TaskStatusManager.UpdateInspectionTaskExpiredStatus(); // 每次查询前先更新一下过期状态

            string sql = "select t.ID,t.巡检任务编码,p.功能位置编码,p.功能位置描述,p.位置简称,d.部门名称 as 设备管理部门,m.姓名 as 设备负责人,dbo.fn_GetMemberNamesByIds(t.巡检人员IDs) as 巡检人员," +
                         "dbo.fn_GetMemberNamesByIds(t.任务接取人ID) as 任务接取人员,t.计划执行日期,t.巡检开始时间,t.巡检结束时间,t.故障现象,es.状态 as 执行状态,os.状态 as 过期状态,t.创建时间 " +
                         "from 巡检任务 as t " + 
                         "left join 设备功能位置档案 as p on t.设备功能位置编码 = p.功能位置编码 " +
                         "left join 部门 as d on p.管理部门编码 = d.部门编码 " + 
                         "left join 成员 as m on p.责任人ID = m.ID " +
                         "left join 执行状态 as es on t.执行状态编码 = es.编码 " +
                         "left join 过期状态 as os on t.过期状态编码 = os.编码 " +
                         "where t.IsDelete = 0";

            object executeStatusObj = this.comboBox执行状态.SelectedValue;
            string executeStatus = executeStatusObj == null ? "" : executeStatusObj.ToString();
            if (!string.IsNullOrEmpty(executeStatus))
            {
                sql += " and t.执行状态编码 = '" + executeStatus + "'";
            }

            object overStatusObj = this.comboBox过期状态.SelectedValue;
            string overStatus = overStatusObj == null ? "" : overStatusObj.ToString();
            if (!string.IsNullOrEmpty(overStatus))
            {
                sql += " and t.过期状态编码 = '" + overStatus + "'";
            }

            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn巡检任务_AfterChangeDataSource(DataTable newTable)
        {
            var colStartDate =  this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检开始时间");
            colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            var colEndDate = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检结束时间");
            colEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colEndDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }

        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();
            if (this.CurrentDataSource == null)
            {
                PopUpUtil.ShowInfo("请先点击「刷新」加载数据");
                return;
            }
            if (string.IsNullOrEmpty(keyword))
            {
                // 关键词为空就显示全部数据
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "巡检任务编码 LIKE '%{0}%' OR 功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' OR 设备管理部门 LIKE '%{0}%' " +
                    "OR 设备负责人 LIKE '%{0}%' OR 巡检人员 LIKE '%{0}%' OR 任务接取人员 LIKE '%{0}%' OR 故障现象 LIKE '%{0}%' OR 执行状态 LIKE '%{0}%' OR 过期状态 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void slFlatButton导入_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            using(dlg巡检任务导出 dlg = new dlg巡检任务导出(outData))
            {
                dlg.ShowDialog();
            }
            this.RefreshData();
        }
    }
}