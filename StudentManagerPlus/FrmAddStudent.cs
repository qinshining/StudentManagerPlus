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
using MyVideo;

namespace StudentManagerPlus
{
    public partial class FrmAddStudent : Form
    {
        private StudentService objStudentService = new StudentService();
        private List<Student> stuList = new List<Student>();
        private Video objVideo = null;
        public FrmAddStudent()
        {
            InitializeComponent();
            this.btnCloseVideo.Enabled = this.btnTake.Enabled = false;
            this.dgvStudents.AutoGenerateColumns = false;//禁止自动生成列
            //new Common.DataGridViewStyle().DgvStyle1(this.dgvStudents);
            //初始化班级下拉框
            try
            {
                this.cbbClass.DataSource = new StudentClassService().GetAllClass();
                this.cbbClass.DisplayMember = "ClassName";
                this.cbbClass.ValueMember = "ClassId";
                this.cbbClass.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，请稍后再试：" + ex.Message);
            }
        }

        #region 摄像头 还存在些问题

        //启动摄像头
        private void BtnStartVideo_Click(object sender, EventArgs e)
        {
            try
            {
                objVideo = new Video(pbVideo.Handle, this.pbVideo.Left, this.pbVideo.Top, this.pbVideo.Width, (short)this.pbVideo.Height);
                objVideo.OpenVideo();
                this.btnStartVideo.Enabled = false;
                this.btnCloseVideo.Enabled = this.btnTake.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头启动失败！" + ex.Message, "提示信息");
            }
        }
        //关闭摄像头
        private void BtnCloseVideo_Click(object sender, EventArgs e)
        {
            if (objVideo != null)
            {
                objVideo.CloseVideo();
                this.btnStartVideo.Enabled = true;
                this.btnCloseVideo.Enabled = this.btnTake.Enabled = false;
            }
        }
        //拍照
        private void BtnTake_Click(object sender, EventArgs e)
        {
            if (objVideo == null)
            {
                MessageBox.Show("请先启动摄像头！", "保存提示");
            }
            else
            {
                this.pbStudentImg.Image = objVideo.CatchVideo();
            }
        }

        #endregion

        //清除照片
        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.pbVideo.Image = null;
            this.pbStudentImg.Image = null;
        }
        //选择照片
        private void BtnChoosePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbStudentImg.Image = Image.FromFile(openFile.FileName);
            }
        }
        //添加学员
        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            DateTime serverDate;
            #region 校验数据
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入学员姓名", "校验提示");
                this.txtStudentName.Focus();
                return;
            }
            if (!this.rdoMale.Checked && !this.rdoFemale.Checked)
            {
                MessageBox.Show("请选择性别", "校验提示");
                return;
            }
            if (this.cbbClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择所在班级", "校验提示");
                return;
            }
            if (this.txtStudentIdNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入身份证号", "校验提示");
                this.txtStudentIdNo.Focus();
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入考勤卡号", "校验提示");
                this.txtCardNo.Focus();
                return;
            }
            //if (this.txtPhoneNumber.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入联系电话", "校验提示");
            //    this.txtPhoneNumber.Focus();
            //    return;
            //}
            //if (this.txtStudentAddress.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("请输入家庭住址", "校验提示");
            //    this.txtStudentAddress.Focus();
            //    return;
            //}
            if (!Common.DataValidate.IsIdNo(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("请检查身份证号是否正确", "校验提示");
                this.txtStudentIdNo.Focus();
                return;
            }
            if (!Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd").Equals(this.txtStudentIdNo.Text.Trim().Substring(6, 8)))
            {
                MessageBox.Show("身份证号与出生日期不符", "校验提示");
                this.txtStudentIdNo.Focus();
                return;
            }
            try
            {
                serverDate = DALCommon.GetServerTime();
                if (serverDate.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year < 1 || serverDate.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year > 35)
                {
                    MessageBox.Show("年龄需要在1~35之间", "校验提示");
                    return;
                }
                if (objStudentService.IsIdNoExists(this.txtStudentIdNo.Text.Trim()))
                {
                    MessageBox.Show("身份证号重复，请检查或联系管理员", "校验提示");
                    this.txtStudentIdNo.Focus();
                    return;
                }
                if (objStudentService.IsCardNoExists(this.txtCardNo.Text.Trim()))
                {
                    MessageBox.Show("考勤卡号重复，请检查或联系管理员", "校验提示");
                    this.txtStudentIdNo.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，请稍后再试：" + ex.Message);
                return;
            }
            #endregion

            #region 封装数据
            Student student = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? 1 : 0,
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                Age = serverDate.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                ClassId = Convert.ToInt32(this.cbbClass.SelectedValue),
                ClassName = this.cbbClass.Text,
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtStudentAddress.Text.Trim(),
                StuImage = this.pbStudentImg.Image == null ? null : new Common.SerializeObjectToString().SerializeObject(this.pbStudentImg.Image)
            };
            #endregion

            #region 调用后台方法添加学员
            try
            {
                int studentId = objStudentService.AddStudent(student);
                if (studentId > 1)
                {
                    student.StudentId = studentId;
                    this.stuList.Add(student);
                    this.dgvStudents.DataSource = null;
                    this.dgvStudents.DataSource = this.stuList;
                    DialogResult result = MessageBox.Show("添加成功，是否清空表单？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        foreach (Control item in this.gbStudentInfo.Controls)
                        {
                            if (item is TextBox)
                            {
                                ((TextBox)item).Clear();
                            }
                        }
                        this.rdoMale.Checked = false;
                        this.rdoFemale.Checked = false;
                        this.cbbClass.SelectedIndex = -1;
                        this.pbStudentImg.Image = null;
                        this.txtStudentName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("添加失败，请稍后尝试！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }
        //关闭窗体
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //显示行号
        private void DgvStudents_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        private void FrmAddStudent_Load(object sender, EventArgs e)
        {
            this.txtStudentName.Focus();
        }
    }
}
