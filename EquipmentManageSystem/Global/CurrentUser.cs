using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.Global
{
    /// <summary>
    /// 记录当前登录用户信息
    /// </summary>
    public class CurrentUser
    {
        public string ID { get; }         // 用户ID
        public string UserName { get; }   // 用户名
        public string Password { get; }   // 密码
        public string Name { get; }       // 姓名
        public string Gender { get; }     // 性别
        public string RoleCode { get; }   // 角色编码
        public long MemberID { get; }     // 关联的成员ID

        public CurrentUser(
            string id, string userName, string password, string name,
            string gender, string roleCode, long memberID)
        {
            this.ID = id;
            this.UserName = userName;
            this.Password = password;
            this.Name = name;
            this.Gender = gender;
            this.RoleCode = roleCode;
            this.MemberID = memberID;
        }
    }
}
