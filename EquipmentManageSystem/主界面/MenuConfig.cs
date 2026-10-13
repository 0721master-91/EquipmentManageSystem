using System;
using System.Collections.Generic;

namespace EquipmentManageSystem.主界面
{
    public static class MenuConfigData
    {
        public static List<MenuConfig> GetMenuConfigData()
        {
            var configs = new List<MenuConfig>
            {
                new MenuConfig
                {
                    Name = "设备管理",
                    Text = "设备管理",
                    SubMenus =
                    {
                        new SubMenuConfig { Text = "功能主设备档案",
                                            FormType = typeof(设备管理.ctn功能主设备档案) },
                        new SubMenuConfig { Text = "功能位置档案",
                                            FormType = typeof(设备管理.ctn功能位置档案) }
                    }
                },
                new MenuConfig
                {
                    Name = "标准管理",
                    Text = "标准管理",
                    SubMenus =
                    {
                         new SubMenuConfig { Text = "巡检标准", FormType = typeof(标准管理.ctn巡检标准) },
                         new SubMenuConfig { Text = "保养标准", FormType = typeof(标准管理.ctn保养标准) }
                    }
                },
                new MenuConfig
                {
                    Name = "设备巡检",
                    Text = "设备巡检",
                    SubMenus =
                    {
                        new SubMenuConfig { Text = "巡检任务", FormType = typeof(设备巡检.ctn巡检任务) },
                        new SubMenuConfig { Text = "任务接取", FormType = typeof(设备巡检.ctn巡检任务接取) },
                    }
                },
                new MenuConfig
                {
                    Name = "设备保养",
                    Text = "设备保养",
                    SubMenus =
                    {
                        new SubMenuConfig {Text = "保养任务", FormType = typeof(设备保养.ctn保养任务) },
                        new SubMenuConfig {Text = "任务接取", FormType = typeof(设备保养.ctn保养任务接取) },
                        new SubMenuConfig {Text = "保养验收", FormType = typeof(设备保养.ctn保养任务验收) }
                    }
                },
                new MenuConfig
                {
                    Name = "设备维修",
                    Text = "设备报修",
                    SubMenus =
                    {
                        new SubMenuConfig {Text = "故障报修"},
                        new SubMenuConfig {Text = "维修任务"},
                        new SubMenuConfig {Text = "任务接取"},
                        new SubMenuConfig {Text = "维修验收"}
                    }
                }
            };
            return configs;
        }
    }

    /// <summary>
    /// 一级菜单配置项
    /// </summary>
    public class MenuConfig
    {
        /// <summary>菜单名称（唯一标识）</summary>
        public string Name { get; set; }

        /// <summary>一级按钮显示文本</summary>
        public string Text { get; set; }

        /// <summary>二级子菜单项</summary>
        public List<SubMenuConfig> SubMenus { get; set; }

        public MenuConfig()
        {
            SubMenus = new List<SubMenuConfig>();
        }
    }

    /// <summary>
    /// 二级菜单配置项
    /// </summary>
    public class SubMenuConfig
    {
        /// <summary>按钮显示文本</summary>
        public string Text { get; set; }

        /// <summary>点击后打开的内容窗体类型</summary>
        public Type FormType { get; set; }
    }
}
