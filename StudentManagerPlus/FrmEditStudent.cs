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
    public partial class FrmEditStudent : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        public FrmEditStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            try
            {
                this.cbbClass.DataSource = objClassService.GetAllClass();
                this.cbbClass.DisplayMember = "ClassName";
                this.cbbClass.ValueMember = "ClassId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，请稍后再试：" + ex.Message);
            }
        }
        public FrmEditStudent(Student student, bool isReadOnly) : this()
        {
            this.txtStudentId.Text = student.StudentId.ToString();
            this.txtStudentName.Text = student.StudentName;
            this.rdoMale.Checked = student.Gender == 1;
            this.rdoFemale.Checked = student.Gender == 0;
            this.dtpBirthday.Value = student.Birthday;
            this.cbbClass.SelectedValue = student.ClassId;//装箱
            this.txtPhoneNumber.Text = student.PhoneNumber;
            this.txtStudentIdNo.Text = student.StudentIdNo;
            this.txtCardNo.Text = student.CardNo;
            this.txtStudentAddress.Text = student.StudentAddress;
            this.pbStudentImg.Image = student.StuImage.Length == 0 ? Image.FromFile("default.png") : (Image)new Common.SerializeObjectToString().DeserializeObject(student.StuImage);
            if (isReadOnly)
            {
                foreach (Control item in this.gbStudentInfo.Controls)
                {
                    if (item is TextBox)
                    {
                        ((TextBox)item).ReadOnly = true;
                    }
                    if (item is RadioButton)
                    {
                        ((RadioButton)item).Enabled = false;
                    }
                    if (item is DateTimePicker)
                    {
                        ((DateTimePicker)item).Enabled = false;
                    }
                    if (item is ComboBox)
                    {
                        ((ComboBox)item).Enabled = false;
                    }
                }
                this.Text = "学员详细信息";
                this.lblTitle.Visible = this.btnSave.Visible = this.btnChooseImg.Visible = false;
            }
        }

        private void BtnChooseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbStudentImg.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                if (objStudentService.IsIdNoExists(this.txtStudentIdNo.Text.Trim(), this.txtStudentId.Text.Trim()))
                {
                    MessageBox.Show("身份证号重复，请检查或联系管理员", "校验提示");
                    this.txtStudentIdNo.Focus();
                    return;
                }
                if (objStudentService.IsCardNoExists(this.txtCardNo.Text.Trim(), this.txtStudentId.Text.Trim()))
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
                StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
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
                int result = objStudentService.ModifyStudent(student);
                if (result == 1)
                {
                    MessageBox.Show("修改成功", "提示信息");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败，请刷新后再试！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
