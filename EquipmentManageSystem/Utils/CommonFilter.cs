using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 提供通用的过滤选项初始化数据
    /// </summary>
    public static class CommonFilter
    {

        /// <summary>
        /// 获取启用状态过滤选项
        /// DisplayMember = "状态", ValueMember = "状态值"
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEnabledStatusFilter()
        {
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("状态", typeof(string));
            dtStatus.Columns.Add("状态值", typeof(object));
            DataRow row1 = dtStatus.NewRow();
            row1["状态"] = "全部";
            row1["状态值"] = null;
            dtStatus.Rows.Add(row1);
            DataRow row2 = dtStatus.NewRow();
            row2["状态"] = "启用";
            row2["状态值"] = 1;
            dtStatus.Rows.Add(row2);
            DataRow row3 = dtStatus.NewRow();
            row3["状态"] = "停用";
            row3["状态值"] = 0;
            dtStatus.Rows.Add(row3);

            return dtStatus;
        }

        /// <summary>
        /// 初始化下拉框选择项
        /// </summary>
        /// <param name="comboBox">控件</param>
        /// <param name="displayMenber">显示字段</param>
        /// <param name="valueMember">值字段</param>
        /// <param name="tableName">表名</param>
        /// <param name="needAll">是否需要全部选项（默认true）</param>
        /// <param name="sql">自定义sql语句</param>
        public static void InitCombox(ComboBox comboBox,string displayMenber, string valueMember, string tableName,bool needAll = true,string sql = "")
        {
            if (string.IsNullOrEmpty(sql))
            {
                sql = string.Format("select {0},{1} from {2}", displayMenber, valueMember, tableName);
            }
            
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            if (needAll)
            {
                DataRow row = dt.NewRow();
                row[valueMember] = string.Empty;
                row[displayMenber] = "全部";
                dt.Rows.InsertAt(row, 0);
            }

            comboBox.DataSource = dt;
            comboBox.DisplayMember = displayMenber;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedValue = needAll ? string.Empty : null;
        }
    }
}
