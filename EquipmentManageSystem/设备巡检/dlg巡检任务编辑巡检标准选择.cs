using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板.选择窗口模版;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备巡检
{
    public partial class dlg巡检任务编辑巡检标准选择 : temp选择窗口
    {
        private string Code; // 设备功能位置编码

        public string part; // 巡检部位
        public string content; // 巡检内容
        public string type; // 巡检类型
        public string standard; // 判断标准
        public string cycle; // 巡检周期
        public string unit; // 周期单位
        public string remind; // 提前提醒天数
        public string start; // 开始执行日期

        public dlg巡检任务编辑巡检标准选择(string code)
        {
            this.Code = code;
            InitializeComponent();
        }

        private bool dlg巡检任务编辑巡检标准选择_BeforeQuery()
        {
            this.Sql = "select xjjh.巡检部位,xjjh.巡检内容,xjjh.巡检类型,xjjh.判断标准,xjjh.巡检周期,u.单位名称 as 周期单位,xjjh.提前提醒天数,xjjh.开始执行日期 " +
                       "from 设备巡检计划 as xjjh " +
                       "left join 周期单位 as u on xjjh.周期单位编码 = u.单位编码 " +
                       "left join 设备功能位置档案 as d on xjjh.功能位置单据号 = d.单据号 " +
                       "where d.功能位置编码 = '" + this.Code + "'" + 
                       "and xjjh.IsDelete = 0";
            return true;
        }

        private bool dlg巡检任务编辑巡检标准选择_PreOK()
        {
            if (this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowWarning("请选择一条数据！");
                return false;
            }

            this.part = this.SelectedRows[0]["巡检部位"]?.ToString();
            this.content = this.SelectedRows[0]["巡检内容"]?.ToString();
            this.type = this.SelectedRows[0]["巡检类型"]?.ToString();
            this.standard = this.SelectedRows[0]["判断标准"]?.ToString();
            this.cycle = this.SelectedRows[0]["巡检周期"]?.ToString();
            this.unit = this.SelectedRows[0]["周期单位"]?.ToString();
            this.remind = this.SelectedRows[0]["提前提醒天数"]?.ToString();
            this.start = this.SelectedRows[0]["开始执行日期"]?.ToString();

            return true;
        }
    }
}
