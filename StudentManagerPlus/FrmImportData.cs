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
    public partial class FrmImportData : Form
    {
        private ImportDataFromExcel importDataFromExcel = new ImportDataFromExcel();
        public FrmImportData()
        {
            InitializeComponent();
            //禁止自动生成列
            this.dgvStudents.AutoGenerateColumns = false;
        }

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.dgvStudents.DataSource = importDataFromExcel.GetStudentsByExcle(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.dgvStudents.RowCount == 0)
            {
                return;
            }
            List<Student> stuList = new List<Student>();
            try
            {

                foreach (DataGridViewRow row in this.dgvStudents.Rows)
                {
                    stuList.Add(new Student()
                    {
                        StudentName = row.Cells["StudentName"].Value.ToString(),
                        Gender = row.Cells["GenderName"].Value.ToString().Equals("男") ? 1 : 0,
                        Birthday = Convert.ToDateTime(row.Cells["Birthday"].Value),
                        Age = DateTime.Now.Year - Convert.ToDateTime(row.Cells["Birthday"].Value).Year,
                        StudentIdNo = row.Cells["StudentIdNo"].Value.ToString(),
                        CardNo = row.Cells["CardNo"].Value.ToString(),
                        PhoneNumber = row.Cells["PhoneNumber"].Value.ToString(),
                        StudentAddress = row.Cells["StudentAddress"].Value.ToString(),
                        ClassId = Convert.ToInt32(row.Cells["ClassId"].Value)
                    });
                }
                if (importDataFromExcel.ImportData(stuList))
                {
                    MessageBox.Show("导入成功！");
                    this.dgvStudents.DataSource = null;
                }
                else
                {
                    MessageBox.Show("导入失败，请重试", "提示信息");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入出现异常：" + ex.Message, "提示信息");
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
