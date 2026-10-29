using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.系统管理
{
    /// <summary>
    /// 任务生成
    /// </summary>
    public static class TaskAutoGenerate
    {
        /// <summary>
        /// 生成任务
        /// </summary>
        public static void Execute()
        {
            PopUpUtil.ShowInfo("开始生成任务");
            GenerateInspectionTask();
            GenerateMaintenanceTask();
            PopUpUtil.ShowInfo("任务生成完成");
        }

        /// <summary>
        /// 生成巡检任务
        /// </summary>
        private static void GenerateInspectionTask()
        {
            DataTable config = GetConfig(TaskType.INSPECTION);
            DataRow row = config == null || config.Rows.Count == 0 ? null : config.Rows[0];
            if (!IsCreateTask(row)) return;
            InspectionTaskGenerate.GenerateInspectionTask();
        }

        /// <summary>
        /// 生成保养任务
        /// </summary>
        private static void GenerateMaintenanceTask()
        {
            DataTable config = GetConfig(TaskType.MAINTENANCE);
            DataRow row = config == null || config.Rows.Count == 0 ? null : config.Rows[0];
            Console.WriteLine(IsCreateTask(row));
            if (!IsCreateTask(row)) return;
            MaintenanceTaskGenerate.GenerateMaintenanceTask();
        }

        /// <summary>
        /// 获取任务生成配置
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        private static DataTable GetConfig(string taskType = null)
        {
            string sql = "select top 1 c.配置编码,c.执行日期,c.日期类型编码,c.数据源编码,c.适用范围编码,cds.优先级 " +
                         "from 任务生成配置 as c " +
                         "join 日期类型 as dt on c.日期类型编码 = dt.编码 " +
                         "join 配置数据源 as cds on c.数据源编码 = cds.编码 " +
                         "join 配置适用范围 as caa on c.适用范围编码 = caa.编码 " +
                         "where c.IsDelete = 0 " +
                            "and caa.编码 in ('ALL', '" + taskType + "') " +
                            "and c.执行日期 = cast(getDate() as date) " +
                         "order by cds.优先级 ";
            Console.WriteLine(sql);
            return SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

        }

        /// <summary>
        /// 判断是否应当生成任务
        /// </summary>
        /// <param name="row">配置数据行</param>
        /// <returns>是否生成</returns>
        private static bool IsCreateTask(DataRow row)
        {
            if(row != null)
            {
                if (row["日期类型编码"]?.ToString() == "WORKDAY")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DateTime today = DateTime.Today;
                bool isWeekend = today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday;
                if (isWeekend)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }



        /// <summary>
        /// 获取保养任务标准
        /// </summary>
        /// <returns></returns>
        private static DataTable GetMaintenanceTaskStandard()
        {
            string sql = "select mp.ID,mp.功能位置单据号,mp.保养内容,gt.类型 as 给油类型,rt.方式 as 润换方式,mp.润滑脂型号,cu.单位名称 as 周期单位,mp.提前提醒天数,mp.开始执行日期 " +
                         "from 设备保养计划 as mp " +
                         "join 设备功能位置档案 as p on mp.功能位置单据号 = p.单据号 " +
                         "left join 给油类型 as gt on gt.编码 = gt.给油类型编码 " +
                         "left join 润换方式 as rt on rt.编码 = mp.润换方式编码 " +
                         "left join 周期单位 as cu on cu.单位编码 = mp.周期单位编码 " +
                         "where mp.IsDelete = 0 " +
                            "and mp.开始执行日期 = getDate() " +
                            "and p.IsDelete = 0 ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt != null)
            {
                dt.Columns.Add("下次执行日期", typeof(DateTime));
                foreach (DataRow row in dt.Rows)
                {
                    string cycleCode = row["周期单位"].ToString();
                    decimal cycle = Convert.ToDecimal(row["周期"]);
                    row["下次执行日期"] = CalculateUtil.CalculateNextDateTime(DateTime.Today, cycle, cycleCode);
                }
            }
            return dt;
        }
    }

    public static class TaskType
    {
        public static string ALL = "ALL"; // 查询时包含所有类型
        public static string INSPECTION = "INSPECTION";
        public static string MAINTENANCE = "MAINTENANCE";

    }
}
