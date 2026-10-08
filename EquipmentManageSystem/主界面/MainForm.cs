﻿﻿﻿﻿﻿using EquipmentManageSystem.模板;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.主界面
{
    public partial class MainForm : Form
    {
        //上一个菜单项
        private MenuItemInfo lastExpansionedMenu = null;

        //所有一级菜单列表
        private List<MenuItemInfo> menuItemList = new List<MenuItemInfo>();

        //上一个显示内容
        private Form lastShowForm = null;

        public MainForm()
        {
            InitializeComponent();
            InitMenuItems(); //初始化菜单项
        }

        //页面加载时设置页面样式
        private void Form主界面_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            this.Width = workingArea.Width;
            this.Height = workingArea.Height;
        }

        /// <summary>
        /// 初始化所有菜单项，通过配置动态生成，后续可改为从数据库读取配置
        /// </summary>
        private void InitMenuItems()
        {
            this.menuItemList = MenuBuilder.Build(this.panel菜单选项区, MenuConfigData.GetMenuConfigData(), this);
        }

        //更换二级菜单显示
        public void changeSubMenuShow(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null) return;

            //查找点击的菜单项
            MenuItemInfo currentMenu = this.menuItemList.FirstOrDefault(m => m.Button == clickedBtn);
            if(currentMenu != null)
            {
                currentMenu.changeSubMenuShow(this.lastExpansionedMenu);
                this.lastExpansionedMenu = currentMenu;
            }
        }

        //选中二级菜单项
        public void selectSubButton(object sender, EventArgs e)
        {
            Button clickedSubBtn = sender as Button;
            this.lastExpansionedMenu.changeSelectSubButton(clickedSubBtn);
            showContent(clickedSubBtn);
        }

        //显示选中的二级菜单项对应的内容
        private void showContent(Button subButton)
        {
            // 动态配置时：直接从按钮 Tag 拿到类型并创建（无反射、无名称映射）
            Form currentForm = (Form)Activator.CreateInstance(subButton.Tag as Type);

            if (this.lastShowForm != null)
            {
                this.lastShowForm.Close();
                this.lastShowForm.Dispose();
                this.lastShowForm = null;
            }

            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;

            this.panel内容显示区.Controls.Clear();
            this.panel内容显示区.Controls.Add(currentForm);

            this.lastShowForm = currentForm;
            currentForm.Show();
        }
    }   

}