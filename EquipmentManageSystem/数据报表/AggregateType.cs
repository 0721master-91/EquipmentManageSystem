using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.数据报表
{
    /// <summary>
    /// 聚合计算类型
    /// </summary>
    public enum AggregateType
    {
        /// <summary>
        /// 计数
        /// </summary>
        Count,

        /// <summary>
        /// 求和
        /// </summary>
        Sum,

        /// <summary>
        /// 平均值
        /// </summary>
        Average,

        /// <summary>
        /// 自定义计算
        /// </summary>
        Custom
    }

    /// <summary>
    /// 聚合计算配置
    /// </summary>
    public class AggregateConfig
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// 聚合类型
        /// </summary>
        public AggregateType Type;

        /// <summary>
        /// 计算列名（用于Count、Sum、Average）
        /// </summary>
        public string ColumnName;
        /// <summary>
        /// 自定义计算函数（当Type=Custom时使用）
        /// 传入部门所有数据行，返回计算结果
        /// </summary>
        public Func<List<DataRow>, object> CustomCalculateFunc;

        /// <summary>
        /// 创建计数聚合配置
        /// </summary>
        /// <param name="displayName">显示名称</param>
        /// <param name="columnName">计数的列名</param>
        /// <returns></returns>
        public static AggregateConfig CreateCount(string displayName, string columnName = null)
        {
            return new AggregateConfig
            {
                DisplayName = displayName,
                Type = AggregateType.Count,
                ColumnName = columnName,
                CustomCalculateFunc = rows => rows.Count
            };
        }

        /// <summary>
        /// 创建求和聚合配置
        /// </summary>
        /// <param name="displayName">显示名称</param>
        /// <param name="columnName">求和的列名</param>
        /// <returns></returns>
        public static AggregateConfig CreateSum(string displayName, string columnName)
        {
            return new AggregateConfig
            {
                DisplayName = displayName,
                Type = AggregateType.Sum,
                ColumnName = columnName,
                CustomCalculateFunc = rows =>
                {
                    double sum = 0;
                    foreach (var row in rows)
                    {
                        if (row[columnName] != DBNull.Value)
                        {
                            sum += Convert.ToDouble(row[columnName]);
                        }
                    }
                    return sum;
                }
            };
        }

        /// <summary>
        /// 创建平均值聚合配置
        /// </summary>
        /// <param name="displayName">显示名称</param>
        /// <param name="columnName">计算平均值的列名</param>
        /// <returns></returns>
        public static AggregateConfig CreateAverage(string displayName, string columnName)
        {
            return new AggregateConfig
            {
                DisplayName = displayName,
                Type = AggregateType.Average,
                ColumnName = columnName,
                CustomCalculateFunc = rows =>
                {
                    var validRows = new List<double>();
                    foreach (var row in rows)
                    {
                        if (row[columnName] != DBNull.Value)
                        {
                            validRows.Add(Convert.ToDouble(row[columnName]));
                        }
                    }
                    return validRows.Count == 0 ? "-" : validRows.Average().ToString("F2");
                }
            };
        }

        /// <summary>
        /// 创建自定义聚合配置
        /// </summary>
        /// <param name="displayName">显示名称</param>
        /// <param name="calculateFunc">自定义计算函数</param>
        /// <returns></returns>
        public static AggregateConfig CreateCustom(string displayName, Func<List<DataRow>, object> calculateFunc)
        {
            return new AggregateConfig
            {
                DisplayName = displayName,
                Type = AggregateType.Custom,
                CustomCalculateFunc = calculateFunc
            };
        }
    }
}
