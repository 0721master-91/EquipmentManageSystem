using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EquipmentManageSystem.主界面
{
    public enum MenuColorType
    {
        /// <summary>
        /// 一级菜单选中状态
        /// </summary>
        Level1Selected,

        /// <summary>
        /// 一级菜单未选中状态
        /// </summary>
        Level1UnSelected,

        /// <summary>
        /// 二级菜单选中状态
        /// </summary>
        Level2Selected,

        /// <summary>
        /// 二级菜单未选中状态
        /// </summary>
        Level2UnSelected
    }

    public static class MenuColorProvider
    {
        // 一级菜单 - 选中状态颜色 (DodgerBlue)
        private static readonly Color _level1Selected = Color.FromArgb(30, 144, 255);
        // 一级菜单 - 未选中状态颜色 (CornflowerBlue)
        private static readonly Color _level1UnSelected = Color.FromArgb(100, 149, 237);
        // 二级菜单 - 选中状态颜色 (AliceBlue)
        private static readonly Color _level2Selected = Color.FromArgb(240, 248, 255);
        // 二级菜单 - 未选中状态颜色 (White)
        private static readonly Color _level2UnSelected = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// 根据菜单颜色类型获取对应的 System.Drawing.Color 值
        /// </summary>
        public static Color GetColor(MenuColorType type)
        {
            switch (type)
            {
                case MenuColorType.Level1Selected:
                    return _level1Selected;
                case MenuColorType.Level1UnSelected:
                    return _level1UnSelected;
                case MenuColorType.Level2Selected:
                    return _level2Selected;
                case MenuColorType.Level2UnSelected:
                    return _level2UnSelected;
                default:
                    return Color.White;
            }
        }
    }

}
