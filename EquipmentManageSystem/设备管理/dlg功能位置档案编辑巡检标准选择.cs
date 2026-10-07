using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.模板;
using EquipmentManageSystem.模板.选择窗口模版;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能位置档案编辑巡检标准选择 : temp选择窗口
    {
        public string Part; // 巡检部位
        public string Content; // 巡检内容
        public string Type; // 巡检类型
        public string JudgeStandard; // 判断标准
        public int Cycle; // 巡检周期
        public string CycleUnitCode; // 巡检周期单位编码
        public string PreNoticeDays; // 提前提醒天数
        public DateTime StartTime; // 开始执行时间

        public dlg功能位置档案编辑巡检标准选择()
        {
            InitializeComponent();
        }

        private bool dlg功能位置档案编辑巡检标准选择_PreOK()
        {
            if(this.selectedRows.Count == 0)
            {
                PopUpUtil.ShowInfo("请选择巡检标准");
                return false;
            }

            DataRow row = this.selectedRows[0];

            this.Part = row["巡检部位"].ToString();
            this.Content = row["巡检内容"].ToString();
            this.Type = row["巡检类型"].ToString();
            this.JudgeStandard = row["判断标准"].ToString();
            this.Cycle = Convert.ToInt32(row["巡检周期"]);
            this.CycleUnitCode = row["周期单位编码"].ToString();
            this.PreNoticeDays = row["提前提醒天数"].ToString();

            return true;
        }

        private bool dlg功能位置档案编辑巡检标准选择_BeforeQuery()
        {
            this.Sql = "select s.巡检部位编码,s.巡检部位,s.巡检内容,s.巡检类型,判断标准,s.巡检周期,s.周期单位编码,z.单位名称 as 周期单位,s.提前提醒天数  " +
                "from 巡检标准 as s " +
                "left join 周期单位 as z on z.单位编码 = s.周期单位编码 " +
                "where IsDelete = 0";

            return true;
        }

        private void dlg功能位置档案编辑巡检标准选择_AfterFillControls()
        {
            this.dataGridView数据表.Columns["周期单位编码"].Visible = false;
        }
    }
}
