﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 用于巡检、保养任务状态管理
    /// </summary>
    public static class TaskStatusManager
    {

        public static void UpdateInspectionTaskExpiredStatus()
        {
            string sql = "update 巡检任务 " +
                         "set 过期状态编码='EXPIRED' " +
                         "where 执行状态编码='WAITING' " +
                         "and 过期状态编码='UNEXPIRED' " +
                         "and 过期时间 < getdate()";
            SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteSql(sql);
        }
    }
}