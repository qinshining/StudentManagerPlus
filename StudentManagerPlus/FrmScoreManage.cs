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
    public partial class FrmScoreManage : Form
    {
        private ScoreListService objScoreService = new ScoreListService();
        public FrmScoreManage()
        {
            InitializeComponent();
            try
            {
                //初始化下拉框
                this.cbbClass.DataSource = new StudentClassService().GetAllClass();
                this.cbbClass.DisplayMember = "ClassName";
                this.cbbClass.ValueMember = "ClassId";
                this.cbbClass.SelectedIndex = -1;
                this.cbbClass.SelectedIndexChanged += new EventHandler(CbbClass_SelectedIndexChanged);//绑定事件
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，请稍后再试：" + ex.Message, "提示信息");
                return;
            }
            //禁止列自动增长
            this.dgvScoreList.AutoGenerateColumns = false;
            ShowResult(string.Empty);
        }

        private void ShowResult(string classId)
        {
            try
            {
                //成绩列表
                this.dgvScoreList.AutoGenerateColumns = false;
                this.dgvScoreList.DataSource = objScoreService.GetStudentScoreList(classId);
                //考试分析
                Dictionary<string, string> scoreInfo = objScoreService.GetScoreInfo(classId);
                this.lblTotal.Text = scoreInfo["attendCount"];
                this.lblAbsentCount.Text = scoreInfo["absentCount"];
                this.lblAvgCSharp.Text = Convert.ToDouble(scoreInfo["avgCSharp"]).ToString("0.00");
                this.lblAvgDB.Text = Convert.ToDouble(scoreInfo["avgDB"]).ToString("0.00");
                //缺考名单
                this.lbAbsentList.Items.Clear();
                this.lbAbsentList.Items.AddRange(objScoreService.GetAbsentNames(classId).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现异常，请稍后再试：" + ex.Message, "提示信息");
            }
        }

        private void CbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowResult(this.cbbClass.SelectedIndex == -1 ? string.Empty : this.cbbClass.SelectedValue.ToString());
        }

        private void BtnQueryAll_Click(object sender, EventArgs e)
        {
            this.cbbClass.SelectedIndex = -1;
            ShowResult(string.Empty);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvScoreList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value is ScoreList)
            {
                e.Value = ((ScoreList)e.Value).CSharp;
            }
            if (e.ColumnIndex == 5 && e.Value is ScoreList)
            {
                e.Value = ((ScoreList)e.Value).SQLServerDB;
            }
        }

        private void DgvScoreList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
