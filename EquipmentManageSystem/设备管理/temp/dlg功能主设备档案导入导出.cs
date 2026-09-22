using EquipmentManageSystem.模板.导入导出模板;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo;

namespace EquipmentManageSystem.设备管理
{
    public partial class dlg功能主设备档案导入导出 : temp导入导出模版
    {

        public dlg功能主设备档案导入导出():base()
        {
            this.ExcelTemplates = this.GetExcelTemplate();
            InitializeComponent();
        }

        public dlg功能主设备档案导入导出(DataTable outData): base()
        {
            this.ExcelTemplates = this.GetExcelTemplate();
            this.OutData = outData;
            InitializeComponent();
        }

        //重写导入前逻辑
        protected override bool BeforeImport(DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                row["设备编码"] = row["设备编码"]?.ToString() + "_测试";
            }

            return true;
        }

        public List<ExcelTemplate> GetExcelTemplate()
        {
            List<ExcelTemplate> excelTemplates = new List<ExcelTemplate>();
            excelTemplates.Add(new ExcelTemplate(
                "设备编码", 
                "输入设备编码", 
                false, 
                new ExcelTemplate.StoreInfo("设备编码", StoreFieldType.String),
                "Test001"));
            excelTemplates.Add(new ExcelTemplate(
                "设备名称", 
                "请输入设备名称", 
                false, 
                new ExcelTemplate.StoreInfo("设备名称",StoreFieldType.String),
                "测试设备1"));
            excelTemplates.Add(new ExcelTemplate(
                "设备类型", 
                "请输入设备类型名称（需在「设备类型」表中存在）",
                false,
                new ExcelTemplate.StoreInfo("设备类型编码",StoreFieldType.String,"设备类型","类型名称",StoreFieldType.String,"类型编码"),
                "车辆设备"));
            excelTemplates.Add(new ExcelTemplate(
                "设备模块", 
                "请输入设备模块名称（需在「设备模块」表中存在）",
                false,
                new ExcelTemplate.StoreInfo("设备模块编码",StoreFieldType.String,"设备模块","模块名称",StoreFieldType.String,"模块编码"),
                "门禁系统"));
            excelTemplates.Add(new ExcelTemplate(
                "启用状态", 
                "1=启用，0=停用（留空默认为启用）", 
                true, 
                new ExcelTemplate.StoreInfo("IsEnabled", StoreFieldType.Int),
                "1"));
            return excelTemplates;
        }
    }
}
