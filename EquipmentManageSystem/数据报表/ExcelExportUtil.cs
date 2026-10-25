﻿﻿﻿﻿﻿﻿﻿﻿﻿using EquipmentManageSystem.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.数据报表
{
    /// <summary>
    /// Excel导出工具类（负责报表导出）
    /// </summary>
    public static class ExcelExportUtil
    {
        /// <summary>
        /// 导出数据为Excel
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="fileName">导出文件名</param>
        /// <param name="aggregates">导出额外信息配置</param>
        /// <param name="queryData">数据查询数据（这里主要获取其中的日期信息）</param>
        public static void ExportDataAsExcel(DataTable dt, string fileName, List<AggregateConfig> aggregates, QueryData queryData)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                PopUpUtil.ShowInfo("没有数据需要导出！");
                return;
            }

            if(!dt.Columns.Contains("组织") || !dt.Columns.Contains("部门"))
            {
                throw new Exception("数据源中必须包含组织、部门两列！");
            }

            // 获取数据列
            var dataColumns = dt.Columns.Cast<DataColumn>()
                                .Where(c => c.ColumnName != "组织" && c.ColumnName != "部门")
                                .ToArray();

            // 进行分组
            var groupData = dt.AsEnumerable()
             .OrderBy(row => row["组织"])
             .ThenBy(row => row["部门"])
             .GroupBy(row => row["组织"].ToString())
             .Select(orgGroup => new
             {
                 OrgName = orgGroup.Key,
                 Departments = orgGroup.GroupBy(row => row["部门"].ToString())
                     .Select(deptGroup => new
                     {
                         DeptName = deptGroup.Key,
                         Rows = deptGroup.ToList()
                     })
             })
             .ToList();

            CreateExcel(fileName, groupData, dataColumns, aggregates, queryData);
        }

        /// <summary>
        /// 创建Excel文件并写入数据
        /// </summary>
        private static void CreateExcel(
            string fileName,
            dynamic groupData,
            DataColumn[] dataColumns,
            List<AggregateConfig> aggregates,
            QueryData queryData)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                // 创建工作表
                string sheetName = $"{queryData.StartTime:yyyyMMdd}-{queryData.EndTime:yyyyMMdd}";
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);

                // 写入日期范围
                worksheet.Cells[1, 1].Value = $"日期时间：{queryData.StartTime:yyyy-MM-dd HH:mm:ss} 至 {queryData.EndTime:yyyy-MM-dd HH:mm:ss}";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 12;
                // 合并第1行的所有列
                int totalCols = 2 + dataColumns.Length; // 组织 + 部门 + 数据列
                worksheet.Cells[1, 1, 1, totalCols].Merge = true;

                //写入表头
                worksheet.Cells[2, 1].Value = "组织";
                worksheet.Cells[2, 2].Value = "部门";
                for (int i = 0; i < dataColumns.Length; i++)
                {
                    worksheet.Cells[2, 3 + i].Value = dataColumns[i].ColumnName;
                }
                // 设置表头样式
                SetHeaderStyle(worksheet, totalCols);

                // 4. 从第3行开始写入数据
                int currentRow = 3;
                WriteData(worksheet, groupData, dataColumns, aggregates, ref currentRow);

                // 5. 自动调整列宽
                AutoFitColumns(worksheet, totalCols, currentRow - 1);

                // 6. 弹出保存对话框
                SaveExcel(package, fileName);
            }
        }

        /// <summary>
        /// 自动调整列宽（处理合并单元格的情况）
        /// </summary>
        private static void AutoFitColumns(ExcelWorksheet worksheet, int startCol, int endRow)
        {
            int totalCols = worksheet.Dimension.Columns;

            for (int col = 1; col <= totalCols; col++)
            {
                double maxWidth = 0;

                // 遍历该列的所有行，计算最大宽度
                for (int row = 1; row <= endRow; row++)
                {
                    var cell = worksheet.Cells[row, col];
                    if (cell.Value != null)
                    {
                        string text = cell.Value.ToString();
                        double width = text.Length;

                        // 中文字符按2个宽度计算
                        foreach (char c in text)
                        {
                            if (c > 127) width += 1;
                        }

                        if (width > maxWidth)
                        {
                            maxWidth = width;
                        }
                    }
                }

                // 组织列和部门列设置固定最小宽度，数据列使用原来的逻辑
                if (col == 1) // 组织列
                {
                    maxWidth = Math.Max(15, Math.Min(30, maxWidth));
                }
                else if (col == 2) // 部门列
                {
                    maxWidth = Math.Max(15, Math.Min(35, maxWidth));
                }
                else // 数据列
                {
                    maxWidth = Math.Max(10, Math.Min(50, maxWidth));
                }

                // 额外增加2个字符的边距
                worksheet.Column(col).Width = maxWidth + 2;
            }
        }

        /// <summary>
        /// 设置表头样式
        /// </summary>
        private static void SetHeaderStyle(ExcelWorksheet worksheet, int totalCols)
        {
            var headerRange = worksheet.Cells[2, 1, 2, totalCols];
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Font.Color.SetColor(System.Drawing.Color.White);
            headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 102, 204)); // 蓝色背景
            headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            headerRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        }

        /// <summary>
        /// 弹出保存对话框并保存Excel
        /// </summary>
        private static void SaveExcel(ExcelPackage package, string fileName)
        {
            using (System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog())
            {
                saveDialog.Filter = "Excel文件|*.xlsx";
                saveDialog.FileName = fileName;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        package.SaveAs(new System.IO.FileInfo(saveDialog.FileName));
                        PopUpUtil.ShowInfo("导出成功！");
                    }
                    catch (System.InvalidOperationException)
                    {
                        // 文件被占用，自动生成带序号的文件名
                        string newPath = GetUniqueFileName(saveDialog.FileName);
                        package.SaveAs(new System.IO.FileInfo(newPath));
                        PopUpUtil.ShowInfo($"文件已被占用，已保存为：{System.IO.Path.GetFileName(newPath)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        PopUpUtil.ShowError("导出失败：" + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 生成唯一的文件名（当文件被占用时）
        /// </summary>
        private static string GetUniqueFileName(string originalPath)
        {
            string directory = System.IO.Path.GetDirectoryName(originalPath);
            string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(originalPath);
            string extension = System.IO.Path.GetExtension(originalPath);

            int counter = 1;
            string newPath;

            do
            {
                newPath = System.IO.Path.Combine(directory, $"{fileNameWithoutExt}({counter}){extension}");
                counter++;
            }
            while (System.IO.File.Exists(newPath) || IsFileInUse(newPath));

            return newPath;
        }

        /// <summary>
        /// 检查文件是否被占用
        /// </summary>
        private static bool IsFileInUse(string filePath)
        {
            // 文件不存在，未被占用
            if (!System.IO.File.Exists(filePath))
            {
                return false;
            }

            try
            {
                using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None))
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// 写入数据和聚合行
        /// </summary>
        private static void WriteData(
            ExcelWorksheet worksheet,
            dynamic groupData,
            DataColumn[] dataColumns,
            List<AggregateConfig> aggregates,
            ref int currentRow)
        {
            foreach (var org in groupData)
            {
                int orgStartRow = currentRow; // 记录组织开始行号

                foreach (var dept in org.Departments)
                {
                    int deptStartRow = currentRow; // 记录部门开始行号

                    //  写入部门的所有数据行
                    foreach (var row in dept.Rows)
                    {
                        // 写入组织列
                        worksheet.Cells[currentRow, 1].Value = org.OrgName;
                        // 写入部门列
                        worksheet.Cells[currentRow, 2].Value = dept.DeptName;
                        // 写入数据列（从第3列开始）
                        for (int i = 0; i < dataColumns.Length; i++)
                        {
                            var value = row[dataColumns[i]];
                            // 处理DateTime类型，避免Excel显示为序列号
                            if (value is DateTime dateTime)
                            {
                                worksheet.Cells[currentRow, 3 + i].Value = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                worksheet.Cells[currentRow, 3 + i].Value = value;
                            }
                        }
                        currentRow++;
                    }

                    //  写入聚合行
                    if (aggregates != null && aggregates.Count > 0)
                    {
                        // 写入聚合行的组织和部门列
                        worksheet.Cells[currentRow, 1].Value = org.OrgName;
                        worksheet.Cells[currentRow, 2].Value = dept.DeptName + "（小计）";
                        
                        WriteAggregateRow(worksheet, currentRow, aggregates, dept.Rows);
                        currentRow++;
                    }

                    // 合并部门单元格
                    if (currentRow - deptStartRow > 1)
                    {
                        worksheet.Cells[$"B{deptStartRow}:B{currentRow - 1}"].Merge = true;
                        worksheet.Cells[$"B{deptStartRow}:B{currentRow - 1}"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    }
                }

                // 合并组织单元格
                if (currentRow - orgStartRow > 1)
                {
                    worksheet.Cells[$"A{orgStartRow}:A{currentRow - 1}"].Merge = true;
                    worksheet.Cells[$"A{orgStartRow}:A{currentRow - 1}"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                }
            }
        }

        /// <summary>
        /// 写入聚合行
        /// </summary>
        private static void WriteAggregateRow(ExcelWorksheet worksheet,int row,List<AggregateConfig> aggregates,List<DataRow> deptRows)
        {
            // 遍历所有聚合配置
            for (int i = 0; i < aggregates.Count; i++)
            {
                var config = aggregates[i];

                // 计算聚合值
                object value = config.CustomCalculateFunc(deptRows);

                // 写入Excel
                int col = 3 + i;
                worksheet.Cells[row, col].Value = $"{config.DisplayName}: {value}";

                // 设置聚合行样式
                worksheet.Cells[row, col].Style.Font.Bold = true;
                worksheet.Cells[row, col].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[row, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(242, 242, 242)); // 浅灰色背景
                worksheet.Cells[row, col].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            }
        }
    }
}