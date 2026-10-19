using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.设备维修
{
    public partial class uc维修工单维修信息 : UserControl
    {
        public uc维修工单维修信息()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载维修信息
        /// </summary>
        /// <param name="billCode">维修工单编码</param>
        public void LoadRepairInfo(string billCode)
        {
            string sql = "select rr.*,dbo.fn_CountRepairRecords('" + billCode + "') as 维修次数 " +
                         "from dbo.fn_GetRepairRecordByBill('" + billCode + "') as rr";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            string checkAndAcceptStatusCode = dt.Rows[0]["验收状态编码"].ToString();

            // 由函数获取的记录是进过处理后的数据，如果为空说明只有一条数据并没有维修完成
/*            if (string.IsNullOrEmpty(checkAndAcceptStatusCode))
            {
                this.textBox维修次数.Text = "0";
                return;
            }*/

            // 填充故障处理信息
            this.textBox维修结果.Text = dt.Rows[0]["维修结果"].ToString();
            this.textBox备注信息.Text = dt.Rows[0]["维修备注信息"].ToString();
            this.textBox故障原因.Text = dt.Rows[0]["故障原因"].ToString();
            this.textBox影响说明.Text = dt.Rows[0]["影响说明"].ToString();
            this.textBox处理方案.Text = dt.Rows[0]["处理方案"].ToString();
            this.textBox预防措施.Text = dt.Rows[0]["预防措施"].ToString();
            object repairdStartTimeObj = dt.Rows[0]["维修开始时间"];
            string repairdStartTime = repairdStartTimeObj == DBNull.Value ? string.Empty : Convert.ToDateTime(repairdStartTimeObj).ToString("yyyy-MM-dd HH:mm:ss");
            this.textBox维修开始时间.Text = repairdStartTime;
            object repairdEndTimeObj = dt.Rows[0]["维修结束时间"];
            string repairdEndTime = repairdEndTimeObj == DBNull.Value ? string.Empty : Convert.ToDateTime(repairdEndTimeObj).ToString("yyyy-MM-dd HH:mm:ss");
            this.textBox维修结束时间.Text = repairdEndTime;
            this.textBox维修用时.Text = CalculateRepairTime(repairdStartTime, repairdEndTime);
            this.textBox维修次数.Text = dt.Rows[0]["维修次数"].ToString();
            PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel维修完成照片, dt.Rows[0]["维修照片路径"].ToString());

            // 填充验收信息
            this.textBox验收人.Text = dt.Rows[0]["验收人"].ToString();
            object acceptTimeObj = dt.Rows[0]["验收时间"];
            string acceptTime = acceptTimeObj == DBNull.Value ? string.Empty : Convert.ToDateTime(acceptTimeObj).ToString("yyyy-MM-dd HH:mm:ss");
            this.textBox验收时间.Text = acceptTime;
            this.textBox验收结果.Text = dt.Rows[0]["验收状态"].ToString();

            if(checkAndAcceptStatusCode == "REJECTED")
            {
                this.label验收结果.Visible = true;
                this.textBox重新维修原因.Visible = true;
                this.textBox重新维修原因.Text = dt.Rows[0]["重新维修原因"].ToString();
            }
        }

        /// <summary>
        /// 计算维修时间
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        private string CalculateRepairTime(string startTime, string endTime)
        {
            if (string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            {
                return String.Empty;
            }

            TimeSpan span = Convert.ToDateTime(endTime) - Convert.ToDateTime(startTime);
            string timeTaken = string.Empty;
            if (span.TotalSeconds >= 0)
            {
                timeTaken = (span.Days > 0 ? span.Days + "天" : "0天") +
                             (span.Hours > 0 ? span.Hours + "小时" : "0小时") +
                             (span.Minutes > 0 ? span.Minutes + "分钟" : "0分钟") +
                             (span.Seconds > 0 ? span.Seconds + "秒" : "0秒");    
            }
            else
            {
                timeTaken = "结束时间早于开始时间";
            }
            return timeTaken;
        }
    }
}
