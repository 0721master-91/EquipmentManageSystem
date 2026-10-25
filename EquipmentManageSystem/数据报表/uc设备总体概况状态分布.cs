﻿﻿﻿﻿﻿﻿﻿﻿﻿using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.数据报表
{
    public partial class uc设备总体概况状态分布 : UserControl
    {
        private QueryData QueryDataInfo;

        public uc设备总体概况状态分布()
        {
            InitializeComponent();
        }

        private void button人员工作量导出_Click(object sender, EventArgs e)
        {
            using (dlg导出 dlg = new dlg导出()
            {
                QueryDataInfo = this.QueryDataInfo,
                Type = ExportDataType.EquipmentStatus
            })
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 加载饼图
        /// </summary>
        /// <param name="queryData">查询条件数据</param>
        /// <param name="panel">加载饼图的容器</param>
        public DataTable LoadPieChart(QueryData queryData)
        {
            DataTable dt = this.GetPieChartData(queryData);
            this.QueryDataInfo = queryData;
            this.GeneratePieChart(dt, this.panel饼状图区);
            return dt;
        }

        /// <summary>
        /// 获取饼图数据
        /// </summary>
        /// <param name="queryData">查询条件数据</param>
        /// <returns></returns>
        private DataTable GetPieChartData(QueryData queryData)
        {
            string sql = "select sum(case when 设备状态编码 = 'NORMAL' then 1 else 0 end) as 正常运行, " +
                                "sum(case when 设备状态编码 = 'REPAIRING' then 1 else 0 end) as 维修中, " +
                                "sum(case when 设备状态编码 in ('ABNORMAL','DEACTIVATE') then 1 else 0 end) as 停机或异常, " +
                                "sum(case when 设备状态编码 = 'SCRAP' then 1 else 0 end) as 其他 " +
                         "from 设备功能位置档案 " +
                         "where IsDelete = 0 ";
            if(!string.IsNullOrEmpty(queryData.OrgCode))
            {
                sql += "and 组织编码 = '" + queryData.OrgCode + "' ";

                if (!string.IsNullOrEmpty(queryData.DepCode))
                {
                    sql += "and 管理部门编码 = '" + queryData.DepCode + "' ";
                }
            }

            return SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
        }

        /// <summary>
        /// 生成饼图
        /// </summary>
        /// <param name="dt">饼图数据</param>
        /// <param name="panel">承载饼图容器</param>
        private void GeneratePieChart(DataTable dt, Panel panel)
        {
            var chart = new ChartControl();
            var series = new Series("状态统计", ViewType.Doughnut);
            Color[] colors = { Color.MediumSpringGreen, Color.Orange, Color.Red, Color.Beige };

            DataTable pieData = new DataTable();
            pieData.Columns.Add("状态", typeof(string));
            pieData.Columns.Add("数量", typeof(int));

            bool isEmpty = (dt == null || dt.Rows.Count == 0);

            DataRow row = dt.Rows[0];
            int totalCount = this.CalculateTotalCount(row);

            // 如果总数为0，也显示暂无数据
            if (totalCount == 0)
            {
                pieData.Rows.Add("暂无数据", 1);
                chart.Titles.Add(new ChartTitle { Text = "暂无数据" });
            }
            else
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    int count = row[dc] == DBNull.Value ? 0 : Convert.ToInt32(row[dc]);
                    pieData.Rows.Add(dc.ColumnName, count);
                    this.UpdateRatio(dc.ColumnName, count, totalCount);
                }
            }

            // 这里加入总数，外面获取时不用再计算
            dt.Columns.Add("总数", typeof(int));
            dt.Rows[0]["总数"] = totalCount;

            series.DataSource = pieData;
            series.ArgumentDataMember = "状态";
            series.ValueDataMembers.AddRange("数量");

            // 标签样式
            var pieLabel = (PieSeriesLabel)series.Label;
            pieLabel.Position = PieSeriesLabelPosition.Radial;
            pieLabel.TextPattern = "{V}";
            pieLabel.Border.Visibility = DefaultBoolean.False;
            pieLabel.BackColor = Color.Transparent;
            pieLabel.Font = new Font("黑体", 14F, FontStyle.Bold);
            pieLabel.TextColor = Color.White;
            pieLabel.Antialiasing = true;
            pieLabel.ResolveOverlappingMode = ResolveOverlappingMode.Default;

            //颜色分配
            chart.CustomDrawSeriesPoint += (s, e) =>
            {
                if (e.SeriesPoint.Argument == "暂无数据")
                {
                    e.SeriesPoint.Color = Color.Silver;
                    return;
                }

                string arg = e.SeriesPoint.Argument;
                // 按 pieData 行顺序查找 Argument 对应的颜色索引
                for (int i = 0; i < pieData.Rows.Count && i < colors.Length; i++)
                {
                    if (pieData.Rows[i]["状态"].ToString() == arg)
                    {
                        e.SeriesPoint.Color = colors[i];
                        break;
                    }
                }
            };

            chart.Legend.Visible = false;
            chart.BorderOptions.Visible = false;
            ((DoughnutSeriesView)series.View).Border.Visibility = DefaultBoolean.False;
            series.ToolTipEnabled = DefaultBoolean.True;
            series.ToolTipPointPattern = "{A}：{V}";

            // 如果是暂无数据，隐藏标签
            if (isEmpty || (pieData.Rows.Count == 1 && pieData.Rows[0]["状态"].ToString() == "暂无数据"))
            {
                series.LabelsVisibility = DefaultBoolean.False;
                series.ToolTipPointPattern = "{A}：0";
            }

            chart.Series.Add(series);
            panel.Controls.Clear();
            chart.Dock = DockStyle.Fill;
            panel.Controls.Add(chart);
        }

        private int CalculateTotalCount(DataRow row)
        {
            int normalCount = row["正常运行"] == DBNull.Value ? 0 : Convert.ToInt32(row["正常运行"]);
            int maintenanceCount = row["维修中"] == DBNull.Value ? 0 : Convert.ToInt32(row["维修中"]);
            int stopCount = row["停机或异常"] == DBNull.Value ? 0 : Convert.ToInt32(row["停机或异常"]);
            int otherCount = row["其他"] == DBNull.Value ? 0 : Convert.ToInt32(row["其他"]);
            return normalCount + maintenanceCount + stopCount + otherCount;
        }

        private void UpdateRatio(string colName, int count, int totalCount)
        {
            double percent = (double)count / totalCount * 100;
            string percentStr = percent.ToString("0.##") + "%";

            string labelName = "label" + colName + "比例";
            Label label = (Label)this.panel注释区.Controls.Find(labelName, true)[0];
            label.Text = percentStr;
        }
    }
}