using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EquipmentManageSystem.登录界面;
using EquipmentManageSystem.主界面;
using EquipmentManageSystem.模板.导入导出模板;

namespace EquipmentManageSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SLControls.SLDbService.SLOnlyInstOleDb.Services.InitDb();


/*            Global.UserSession.TestInit();
            Application.Run(new MainForm());*/
            Form登录界面 frmLogin = new Form登录界面();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }

        }
    }
}
