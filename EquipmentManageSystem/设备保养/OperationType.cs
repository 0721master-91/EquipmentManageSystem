using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.设备保养
{
    /// <summary>
    /// 任务操作类型
    /// </summary>
    public enum OperationType
    {
        /// <summary>一般操作，保养任务数据的CRUD操作</summary>
        Common,

        /// <summary>保养任务提交</summary>
        TaskSubmit,

        /// <summary>验收提交</summary>
        AcceptanceSubmit
    }
}
