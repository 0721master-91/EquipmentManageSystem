using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.模板.导入导出模板
{
    public class ExportField
    { 

        [DisplayName("Excel字段名")]
        [Description("在Excel中显示的列名")]
        public string ExcelFieldName { get; set; }

        [DisplayName("选项名称")]
        [Description("导出选择字段是显示的名称")]
        public string OptionName { get; set; }

        
        [DisplayName("是否主表字段")]
        [Description("是否为是主表字段")]
        public bool IsMainTableField { get; set; }

        [DisplayName("外表表名")]
        [Description("需要获取数据的表名")]
        public string ForeignTable { get; set; }

        [DisplayName("关联关系")]
        [Description("关联关系")]
        public List<FiledRelationship> Relationships { get; set; }

        [DisplayName("查询字段")]
        [Description("从外表中获取值的字段值")]
        public string ForeignTableField { get; set; }

        [DisplayName("条件字段")]
        [Description("作为查询条件的字段名，需要唯一，用于where条件")]
        public string ConditionField { get; set; }

        public Func< DataTable, Dictionary<string,string>> ValueResolver { get; set; }

        public ExportField() { }
        public ExportField(string excelFieldName, string optionName, bool isMainTableField, string foreignTable, List<FiledRelationship> relationships, string foreignTableField)
        {
            this.ExcelFieldName = excelFieldName;
            this.OptionName = optionName;
            this.IsMainTableField = isMainTableField;
            this.ForeignTable = foreignTable;
            this.Relationships = relationships;
            this.ForeignTableField = foreignTableField;
        }

        /// <summary>
        /// 主表与外表的关联关系，用于join条件
        /// </summary>
        public class FiledRelationship
        {
            [DisplayName("主表字段")]
            [Description("主表字段")]
            public string MainTableField { get; set; }

            [DisplayName("外表字段")]
            [Description("外表字段")]
            public string ForeignTableField { get; set; }

            public FiledRelationship() { }

            public FiledRelationship(string mainTableField, string foreignTableField)
            {
                this.MainTableField = mainTableField;
                this.ForeignTableField = foreignTableField;
            }
        }

    }
}
