using DevExpress.XtraGrid.Views.Grid;
using SLControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLQLControls.模板;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 圣兰编辑对话框工具类
    /// </summary>
    public static class SLEditDialogUtil
    {
        /// <summary>
        /// 获取信息展示界面对象，无修改操作键
        /// </summary>
        /// <param name="gc">圣兰数据表格控件</param>
        /// <param name="type">展示界面数据类型</param>
        /// <returns>显示界面对象</returns>
        public static SLAomTmpForm GetDetaisDialogObj(temp标准基本信息GridControl gc, Type type)
        {
            var gv = gc.slDevGridControlMain.MainGridView;
            // 判断是否有选中行
            if (gv.FocusedRowHandle < 0)
            {
                PopUpUtil.ShowInfo("请先选择要查看的数据！");
                return null;
            }

            // 获取指定行
            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row == null) return null;
            long id = Convert.ToInt64(row["ID"]);

            // 显示信息展示界面
            SLAomTmpForm form = (SLAomTmpForm)Activator.CreateInstance(type) ;

            form.OperFlag = SLControls.SLGlobal.SleOperFlag.Modify;
            form.TableName = gc.TableName;
            form.PrimaryKey = new SLControls.SLGlobal.SlcFieldInfo()
            {
                OperatorMode = SLControls.SLGlobal.SleOperatorMode.Read,
                KeyName = "ID",
                KeyValue = id,
                KeyType = SLControls.SLGlobal.SleDataType.Digit
            };

            return form;
        }
    }
}
