using EquipmentManageSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.系统管理
{
    /// <summary>
    /// 巡检任务生成
    /// </summary>
    public static class InspectionTaskGenerate
    {
        public static void GenerateInspectionTask()
        {
            DataTable dt = GetInspectionTaskStandard();
            if (dt == null || dt.Rows.Count == 0) return;

            var groups = dt.Rows.Cast<DataRow>().GroupBy(r => r["功能位置单据号"].ToString());
            var services = SLControls.SLDbService.SLOnlyInstOleDb.Services;

            services.BeginTran();
            try
            {
                foreach (var group in groups)
                {
                    string billCode = group.Key;
                    string positionCode = group.First()["功能位置编码"].ToString();

                    if (ExistInspectionTask(billCode, positionCode)) continue;
                    InsertInspectionTask(group);
                }
                services.Commit();
            }
            catch (Exception ex)
            {
                PopUpUtil.ShowError(ex.Message);
                services.RollBack();
            }

        }

        /// <summary>
        /// 获取巡检任务标准
        /// </summary>
        /// <returns></returns>
        private static DataTable GetInspectionTaskStandard()
        {
            string sql = "select ip.ID,ip.功能位置单据号,p.功能位置编码,p.巡检人员IDs,ip.巡检部位,ip.巡检内容,ip.巡检类型,ip.判断标准,ip.巡检周期,cu.单位名称 as 周期单位,ip.提前提醒天数,ip.开始执行日期 " +
                         "from 设备巡检计划 as ip " +
                         "join 设备功能位置档案 as p on ip.功能位置单据号 = p.单据号 " +
                         "left join 周期单位 as cu on cu.单位编码 = ip.周期单位编码 " +
                         "where ip.IsDelete = 0 " +
                            "and p.IsDelete = 0 " +
                            "and ip.开始执行日期 = cast(getDate() as date) ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt != null)
            {
                dt.Columns.Add("下次执行日期", typeof(DateTime));
                foreach (DataRow row in dt.Rows)
                {
                    string cycleCode = row["周期单位"].ToString();
                    decimal cycle = Convert.ToDecimal(row["巡检周期"]);
                    DateTime startDate = Convert.ToDateTime(row["开始执行日期"]);
                    row["下次执行日期"] = CalculateUtil.CalculateNextDateTime(startDate, cycle, cycleCode);
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断巡检任务是否存在
        /// </summary>
        /// <param name="billCode">设备功能位置单据号</param>
        /// <param name="positionCode">功能位置编码</param>
        /// <returns></returns>
        private static bool ExistInspectionTask(string billCode,string positionCode)
        {
            string sql = "select count(*) " +
                         "from 巡检任务 " +
                         "where IsDelete = 0 " +
                            "and 设备功能位置编码 = '" + positionCode + "' " +
                            "and 上游单据号 = '" + billCode + "' " +
                            "and 计划执行日期 = cast(getDate() as date) ";
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForInt(sql);
            return num == 0 ? false : true;
        }

        /// <summary>
        /// 插入巡检任务
        /// </summary>
        private static void InsertInspectionTask(IGrouping<string, DataRow> group)
        {
            DataRow row = group.First();
            string billCodeSource = SqlCommonUtil.GenerateCode("XJRW", "巡检任务", "巡检任务编码");
            string billCode = SqlCommonUtil.FormatSqlValue(billCodeSource);
            string memberID = UserSession.CurrentUser.MemberID.ToString();
            string positionCode = SqlCommonUtil.FormatSqlValue(row["功能位置编码"]);
            string billType = SqlCommonUtil.FormatSqlValue("巡检任务");
            string billSource = SqlCommonUtil.FormatSqlValue("设备功能位置档案");
            string upBillCode = SqlCommonUtil.FormatSqlValue(row["功能位置单据号"]);
            string expiretime = SqlCommonUtil.FormatSqlValue(Convert.ToDateTime(row["下次执行日期"]).Date.AddHours(-6).AddMinutes(-30));
            string executeDate = SqlCommonUtil.FormatSqlValue(row["开始执行日期"]);
            string memberIDs = SqlCommonUtil.FormatSqlValue(row["巡检人员IDs"]);
            DateTime time = Convert.ToDateTime(row["开始执行日期"]).Date.AddHours(8).AddMinutes(30);
            string startTime = SqlCommonUtil.FormatSqlValue(time);
            string remindDays = SqlCommonUtil.FormatSqlValue(row["提前提醒天数"]);

            string sql = string.Format("insert into 巡检任务(创建人,巡检任务编码,单据类型,单据来源,上游单据号,过期时间,设备功能位置编码,计划执行日期,巡检人员IDs,巡检开始时间,提前提醒天数,最后修改人) " +
                                       "values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11})",
                                        memberID, billCode, billType, billSource, upBillCode, expiretime, positionCode, executeDate, memberIDs, startTime, remindDays, memberID);
            Console.WriteLine(sql);
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("自动生成巡检任务失败");

            InsertInspectionTaskDetail(group, billCodeSource);
            UpdateInspectionTaskStandard(group);
        }

        private static readonly string[] InspectionDetailColumns =
        {
            "所属巡检任务编码", "巡检部位", "巡检内容", "巡检类型", "判断标准",
            "巡检周期", "周期单位", "提前提醒天数", "开始执行日期", "下次执行日期"
        };

        private static void InsertInspectionTaskDetail(IGrouping<string, DataRow> group, string inspectionTaskCode)
        {
            if (!group.Any()) return;

            List<string> valueRows = group.Select(row =>
                "(" + string.Join(",", InspectionDetailColumns.Select(col =>
                    col == "所属巡检任务编码"
                        ? SqlCommonUtil.FormatSqlValue(inspectionTaskCode)
                        : SqlCommonUtil.FormatSqlValue(row[col]))) + ")")
                .ToList();

            string sql = "insert into 巡检任务标准(" + string.Join(",", InspectionDetailColumns) + ") values " + string.Join(",", valueRows);
            Console.WriteLine(sql);
            int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
            if (num <= 0) throw new Exception("自动生成巡检任务标准失败");
        }

        private static void UpdateInspectionTaskStandard(IGrouping<string, DataRow> group)
        {
            foreach (DataRow row in group)
            {
                string sql = "update 设备巡检计划 set 开始执行日期 = '" + row["下次执行日期"] + "' where ID = '" + row["ID"]  + "'";
                int num = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
                if (num <= 0) throw new Exception("更新设备巡检计划失败");
            }
        }
    }
}