using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Utils
{
    public static class CalculateUtil
    {
        /// <summary>
        /// 计算下一个时间
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="cycle">周期</param>
        /// <param name="cycleUnit">周期单位</param>
        /// <returns>下一个时间</returns>
        public static DateTime CalculateNextDateTime(DateTime startTime, decimal cycle, string cycleUnit)
        {
            if (cycle < 0)
            {
                cycle = 0;
            }

            switch (cycleUnit?.Trim().ToLower())
            {
                case "天":
                case "day":
                case "d":
                    return startTime.AddDays((double)cycle);

                case "周":
                case "week":
                case "w":
                    return startTime.AddDays((double)cycle * 7);
                
                case "月":
                case "month":
                case "m":
                    return startTime.AddMonths((int)cycle);

                default:
                    return startTime;
            }
        }
    }
}
