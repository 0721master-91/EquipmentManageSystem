using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.数据报表
{
    public class QueryData
    {
        /// <summary>
        /// 组织编码
        /// </summary>
        public string OrgCode { get; set; }
        
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepCode { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
