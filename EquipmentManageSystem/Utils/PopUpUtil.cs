using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 对MessageBox进行封装，提供通用显示
    /// 只是减少按键与类型的设置
    /// </summary>
    public static class PopUpUtil
    {
        /// <summary>
        /// 展示提示信息
        /// </summary>
        /// <param name="info"></param>
        public static void ShowInfo(string info)
        {
            MessageBox.Show(info, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 展示警告信息
        /// </summary>
        /// <param name="info"></param>
        public static void ShowWarning(string info)
        {
            MessageBox.Show(info, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// 展示错误信息
        /// </summary>
        /// <param name="info"></param>
        public static void ShowError(string info)
        {
            MessageBox.Show(info, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
