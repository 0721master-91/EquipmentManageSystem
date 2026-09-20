using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.主界面
{
    public class MenuItemInfo
    {
        /// 菜单名称
        public string _name { get; set; }
        /// 一级菜单项
        public Button _button { get; set; }
        /// 二级菜单区
        public Panel _subPanel { get; set; }
        /// 所有二级菜单项
        public List<Button> _subButtons { get; set; }
        /// 当前选中的二级菜单项
        public Button _currentSelectedSubButton { get; set; }

        public MenuItemInfo()
        {
            _subButtons = new List<Button>();
        }

        public void RegisterSubButtons()
        {
            if (_subButtons != null && _subButtons.Count > 0)
            {
                foreach (Button btn in _subButtons)
                {
                    btn.Tag = this;
                }
            }
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

            if(this._name == last._name)
            {
                this._subPanel.Visible = !this._subPanel.Visible;
                this._button.BackColor = this._subPanel.Visible ? MenuColorProvider.GetColor(MenuColorType.Level1Selected) : MenuColorProvider.GetColor(MenuColorType.Level1UnSelected);    
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
            this._subPanel.Visible = true;
            this._button.BackColor = MenuColorProvider.GetColor(MenuColorType.Level1Selected);
        }

        /// <summary>
        /// 隐藏二级菜单
        /// </summary>
        public void hide()
        {
            this._subPanel.Visible = false;
            this._button.BackColor = MenuColorProvider.GetColor(MenuColorType.Level1UnSelected);
            if (this._currentSelectedSubButton != null)
                this._currentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2UnSelected);
            this._currentSelectedSubButton = null;
        }  

        /// <summary>
        /// 切换二级菜单选中项
        /// </summary>
        public void changeSelectSubButton(Button btn)
        {
            if(this._currentSelectedSubButton == null)
            {
                this._currentSelectedSubButton = btn;
                this._currentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2Selected);
                return;
            }

            if (this._currentSelectedSubButton != btn)
            {
                this._currentSelectedSubButton.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2UnSelected);
                btn.BackColor = MenuColorProvider.GetColor(MenuColorType.Level2Selected);
                this._currentSelectedSubButton = btn;
            }
        }
    }
}
