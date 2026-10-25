using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.数据报表
{
    /// <summary>
    ///  导出入口，由该类开始导出数据的整体逻辑
    /// </summary>
    public class ExportEntrance
    {

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="queryData">查询条件</param>
        /// <param name="type">导出数据板块类型</param>
        /// <param name="isExportNull">是否导出空数据</param>
        /// <param name="dt">导出数据(这里为了为了单据板块可以直接传入数据，不用再去查询了)</param>
        /// <param name="fileName">导出文件名</param>
        public void ExportData(QueryData queryData, ExportDataType type, bool isExportNull = false, DataTable data = null,string fileName = null)
        {
            DataTable dt = null;
            switch (type)
            {
                case ExportDataType.EquipmentStatus:
                    dt = this.GetEquipmentStatusData(queryData, isExportNull);
                    break;
                case ExportDataType.WorkLoad:
                    dt = this.GetWorkLoadData(queryData, isExportNull);
                    break;
                case ExportDataType.BillSummary:
                    dt = data;
                    break;
            }

            if (dt != null)
            {
                var aggregates = ExportConfig.GetAggregateConfig(type);
                fileName = string.IsNullOrEmpty(fileName) ? this.GetFileName(type) : fileName;
                ExcelExportUtil.ExportDataAsExcel(dt, fileName, aggregates,queryData);
            }
            else
            {
                PopUpUtil.ShowInfo("没有数据导出！");
            }
        }

        private string GetFileName(ExportDataType type)
        {
            string fileName = string.Empty;
            switch (type)
            {
                case ExportDataType.EquipmentStatus:
                    fileName = "设备状态数据导出";
                    break;
                case ExportDataType.WorkLoad:
                    fileName = "工作量数据导出";
                    break;
                case ExportDataType.BillSummary:
                    fileName = "单据汇总数据导出";
                    break;
            }
            return fileName;
        }

        /// <summary>
        /// 获取设备状态数据
        /// </summary>
        /// <param name="queryData"></param>
        /// <param name="isExportNull"></param>
        /// <returns></returns>
        private DataTable GetEquipmentStatusData(QueryData queryData, bool isExportNull)
        {
            string sql = "select o.组织名称 as 组织, d.部门名称 as 部门, " +
                            "count(p.ID) as 总数, " +
                            "sum(case when p.设备状态编码 = 'NORMAL' then 1 else 0 end) as 正常运行, " +
                            "sum(case when p.设备状态编码 = 'REPAIRING' then 1 else 0 end) as 维修中, " +
                            "sum(case when p.设备状态编码 in ('ABNORMAL','DEACTIVATE') then 1 else 0 end) as 停机或异常, " +
                            "sum(case when p.设备状态编码 = 'SCRAP' then 1 else 0 end) as 其他 " +
                         "from 组织 as o " +
                         "join 部门 as d on o.组织编码 = d.组织编码 " +
                         "left join 设备功能位置档案 as p on d.部门编码 = p.管理部门编码 and p.IsDelete = 0 " +
                         "where 1=1 ";

            if (!string.IsNullOrEmpty(queryData.OrgCode))
            {
                sql += "and o.组织编码 = '" + queryData.OrgCode + "' ";

                if (!string.IsNullOrEmpty(queryData.DepCode))
                {
                    sql += "and d.部门编码 = '" + queryData.DepCode + "' ";
                }
            }
            sql += "group by o.组织名称, d.部门名称, o.组织编码, d.部门编码 ";
            if (!isExportNull)
            {
                sql += "having count(p.ID) > 0 ";
            }
            sql += "order by o.组织编码, d.部门编码";

            return SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
        }

        /// <summary>
        /// 获取工作量数据
        /// </summary>
        /// <param name="queryData"></param>
        /// <param name="isExportNull"></param>
        /// <returns></returns>
        private DataTable GetWorkLoadData(QueryData queryData, bool isExportNull)
        {
            string orgCode = SqlCommonUtil.FormatSqlValue(queryData.OrgCode);
            string depCode = SqlCommonUtil.FormatSqlValue(queryData.DepCode);
            string startTime = SqlCommonUtil.FormatSqlValue(queryData.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string endTime = SqlCommonUtil.FormatSqlValue(queryData.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));

            string sql = "exec sp_GetWorkLoad " + orgCode + "," + depCode + "," + startTime + "," + endTime;
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            if (!isExportNull)
            {
                dt = dt.AsEnumerable()
                       .Where(row => row["姓名"] != DBNull.Value && row["姓名"] != null)
                       .CopyToDataTable();
            }

            return dt;
        }
    }
}
