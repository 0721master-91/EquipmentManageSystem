using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.系统管理
{
    public static class MaintenanceTaskGenerate
    {
        /// <summary>
        /// 保养任务生成
        /// </summary>
        public static void GenerateMaintenanceTask()
        {
            DataTable dt = GetMaintenanceTaskStandard();
            if (dt == null || dt.Rows.Count == 0) return;

            Console.WriteLine("保养任务生成开始");
            Console.WriteLine("dt.Rows.Count = " + dt.Rows.Count);
            var groups = dt.Rows.Cast<DataRow>().GroupBy(r => r["功能位置单据号"].ToString());
            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            services.BeginTran();
            try
            {
                foreach (var group in groups)
                {
                    string billCode = group.Key;
                    string positionCode = group.First()["功能位置编码"].ToString();

                    if (ExistMaintenanceTask(billCode, positionCode)) continue;
                    InsertMaintenanceTask(group);
                }
                services.Commit();
            }
            catch (Exception ex)
            {
                PopUpUtil.ShowError(ex.Message);
                services.RollBack();
            }
            Console.WriteLine("保养任务生成结束");
        }

        /// <summary>
        /// 获取保养任务标准
        /// </summary>
        /// <returns></returns>
        private static DataTable GetMaintenanceTaskStandard()
        {
            string sql = "select mp.ID,mp.功能位置单据号,p.功能位置编码,p.维保人员IDs,mp.保养内容,gt.类型 as 给油类型,rt.方式 as 润换方式,mp.润滑脂型号,mp.执行周期,cu.单位名称 as 周期单位,mp.提前提醒天数,mp.开始执行日期 as 保养开始日期 " +
                         "from 设备保养计划 as mp " +
                         "join 设备功能位置档案 as p on mp.功能位置单据号 = p.单据号 " +
                         "left join 给油类型 as gt on gt.编码 = mp.给油类型编码 " +
                         "left join 润换方式 as rt on rt.编码 = mp.润换方式编码 " +
                         "left join 周期单位 as cu on cu.单位编码 = mp.周期单位编码 " +
                         "where mp.IsDelete = 0 " +
                            "and mp.开始执行日期 = cast(getDate() as date) " +
                            "and p.IsDelete = 0 ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt != null)
            {
                dt.Columns.Add("下次保养日期", typeof(DateTime));
                foreach (DataRow row in dt.Rows)
                {
                    string cycleCode = row["周期单位"].ToString();
                    decimal cycle = Convert.ToDecimal(row["执行周期"]);
                    DateTime startDate = Convert.ToDateTime(row["保养开始日期"]);
                    row["下次保养日期"] = CalculateUtil.CalculateNextDateTime(startDate, cycle, cycleCode);
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断保养任务是否存在
        /// </summary>
        /// <param name="billCode">设备功能位置单据号</param>
        /// <param name="positionCode">功能位置编码</param>
        /// <returns></returns>
        private static bool ExistMaintenanceTask(string billCode, string positionCode)
        {
            string sql = "select count(*) " +
                         "from 保养任务 " +
                         "where IsDelete = 0 " +
                            "and 设备功能位置编码 = '" + positionCode + "' " +
                            "and 上游单据号 = '" + billCode + "' " +
                            "and 计划执行日期 = cast(getDate() as date) ";
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForInt(sql);
            return num == 0 ? false : true;
        }

        /// <summary>
        /// 插入保养任务
        /// </summary>
        private static void InsertMaintenanceTask(IGrouping<string, DataRow> group)
        {
            DataRow row = group.First();
            string billCodeSource = SqlCommonUtil.GenerateCode("BYRW", "保养任务", "保养任务编码");
            string billCode = SqlCommonUtil.FormatSqlValue(billCodeSource);
            string memberID = UserSession.CurrentUser.MemberID.ToString();
            string expireTime = SqlCommonUtil.FormatSqlValue(Convert.ToDateTime(row["下次保养日期"]).Date.AddHours(-6).AddMinutes(-30));
            string positionCode = SqlCommonUtil.FormatSqlValue(row["功能位置编码"]);
            string billType = SqlCommonUtil.FormatSqlValue("保养任务");
            string billSource = SqlCommonUtil.FormatSqlValue("设备功能位置档案");
            string upBillCode = SqlCommonUtil.FormatSqlValue(row["功能位置单据号"]);
            string executeDate = SqlCommonUtil.FormatSqlValue(row["保养开始日期"]);
            string memberIDs = SqlCommonUtil.FormatSqlValue(row["维保人员IDs"]);
            string startTime = SqlCommonUtil.FormatSqlValue(Convert.ToDateTime(row["保养开始日期"]).Date.AddHours(8).AddMinutes(30));

            string sql = string.Format("insert into 保养任务(创建人,保养任务编码,单据类型,单据来源,上游单据号,过期时间,设备功能位置编码,计划执行日期,保养人员IDs,保养开始时间,最后修改人) " +
                                       "values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",
                                       memberID,billCode,billType,billSource,upBillCode,expireTime,positionCode,executeDate,memberIDs,startTime,memberID);
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("自动生成保养任务失败！");

            InsertMaintenanceDetail(group, billCodeSource);
            UpdateMaintenanceTaskStandard(group);
        }

        private static readonly string[] MaintenanceDetailColumns =
        {
            "所属保养任务编码", "保养内容", "给油类型", "润换方式", "润滑脂型号","执行周期", "周期单位", "保养开始日期", "下次保养日期"
        };

        private static void InsertMaintenanceDetail(IGrouping<string, DataRow> group, string inspectionTaskCode)
        {
            if (!group.Any()) return;

            List<string> valueRows = group.Select(row =>
                "(" + string.Join(",", MaintenanceDetailColumns.Select(col =>
                    col == "所属保养任务编码"
                        ? SqlCommonUtil.FormatSqlValue(inspectionTaskCode)
                        : SqlCommonUtil.FormatSqlValue(row[col]))) + ")")
                .ToList();

            string sql = "insert into 保养任务标准(" + string.Join(",", MaintenanceDetailColumns) + ") values " + string.Join(",", valueRows);
            Console.WriteLine(sql);
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("自动生成巡检任务标准失败");
        }

        private static void UpdateMaintenanceTaskStandard(IGrouping<string, DataRow> group)
        {
            foreach (DataRow row in group)
            {
                string sql = "update 设备保养计划 set 开始执行日期 = '" + row["下次保养日期"] + "' where ID = '" + row["ID"] + "'";
                int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
                if (num <= 0) throw new Exception("更新设备保养计划失败");
            }
        }
    }
}
