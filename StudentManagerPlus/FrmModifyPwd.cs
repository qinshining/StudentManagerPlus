using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace StudentManagerPlus
{
    public partial class FrmModifyPwd : Form
    {
        private SysAdminService objAdminService = new SysAdminService();
        public FrmModifyPwd()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.txtOldPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入原密码", "提示信息");
                this.txtOldPwd.Focus();
                return;
            }
            if (this.txtNewPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入新密码", "提示信息");
                this.txtNewPwd.Focus();
                return;
            }
            if (this.txtNewPwdConfirm.Text.Length == 0)
            {
                MessageBox.Show("请确认新密码", "提示信息");
                this.txtNewPwd.Focus();
                return;
            }
            if (this.txtNewPwdConfirm.Text != this.txtNewPwd.Text)
            {
                MessageBox.Show("两次输入的新密码不一致", "提示信息");
                return;
            }
            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = Program.currentAdmin.LoginId,
                LoginPwd = this.txtNewPwd.Text
            };
            try
            {
                if (objAdminService.ModifyPwd(sysAdmin) == 1)
                {
                    MessageBox.Show("密码修改成功，请重新登录", "提示信息");
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("密码修改失败，请稍后再试", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
