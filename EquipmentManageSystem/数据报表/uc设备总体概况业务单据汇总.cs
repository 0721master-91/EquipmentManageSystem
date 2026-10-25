using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquipmentManageSystem.Utils;

namespace EquipmentManageSystem.数据报表
{
    public partial class uc设备总体概况业务单据汇总 : UserControl
    {
        private QueryData QueryDataInfo; // 查询条件
        private OrderType CurrentType; // 当前展示的板块

        private int DisplayQuantity = 10; // 每页展示数量
        private int CurrentPage = 1; // 当前页码
        private DataTable TempDataSource; // 临时数据源
        private int TotalPage; // 总页数
        private int TotalCount; // 总记录数
        private int ApproachingPage = 1; // 即将前往的页码

        private bool IsLoadingData = false; //是否正在加载数据 
        public uc设备总体概况业务单据汇总()
        {
            InitializeComponent();
        }

        private void uc设备总体概况业务单据汇总_Load(object sender, EventArgs e)
        {
            this.button设备保养.Tag = OrderType.Maintenance;
            this.button设备维修.Tag = OrderType.Repair;
            this.button设备巡检.Tag = OrderType.Inspect;

            this.textBox显示条数.Text = this.DisplayQuantity.ToString();
            this.textBox前往页数.Text = this.CurrentPage.ToString();

            this.LoadPageTurnPicture();
        }

