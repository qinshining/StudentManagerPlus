using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace StudentManagerPlus
{
    public partial class FrmSetDB : Form
    {
        public FrmSetDB()
        {
            InitializeComponent();
            //初始化数据
            string currentString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            string[] connInfo = currentString.Split(';');
            this.txtServer.Text = connInfo[0].Substring(connInfo[0].IndexOf('=') + 1);
            this.txtDataBase.Text = connInfo[1].Substring(connInfo[1].IndexOf('=') + 1);
            this.txtUid.Text = connInfo[2].Substring(connInfo[2].IndexOf('=') + 1);
            this.txtPwd.Text = connInfo[3].Substring(connInfo[3].IndexOf('=') + 1);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.txtServer.Text.Trim().Length == 0 || this.txtDataBase.Text.Trim().Length == 0 || this.txtUid.Text.Trim().Length == 0 || this.txtPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入完整数据");
                return;
            }
            string newString = "Server=" + this.txtServer.Text.Trim() + ";" + "DataBase=" + this.txtDataBase.Text.Trim() + ";" + "Uid=" + this.txtUid.Text.Trim() + ";" + "Pwd=" + this.txtPwd.Text;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["connString"].ConnectionString = newString;
                config.Save(ConfigurationSaveMode.Minimal);
                MessageBox.Show("保存成功", "提示信息");
                Application.Restart();//重启确保配置刷新
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常，请稍后再试：" + ex.Message, "提示信息");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
