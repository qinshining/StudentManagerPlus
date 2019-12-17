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
    public partial class FrmStudentManage : Form
    {
        private StudentService objStudentService = new StudentService();
        private List<Student> stuList = null;
        public FrmStudentManage()
        {
            InitializeComponent();
            this.dgvStudents.AutoGenerateColumns = false;
            //初始化班级下拉框
            try
            {
                List<StudentClass> list = new StudentClassService().GetAllClass();
                list.Insert(0, new StudentClass()
                {
                    ClassId = -1,
                    ClassName = "--统计全部--"
                });
                this.cbbClass.DataSource = list;
                this.cbbClass.DisplayMember = "ClassName";
                this.cbbClass.ValueMember = "ClassId";
                this.cbbClass.SelectedIndex = 0;
                BtnQueryByClass_Click(null, null);//初始化时调用一次查询
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请稍后再试：" + ex.Message);
            }
        }
        //按班级查询
        private void BtnQueryByClass_Click(object sender, EventArgs e)
        {
            string classId = Convert.ToInt32(this.cbbClass.SelectedValue) == -1 ? string.Empty : this.cbbClass.SelectedValue.ToString();
            try
            {
                stuList = objStudentService.GetStudentsByClassId(classId);
                this.dgvStudents.DataSource = stuList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请稍后再试：" + ex.Message);
            }
        }
        //按学号查询
        private void BtnQueryByStudentId_Click(object sender, EventArgs e)
        {
            try
            {
                stuList = objStudentService.GetStudentsById(this.txtStudentId.Text.Trim());
                this.dgvStudents.DataSource = stuList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请稍后再试：" + ex.Message);
            }
        }
        //导出Excel
        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (this.stuList == null || this.dgvStudents.RowCount == 0)
            {
                return;
            }
            try
            {
                new ExcelPrint.DataExport().ExportData(this.dgvStudents, "学员信息表");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出数据发生异常，请检查：" + ex.Message, "错误提示");
            }
        }
        //打印当前页
        private void BtnPrintCurrent_Click(object sender, EventArgs e)
        {
            if (this.dgvStudents.CurrentRow == null)
            {
                MessageBox.Show("请选择要打印的学员", "提示信息");
                return;
            }
            Student student = this.dgvStudents.CurrentRow.DataBoundItem as Student;
            try
            {
                new ExcelPrint.ExcelPrint().PrintStudent(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常，请检查：" + ex.Message, "提示信息");
            }
        }
        //按姓名降序
        private void BtnOrderByNameDESC_Click(object sender, EventArgs e)
        {
            if (this.stuList == null)
            {
                return;
            }
            this.stuList.Sort(new OrderByNameDESC());
            this.dgvStudents.Refresh();
        }
        //按学号降序
        private void BtnOrderByIdDESC_Click(object sender, EventArgs e)
        {
            if (this.stuList == null)
            {
                return;
            }
            this.stuList.Sort(new OrderByIdDesc());
            this.dgvStudents.Refresh();
        }
        //修改学员【按钮】
        private void BtnModify_Click(object sender, EventArgs e)
        {
            if (this.dgvStudents.CurrentRow == null || this.dgvStudents.RowCount == 0)
            {
                return;
            }
            Student student = this.dgvStudents.CurrentRow.DataBoundItem as Student;
            FrmEditStudent frmEditStudent = new FrmEditStudent(student, false);
            DialogResult result = frmEditStudent.ShowDialog();
            if (result == DialogResult.OK)
            {
                BtnQueryByClass_Click(null, null);
            }
        }
        //删除学员【按钮】
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvStudents.CurrentRow == null || this.dgvStudents.RowCount == 0)
            {
                return;
            }
            Student student = this.dgvStudents.CurrentRow.DataBoundItem as Student;
            DialogResult dialogResult = MessageBox.Show(string.Format("确定要删除【{0}：{1}】学员吗？", student.StudentId, student.StudentName), "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    int result = objStudentService.DeleteStudent(student);
                    if (result == 1)
                    {
                        MessageBox.Show("删除成功", "提示信息");
                        BtnQueryByClass_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("删除失败，请刷新后再试！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //修改学员【右键】
        private void TsmiModify_Click(object sender, EventArgs e)
        {
            BtnModify_Click(null, null);
        }
        //删除学员【右键】
        private void TsmiDelete_Click(object sender, EventArgs e)
        {
            BtnDelete_Click(null, null);
        }
        //双击查看详细信息
        private void DgvStudents_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dgvStudents.CurrentRow == null || e.RowIndex == -1)
            {
                return;
            }
            Student currentStudent = this.dgvStudents.CurrentRow.DataBoundItem as Student;
            FrmEditStudent frmEditStudent = new FrmEditStudent(currentStudent, true);
            frmEditStudent.ShowDialog();
        }
        //关闭窗口
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvStudents_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void CbbClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BtnQueryByClass_Click(null, null);
            }
        }

        private void TxtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length != 0 && e.KeyValue == 13)
            {
                BtnQueryByStudentId_Click(null, null);
            }
        }
    }

    class OrderByNameDESC : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    class OrderByIdDesc : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }
}
