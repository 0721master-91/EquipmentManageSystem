using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板.选择窗口模版;

namespace EquipmentManageSystem.设备保养
{
    public partial class dlg保养任务编辑保养标准选择 : temp选择窗口
    {
        public string Content; // 保养内容
        public string GiveOilType; // 给油类型
        public string LubricantChangeType; // 润换方式
        public string LubricantModel; // 润滑脂型号
        public string Cycle; // 执行周期
        public string Unit; // 周期单位
        public DateTime StartDate; // 保养开始日期

        private string PositionCode; // 功能位置编码
        public dlg保养任务编辑保养标准选择(string positionCode)
        {
            InitializeComponent();
            this.PositionCode = positionCode;
        }

        private bool dlg保养任务编辑保养标准选择_BeforeQuery()
        {
            this.Sql = "select b.保养内容,g.类型 as 给油类型,r.方式 as 润换方式,b.润滑脂型号,b.执行周期,z.单位名称 as 周期单位,b.提前提醒天数,b.开始执行日期 " +
                       "from 设备保养计划 as b " +
                       "left join 给油类型 as g on b.给油类型编码 = g.编码 " +
                       "left join 润换方式 as r on b.润换方式编码 = r.编码 " +
                       "left join 周期单位 as z on b.周期单位编码 = z.单位编码 " +
                       "join 设备功能位置档案 as p on b.功能位置单据号 = p.单据号 " +
                       "where p.功能位置编码='" + PositionCode + "' " + 
                       "and b.IsDelete = 0";

            return true;
        }

        private bool dlg保养任务编辑保养标准选择_PreOK()
        {
            if(this.SelectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请选择保养标准");
                return false;
            }

            this.Content = this.SelectedRows[0]["保养内容"].ToString();
            this.GiveOilType = this.SelectedRows[0]["给油类型"].ToString();
            this.LubricantChangeType = this.SelectedRows[0]["润换方式"].ToString();
            this.LubricantModel = this.SelectedRows[0]["润滑脂型号"].ToString();
            this.Cycle = this.SelectedRows[0]["执行周期"].ToString();
            this.Unit = this.SelectedRows[0]["周期单位"].ToString();
            this.StartDate = Convert.ToDateTime(this.SelectedRows[0]["开始执行日期"]);

            return true;
        }
    }
}
