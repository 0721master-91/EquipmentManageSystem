﻿﻿﻿﻿using System;
using System.ComponentModel;
using System.Data;

namespace EquipmentManageSystem.模板.导入导出模板
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ExcelTemplate
    {
        [DisplayName("Excel字段名")]
        [Description("在Excel中显示的列名")]
        public string FieldName { get; set; }

        [DisplayName("备注说明")]
        [Description("用于添加在Excel中说明该字段的信息")]
        public string Description { get; set; }

        [DisplayName("是否必填")]
        [Description("该字段的值是否为必填")]
        public bool NullEnabled { get; set; }

        [DisplayName("数据库存储信息")]
        [Description("导入数据时，需要要存储到数据库中的信息以及获取其他值相关信息")]
        public StoreInfo DatabaseStoreInfo { get; set; } = new StoreInfo();

        [DisplayName("示例数据")]
        [Description("示例数据")]
        public string Example { get; set; }//示例数据

        //数据库存储信息类
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class StoreInfo
        {
            [NotifyParentProperty(true)]
            [DisplayName("主表存储字段")]
            [Description("插入数据时，该字段对应的数据库表字段名")]
            public string MainTableStoreField { get; set; }//主表存储字段名

            [NotifyParentProperty(true)]
            [DisplayName("主表存储字段类型")]
            [Description("该字段存储在数据库中的数据类型")]
            public StoreFieldType FieldType { get; set; }

            [NotifyParentProperty(true)]
            [DisplayName("外表表名")]
            [Description("需要该数据需要从外表访问获取的表名")]
            public string ForeignTable { get; set; }

            [NotifyParentProperty(true)]
            [DisplayName("外表条件字段")]
            [Description("用于查询外表的条件字段名")]
            public string ConditionField { get; set; }

            [NotifyParentProperty(true)]
            [DisplayName("外表条件字段类型")]
            [Description("用于查询外表的条件字段类型")]
            public StoreFieldType ConditionFieldType { get; set; }

            [NotifyParentProperty(true)]
            [DisplayName("外表存储字段")]
            [Description("最终需要存储到主表的外表字段名")]
            public string ForeignTableStoreField { get; set; }

            [Browsable(false)]
            public Func<string, DataRow, object> ValueResolver { get; set; }// 委托：用于自定义将Excel单元格的值转换为数据库存储的值的逻辑

            public StoreInfo() { }
            //无外表参与，直接存入字段
            public StoreInfo(string mainTableStoreField, StoreFieldType fieldType)
            {
                this.MainTableStoreField = mainTableStoreField;
                this.FieldType = fieldType;
            }

            //需要到外表获取值填到主表
            public StoreInfo(string mainTableStoreField, StoreFieldType fieldType, string foreignTable, string ConditionField, StoreFieldType ConditionFieldType, string foreignTableStoreField)
            {
                this.MainTableStoreField = mainTableStoreField;
                this.FieldType = fieldType;
                this.ForeignTable = foreignTable;
                this.ConditionField = ConditionField;
                this.ConditionFieldType = ConditionFieldType;
                this.ForeignTableStoreField = foreignTableStoreField;
            }
        }

        public ExcelTemplate() { }

        //有示例数据的构造函数
        public ExcelTemplate(string fieldName, string description, bool nullEnabled, StoreInfo storeInfo, string example)
        {
            this.FieldName = fieldName;
            this.Description = description;
            this.NullEnabled = nullEnabled;
            this.DatabaseStoreInfo = storeInfo;
            this.Example = example;
        }
    }
}