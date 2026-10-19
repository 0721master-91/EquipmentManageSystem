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
    public partial class uc维修工单基本信息 : UserControl
    {
        public uc维修工单基本信息()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载维修工单基本信息
        /// </summary>
        /// <param name="billCode">维修工单单据号（编码）</param>
        public void LoadRepairdOrderBaseData(string billCode)
        {
            this.LoadBillCodeInfo(billCode);
            this.LoadOrganizationInfo(billCode);
            this.LoadFunctionPositionInfo(billCode);
        } 

        /// <summary>
        /// 加载单据信息,主要包含维修工单中的信息
        /// </summary>
        private void LoadBillCodeInfo(string billCode)
        {
            string sql = "select rwo.单据类型,rwo.单据来源,rwo.上游单据号,es.状态 as 执行状态,dbo.fn_GetMemberNamesByIds(rwo.维修人员IDs) as 维修人员,ul.程度 as 紧急程度,rwo.故障开始时间," +
                            "rwo.故障现象,rwo.故障备注信息,rwo.故障开始时间,rwo.故障照片路径 " +
                         "from 维修工单 as rwo " +
                         "left join 执行状态 as es on rwo.执行状态编码 = es.编码 " +
                         "left join 紧急程度 as ul on rwo.紧急程度编码 = ul.编码 " +
                         "where rwo.维修工单编码 = '" + billCode + "'";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            if(dt.Rows.Count == 0)
            {
                PopUpUtil.ShowWarning("未找到该维修工单的信息！");
                return;
            }

            this.textBox单据号.Text = billCode;
            this.textBox单据类型.Text = dt.Rows[0]["单据类型"].ToString();
            this.textBox单据来源.Text = dt.Rows[0]["单据来源"].ToString();
            this.textBox上游单据号.Text = dt.Rows[0]["上游单据号"].ToString();
            this.textBox执行状态.Text = dt.Rows[0]["执行状态"].ToString();
            this.textBox维修人员.Text = dt.Rows[0]["维修人员"].ToString();
            this.textBox紧急程度.Text = dt.Rows[0]["紧急程度"].ToString();
            this.textBox故障开始时间.Text = dt.Rows[0]["故障开始时间"].ToString();
            this.textBox故障现象.Text = dt.Rows[0]["故障现象"].ToString();
            this.textBox故障备注.Text = dt.Rows[0]["故障备注信息"].ToString();

            object pathsObj = dt.Rows[0]["故障照片路径"];
            string paths = pathsObj == null ? "" : pathsObj.ToString();
            PictureHandleUtil.LoadPicturesToPanel(this.flowLayoutPanel故障照片, paths);
        }

        /// <summary>
        /// 加载组织机构信息
        /// 该信息不能从维修工单表中直接获取，需要从其他表中获取
        /// </summary>
        /// <param name="billCode"></param>
        private void LoadOrganizationInfo(string billCode)
        {
            string sql = "select o.公司地址,d.部门名称,m.姓名 " +
                         "from 成员 as m " +
                         "join 维修工单 as rwo on rwo.报修人ID = m.ID " +
                         "left join 部门 as d on m.部门编码 = d.部门编码 " +
                         "left join 组织 as o on d.组织编码 = o.组织编码 " +
                         "where rwo.维修工单编码 = '" + billCode + "'";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            this.textBox流程组织.Text = dt.Rows[0]["公司地址"].ToString();
            this.textBox流程部门.Text = dt.Rows[0]["部门名称"].ToString();
            this.textBox报修人.Text = dt.Rows[0]["姓名"].ToString();
        }

        /// <summary>
        /// 加载功能位置信息
        /// 该信息维修工单中没有，需要通过维修工单获取功能位置编码
        /// </summary>
        private void LoadFunctionPositionInfo(string billCode)
        {
            string sql = "select s.功能位置编码,s.功能位置描述,s.位置简称,r.名称 as 所属区域,d.部门名称 as 管理部门,m.姓名 as 设备责任人 " +
                         "from 设备功能位置档案 as s " +
                         "left join 区域 as r on s.所属区域编码 = r.编码 " +
                         "left join 部门 as d on s.管理部门编码 = d.部门编码 " +
                         "left join 成员 as m on s.责任人ID = m.ID " +
                         "join 维修工单 rwo on rwo.功能位置编码 = s.功能位置编码 " +
                         "where rwo.维修工单编码 = '" + billCode + "'";
            DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

            this.textBox功能位置编码.Text = dt.Rows[0]["功能位置编码"].ToString();
            this.textBox功能位置描述.Text = dt.Rows[0]["功能位置描述"].ToString();
            this.textBox位置简称.Text = dt.Rows[0]["位置简称"].ToString();
            this.textBox所属区域.Text = dt.Rows[0]["所属区域"].ToString();
            this.textBox设备管理部门.Text = dt.Rows[0]["管理部门"].ToString();
            this.textBox设备负责人.Text = dt.Rows[0]["设备责任人"].ToString();
        }
    }
}
