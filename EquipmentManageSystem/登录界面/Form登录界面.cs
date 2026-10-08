using System;
using System.Data;
using System.Windows.Forms;

namespace EquipmentManageSystem.登录界面
{
    public partial class Form登录界面 : Form
    {
        public Form登录界面()
        {
            InitializeComponent();
        }

        private void button登录_Click(object sender, EventArgs e)
        {
            string userName = this.textBox用户名输入框.Text.Trim();
            string pwd = this.textBox密码输入框.Text.Trim();

            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("用户名或密码不能为空","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                string sql = string.Format("select * from [用户] where 用户名 = '{0}' and 密码 = '{1}'",userName.Replace("'","''"),pwd.Replace("'","''"));
                DataTable dt = SLControls.SLDbService.SLOnlyInstOleDb.Services.ExecuteForDataTable(sql);

                if(dt != null && dt.Rows.Count > 0)
                {
                    Global.UserSession.Login(dt.Rows[0]); // 将用户信息保存到全局变量中
                    MessageBox.Show("登录成功！欢迎，" + dt.Rows[0]["姓名"], "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录失败,账号或密码错误","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("登录失败" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
