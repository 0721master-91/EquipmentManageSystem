﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备维修
{
    public partial class uc维修工单维修记录 : UserControl
    {
        public uc维修工单维修记录()
        {
            InitializeComponent();
        }

        private void uc维修工单维修记录_Load(object sender, EventArgs e)
        {
            GridInit.InitRepairRecordGrid(this.dataGridView维修记录);
        }
        
        /// <summary>
        /// 加载维修记录
        /// </summary>
        /// <param name="billCode">维修工单编码</param>
        public void LoadRepairRecorData(string billCode)
        {
            string sql = "select dbo.fn_GetMemberNamesByIds(rr.维修人ID) as 维修人,rres.结果 as 维修结果,rr.维修开始时间,rr.维修结束时间,rr.维修备注信息,rr.故障原因,rr.处理方案, " +
                            "dbo.fn_GetMemberNamesByIds(rr.验收人ID) as 验收人,rr.验收时间,cas.状态 as 验收状态,rr.重新维修原因 " +
                         "from 维修记录 as rr " +
                         "left join 维修结果 as rres on rr.维修结果编码 = rres.编码 " +
                         "left join 验收状态 as cas on rr.验收状态编码 = cas.编码 " +
                         "where 维修工单编码 = '" + billCode + "' " + 
                         "order by 创建时间";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            DataTable record = this.dataGridView维修记录.DataSource as DataTable;
            foreach (DataRow r in dt.Rows)
            {
                DataRow row = record.NewRow();
                row["维修人"] = r["维修人"];
                row["维修结果"] = r["维修结果"];
                row["维修开始时间"] = r["维修开始时间"];
                row["维修结束时间"] = r["维修结束时间"];
                row["维修备注信息"] = r["维修备注信息"];
                row["故障原因"] = r["故障原因"];
                row["处理方案"] = r["处理方案"];
                row["验收人"] = r["验收人"];
                row["验收时间"] = r["验收时间"];
                row["验收结果"] = r["验收状态"];
                row["重新维修原因"] = r["重新维修原因"];
                record.Rows.Add(row);
            }
        }
    }
}