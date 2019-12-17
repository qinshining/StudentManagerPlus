using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateApp
{
    public partial class FrmUpdate : Form
    {
        private UpdateManager objUpdateManager = null;
        private bool isDownloading = false;
        private bool isCompleted = false;
        public FrmUpdate()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            try
            {
                this.objUpdateManager = new UpdateManager();
                this.lblVersion.Text = this.objUpdateManager.LastUpdateInfo.Version;
                this.lblLastUpdateTime.Text = this.objUpdateManager.LastUpdateInfo.UpdateTime.ToString();
                foreach (var item in this.objUpdateManager.NewUpdateInfo.FileList)
                {
                    ListViewItem lvItem = new ListViewItem(item[0]);
                    lvItem.SubItems.AddRange(new string[]
                    {
                        item[1],
                        item[2],
                        string.Empty
                    });
                    this.lbUpdateList.Items.Add(lvItem);
                }
                this.objUpdateManager.ReportProcess += ShowReport;
                this.btnComplete.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 无边框窗体移动

        private bool leftFlag = false;
        private Point offSet;
        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftFlag = true;
                offSet = new Point(-e.X, -e.Y);
            }
        }
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point current = MousePosition;
                current.Offset(offSet);
                Location = current;
            }
        }
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }


        #endregion

        private void ShowReport(int index, int percent)
        {
            this.lbUpdateList.Items[index].SubItems[3].Text = percent + "%";
            this.pbDownloadPercent.Value = percent;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (this.objUpdateManager.IsNewest)
            {
                MessageBox.Show("当前是最新版本，不需要更新！！！(#^.^#)", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.lblTips.Text = "正在下载文件，请稍等...";
            this.lblStatus.Text = "正在下载...";
            try
            {
                this.isDownloading = true;
                this.objUpdateManager.DownloadFile();
                this.btnNext.Visible = false;
                this.btnCancel.Visible = false;
                this.btnComplete.Visible = true;
                this.btnComplete.Location = this.btnCancel.Location;
                this.isDownloading = false;
                this.lblTips.Text = "点击“完成”执行更新";
                this.lblStatus.Text = "下载完毕";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.btnNext.Text = "重试";
                this.lblTips.Text = "点击“重试”重新下载";
                this.lblStatus.Text = "下载发生异常";
                this.isDownloading = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                this.objUpdateManager.CopyFile();
                this.isCompleted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("复制文件过程中发生异常，请查看异常信息并重试\r\n" + ex.Message);
                return;
            }
            System.Diagnostics.Process.Start("StudentManagerPlus.exe");
            Application.ExitThread();
            Application.Exit();
        }

        private void FrmUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.isCompleted)
            {
                string questionInfo = string.Empty;
                if (this.isDownloading)
                {
                    questionInfo = "当前文件正在下载，确定要退出吗？";
                }
                else
                {
                    questionInfo = "当前更新尚未完成，确定要退出吗？";
                }
                DialogResult result = MessageBox.Show(questionInfo, "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.ExitThread();
                }
            }
        }
    }
}
