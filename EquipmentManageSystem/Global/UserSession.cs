using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Global
{
    public static class UserSession
    {
        public static CurrentUser CurrentUser { get; private set; }

        /// <summary>登录成功后调用</summary>
        public static void Login(DataRow row)
        {
            object memberIDObj = row["关联成员ID"];
            long memberID = -1;
            if (memberIDObj == DBNull.Value || memberIDObj == null)
            {
                memberID = 0;
            }
            else
            {
                if(long.TryParse(memberIDObj.ToString(), out long id))
                {
                    memberID = id;
                }
            }

            CurrentUser = new CurrentUser(
                row["ID"]?.ToString(),
                row["用户名"]?.ToString(),
                row["密码"]?.ToString(),
                row["姓名"]?.ToString(),
                row["性别"]?.ToString(),
                row["角色编码"]?.ToString(),
                memberID);
        }

        /// <summary>
        /// 测试用
        /// </summary>
        public static void TestInit()
        {
            CurrentUser = new CurrentUser("1", "admin", "123456", "管理员", "男", "ADMIN", 5);
        }
    }
}
