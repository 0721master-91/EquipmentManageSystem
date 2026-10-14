using SLControls.SLGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Global
{
    /// <summary>
    ///  用于记录操作信息
    /// </summary>
    public static class DataTrack
    {
        /// <summary>
        /// 记录操作信息：最后修改时间，创建人等等信息
        /// </summary>
        public static void AddTrack(FieldArray fields, SleOperFlag operFlag)
        {
            if(operFlag == SleOperFlag.New || operFlag == SleOperFlag.CopyNew)
            {
                fields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "创建人",
                    KeyValue = UserSession.CurrentUser.MemberID,
                    KeyType = SleDataType.String
                });
            }

            fields.Add(new SlcFieldInfo
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "最后修改时间",
                KeyValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                KeyType = SleDataType.DateTime
            });
        }

    }
}
