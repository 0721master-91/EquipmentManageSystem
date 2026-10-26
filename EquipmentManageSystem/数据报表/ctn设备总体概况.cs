using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;
using EquipmentManageSystem.Global;

namespace EquipmentManageSystem.数据报表
{
    public partial class ctn设备总体概况 : Form
    {
        private static QueryData QueryDataInfo;

        public ctn设备总体概况()
        {
            InitializeComponent();
            this.InitQueryData();
        }

        private void ctn系统总体概况_Load(object sender, EventArgs e)
        {
            // 加载用户信息显示
            string helloInfo = DateTime.Now > DateTime.Parse("05:00:00") ? "早上好" : 
                                        DateTime.Now > DateTime.Parse("12:00:00") ? "中午好" : "晚上好";
            this.label用户信息.Text = helloInfo + "，欢迎【" + UserSession.CurrentUser.Name + "】使用【设备管理系统】";


            // 初始化查询条件
            this.comboBox组织.Text = "全部";
            this.comboBox部门.Text = "全部";
            this.dateTimePicker开始日期.Value = QueryDataInfo.StartTime.Date;
            this.dateTimePicker结束日期.Value = QueryDataInfo.EndTime.Date;
            this.RefreshData();

        }

        private void comboBox组织_MouseDown(object sender, MouseEventArgs e)
        {
            using (dlg组织部门选择 dlg = new dlg组织部门选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox组织.Text = dlg.SelectOrgName;
                    QueryDataInfo.OrgCode = dlg.SelectOrgCode;

                    if (string.IsNullOrEmpty(dlg.SelectOrgCode))
                    {
                        this.comboBox部门.Text = "全部";
                        QueryDataInfo.OrgCode = null;
                    }

                    this.RefreshData();
                }
            }
        }

        private void comboBox部门_MouseDown(object sender, MouseEventArgs e)
        {
            string orgCode = QueryDataInfo.OrgCode;
            if (string.IsNullOrEmpty(orgCode))
            {
                PopUpUtil.ShowInfo("请先选择组织");
                return;
            }

            using(dlg组织部门选择 dlg = new dlg组织部门选择(orgCode))
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBox部门.Text = dlg.SelectDepName;
                    QueryDataInfo.DepCode = dlg.SelectDepCode;

                    if (string.IsNullOrEmpty(dlg.SelectDepCode))
                    {
                        this.comboBox部门.Text = "全部";
                        QueryDataInfo.DepCode = null;
                    }
                }

                this.RefreshData();
            }
        }

        /// <summary>
        /// 初始化查询条件
        /// </summary>
        private void InitQueryData()
        {
            if (QueryDataInfo == null)
            {
                QueryDataInfo = new QueryData();
            }

            QueryDataInfo.OrgCode = null;
            QueryDataInfo.DepCode = null;
            QueryDataInfo.StartTime = DateTime.Today.AddDays(-7);
            QueryDataInfo.EndTime = DateTime.Today.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            DataTable dt = this.LoadPieChart();
            this.LoadEquipmentSatus(dt);
            this.LoadBarChart();
            this.LoadOrderData();
        }

        /// <summary>
        /// 加载设备状态
        /// </summary>
        private void LoadEquipmentSatus(DataTable dt)
        {
            // 加载图片
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox正常运行图片, "Resources\\正常运行.png");
            this.label正常运行数据.Text = dt.Rows[0]["正常运行"] == DBNull.Value ? "0" : dt.Rows[0]["正常运行"].ToString();
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox维修中图片, "Resources\\维修中.png");
            this.label维修中数据.Text = dt.Rows[0]["维修中"] == DBNull.Value ? "0" : dt.Rows[0]["维修中"].ToString();
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox停机或异常图片, "Resources\\故障停机.png");
            this.label停机或异常数据.Text = dt.Rows[0]["停机或异常"] == DBNull.Value ? "0" : dt.Rows[0]["停机或异常"].ToString();
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox设备总数图片, "Resources\\设备设施.png");
            this.label设备总数数据.Text = dt.Rows[0]["总数"].ToString();
        }

        /// <summary>
        /// 加载饼图
        /// </summary>
        private DataTable LoadPieChart()
        {
            this.panel设备状态分布区.Controls.Clear();
            uc设备总体概况状态分布 uc = new uc设备总体概况状态分布();
            uc.Dock = DockStyle.Fill;
            this.panel设备状态分布区.Controls.Add(uc);
            return uc.LoadPieChart(QueryDataInfo);
        }

        /// <summary>
        /// 加载柱状图
        /// </summary>
        private void LoadBarChart()
        {
            this.panel人员工作量区.Controls.Clear();
            uc设备总体概况人员工作量 uc = new uc设备总体概况人员工作量();
            uc.Dock = DockStyle.Fill;
            this.panel人员工作量区.Controls.Add(uc);
            uc.LoadBarChart(QueryDataInfo);
        }

        private void LoadOrderData()
        {
            // 该板块有3个内容，通过修改查询条件的时候需要更新，这里直接修改查询条件，在对应控件内部进行更新数据
            this.uc设备总体概况业务单据汇总.SetQueryDataInfo(QueryDataInfo);
        }

        private void dateTimePicker开始日期_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = this.dateTimePicker开始日期.Value.Date;
            DateTime endDate = this.dateTimePicker结束日期.Value.Date;

            if (startDate > endDate)
            {
                PopUpUtil.ShowInfo("开始日期不能大于结束日期");
                return;
            }

            QueryDataInfo.StartTime = startDate;
            this.RefreshData();
        }

        private void dateTimePicker结束日期_ValueChanged(object sender, EventArgs e)
        {
            DateTime startDate = this.dateTimePicker开始日期.Value.Date;
            DateTime endDate = this.dateTimePicker结束日期.Value.Date;

            if (startDate > endDate)
            {
                PopUpUtil.ShowInfo("结束日期不能小于开始日期");
                return;
            }

            QueryDataInfo.EndTime = endDate.AddDays(1).AddTicks(-1);

            this.RefreshData();
        }

        private void button重置_Click(object sender, EventArgs e)
        {
            this.InitQueryData();
            this.comboBox组织.Text = "全部";
            this.comboBox部门.Text = "全部";
            this.dateTimePicker开始日期.Value = QueryDataInfo.StartTime.Date;
            this.dateTimePicker结束日期.Value = QueryDataInfo.EndTime.Date;
            this.RefreshData();
        }
    }
}
