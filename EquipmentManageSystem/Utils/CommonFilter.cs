using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 提供通用的过滤选项初始化数据
    /// </summary>
    public static class CommonFilter
    {

        /// <summary>
        /// 获取启用状态过滤选项
        /// DisplayMember = "状态", ValueMember = "状态值"
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEnabledStatusFilter()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("状态", typeof(string));
            dtStatus.Columns.Add("状态值", typeof(object));
            DataRow row1 = dtStatus.NewRow();
            row1["状态"] = "全部";
            row1["状态值"] = null;
            dtStatus.Rows.Add(row1);
            DataRow row2 = dtStatus.NewRow();
            row2["状态"] = "启用";
            row2["状态值"] = 1;
            dtStatus.Rows.Add(row2);
            DataRow row3 = dtStatus.NewRow();
            row3["状态"] = "停用";
            row3["状态值"] = 0;
            dtStatus.Rows.Add(row3);

            return dtStatus;
        }
    }
}
