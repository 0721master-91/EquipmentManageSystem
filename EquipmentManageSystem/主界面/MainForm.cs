using EquipmentManageSystem.模板;
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
        /// 初始化所有菜单项，注册到列表中
        /// 后续改为重数据库中读取菜单配置，自动生成对应的菜单项，这里先写死
        /// </summary>
        private void InitMenuItems()
        {
            //设备管理
            MenuItemInfo menu设备管理 = new MenuItemInfo();
            menu设备管理._name = "设备管理";
            menu设备管理._button = this.button设备管理;
            menu设备管理._subPanel = this.panel设备管理二级菜单区;
            menu设备管理._subButtons.Add(this.button设备管理_功能主设备档案);
            menu设备管理._subButtons.Add(this.button设备管理_功能位置档案);
            menu设备管理.RegisterSubButtons();
            menuItemList.Add(menu设备管理);

            //===== 标准管理 =====
            MenuItemInfo menu标准管理 = new MenuItemInfo();
            menu标准管理._name = "标准管理";
            menu标准管理._button = this.button标准管理;
            menu标准管理._subPanel = this.panel标准管理二级菜单区;
            menu标准管理._subButtons.Add(this.button标准管理_保养标准);
            menu标准管理._subButtons.Add(this.button标准管理_巡检标准);
            menu标准管理.RegisterSubButtons();
            menuItemList.Add(menu标准管理);
        }

        //更换二级菜单显示
        private void changeSubMenuShow(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null) return;

            //查找点击的菜单项
            MenuItemInfo currentMenu = this.menuItemList.FirstOrDefault(m => m._button == clickedBtn);
            if(currentMenu != null)
            {
                currentMenu.changeSubMenuShow(this.lastExpansionedMenu);
                this.lastExpansionedMenu = currentMenu;
            }
        }

        //选中二级菜单项
        private void selectSubButton(object sender, EventArgs e)
        {
            Button clickedSubBtn = sender as Button;
            this.lastExpansionedMenu.changeSelectSubButton(clickedSubBtn);
            showContent(clickedSubBtn);
        }

        //显示选中的二级菜单项对应的内容
        private void showContent(Button subButton)
        {

            Form currentForm = this.getFormBySubButton(subButton);

            if (currentForm == null) return;

            if(this.lastShowForm != null)
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

        //获取二级菜单项对应的内容区对象
        private Form getFormBySubButton(Button subButton)
        {
            string name = subButton.Name;
            
            if(!name.StartsWith("button"))
            {
                /*MessageBox.Show("未指定该项对应的内容区对象", "错误",MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                InfoShowUtil.Error(this,"未指定该项对应的内容区对象");
                return null;
            }

            string path = name.Replace("button","").Replace("_", ".ctn");//通过对菜单项的属性重组获得打开路径
            string fullPath = "EquipmentManageSystem." + path;

            //通过反射获取对应的内容区对象
            Type formType = Type.GetType(fullPath);
            if(formType == null)
            {
                /*MessageBox.Show("未查找到对应内容对象","错误",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);*/
                InfoShowUtil.Error(this,"未查找到对应内容对象");
                return null;
            }
            return (Form)Activator.CreateInstance(formType);

        }
    }   

}
