﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.主界面
{
    public class MenuItemInfo
    {
        /// 菜单名称
        public string Name { get; set; }
        /// 一级菜单项
        public Button Button { get; set; }
        /// 二级菜单区
        public Panel SubPanel { get; set; }
        /// 所有二级菜单项
        public List<Button> SubButtons { get; set; }
        /// 当前选中的二级菜单项
        public Button CurrentSelectedSubButton { get; set; }

        public MenuItemInfo()
        {
            SubButtons = new List<Button>();
        }

        /// <summary>
        /// 关闭菜单项
        /// </summary>
        public void close()
        {

        }

        /// <summary>
        /// 切换二级菜单显示
        /// </summary>
        public void changeSubMenuShow(MenuItemInfo last)
        {
        
            if(last == null)
            {
                this.show();
                return;
            }

            if(this.Name == last.Name)
            {
                this.SubPanel.Visible = !this.SubPanel.Visible;
                this.Button.BackColor = this.SubPanel.Visible ? MenuColorProvider.GetColor(MenuColorType.Level1Selected) : MenuColorProvider.GetColor(MenuColorType.Level1UnSelected);    
            }
            else
            {
                this.show();
                last.hide();
            }
        }

        /// <summary>
        /// 打开二级菜单
        /// </summary>
        public void show()
        {
            this.SubPanel.Visible = true;
            this.Button.BackColor = MenuColorProvider.GetColor(MenuColorType.Level1Selected);
        }

        /// <summary>
        /// 隐藏二级菜单
        /// </summary>
        public void hide()
        {
            this.SubPanel.Visible = false;
            this.Button.BackColor = MenuColorProvider.GetColor(MenuColorType.Level1UnSelected);
            if (this.CurrentSelectedSubButton != null)
                this.CurrentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2UnSelected);
            this.CurrentSelectedSubButton = null;
        }  

        /// <summary>
        /// 切换二级菜单选中项
        /// </summary>
        public void changeSelectSubButton(Button btn)
        {
            if(this.CurrentSelectedSubButton == null)
            {
                this.CurrentSelectedSubButton = btn;
                this.CurrentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2Selected);
                return;
            }

            if (this.CurrentSelectedSubButton != btn)
            {
                this.CurrentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2UnSelected);
                btn.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2Selected);
                this.CurrentSelectedSubButton = btn;
            }
        }
    }
}