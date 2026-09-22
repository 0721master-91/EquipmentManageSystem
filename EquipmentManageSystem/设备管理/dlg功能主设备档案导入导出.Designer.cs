﻿
namespace EquipmentManageSystem.设备管理
{
    partial class dlg功能主设备档案导入导出
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate excelTemplate1 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo storeInfo1 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate excelTemplate2 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo storeInfo2 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate excelTemplate3 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo storeInfo3 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate excelTemplate4 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo storeInfo4 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate excelTemplate5 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate();
            EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo storeInfo5 = new EquipmentManageSystem.模板.导入导出模板.ExcelTemplate.StoreInfo();
            EquipmentManageSystem.模板.导入导出模板.ExportField exportField1 = new EquipmentManageSystem.模板.导入导出模板.ExportField();
            EquipmentManageSystem.模板.导入导出模板.ExportField exportField2 = new EquipmentManageSystem.模板.导入导出模板.ExportField();
            EquipmentManageSystem.模板.导入导出模板.FieldRelationship fieldRelationship1 = new EquipmentManageSystem.模板.导入导出模板.FieldRelationship();
            this.SuspendLayout();
            // 
            // dlg功能主设备档案导入导出
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 765);
            storeInfo1.ConditionField = "";
            storeInfo1.ConditionFieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo1.FieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo1.ForeignTable = "";
            storeInfo1.ForeignTableStoreField = "";
            storeInfo1.MainTableStoreField = "设备编码";
            storeInfo1.ValueResolver = null;
            excelTemplate1.DatabaseStoreInfo = storeInfo1;
            excelTemplate1.Description = "输入设备编码";
            excelTemplate1.Example = "Test001";
            excelTemplate1.FieldName = "设备编码";
            excelTemplate1.NullEnabled = true;
            storeInfo2.ConditionField = null;
            storeInfo2.ConditionFieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo2.FieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo2.ForeignTable = null;
            storeInfo2.ForeignTableStoreField = null;
            storeInfo2.MainTableStoreField = "设备名称";
            storeInfo2.ValueResolver = null;
            excelTemplate2.DatabaseStoreInfo = storeInfo2;
            excelTemplate2.Description = "请输入设备名称";
            excelTemplate2.Example = "测试设备1";
            excelTemplate2.FieldName = "设备名称";
            excelTemplate2.NullEnabled = false;
            storeInfo3.ConditionField = "类型名称";
            storeInfo3.ConditionFieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo3.FieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo3.ForeignTable = "设备类型";
            storeInfo3.ForeignTableStoreField = "类型编码";
            storeInfo3.MainTableStoreField = "设备类型编码";
            storeInfo3.ValueResolver = null;
            excelTemplate3.DatabaseStoreInfo = storeInfo3;
            excelTemplate3.Description = "请输入设备类型名称（需在「设备类型」表中存在）";
            excelTemplate3.Example = "车辆设备";
            excelTemplate3.FieldName = "设备类型";
            excelTemplate3.NullEnabled = false;
            storeInfo4.ConditionField = "模块名称";
            storeInfo4.ConditionFieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo4.FieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo4.ForeignTable = "设备模块";
            storeInfo4.ForeignTableStoreField = "模块编码";
            storeInfo4.MainTableStoreField = "设备模块编码";
            storeInfo4.ValueResolver = null;
            excelTemplate4.DatabaseStoreInfo = storeInfo4;
            excelTemplate4.Description = "请输入设备模块名称（需在「设备模块」表中存在）";
            excelTemplate4.Example = "门禁系统";
            excelTemplate4.FieldName = "设备模块";
            excelTemplate4.NullEnabled = false;
            storeInfo5.ConditionField = null;
            storeInfo5.ConditionFieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo5.FieldType = EquipmentManageSystem.模板.导入导出模板.StoreFieldType.String;
            storeInfo5.ForeignTable = null;
            storeInfo5.ForeignTableStoreField = null;
            storeInfo5.MainTableStoreField = "IsEnabled";
            storeInfo5.ValueResolver = null;
            excelTemplate5.DatabaseStoreInfo = storeInfo5;
            excelTemplate5.Description = "1=启用，0=停用（留空默认为启用）";
            excelTemplate5.Example = "1";
            excelTemplate5.FieldName = "启用状态";
            excelTemplate5.NullEnabled = false;
            this.ExcelTemplates.Add(excelTemplate1);
            this.ExcelTemplates.Add(excelTemplate2);
            this.ExcelTemplates.Add(excelTemplate3);
            this.ExcelTemplates.Add(excelTemplate4);
            this.ExcelTemplates.Add(excelTemplate5);
            exportField1.ConditionField = "ID";
            exportField1.ExcelFieldName = "E设备状态";
            exportField1.ForeignTable = "设备档案";
            exportField1.ForeignTableField = "IsEnabled";
            exportField1.IsMainTableField = true;
            exportField1.OptionName = "E设备状态";
            exportField2.ConditionField = "ID";
            exportField2.ExcelFieldName = "E设备类型";
            exportField2.ForeignTable = "设备类型";
            exportField2.ForeignTableField = "类型名称";
            exportField2.IsMainTableField = false;
            exportField2.OptionName = "E设备类型";
            fieldRelationship1.ForeignTableField = "类型编码";
            fieldRelationship1.MainTableField = "设备类型编码";
            exportField2.Relationships.Add(fieldRelationship1);
            this.ExtraFields.Add(exportField1);
            this.ExtraFields.Add(exportField2);
            this.Name = "dlg功能主设备档案导入导出";
            this.OutEnabled = true;
            this.TableName = "设备档案";
            this.Text = "dlg功能主设备档案导入导";
            this.ResumeLayout(false);

        }

        #endregion
    }
}