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
    public partial class FrmStartUpdate : Form
    {
        public FrmStartUpdate()
        {
            InitializeComponent();
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
        private void Frm_MouseMove(object sender, MouseEventArgs  e)
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //todo
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
