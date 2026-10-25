﻿﻿using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.数据报表
{
    public partial class uc设备总体概况人员工作量 : UserControl
    {
        private QueryData QueryDataInfo;

        public uc设备总体概况人员工作量()
        {
            InitializeComponent();
        }

        private void button人员工作量导出_Click(object sender, EventArgs e)
        {
            using(dlg导出 dlg = new dlg导出() 
            {
                QueryDataInfo = this.QueryDataInfo,
                Type = ExportDataType.WorkLoad,
            })
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 加载柱状图
        /// </summary>
        /// <param name="queryData">查询参数</param>
        /// <param name="panel">承载柱状图容器</param>
        public void LoadBarChart(QueryData queryData)
        {
            this.QueryDataInfo = queryData;
            DataTable dt = this.GetBarChartData(queryData);
            this.GenerateBarChart(dt, this.panel柱状图内容区);
        }

        /// <summary>
        /// 获取柱状图数据
        /// </summary>
        /// <param name="queryData">查询参数</param>
        /// <returns></returns>
        private DataTable GetBarChartData(QueryData queryData)
        {
            string orgCode = SqlCommonUtil.FormatSqlValue(queryData.OrgCode);
            string depCode = SqlCommonUtil.FormatSqlValue(queryData.DepCode);
            string startTime = SqlCommonUtil.FormatSqlValue(queryData.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string endTime = SqlCommonUtil.FormatSqlValue(queryData.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));

            string sql = "exec sp_GetWorkLoad " + orgCode +","+ depCode + "," + startTime + "," + endTime;

            Console.WriteLine(sql);
            return SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
        }

        /// <summary>
        /// 生成柱状图
        /// </summary>
        /// <param name="dt">柱状图数据</param>
        /// <param name="panel">承载柱状图容器</param>
        private void GenerateBarChart(DataTable dt, Panel panel)
        {


            var chart = new ChartControl();

            var seriesMaintenance = new Series("保养", ViewType.Bar);
            var seriesRepair = new Series("维修", ViewType.Bar);
            var seriesInspect = new Series("巡检", ViewType.Bar);

            // 绑定数据
            seriesMaintenance.DataSource = dt;
            seriesMaintenance.ArgumentDataMember = "姓名";
            seriesMaintenance.ValueDataMembers.AddRange("保养");

            seriesRepair.DataSource = dt;
            seriesRepair.ArgumentDataMember = "姓名";
            seriesRepair.ValueDataMembers.AddRange("维修");

            seriesInspect.DataSource = dt;
            seriesInspect.ArgumentDataMember = "姓名";
            seriesInspect.ValueDataMembers.AddRange("巡检");

            // 设置颜色
            Color[] colors = { Color.SpringGreen, Color.Orange, Color.Red };

            // 设置标签样式
            foreach (var series in new[] { seriesMaintenance,seriesRepair, seriesInspect })
            {
                series.LabelsVisibility = DefaultBoolean.True;
                var label = (BarSeriesLabel)series.Label;
                label.Position = BarSeriesLabelPosition.Center;
                label.TextPattern = "{V}";
                label.Font = new Font("黑体", 10F, FontStyle.Bold);
                label.TextColor = Color.White;
                label.Antialiasing = true;
                label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
                label.BackColor = Color.Transparent;
                label.Border.Visibility = DefaultBoolean.False;  // 隐藏标签边框
            }

            // 自定义颜色
            chart.CustomDrawSeriesPoint += (s, e) =>
            {
                if (e.Series.Name == "保养") e.SeriesPoint.Color = colors[0];
                else if (e.Series.Name == "巡检") e.SeriesPoint.Color = colors[1];
                else if (e.Series.Name == "维修") e.SeriesPoint.Color = colors[2];
            };

            chart.Series.Add(seriesMaintenance);
            chart.Series.Add(seriesInspect);
            chart.Series.Add(seriesRepair);

            // 图表样式
            chart.Legend.Visible = false;
            chart.Legend.Direction = LegendDirection.TopToBottom;
            chart.BorderOptions.Visible = false;
            chart.Dock = DockStyle.Fill;

            panel.Controls.Clear();
            panel.Controls.Add(chart);
        }
    }
}