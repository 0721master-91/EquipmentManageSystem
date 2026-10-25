using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using EquipmentManageSystem.Utils;
using SLQLControls.模板;
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.设备管理
{
    public partial class ctn功能位置档案 : temp标准基本信息GridControl
    {
        public ctn功能位置档案()
        {
            InitializeComponent();
        }

        private void ctn功能位置档案_Load(object sender, EventArgs e)
        {
            this.slDevGridControlMain.RowFont = new Font("宋体", 11f);
            this.slDevGridControlMain.ColumnFont = new Font("宋体", 11f);
            this.Type编辑窗口 = typeof(dlg功能位置档案编辑);
            this.slDevGridControlMain.ShowFooter = true;

            LoadFilter();
        }

        /// <summary>
        /// 加载筛选条件
        /// </summary>
        private void LoadFilter()
        {
            // 设备类型
            CommonFilter.InitCombox(this.comboBox设备类型, "类型名称", "类型编码", "设备类型");

            // 组织
            CommonFilter.InitCombox(this.comboBox组织名称, "组织名称", "组织编码", "组织");

            // 设备状态
            CommonFilter.InitCombox(this.comboBox设备状态, "状态", "编码", "设备状态");
        }

        /// <summary>
        /// 打开选择人员对话框(多选)
        /// </summary>
        private void OpenMemberMuiltySelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string title = comboBox.Name.Substring(9) + "选择";
            using (dlg人员选择 dlg = new dlg人员选择(title) { IsMultiSelect = true})
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Text = dlg.SelectedMemberNames;
                    comboBox.Tag = dlg.SelectedMemberIDs;
                }
            }
        }

        /// <summary>
        /// 打开选择人员对话框(单选)
        /// </summary>
        private void OpenMemberSingleSelectDialog(object sender, MouseEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string title = comboBox.Name.Substring(9) + "选择";
            using (dlg人员选择 dlg = new dlg人员选择(title))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    comboBox.Text = dlg.SelectedMemberNames;
                    comboBox.Tag = dlg.SelectedMemberIDs;
                }
            }
        }

        private bool ctn功能位置档案_BeforeChangeDataSource()
        {
            string sql = "select s.ID,s.功能位置编码,s.功能位置描述,s.位置简称,t.类型名称 as 设备类型,o.组织名称 as 组织,d.部门名称 as 管理部门,m.姓名 as 责任人,st.状态 as 设备状态," +
                            "dbo.fn_GetMemberNamesByIds(s.巡检人员IDs) as 巡检人员," +
                            "dbo.fn_GetMemberNamesByIds(s.维保人员IDs) as 维保人员," +
                            "dbo.fn_GetMemberNamesByIds(s.检验人员IDs) as 检验人员 " +
                           "from 设备功能位置档案 as s " + 
                           "left join 设备类型 as t on s.设备类型编码 = t.类型编码 " +
                           "left join 组织 as o on s.组织编码 = o.组织编码 " +
                           "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                           "left join 成员 as m on s.责任人ID = m.ID " +
                           "left join 设备状态 as st on s.设备状态编码 = st.编码 " +
                           "where s.IsDelete = 0 ";

            object typeObj = this.comboBox设备类型.SelectedValue;
            string type = typeObj == null ? "" : typeObj.ToString();
            if (!string.IsNullOrEmpty(type))
            {
                sql += "and s.设备类型编码 = '" + type + "' ";
            }

            object orgObj = this.comboBox组织名称.SelectedValue;
            string org = orgObj == null ? "" : orgObj.ToString();
            if (!string.IsNullOrEmpty(org))
            {
                sql += "and s.组织编码 = '" + org + "' ";
            }

            object responsiblePersonIDObj = this.comboBox责任人.Tag;
            string responsiblePersonID = responsiblePersonIDObj == null ? "" : responsiblePersonIDObj.ToString();
            if (!string.IsNullOrEmpty(responsiblePersonID))
            {
                sql += " and s.责任人ID = " + responsiblePersonID + " ";
            }

            string statusCodeObj = this.comboBox设备状态.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(statusCodeObj))
            {
                sql += "and s.设备状态编码 = '" + statusCodeObj + "' ";
            }

            object inspectionPersonIDsObj = this.comboBox巡检人员.Tag;
            string inspectionPersonIDs = inspectionPersonIDsObj == null ? "" : inspectionPersonIDsObj.ToString();
            if (!string.IsNullOrEmpty(inspectionPersonIDs))
            {
                sql += CombineSql(inspectionPersonIDs.Split(','), "s.巡检人员IDs");
            }

            object maintenancePersonIDsObj = this.comboBox维保人员.Tag;
            string maintenancePersonIDs = maintenancePersonIDsObj == null ? "" : maintenancePersonIDsObj.ToString();
            if (!string.IsNullOrEmpty(maintenancePersonIDs))
            {
                sql += CombineSql(maintenancePersonIDs.Split(','), "s.维保人员IDs");
            }

            object checkPersonIDsObj = this.comboBox检验人员.Tag;
            string checkPersonIDs = checkPersonIDsObj == null ? "" : checkPersonIDsObj.ToString();
            if (!string.IsNullOrEmpty(checkPersonIDs))
            {
                sql += CombineSql(checkPersonIDs.Split(','), "s.检验人员IDs");
            }

            sql += " order by s.创建时间 desc";
            this.Sql查询 = sql;

            return true;
        }

        /// <summary>
        /// 将成员ID组合成SQL语句，用于查询
        /// </summary>
        /// <param name="memberIDList">成员id列表</param>
        /// <param name="fileName">匹配字段名</param>
        /// <returns></returns>
        private string CombineSql(string[] memberIDList,string fileName)
        {
            List<string> conditions = new List<string>();
            foreach(string id in memberIDList)
            {
                conditions.Add("charindex(',' + '" + id + "' + ',' , ',' + " + fileName + " + ',') > 0");
            }
            string sqlCondition = "(" + string.Join(" and ", conditions) + ")";
            return " and " + sqlCondition;
        }

        private void button查看详细_Click(object sender, EventArgs e)
        {
            using(dlg功能位置档案编辑 dlg = SLEditDialogUtil.GetDetaisDialogObj(this,typeof(dlg功能位置档案编辑)) as dlg功能位置档案编辑)
            {
                if (dlg == null) return;
                dlg.IsCloseModify = true;
                dlg.ShowDialog();
            }

        }

        private DataTable CurrentDataSource;
        private void ctn功能位置档案_AfterChangeDataSource(DataTable newTable)
        {
            this.textBox模糊查询.Text = string.Empty;
            this.CurrentDataSource = newTable;
            this.slDevGridControlMain.MainGridView.BestFitColumns();

            this.slDevGridControlMain.SetSummaryItem("功能位置编码", "合计：{0}", SummaryItemType.Count);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        private void FuzzyQuery(object sender, EventArgs e)
        {
            string keyword = this.textBox模糊查询.Text.Trim();

            if(this.CurrentDataSource == null)
            {
                PopUpUtil.ShowWarning("请先加载数据");
                return;
            }

            if (string.IsNullOrEmpty(keyword))
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                this.CurrentDataSource.DefaultView.RowFilter = string.Format(
                    "功能位置编码 LIKE '%{0}%' OR 功能位置描述 LIKE '%{0}%'OR 位置简称 LIKE '%{0}%' OR 设备类型 LIKE '%{0}%' OR 组织 LIKE '%{0}%' OR " +
                    "责任人 LIKE '%{0}%' OR 设备状态 LIKE '%{0}%' OR 巡检人员 LIKE '%{0}%' OR 维保人员 LIKE '%{0}%' OR 检验人员 LIKE '%{0}%'",
                    keyword);
            }
        }

        private void slFlatButton导入_Click(object sender, EventArgs e)
        {
            DataTable outData = this.CurrentDataSource.DefaultView.ToTable();
            if (outData.Rows.Count == 0)
            {
                PopUpUtil.ShowWarning("没有数据可以导出");
                return;
            }

            using(dlg功能位置档案导出 dlg = new dlg功能位置档案导出(outData))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.RefreshData();
                }
            }
        }
    }
}
