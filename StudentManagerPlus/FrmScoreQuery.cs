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
    public partial class FrmScoreQuery : Form
    {
        private ScoreListService objScoreService = new ScoreListService();
        private DataSet ds = null;
        public FrmScoreQuery()
        {
            InitializeComponent();
            //初始化班级下拉框
            try
            {
                this.cbbClass.DataSource = new StudentClassService().GetClasses().Tables[0];
                this.cbbClass.DisplayMember = "ClassName";
                this.cbbClass.ValueMember = "ClassId";
                this.cbbClass.SelectedIndex = -1;
                this.cbbClass.SelectedIndexChanged += new EventHandler(CbbClass_SelectedIndexChanged);
                this.ds = objScoreService.GetScoreData();
                this.dgvScoreList.AutoGenerateColumns = false;
                this.dgvScoreList.DataSource = this.ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统发生异常，请稍后再试：" + ex.Message, "提示信息");
            }
            ////关闭列排序，确保列标题居中
            //foreach (DataGridViewColumn item in this.dgvScoreList.Columns)
            //{
            //    item.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
        }
        private string SpliceFilter()
        {
            StringBuilder filter = new StringBuilder();
            filter.Append("1 = 1");
            if (this.cbbClass.SelectedIndex != -1)
            {
                filter.AppendFormat(" and ClassId = {0}", this.cbbClass.SelectedValue.ToString());
            }
            if (this.txtCSharp.Text.Trim().Length != 0 && Common.DataValidate.IsNumber(this.txtCSharp.Text.Trim()))
            {
                filter.AppendFormat(" and CSharp >= {0}", this.txtCSharp.Text.Trim());
            }
            if (this.txtDB.Text.Trim().Length != 0 && Common.DataValidate.IsNumber(this.txtDB.Text.Trim()))
            {
                filter.AppendFormat(" and SQLServerDB >= {0}", this.txtDB.Text.Trim());
            }
            return filter.ToString();
        }

        private void CbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ds.Tables[0].DefaultView.RowFilter = SpliceFilter();
        }

        private void TxtCSharp_TextChanged(object sender, EventArgs e)
        {
            if (this.txtCSharp.Text.Trim().Length != 0 && !Common.DataValidate.IsNumber(this.txtCSharp.Text.Trim()))
            {
                MessageBox.Show("请输入正确的数值", "提示信息");
                this.txtCSharp.SelectAll();
                this.txtCSharp.Focus();
                return;
            }
            this.ds.Tables[0].DefaultView.RowFilter = SpliceFilter();
        }

        private void TxtDB_TextChanged(object sender, EventArgs e)
        {
            if (this.txtDB.Text.Trim().Length != 0 && !Common.DataValidate.IsNumber(this.txtDB.Text.Trim()))
            {
                MessageBox.Show("请输入正确的数值", "提示信息");
                this.txtDB.SelectAll();
                this.txtDB.Focus();
                return;
            }
            this.ds.Tables[0].DefaultView.RowFilter = SpliceFilter();
        }

        private void BtnQueryAll_Click(object sender, EventArgs e)
        {
            this.cbbClass.SelectedIndex = -1;
            this.txtCSharp.Clear();
            this.txtDB.Clear();
            this.ds.Tables[0].DefaultView.RowFilter = "1 = 1";
        }

        private void BtnPrintCurrent_Click(object sender, EventArgs e)
        {
            if (this.ds == null || this.dgvScoreList.RowCount == 0)
            {
                return;
            }
            try
            {
                new ExcelPrint.DataExport().ExportData(this.dgvScoreList, "学员成绩表");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出数据发生异常，请检查：" + ex.Message, "错误提示");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvScoreList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
