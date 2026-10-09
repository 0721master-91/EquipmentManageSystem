using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板.选择窗口模版;

namespace EquipmentManageSystem.Global
{
    public partial class dlg设备功能位置选择 : temp选择窗口
    {
        public string PositionCode; // 功能位置编码
        public string PositionDescription; // 功能位置描述
        public string PositionShortName; // 位置简称
        public string Area; // 所属区域
        public string EquipmentType; // 设备类型
        public string Organization; // 组织
        public string Department; // 管理部门
        public string ResponsiblePerson; // 责任人
        public string EquipmentStatus; // 设备状态
        public string InspectionPeople; // 巡检人员
        public string MaintenancePeople; // 维保人员
        public string CheckePeople; // 检验人员

        public dlg设备功能位置选择()
        {
            InitializeComponent();
        }

        private bool dlg设备功能位置选择_BeforeQuery()
        {
            this.Sql = "select s.ID,s.功能位置编码,s.功能位置描述,s.位置简称,t.类型名称 as 设备类型,r.名称 as 所属区域,o.组织名称 as 组织,d.部门名称 as 管理部门,m.姓名 as 责任人,st.状态 as 设备状态," +
                       "dbo.fn_GetMemberNamesByIds(s.巡检人员IDs) as 巡检人员," +
                       "dbo.fn_GetMemberNamesByIds(s.维保人员IDs) as 维保人员," +
                       "dbo.fn_GetMemberNamesByIds(s.检验人员IDs) as 检验人员 " +
                       "from 设备功能位置档案 as s " +
                       "left join 设备类型 as t on s.设备类型编码 = t.类型编码 " +
                       "left join 区域 as r on s.所属区域编码 = r.编码 " +
                       "left join 组织 as o on s.组织编码 = o.组织编码 " +
                       "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                       "left join 成员 as m on s.责任人ID = m.ID " +
                       "left join 设备状态 as st on s.设备状态编码 = st.编码 " +
                       "where s.Isdelete = 0 ";

            return true;
        }

        private bool dlg设备功能位置选择_PreOK()
        {
            if(this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowWarning("请选择一条记录！");
                return false;
            }

            this.PositionCode = this.SelectedRows[0]["功能位置编码"].ToString();
            this.PositionDescription = this.SelectedRows[0]["功能位置描述"].ToString();
            this.PositionShortName = this.SelectedRows[0]["位置简称"].ToString();
            this.EquipmentType = this.SelectedRows[0]["设备类型"].ToString();
            this.Area = this.SelectedRows[0]["所属区域"].ToString();
            this.Organization = this.SelectedRows[0]["组织"].ToString();
            this.Department = this.SelectedRows[0]["管理部门"].ToString();
            this.ResponsiblePerson = this.SelectedRows[0]["责任人"].ToString();
            this.EquipmentStatus = this.SelectedRows[0]["设备状态"].ToString();
            this.InspectionPeople = this.SelectedRows[0]["巡检人员"].ToString();
            this.MaintenancePeople = this.SelectedRows[0]["维保人员"].ToString();
            this.CheckePeople = this.SelectedRows[0]["检验人员"].ToString();

            return true;
        }
    }
}
