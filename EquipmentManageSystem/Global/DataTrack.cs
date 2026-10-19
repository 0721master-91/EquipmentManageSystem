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
                DeleteFields(fields,"创建人");
                fields.Add(new SlcFieldInfo
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "创建人",
                    KeyValue = UserSession.CurrentUser.MemberID,
                    KeyType = SleDataType.String
                });
            }

            DeleteFields(fields, "最后修改时间");
            fields.Add(new SlcFieldInfo
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "最后修改时间",
                KeyValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                KeyType = SleDataType.DateTime
            });

            DeleteFields(fields, "最后修改人");
            fields.Add(new SlcFieldInfo
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "最后修改人",
                KeyValue = UserSession.CurrentUser.MemberID,
                KeyType = SleDataType.Digit
            });
        }

        /// <summary>
        /// 删除指定字段
        /// </summary>
        /// <param name="fields">列表</param>
        /// <param name="fieldName">待删除字段</param>
        private static void DeleteFields(FieldArray fields, string fieldName)
        {
            for (int i = fields.Count - 1; i >= 0; i--)
            {
                if (fields[i].KeyName == fieldName)
                {
                    fields.RemoveAt(i);
                }
            }
        }

    }
}
