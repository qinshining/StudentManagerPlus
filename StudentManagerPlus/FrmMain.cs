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
using UpdateApp;

namespace StudentManagerPlus
{
    public partial class FrmMain : Form
    {
        private UpdateManager objUpdateManager = null;
        public FrmMain()
        {
            InitializeComponent();
            //初始化版本号
            this.lblVersion.Text = ConfigurationManager.AppSettings["p_version"].ToString();
            this.lblCurrentUser.Text = Program.currentAdmin.AdminName;
            try
            {
                this.objUpdateManager = new UpdateManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 无边框窗体移动

        private bool lefFlag;
        private Point offSet;
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lefFlag = true;
                offSet = new Point(-e.X, -e.Y);
            }
        }

        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (lefFlag)
            {
                Point position = Control.MousePosition;
                position.Offset(offSet.X, offSet.Y);
                Location = position;
            }
        }

        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (lefFlag)
            {
                lefFlag = false;
            }
        }

        #endregion

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 菜单栏按钮

        //修改密码
        private void TsmiChangePwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd frmModifyPwd = new FrmModifyPwd();
            frmModifyPwd.ShowDialog();
        }

        private void TsmiSwitchAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("切换账号，确定吗？", "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenNewForm(Form form)
        {
            foreach (Control item in this.splitContainer.Panel2.Controls)
            {
                if (item is Form)
                {
                    ((Form)item).Close();
                }
            }
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.splitContainer.Panel2;
            form.Show();
        }

        private void TsmiAddStudent_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmAddStudent)
            {
                return;
            }
            FrmAddStudent frmAddStudent = new FrmAddStudent();
            OpenNewForm(frmAddStudent);
        }

        private void TsmiImportStudents_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmImportData)
            {
                return;
            }
            FrmImportData frmImportData = new FrmImportData();
            OpenNewForm(frmImportData);
        }

        private void TsmiStudentManage_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmStudentManage)
            {
                return;
            }
            FrmStudentManage frmStudentManage = new FrmStudentManage();
            OpenNewForm(frmStudentManage);
        }

        private void TsmiScoreAnalysis_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmScoreManage)
            {
                return;
            }
            FrmScoreManage frmScoreManage = new FrmScoreManage();
            OpenNewForm(frmScoreManage);
        }

        private void TsmiScoreQuery_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmScoreQuery)
            {
                return;
            }
            FrmScoreQuery frmScoreQuery = new FrmScoreQuery();
            OpenNewForm(frmScoreQuery);
        }

        private void TsmiSignAttendance_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmAttendance)
            {
                return;
            }
            FrmAttendance frmAttendance = new FrmAttendance();
            OpenNewForm(frmAttendance);
        }

        private void TsmiAttendanceQuery_Click(object sender, EventArgs e)
        {
            if (this.splitContainer.Panel2.Controls.Count > 0 && this.splitContainer.Panel2.Controls[0] is FrmAttendanceQuery)
            {
                return;
            }
            FrmAttendanceQuery frmAttendanceQuery = new FrmAttendanceQuery();
            OpenNewForm(frmAttendanceQuery);
        }

        private void TsmiVisitOfficialWeb_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("iexplore.exe", "http://www.xiketang.com");
            System.Diagnostics.Process.Start("iexplore.exe", "https://user.qzone.qq.com/489856617");
        }
        //todo
        private void TsmiUpdateSys_Click(object sender, EventArgs e)
        {
            if (this.objUpdateManager.IsNewest)
            {
                if (this.objUpdateManager.IsNewest)
                {
                    MessageBox.Show("当前是最新版本，不需要更新", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            DialogResult result = MessageBox.Show("为了更新文件,将退出当前程序，请确保数据已经保存！确认退出吗？", "询问",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("UpdateApp.exe");
                Application.Exit();
            }
        }

        private void TsmiAboutUs_Click(object sender, EventArgs e)
        {
            FrmAboutUs frmAboutUs = new FrmAboutUs();
            frmAboutUs.ShowDialog();
        }

        #endregion

        #region 界面按钮

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            TsmiAddStudent_Click(null, null);
        }

        private void BtnStudentManage_Click(object sender, EventArgs e)
        {
            TsmiStudentManage_Click(null, null);
        }

        private void BtnSignAttendance_Click(object sender, EventArgs e)
        {
            TsmiSignAttendance_Click(null, null);
        }

        private void BtnAttendanceManage_Click(object sender, EventArgs e)
        {
            TsmiAttendanceQuery_Click(null, null);
        }

        private void BtnScoreQuery_Click(object sender, EventArgs e)
        {
            TsmiScoreQuery_Click(null, null);
        }

        private void BtnScoreAnalysis_Click(object sender, EventArgs e)
        {
            TsmiScoreAnalysis_Click(null, null);
        }

        private void BtnChangePwd_Click(object sender, EventArgs e)
        {
            TsmiChangePwd_Click(null, null);
        }

        private void BtnSwitchAccount_Click(object sender, EventArgs e)
        {
            TsmiSwitchAccount_Click(null, null);
        }

        private void BtnVisitOfficialWeb_Click(object sender, EventArgs e)
        {
            TsmiVisitOfficialWeb_Click(null, null);
        }

        private void BtnUpdateSys_Click(object sender, EventArgs e)
        {
            TsmiUpdateSys_Click(null, null);
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            TsmiImportStudents_Click(null, null);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("确定要退出吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