        private void comboBox状态选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsLoadingData)
            {
                this.CurrentPage = 1;
                this.textBox前往页数.Text = this.CurrentPage.ToString();
                this.ApproachingPage = 1;

                this.LoadData(this.CurrentType);
            }
        }

        private void textBox显示条数_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox显示条数.Text))
            {
                this.textBox显示条数.Text = this.DisplayQuantity.ToString();
                return;
            }

            if (int.TryParse(this.textBox显示条数.Text, out int displayQuantity))
            {
                if (displayQuantity < 1)
                {
                    this.textBox显示条数.Text = "10";
                    this.DisplayQuantity = 10;
                }
                else
                {
                    this.DisplayQuantity = displayQuantity;
                    this.CurrentPage = 1;
                    this.ApproachingPage = 1;
                    this.textBox前往页数.Text = "1";
                    this.ShowData(this.TempDataSource);
                }
            }
            else
            {
                this.textBox显示条数.Text = this.DisplayQuantity.ToString();
            }
        }
        private void textBox显示条数_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;
            }
        }

        private void textBox前往页数_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox前往页数.Text))
            {
                this.textBox前往页数.Text = this.CurrentPage.ToString();
            }

            if (int.TryParse(this.textBox前往页数.Text, out int approachingPage))
            {
                if (approachingPage < 1)
                {
                    this.textBox前往页数.Text = this.CurrentPage.ToString();
                    this.ApproachingPage = this.CurrentPage;
                }
                else
                {
                    this.ApproachingPage = approachingPage > this.TotalPage ? this.TotalPage : approachingPage;
                    this.textBox前往页数.Text = this.ApproachingPage.ToString();
                }
            }
            else
            {
                this.textBox前往页数.Text = this.CurrentPage.ToString();
            }
        }
        private void textBox前往页数_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;
            }
        }

        private void pictureBox前往_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            
            this.CurrentPage = this.ApproachingPage;
            this.SwitchPage();
        }

        private void pictureBox首页_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            this.textBox前往页数.Text = "1";
            this.ApproachingPage = 1;
            this.CurrentPage = 1;
            this.SwitchPage();
        }

        private void pictureBox向左_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            if (this.CurrentPage > 1)  
            {
                this.CurrentPage--;   
                this.ApproachingPage = this.CurrentPage; 
                this.textBox前往页数.Text = this.CurrentPage.ToString();  
                this.SwitchPage(); 
            }
        }

        private void pictureBox向右_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            if (this.CurrentPage < this.TotalPage) 
            {
                this.CurrentPage++; 
                this.ApproachingPage = this.CurrentPage; 
                this.textBox前往页数.Text = this.CurrentPage.ToString();
                this.SwitchPage(); 
            }

        }

        private void pictureBox最后一页_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;

            this.CurrentPage = this.TotalPage;
            this.textBox前往页数.Text = this.TotalPage.ToString();
            this.ApproachingPage = this.TotalPage;
            this.SwitchPage();
        }

        private void button单据汇总导出_Click(object sender, EventArgs e)
        {
            DataTable data = this.TempDataSource.Copy();
            data.Columns.Remove("ID");
            using (dlg导出 dlg = new dlg导出()
            {
                QueryDataInfo = this.QueryDataInfo,
                Type = ExportDataType.BillSummary,
                OutFileName = this.label一级标题.Text.Substring(2).Replace("-", "_") + "_" +  this.comboBox状态选择.Text,
                Data = data
            })
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// 加载翻页板块中按钮图片
        /// </summary>
        private void LoadPageTurnPicture()
        {
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox首页,"Resources\\箭头-首页.png");
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox向左,"Resources\\箭头-向左.png");
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox向右,"Resources\\箭头-向右.png");
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox最后一页,"Resources\\箭头_最后一页.png");
            PictureHandleUtil.LoadPictureToPictureBox(this.pictureBox前往,"Resources\\Go.png");
        }


        private bool IsFirstLoadData = true; //是否是第一次加载数据
        /// <summary>
        /// 设置查询条件
        /// </summary>
        /// <param name="queryDataInfo"></param>
        public void SetQueryDataInfo(QueryData queryDataInfo)
        {
            this.QueryDataInfo = queryDataInfo;

            if (IsFirstLoadData)
            {
                this.SwitchSector(this.button设备维修, null); // 默认加载维修数据
            }
            else
            {
                this.LoadData(this.CurrentType);
            }
        }

        /// <summary>
        /// 切换展示板块
        /// </summary>
        private void SwitchSector(Object sender, EventArgs e)
        {
            Button button = sender as Button;
            OrderType type = (OrderType)button.Tag;
            this.CurrentType = type;

            this.ChangeStatusContent(type); // 设置状态选择框内容
            this.LoadData(type); // 加载对应的数据

        }

        private void ChangeStatusContent(OrderType type)
        {
            this.IsLoadingData = true;
            this.comboBox状态选择.DataSource = null;
            this.comboBox状态选择.Items.Clear();
            string title = this.label一级标题.Text.Split('-')[0];
            switch (type)
            {
                case OrderType.Repair:
                    {
                        CommonFilter.InitCombox(this.comboBox状态选择, "状态", "编码", "维修状态", false);
                        this.label一级标题.Text = title + "-维修工单";
                    }
                     
                    break;
                case OrderType.Maintenance:
                    {
                        CommonFilter.InitCombox(this.comboBox状态选择, "状态", "编码", "保养状态", false);
                        this.label一级标题.Text = title + "-保养任务";
                    }
                    
                    break;
                case OrderType.Inspect:
                    {
                        CommonFilter.InitCombox(this.comboBox状态选择, "状态", "编码", "执行状态", false);
                        this.label一级标题.Text = title + "-巡检任务";
                    }
                    break;
            }
            this.comboBox状态选择.SelectedIndex = 0;
            this.IsLoadingData = false;
        }

        /// <summary>
        /// 加载对应的数据
        /// </summary>
        /// <param name="type"></param>
        private void LoadData(OrderType type)
        {
            switch (type)
            {
                case OrderType.Repair:
                    this.LoadRepairData();
                    break;
                case OrderType.Maintenance: 
                    this.LoadMaintenanceData();
                    break;
                case OrderType.Inspect:
                    this.LoadInspectData();
                    break;
            }
        }

        /// <summary>
        /// 加载维修数据
        /// </summary>
        private void LoadRepairData()
        {
            string orgCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.OrgCode);
            string depCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.DepCode);
            string startTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string endTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string repairdStatusCode = SqlCommonUtil.FormatSqlValue(this.comboBox状态选择.SelectedValue);

            string sql = "select rwo.ID,rwo.维修工单编码 as 单据号,p.功能位置描述,p.位置简称,m1.姓名 as 设备负责人,rwo.单据来源,rwo.故障开始时间,m2.姓名 as 报修人,rwo.故障现象, " +
                            "dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,ul.程度 as 紧急程度,es.状态 as 执行状态,rs.状态 as 维修状态,rwo.创建时间, " +
                            "o.组织名称 as 组织,m.部门名称 as 部门 " +
                         "from 维修工单 as rwo " +
                         "left join 设备功能位置档案 as p on rwo.功能位置编码=p.功能位置编码 " +
                         "left join 组织 as o on p.组织编码 = o.组织编码 " +
                         "left join 部门 as m on p.管理部门编码 = m.部门编码 " + 
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "left join 执行状态 as es on rwo.执行状态编码 = es.编码 " +
                         "left join 维修状态 as rs on rwo.维修状态编码 = rs.编码 " +
                         "left join 成员 as m1 on m1.ID = p.责任人ID " +
                         "left join 成员 as m2 on m2.ID = rwo.报修人ID " +
                         "where rwo.IsDelete = 0 " +
                            "and rwo.维修状态编码 = " + repairdStatusCode + " " +
                            "and rwo.创建时间 between " + startTime + " and " + endTime + " " +
                            "and (" + orgCode + " is null or o.组织编码 = " + orgCode + ") " +
                            "and (" + orgCode + " is null or " + depCode + " is null or m.部门编码 = " + depCode + ") ";

            Console.WriteLine(sql);
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            this.ShowData(dt);
        }

        /// <summary>
        /// 加载保养数据
        /// </summary>
        private void LoadMaintenanceData()
        {
            string orgCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.OrgCode);
            string depCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.DepCode);
            string startTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string endTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string maintenanceStatusCode = SqlCommonUtil.FormatSqlValue(this.comboBox状态选择.SelectedValue);

            string sql = "select mt.ID,mt.保养任务编码 as 单据号,p.功能位置描述,p.位置简称,mt.计划执行日期,dbo.fn_GetMemberNamesByIds(mt.保养人员IDs) as 保养人员," +
                         "et.状态 as 执行状态,es.状态 as 过期状态,ms.状态 as 保养状态,mt.创建时间, " +
                         "o.组织名称 as 组织,m.部门名称 as 部门 " +
                         "from 保养任务 as mt " +
                         "left join 设备功能位置档案 as p on mt.设备功能位置编码 = p.功能位置编码 " +
                         "left join 组织 as o on p.组织编码 = o.组织编码 " +
                         "left join 部门 as m on p.管理部门编码 = m.部门编码 " +
                         "left join 执行状态 as et on mt.执行状态编码 = et.编码 " +
                         "left join 保养状态 as ms on mt.保养状态编码 = ms.编码 " +
                         "left join 过期状态 as es on mt.过期状态编码 = es.编码 " +
                         "where mt.IsDelete = 0 " +
                            "and mt.保养状态编码 = " + maintenanceStatusCode + " " +
                            "and mt.创建时间 between " + startTime + " and " + endTime + " " +
                            "and (" + orgCode + " is null or o.组织编码 = " + orgCode + ") " +
                            "and (" + orgCode + " is null or " + depCode + " is null or m.部门编码 = " + depCode + ") ";

            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            this.ShowData(dt);
        }

        /// <summary>
        /// 加载巡检数据
        /// </summary>
        private void LoadInspectData()
        {
            string orgCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.OrgCode);
            string depCode = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.DepCode);
            string startTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string endTime = SqlCommonUtil.FormatSqlValue(this.QueryDataInfo.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            string executeStatusCode = SqlCommonUtil.FormatSqlValue(this.comboBox状态选择.SelectedValue);

            string sql = "select t.ID,t.巡检任务编码 as 单据号,p.功能位置描述,p.位置简称,dbo.fn_GetMemberNamesByIds(t.巡检人员IDs) as 巡检人员," +
                         "t.计划执行日期,os.状态 as 过期状态,t.过期时间,es.状态 as 执行状态,t.创建时间, " +
                         "o.组织名称 as 组织,m.部门名称 as 部门 " +
                         "from 巡检任务 as t " +
                         "left join 设备功能位置档案 as p on t.设备功能位置编码 = p.功能位置编码 " +
                         "left join 组织 as o on p.组织编码 = o.组织编码 " +
                         "left join 部门 as m on p.管理部门编码 = m.部门编码 " +
                         "left join 执行状态 as es on t.执行状态编码 = es.编码 " +
                         "left join 过期状态 as os on t.过期状态编码 = os.编码 " +
                         "where t.IsDelete = 0 " +
                            "and t.执行状态编码 = " + executeStatusCode + " " +
                            "and t.创建时间 between " + startTime + " and " + endTime + " " +
                            "and (" + orgCode + " is null or o.组织编码 = " + orgCode + ") " +
                            "and (" + orgCode + " is null or " + depCode + " is null or m.部门编码 = " + depCode + ") ";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);
            this.ShowData(dt);
        }

        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="dt"></param>
        private void ShowData(DataTable dt)
        {   
            this.TotalCount = (dt == null || dt.Rows.Count == 0) ? 0 : dt.Rows.Count;
            if (this.TotalCount > 0)
            {
                this.TotalPage = (int)Math.Ceiling((double)this.TotalCount / this.DisplayQuantity);
            }
            else
            {
                this.TotalPage = 0;
            }
            this.TempDataSource = dt;

            this.SwitchPage(); // 切换显示页面，加载数据
            this.dataGridView单据数据.AllowUserToAddRows = false;
            this.dataGridView单据数据.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            var colID = this.dataGridView单据数据.Columns["ID"];
            if (colID != null) colID.Visible = false;
            this.dataGridView单据数据.Columns["部门"].Visible = false;
            this.dataGridView单据数据.Columns["组织"].Visible = false;


            this.label翻页信息记录.Text = "条/共" + this.TotalCount + "条记录";
            this.label翻页信息页.Text = "共" + this.TotalPage + "页";
        }

        /// <summary>
        /// 切换显示页面
        /// </summary>
        private void SwitchPage()
        {
            if (this.TempDataSource == null) return;

            DataTable pageData = this.TempDataSource.Clone();
            int startIndex = (this.CurrentPage - 1) * this.DisplayQuantity; // 当前页起始索引
            int endIndex = startIndex + this.DisplayQuantity; // 当前页结束索引
            endIndex = endIndex > this.TotalCount ? this.TotalCount : endIndex; // 如果结束索引大于总记录数，则结束索引等于总记录数
            for (int i = startIndex; i < endIndex; i++)
            {
                pageData.ImportRow(this.TempDataSource.Rows[i]);
            }

            this.dataGridView单据数据.DataSource = pageData;
        }
    }
}
 