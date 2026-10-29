using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLControls;
using SLControls.SLGlobal;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.系统管理
{
    public partial class dlg任务生成配置编辑 : SLAomTmpForm
    {
        public dlg任务生成配置编辑()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭修改操作键开关，默认为false
        /// </summary>
        public bool IsCloseModify = false;
        /// <summary>
        /// 关闭数据修改方法,窗口加载后执行
        /// </summary>
        private void CloseModify()
        {
            if (IsCloseModify)
            {
                this.Text = "查看任务生成配置";
                this.button确定.Visible = false;
                this.button取消.Visible = false;
            }
        }

        private void dlg任务生成配置编辑_Load(object sender, EventArgs e)
        {
            this.CloseModify();
        }

        private void dlg任务生成配置编辑_AfterFillControls()
        {
            if (this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox配置编码.Text = SqlCommonUtil.GenerateCode("RWPZ", "任务生成配置", "配置编码");
                this.slTextBox数据源.Text = "手动创建";
                this.slDateTimePicker执行日期.Value = DateTime.Today;
                this.checkBox是否启用.Checked = true; // 默认启用
            }
            else if (this.OperFlag == SleOperFlag.Modify)
            {
                this.checkBox是否启用.Checked = Convert.ToBoolean(this.OtherFields["IsEnabled"]);
            }
        }

        private bool dlg任务生成配置编辑_PreOK(FieldArray aryFields)
        {
            this.OtherFields.Clear();
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox配置编码.Text = SqlCommonUtil.GenerateCode("RWPZ", "任务生成配置", "配置编码");
                this.OtherFields.Add(new SlcFieldInfo()
                {
                    OperatorMode = SleOperatorMode.Write,
                    KeyName = "数据源编码",
                    KeyValue = "MANUAL",
                    KeyType = SleDataType.String
                });
            }
            
            this.OtherFields.Add(new SlcFieldInfo()
            {
                OperatorMode = SleOperatorMode.Write,
                KeyName = "IsEnabled",
                KeyValue = this.checkBox是否启用.Checked,
                KeyType = SleDataType.Digit
            });
            DataTrack.AddTrack(this.OtherFields, this.OperFlag);
            return true;
        }

        private void dlg任务生成配置编辑_AfterExecuteOKSql(object sender, AfterOKSqlEventArgs e)
        {
            if (e.Successful)
            {
                string result = VerifyConfigConflict(this.slTextBox配置编码.Text);
                if(!string.IsNullOrEmpty(result))
                {
                    e.LastError = result;
                    e.Successful = false;
                }
            }
        }

        /// <summary>
        /// 校验同一执行日期下手动配置是否存在冲突
        /// </summary>
        /// <param name="excludeCode">需要排除的配置编码(自身编码)</param>
        /// <returns>返回 null 表示通过，否则返回拒绝原因</returns>
        private string VerifyConfigConflict(string excludeCode)
        {
            DateTime executeDate = this.slDateTimePicker执行日期.Value.Date;
            string dateTypeCode = this.slComboBox日期类型.SelectedRow[2].ToString();
            string areaCode = this.slComboBox适用范围.SelectedRow[2].ToString();

            string sql = "select 配置编码,日期类型编码,适用范围编码 " +
             "from 任务生成配置 " +
             "where IsDelete = 0 " +
                "and 数据源编码 = 'MANUAL'" +
                "and 执行日期 = '" + executeDate.ToString("yyyy-MM-dd") + "' ";

            if (!string.IsNullOrEmpty(excludeCode))
            {
                sql += "and 配置编码 <> '" + excludeCode + "' ";
            }

            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            if (dt.Rows.Count == 0) return null;

            bool isAll = areaCode == "ALL";
            foreach(DataRow row in dt.Rows)
            {
                if (row["适用范围编码"].ToString() == "ALL")
                {
                    if (isAll)
                    {
                        return "该执行日期已存在【全部】范围的配置(" + row["配置编码"] + ")，不能重复添加";
                    }
                    return "该执行日期已存在【全部】范围的配置(" + row["配置编码"] + ")，不能再添加其他范围，请先删除或修改已有配置";
                }
            }

            if (isAll)
            {
                return "该执行日期已存在其他范围的配置，不能再添加【全部】范围，请先删除已有配置";
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row["适用范围编码"].ToString() != areaCode) continue;

                if (row["日期类型编码"].ToString() == dateTypeCode)
                {
                    return "该执行日期下【" + this.slComboBox适用范围.Text + "】已于【" + this.slComboBox日期类型.Text + "】存在，不能重复添加";
                }
                return "该执行日期下【" + this.slComboBox适用范围.Text + "】已配置为其他日期类型，同一范围只能配置一种日期类型";
            }

            return null;
        }
    }
}
