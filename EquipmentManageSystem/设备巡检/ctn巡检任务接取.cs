using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLControls.SLGlobal;
using SLQLControls.模板;

namespace EquipmentManageSystem.设备巡检
{
    public partial class ctn巡检任务接取 : temp标准基本信息GridControl
    {
        public ctn巡检任务接取()
        {
            InitializeComponent();
        }

        private void ctn巡检任务接取_Load(object sender, EventArgs e)
        {
            this.Type编辑窗口 = typeof(dlg巡检任务编辑);

            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
        }

        private bool ctn巡检任务接取_BeforeChangeDataSource()
        {
            string sql = "select t.ID,t.巡检任务编码,p.功能位置编码,p.功能位置描述,p.位置简称,d.部门名称 as 设备管理部门,m.姓名 as 设备负责人,dbo.fn_GetMemberNamesByIds(t.巡检人员IDs) as 巡检人员," +
                         "t.计划执行日期,t.巡检开始时间,es.状态 as 执行状态,os.状态 as 过期状态,t.创建时间 " +
                         "from 巡检任务 as t " + 
                         "left join 设备功能位置档案 as p on t.设备功能位置编码 = p.功能位置编码 " +
                         "left join 部门 as d on p.管理部门编码 = d.部门编码 " + 
                         "left join 成员 as m on p.责任人ID = m.ID " +
                         "left join 执行状态 as es on t.执行状态编码 = es.编码 " +
                         "left join 过期状态 as os on t.过期状态编码 = os.编码 " +
                         "where t.IsDelete = 0 " + 
                         "and t.执行状态编码 = 'WAITING' " +
                         "and t.过期状态编码 = 'UNEXPIRED' ";

            // 如果成员ID大于0，则为非管理员用户，只显示指定了该用户的任务单
            long currentMemberId = UserSession.CurrentUser.MemberID;
            if(currentMemberId > 0)
            {
                sql += " and CHARINDEX(',' + " + currentMemberId + " + ',', ',' + t.巡检人员IDs + ',') > 0";
            }

            this.Sql查询 = sql;

            return true;
        }

        private DataTable CurrentDataSource;
        private void ctn巡检任务接取_AfterChangeDataSource(DataTable newTable)
        {
            var colStartDate = this.slDevGridControlMain.MainGridView.Columns.ColumnByFieldName("巡检开始时间");
            colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colStartDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";

            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
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
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "巡检任务编码 LIKE '%{0}%' OR 功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%' OR 位置简称 LIKE '%{0}%' OR 设备管理部门 LIKE '%{0}%' " +
                    "OR 设备负责人 LIKE '%{0}%' OR 巡检人员 LIKE '%{0}%' OR 执行状态 LIKE '%{0}%' OR 过期状态 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void button任务接取_Click(object sender, EventArgs e)
        {
            var gv = this.slDevGridControlMain.MainGridView;
            if (gv.FocusedRowHandle < 0)              
            {
                PopUpUtil.ShowInfo("请先选择要接取的任务");
                return;
            }

            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row == null) return;

            long id = Convert.ToInt64(row["ID"]);

            using (dlg巡检任务编辑 dlg = new dlg巡检任务编辑(true))
            {
                dlg.OperFlag = SleOperFlag.Modify;
                dlg.TableName = "巡检任务";
                dlg.PrimaryKey = new SlcFieldInfo()
                {
                    OperatorMode = SleOperatorMode.ReadWrite,
                    KeyName = "ID",
                    KeyValue = id,
                    KeyType = SleDataType.Digit
                };
                dlg.ShowDialog();
            }
        }
    }
}
