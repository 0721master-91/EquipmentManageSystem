﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace EquipmentManageSystem.模板.导入导出模板
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ExportField
    {
        [Category("01 基础信息")]
        [DisplayName("Excel字段名")]
        [Description("在Excel中显示的列名")]
        public string ExcelFieldName { get; set; }

        [Category("01 基础信息")]
        [DisplayName("界面选项名称")]
        [Description("导出选择字段时显示的名称")]
        public string OptionName { get; set; }

        [Category("01 基础信息")]
        [DisplayName("是否主表字段")]
        [Description("是否为是主表字段")]
        public bool IsMainTableField { get; set; }

        [Category("02 外表查询配置")]
        [DisplayName("数据来源表名")]
        [Description("需要获取数据的表名")]
        public string ForeignTable { get; set; }

        
        private List<FieldRelationship> _relationships = new List<FieldRelationship>();

        [Category("02 外表查询配置")]
        [DisplayName("关联关系")]
        [Description("关联关系")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<FieldRelationship> Relationships
        {
            get => _relationships;
            set => _relationships = value ?? new List<FieldRelationship>();
        }

        [Category("02 外表查询配置")]
        [DisplayName("需查询字段")]
        [Description("从外表中获取值的字段值")]
        public string ForeignTableField { get; set; }

        [Category("02 外表查询配置")]
        [DisplayName("条件字段")]
        [Description("作为查询条件的字段名，需要唯一，用于where条件")]
        public string ConditionField { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<DataTable, DataTable> ValueResolver { get; set; }

        public ExportField() { }

    }

    /// <summary>
    /// 主表与外表的关联关系，用于join条件
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FieldRelationship
    {
        [NotifyParentProperty(true)]
        [DisplayName("主表字段")]
        [Description("主表字段")]
        public string MainTableField { get; set; }

        [NotifyParentProperty(true)]
        [DisplayName("外表字段")]
        [Description("外表字段")]
        public string ForeignTableField { get; set; }

        public FieldRelationship() { }
    }
}