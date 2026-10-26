﻿using System;
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
    public partial class dlg功能位置档案编辑标准选择 : temp选择窗口
    {

        /// <summary>
        /// 巡检标准
        /// </summary>
        public class InspectionStandard
        {
            public string Part; // 巡检部位
            public string Content; // 巡检内容
            public string Type; // 巡检类型
            public string JudgeStandard; // 判断标准
            public int Cycle; // 巡检周期
            public string CycleUnitCode; // 巡检周期单位编码
            public string PreNoticeDays; // 提前提醒天数
            public DateTime StartTime; // 开始执行时间
        }

        /// <summary>
        /// 保养标准
        /// </summary>
        public class MaintenanceStandard
        {
            public string Content; // 保养内容
            public string GiveOilTypeCode; // 给油类型编码
            public string LubricantModel; // 润滑脂型号
            public string LubricantChangeTypeCode; // 润换方式型号
            public decimal Cycle; // 执行周期
            public string CycleUnitCode; // 执行周期单位编码
            public int PreNoticeDays; // 提前提醒天数
            public DateTime StartTime; // 开始执行时间
        }

        /// <summary>
        /// 标准类型
        /// </summary>
        public enum Standard
        {
            Inspection, // 巡检标准
            Maintenance // 保养标准
        }


        private string InspectionStandardSql = "select s.巡检标准编码,s.巡检部位,s.巡检内容,s.巡检类型,判断标准,s.巡检周期,s.周期单位编码,z.单位名称 as 周期单位,s.提前提醒天数  " +
                                               "from 巡检标准 as s " +
                                               "left join 周期单位 as z on z.单位编码 = s.周期单位编码 " +
                                               "where IsDelete = 0"; // 巡检标准查询sql

        private string MaintenanceStandardSql = "select b.保养标准编码,b.保养内容,b.给油类型编码,g.类型 as 给油类型,b.润换方式编码,r.方式 as 润换方式,b.润滑脂型号,b.执行周期,b.周期单位编码," +
                                                        "z.单位名称 as 周期单位,b.提前提醒天数 " +
                                                "from 保养标准 as b " +
                                                "left join 给油类型 as g on b.给油类型编码 = g.编码 " +
                                                "left join 润换方式 as r on b.润换方式编码 = r.编码 " +
                                                "left join 周期单位 as z on b.周期单位编码 = z.单位编码 " +
                                                "where IsDelete = 0"; // 保养标准查询sql
                                                                

        public InspectionStandard ChosenInspectionStandard; // 选中的巡检标准
        public MaintenanceStandard ChosenMaintenanceStandard; // 选中的保养标准
        public Standard StandardType; // 标准类型

        public dlg功能位置档案编辑标准选择(Standard standardType,string title)
        {
            InitializeComponent();
            this.Text = title;
            this.StandardType = standardType;
        }

        private bool dlg功能位置档案编辑巡检标准选择_PreOK()
        {
            if(this.StandardType == Standard.Inspection)
            {
                if (this.SelectedRows.Count == 0)
                {
                    PopUpUtil.ShowInfo("请选择巡检标准");
                    return false;
                }

                DataRow row = this.SelectedRows[0];
                
                this.ChosenInspectionStandard = new InspectionStandard();
                this.ChosenInspectionStandard.Part = row["巡检部位"].ToString();
                this.ChosenInspectionStandard.Content = row["巡检内容"].ToString();
                this.ChosenInspectionStandard.Type = row["巡检类型"].ToString();
                this.ChosenInspectionStandard.JudgeStandard = row["判断标准"].ToString();
                this.ChosenInspectionStandard.Cycle = Convert.ToInt32(row["巡检周期"]);
                this.ChosenInspectionStandard.CycleUnitCode = row["周期单位编码"].ToString();
                this.ChosenInspectionStandard.PreNoticeDays = row["提前提醒天数"].ToString();

                return true;
            }
            else if(this.StandardType == Standard.Maintenance)
            {
                if (this.SelectedRows.Count == 0)
                {
                    PopUpUtil.ShowInfo("请选择保养标准");
                    return false;
                }

                DataRow row = this.SelectedRows[0];

                this.ChosenMaintenanceStandard = new MaintenanceStandard();
                this.ChosenMaintenanceStandard.Content = row["保养内容"].ToString();
                this.ChosenMaintenanceStandard.GiveOilTypeCode = row["给油类型编码"].ToString();
                this.ChosenMaintenanceStandard.LubricantModel = row["润滑脂型号"].ToString();
                this.ChosenMaintenanceStandard.LubricantChangeTypeCode = row["润换方式编码"].ToString();
                this.ChosenMaintenanceStandard.Cycle = row["执行周期"] != DBNull.Value ? Convert.ToDecimal(row["执行周期"]) : 0;
                this.ChosenMaintenanceStandard.CycleUnitCode = row["周期单位编码"].ToString();
                this.ChosenMaintenanceStandard.PreNoticeDays = row["提前提醒天数"] != DBNull.Value ? Convert.ToInt32(row["提前提醒天数"]) : 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool dlg功能位置档案编辑巡检标准选择_BeforeQuery()
        {
            switch (this.StandardType)
            {
                case Standard.Inspection:
                    this.Sql = this.InspectionStandardSql;
                    break;
                case Standard.Maintenance:
                    this.Sql = this.MaintenanceStandardSql;
                    break;
            }

            if (string.IsNullOrEmpty(this.Sql))
            {
                PopUpUtil.ShowWarning("查询Sql为空");
                return false;
            }
            return true;
        }

        private void dlg功能位置档案编辑巡检标准选择_AfterFillControls()
        {
            this.dataGridView数据表.Columns["周期单位编码"].Visible = false;
        }
    }
}