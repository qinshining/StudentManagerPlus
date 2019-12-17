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
    public partial class FrmAttendanceQuery : Form
    {
        private AttendanceService objAttendance = new AttendanceService();
        private DataSet ds = null;
        public FrmAttendanceQuery()
        {
            InitializeComponent();
            this.dgvStudents.AutoGenerateColumns = false;
            //初始化时查询一次
            ShowSignResult();
        }

        //展示签到结果
        private void ShowSignResult()
        {
            //查询签到记录（允许重复签到）
            this.ds = objAttendance.QueryAttendanceToday(this.dtpQueryDate.Value);
            this.dgvStudents.DataSource = ds.Tables[0];
            //一次获取应到和实到人数
            Dictionary<string, string> attendInfo = objAttendance.GetAttendanceInfo(this.dtpQueryDate.Value);
            this.lblTotal.Text = attendInfo["totalCount"];
            this.lblSignCount.Text = attendInfo["attendCount"];
            this.lblAbsentCount.Text = (Convert.ToInt32(this.lblTotal.Text) - Convert.ToInt32(this.lblSignCount.Text)).ToString();
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            ShowSignResult();
            TxtStudentName_TextChanged(null, null);
        }

        private void TxtStudentName_TextChanged(object sender, EventArgs e)
        {
            if (this.ds == null)
            {
                return;
            }
            if (this.txtStudentName.Text.Trim().Length != 0)
            {
                this.ds.Tables[0].DefaultView.RowFilter = string.Format("StudentName like '{0}%'", this.txtStudentName.Text.Trim());
            }
            else
            {
                this.ds.Tables[0].DefaultView.RowFilter = string.Empty;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvStudents_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
