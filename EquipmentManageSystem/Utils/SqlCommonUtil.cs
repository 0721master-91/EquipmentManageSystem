using EquipmentManageSystem.模板.导入导出模板;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.Utils
{
    public static class SqlCommonUtil
    {
        /// <summary>
        /// 按类型格式化 SQL 值（数字不加引号，字符串加引号，NULL 不加）
        /// </summary>
        /// <param Name="value">初始值</param>
        /// <returns>拼接SQL的最终值</returns>
        public static string FormatSqlValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return "NULL";
            if (value is int || value is decimal || value is long ||
                value is double || value is float || value is short || value is byte)
                return value.ToString();  // 数字不加引号
            return $"'{value.ToString().Replace("'", "''")}'";  // 字符串加引号
        }

        /// <summary>
        /// 根据字段类型转换原始字符串值
        /// </summary>
        /// <param Name="value"></param>
        /// <param Name="type"></param>
        /// <returns>根据类型转换后的值，如果转换失败则返回 DBNull.Value</returns>
        public static object ConvertRawValueByType(string value, StoreFieldType type)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;
            switch (type)
            {
                case StoreFieldType.Int:
                    if (int.TryParse(value, out int intVal))
                        return intVal;
                    return DBNull.Value;
                case StoreFieldType.Decimal:
                    if (decimal.TryParse(value, out decimal decVal))
                        return decVal;
                    return DBNull.Value;
                case StoreFieldType.DateTime:
                    if (DateTime.TryParse(value, out DateTime dtVal))
                        return dtVal;
                    return DBNull.Value;
                case StoreFieldType.Boolean:
                    if (value == "1" || value == "是" || value == "true")
                        return 1;
                    return 0;
                default:
                    return value;
            }

        }

        /// <summary>
        /// 批量格式化值列表，拼成 SQL IN 子句用的逗号分隔字符串
        /// </summary>
        /// <param Name="values">值列表（支持任意类型）</param>
        /// <returns>逗号分隔的格式化字符串，如 'A','B','C' 或 1,2,3</returns>
        public static string FormatSqlValueList(IEnumerable<object> values)
        {
            return string.Join(",", values.Select(v => FormatSqlValue(v)));
        }

        /// <summary>
        /// 将 DataTable 的两列转换为 Dictionary
        /// </summary>
        /// <param Name="table">数据源</param>
        /// <param Name="keyColumn">作为 key 的列名</param>
        /// <param Name="valueColumn">作为 value 的列名</param>
        /// <returns>key-value 映射字典</returns>
        public static Dictionary<string, string> DataTableToDict(DataTable table, string keyColumn, string valueColumn)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string line = "";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    line += table.Rows[i][j]?.ToString() + "\t";
                }
                System.Diagnostics.Debug.WriteLine(line);
            }

            foreach (DataRow row in table.Rows)
            {
                string key = row[keyColumn].ToString();
                object val = row[valueColumn];
                result[key] = (val == null || val == DBNull.Value) ? null : val.ToString();

            }
            return result;
        }

        /// <summary>
        /// 将字典合并到主表数据中（以某列为 key 匹配，添加新列）
        /// </summary>
        /// <param Name="mainTable">主表数据</param>
        /// <param Name="values">要合并的字典（key=条件值, value=附加值）</param>
        /// <param Name="newColumnName">新列名</param>
        /// <param Name="conditionField">主表中用于匹配 key 的列名</param>
        public static void MergeDictToTable(DataTable mainTable, Dictionary<string, string> values, string newColumnName, string conditionField)
        {
            if (mainTable == null || values == null || values.Count == 0)
                return;
            mainTable.Columns.Add(newColumnName, typeof(string));
            foreach (DataRow row in mainTable.Rows)
            {
                string key = row[conditionField]?.ToString();
                if (key != null && values.ContainsKey(key))
                    row[newColumnName] = values[key];
                // key 不在字典中则不赋值，保持 DBNull
            }
        }

        /// <summary>
        /// 生成编码（前缀+日期+序号）
        /// </summary>
        /// <param Name="prefix">编码前缀</param>
        /// <param Name="tableName">目标表名</param>
        /// <param Name="codeField">编码字段</param>
        /// <param Name="dateForma">日期格式默认为 yyyyMMdd</param>
        /// <returns></returns>
        public static string GenerateCode(string prefix,string tableName,string codeField,string dateForma = "yyyyMMdd")
        {
            string today = DateTime.Now.ToString(dateForma);
            string likePattern = prefix + today + "%";

            // 查询当天全部编码
            string sql = string.Format("select {0} from {1} where {0} like '{2}'", codeField, tableName, likePattern);
            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;
            DataTable dt = services.ExecuteForDataTable(sql);


            int maxNum = 1;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string code = row[0].ToString();
                    string seqPart = code.Substring(prefix.Length + today.Length);
                
                    if (int.TryParse(seqPart, out int num) && num > maxNum)
                    {
                        maxNum = num;
                    }
                }

                maxNum += 1;// 有数据，就在最后面加上1
            }

            
            string finalNum = maxNum <= 999 ? maxNum.ToString("D3") : maxNum.ToString();

            return prefix + today + finalNum;
        }
     }
}
