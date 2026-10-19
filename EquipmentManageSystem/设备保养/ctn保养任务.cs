﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备保养
{
    public partial class ctn保养任务 : temp标准基本信息GridControl
    {
        public ctn保养任务()
        {
            InitializeComponent();
        }

        private void ctn保养任务_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg保养任务编辑);
            this.EmployeeName = UserSession.CurrentUser.MemberID.ToString(); 


            CommonFilter.InitCombox(this.comboBox过期状态, "状态", "编码", "过期状态");
            CommonFilter.InitCombox(this.comboBox保养状态, "状态", "编码", "保养状态");
        }

        private bool ctn保养任务_BeforeChangeDataSource()
        {
            TaskStatusManager.UpdateMaintenanceTaskExpiredStatus();

            string sql = "select m.ID,m.保养任务编码,m.设备功能位置编码,p.功能位置描述,p.位置简称,m.计划执行日期,et.状态 as 执行状态,dbo.fn_GetMemberNamesByIds(保养人员IDs) as 保养人员," +
                         "dbo.fn_GetMemberNamesByIds(任务接取人ID) as 任务接取人,ms.状态 as 保养状态,es.状态 as 过期状态,ys.状态 as 验收状态,m.创建时间 " +
                         "from 保养任务 as m " +
                         "left join 设备功能位置档案 as p on m.设备功能位置编码 = p.功能位置编码 " +
                         "left join 执行状态 as et on m.执行状态编码 = et.编码 " +
                         "left join 保养状态 as ms on m.保养状态编码 = ms.编码 " +
                         "left join 过期状态 as es on m.过期状态编码 = es.编码 " +
                         "left join 验收状态 as ys on m.验收状态编码 = ys.编码 " +
                         "where m.IsDelete = 0";

            string positionAbbreviation = this.textBox位置简称.Text.Trim();
            if (!string.IsNullOrEmpty(positionAbbreviation))
            {
                sql += "and p.位置简称 like '%" + positionAbbreviation + "%' ";
            }

            object expiredStatusCodeObj = this.comboBox过期状态.SelectedValue;
            string expiredStatusCode = expiredStatusCodeObj == null ? "" : expiredStatusCodeObj.ToString();
            if (!string.IsNullOrEmpty(expiredStatusCode))
            {
                sql += "and m.过期状态编码 = '" + expiredStatusCode + "' ";
            }

            object personIDObj = this.comboBox保养人员.Tag;
            string personID = personIDObj == null ? "" : personIDObj.ToString();
            if (!string.IsNullOrEmpty(personID))
            {
                sql += "and CHARINDEX(',' + '" + personID + "' + ',', ',' + m.保养人员IDs + ',') > 0 ";
            }

            object maintenanceStatusCodeObj = this.comboBox保养状态.SelectedValue;
            string maintenanceStatusCode = maintenanceStatusCodeObj == null ? "" : maintenanceStatusCodeObj.ToString();
            if (!string.IsNullOrEmpty(maintenanceStatusCode))
            {
                sql += "and m.保养状态编码 = '" + maintenanceStatusCode + "' ";
            }

            this.Sql查询 = sql;
            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn保养任务_AfterChangeDataSource(DataTable newTable)
        {
            var colCreateTime = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("创建时间");
            colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            this.CurrentDataSource = newTable;
            this.textBox模糊查询.Text = string.Empty;
            this.slDevGridControlMain.MainGridView.BestFitColumns();
        }

        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();
            if (this.CurrentDataSource == null)
            {
                PopUpUtil.ShowInfo("请先点击「刷新」加载数据");
                return;
            }
            if (string.IsNullOrEmpty(keyword))
            {
                // 关键词为空就显示全部数据
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                string safeKeyword = keyword.Replace("'", "''");
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "保养任务编码 LIKE '%{0}%' OR 设备功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' " +
                    "OR 保养人员 LIKE '%{0}%' OR 任务接取人 LIKE '%{0}%' " +
                    "OR 执行状态 LIKE '%{0}%' OR 保养状态 LIKE '%{0}%' OR 过期状态 LIKE '%{0}%' OR 验收状态 LIKE '%{0}%'",
                    safeKeyword);
            }
        }   

        // 点击打开人员选择框

        private void comboBox保养人员_MouseDown(object sender, MouseEventArgs e)
        {
            using (dlg人员选择 dlg = new dlg人员选择("保养人员选择"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox保养人员.Text = dlg.SelectedMemberNames;
                    this.comboBox保养人员.Tag = dlg.SelectedMemberIDs;
                }
                this.ActiveControl = null;
            }
        }

        private void slFlatButton导出_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            if (outData.Rows.Count == 0)
            {
                PopUpUtil.ShowInfo("没有数据可以导出");
            }

            using(dlg保养任务导出 dlg = new dlg保养任务导出(outData))
            {
                dlg.ShowDialog();
                this.button刷新.PerformClick();
            }
        }
    }
}