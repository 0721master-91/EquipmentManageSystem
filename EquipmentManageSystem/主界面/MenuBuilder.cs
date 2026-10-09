﻿﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EquipmentManageSystem.主界面
{
    /// <summary>
    /// 菜单动态生成器：按配置创建一级/二级按钮与面板
    /// </summary>
    public static class MenuBuilder
    {
        private const int TopButtonHeight = 38;
        private const int SubButtonHeight = 37;
        private const int Width = 200;
        private static readonly Color TopBtnColor = Color.DodgerBlue;
        private static readonly Color TopBtnText = Color.White;
        private static readonly Color BorderColor = Color.FromArgb(128, 255, 255);

        /// <summary>
        /// 构建一组菜单并返回 MenuItemInfo 列表
        /// </summary>
        public static List<MenuItemInfo> Build(Control container,List<MenuConfig> configs, MainForm owner)
        {
            var result = new List<MenuItemInfo>();
            var allMenuPanels = new List<Panel>();   // 暂存一级菜单容器，稍后逆序 Add 以抵消 Dock=Top 逆序排列

            foreach (var cfg in configs)
            {
                // 一级菜单外层容器
                var menuPanel = new Panel
                {
                    Dock = DockStyle.Top,
                    BackColor = Color.Silver,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                // 二级菜单区
                var subPanel = new Panel
                {
                    Dock = DockStyle.Top,
                    BackColor = Color.White,
                    Visible = false,
                    AutoSize = true
                };

                // 二级按钮（倒序加入以保证 Dock=Top 顺序正确）
                var subButtons = new List<Button>();
                var stackButtons = new List<Button>();
                foreach (var sub in cfg.SubMenus)
                {
                    var subBtn = new Button
                    {
                        Dock = DockStyle.Top,
                        Text = sub.Text,
                        Height = SubButtonHeight,
                        Width = Width,
                        Margin = new Padding(0),
                        Tag = sub.FormType   
                    };
                    subBtn.Click += owner.selectSubButton;
                    stackButtons.Add(subBtn);
                }
                // Dock=Top 顺序为倒序，倒着加入实现正序
                for (int i = stackButtons.Count - 1; i >= 0; i--)
                {
                    subPanel.Controls.Add(stackButtons[i]);
                    subButtons.Add(stackButtons[i]);
                }

                // 一级按钮
                var topBtn = new Button
                {
                    Dock = DockStyle.Top,
                    Text = cfg.Text,
                    Height = TopButtonHeight,
                    Width = Width,
                    BackColor = TopBtnColor,
                    ForeColor = TopBtnText,
                    UseVisualStyleBackColor = false,
                    FlatStyle = FlatStyle.Flat
                };
                topBtn.FlatAppearance.BorderColor = BorderColor;
                topBtn.Click += owner.changeSubMenuShow;

                // 组装
                menuPanel.Controls.Add(subPanel);
                menuPanel.Controls.Add(topBtn);
                allMenuPanels.Add(menuPanel);

                var item = new MenuItemInfo
                {
                    Name = cfg.Name,
                    Button = topBtn,
                    SubPanel = subPanel,
                    SubButtons = subButtons
                };
                result.Add(item);
            }

            // 逆序添加一级菜单容器，抵消 Dock=Top 的逆序排列，使配置顺序 = 显示顺序
            for (int i = allMenuPanels.Count - 1; i >= 0; i--)
            {
                container.Controls.Add(allMenuPanels[i]);
            }

            return result;
        }
    }
}