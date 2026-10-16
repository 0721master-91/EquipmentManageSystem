using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Global
{
    public enum TaskExecuteStatus
    {
        /// <summary>
        /// 任务接取
        /// </summary>
        Receive, 

        /// <summary>
        /// 任务提交
        /// </summary>
        Submit, 

        /// <summary>
        /// 任务验收
        /// </summary>
        CheckAndAccept
    }
}
