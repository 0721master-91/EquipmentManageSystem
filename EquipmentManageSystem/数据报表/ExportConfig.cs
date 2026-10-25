using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.数据报表
{
    /// <summary>
    /// 导出配置
    /// </summary>
    public static class ExportConfig
    {
        /// <summary>
        /// 获取聚合配置
        /// </summary>
        /// <param name="exportDataType">导出数据板块类型</param>
        /// <returns></returns>
        public static List<AggregateConfig> GetAggregateConfig(ExportDataType exportDataType)
        {
            switch (exportDataType)
            {
                case ExportDataType.EquipmentStatus:
                    return GetEquipmentStatusConfig();
                case ExportDataType.WorkLoad:
                    return GetWorkLoadConfig();
                case ExportDataType.BillSummary:
                    return GetBillSummaryConfig();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 获取账单汇总导出配置
        /// </summary>
        /// <returns></returns>
        private static List<AggregateConfig> GetBillSummaryConfig()
        {
            return new List<AggregateConfig>
            {
                AggregateConfig.CreateCount("总数")
            };
        }

        /// <summary>
        /// 获取设备状态导出配置
        /// </summary>
        /// <returns></returns>
        private static List<AggregateConfig> GetEquipmentStatusConfig()
        {
            return new List<AggregateConfig>
            {
                AggregateConfig.CreateCustom("正常运行", rows =>
                {
                    DataRow row = rows[0];
                    int count = row["正常运行"] == DBNull.Value ? 0 : Convert.ToInt32(row["正常运行"]);
                    int total = rows.Sum(r => r["总数"] == DBNull.Value ? 0 : Convert.ToInt32(r["总数"]));
                    double percent = total == 0 ? 0 : (double)count / total * 100;
                    return percent.ToString("0.##") + "%";
                }),
                AggregateConfig.CreateCustom("维修中", rows =>
                {
                    DataRow row = rows[0];
                    int count = row["维修中"] == DBNull.Value ? 0 : Convert.ToInt32(row["维修中"]);
                    int total = rows.Sum(r => r["总数"] == DBNull.Value ? 0 : Convert.ToInt32(r["总数"]));
                    double percent = total == 0 ? 0 : (double)count / total * 100;
                    return percent.ToString("0.##") + "%";
                }),
                AggregateConfig.CreateCustom("停用或异常", rows =>
                {
                    DataRow row = rows[0];
                    int count = row["停机或异常"] == DBNull.Value ? 0 : Convert.ToInt32(row["停机或异常"]);
                    int total = rows.Sum(r => r["总数"] == DBNull.Value ? 0 : Convert.ToInt32(r["总数"]));
                    double percent = total == 0 ? 0 : (double)count / total * 100;
                    return percent.ToString("0.##") + "%";
                }),
                AggregateConfig.CreateCustom("其他", rows =>
                {
                    DataRow row = rows[0];
                    int count = row["其他"] == DBNull.Value ? 0 : Convert.ToInt32(row["其他"]);
                    int total = rows.Sum(r => r["总数"] == DBNull.Value ? 0 : Convert.ToInt32(r["总数"]));
                    double percent = total == 0 ? 0 : (double)count / total * 100;
                    return percent.ToString("0.##") + "%";
                })
            };
        }

        /// <summary>
        /// 获取工作量导出配置
        /// </summary>
        /// <returns></returns>
        private static List<AggregateConfig> GetWorkLoadConfig()
        {
            return new List<AggregateConfig>
            {
                AggregateConfig.CreateCustom("保养合计", rows =>
                {
                    int count = 0;
                    foreach (DataRow row in rows)
                    {
                        count += row["保养"] == DBNull.Value ? 0 : Convert.ToInt32(row["保养"]);
                    }
                    return count.ToString();
                }),
                AggregateConfig.CreateCustom("巡检合计", rows =>
                {
                    int count = 0;
                    foreach (DataRow row in rows)
                    {
                        count += row["巡检"] == DBNull.Value ? 0 : Convert.ToInt32(row["巡检"]);
                    }
                    return count.ToString();
                }),
                AggregateConfig.CreateCustom("维修合计", rows =>
                {
                    int count = 0;
                    foreach (DataRow row in rows)
                    {
                        count += row["维修"] == DBNull.Value ? 0 : Convert.ToInt32(row["维修"]);
                    }
                    return count.ToString();
                }),
                AggregateConfig.CreateCustom("合计", rows =>
                {
                    int count = 0;
                    foreach (DataRow row in rows)
                    {
                        count += row["总数量"] == DBNull.Value ? 0 : Convert.ToInt32(row["总数量"]);
                    }
                    return count.ToString();
                })
            };
        }

    }
}
