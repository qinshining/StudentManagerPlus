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
    public partial class FrmAttendance : Form
    {
        private StudentService objStudentService = new StudentService();
        private AttendanceService objAttendance = new AttendanceService();
        private DateTime dateTime;
        private string[] weekName = { "日", "一", "二", "三", "四", "五", "六", };
        //private List<Student> stuList = new List<Student>();
        public FrmAttendance()
        {
            InitializeComponent();
            //初始化
            this.dgvStudents.AutoGenerateColumns = false;
            try
            {
                dateTime = DALCommon.GetServerTime();
                Timer1_Tick(null, null);//避免延迟
                ShowSignResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请稍后再试：" + ex.Message);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.lblYear.Text = dateTime.Year.ToString();
            this.lblMonth.Text = dateTime.Month.ToString("00");
            this.lblDay.Text = dateTime.Day.ToString("00");
            this.lblTime.Text = dateTime.ToLongTimeString();
            this.lblDayOfWeek.Text = this.weekName[Convert.ToInt32(dateTime.DayOfWeek)];
            dateTime = dateTime.AddSeconds(1);
        }
        //展示签到结果
        private void ShowSignResult()
        {
            //查询签到记录（允许重复签到）
            this.dgvStudents.DataSource = objAttendance.QueryAttendanceToday().Tables[0];

            ////单独获取应到人数和实到人数
            //this.lblTotal.Text = objAttendance.GetStudentCount().ToString();
            //this.lblSignCount.Text = objAttendance.GetAttendCountToday().ToString();

            //一次获取应到和实到人数
            Dictionary<string, string> attendInfo = objAttendance.GetAttendanceInfo();
            this.lblTotal.Text = attendInfo["totalCount"];
            this.lblSignCount.Text = attendInfo["attendCount"];
            this.lblAbsentCount.Text = (Convert.ToInt32(this.lblTotal.Text) - Convert.ToInt32(this.lblSignCount.Text)).ToString();
        }

        private void TxtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtCardNo.Text.Trim().Length != 0 && e.KeyValue == 13)
            {
                try
                {
                    Student student = objStudentService.GetStudentByCardNo(this.txtCardNo.Text.Trim());
                    if (student == null)
                    {
                        MessageBox.Show("卡号不正确！", "提示信息");
                        this.lblTips.Text = "打卡失败！";
                    }
                    else
                    {
                        this.txtStudentName.Text = student.StudentName;
                        this.txtStudentId.Text = student.StudentId.ToString();
                        this.txtClassName.Text = student.ClassName;
                        this.pbStudentImg.Image = student.StuImage.Length == 0 ? Image.FromFile("default.png") : (Image)new Common.SerializeObjectToString().DeserializeObject(student.StuImage);

                        //student.Attendance.SignTime = this.dateTime;//打卡时间，用于展示，在网络不好的情况下可能会和数据库上记录的有差异

                        int result = objAttendance.AddRecord(this.txtCardNo.Text.Trim());
                        if (result == 1)
                        {
                            this.lblTips.Text = "打卡成功！";

                            ////不从后台查询，直接展示本地缓存的数据
                            //this.stuList.Add(student);
                            //this.dgvStudents.DataSource = null;
                            //this.dgvStudents.DataSource = this.stuList;
                            //this.dgvStudents.DataSource = objAttendance.QueryAttendanceToday();//打卡后从后台查询

                            ShowSignResult();
                            this.txtCardNo.Clear();
                        }
                        else
                        {
                            this.lblTips.Text = "打卡失败！";
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.lblTips.Text = "打卡失败！";
                    MessageBox.Show("系统异常，请联系管理员：" + ex.Message);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            this.txtCardNo.Focus();
        }

        private void DgvStudents_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
