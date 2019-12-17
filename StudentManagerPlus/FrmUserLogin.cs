using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;
using System.IO;
using System.Xml;

namespace StudentManagerPlus
{
    public partial class FrmUserLogin : Form
    {
        private SysAdminService objAdminService = new SysAdminService();
        private Dictionary<string, string> accountInfo = null;
        public FrmUserLogin()
        {
            InitializeComponent();
            //初始化密码下拉框
            //this.accountInfo = ReadPwd();
            this.accountInfo = ReadPwdByXML();//通过XML文件形式读取
            if (this.accountInfo != null && this.accountInfo.Count > 0)
            {
                this.cbbAccount.Items.AddRange(this.accountInfo.Keys.ToArray());
                this.cbbAccount.SelectedIndex = this.accountInfo.Count - 1;
                this.txtPwd.Text = this.accountInfo[this.cbbAccount.Text];
                this.ckbSavePwd.Checked = true;
            }
        }
        //下拉框改变事件
        private void CbbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtPwd.Text = this.accountInfo[this.cbbAccount.Text];
        }

        #region 窗体移动

        private bool leftFlag;
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
                Point position = Control.MousePosition;
                position.Offset(offSet.X, offSet.Y);
                Location = position;
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

        //设置连接数据源
        private void BtnSetDataBase_Click(object sender, EventArgs e)
        {
            FrmSetDB frmSetDB = new FrmSetDB();
            frmSetDB.ShowDialog();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //登录
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            #region 数据验证

            if (this.cbbAccount.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入账号", "提示信息");
                this.cbbAccount.Focus();
                return;
            }
            if (!Common.DataValidate.IsInteger(this.cbbAccount.Text.Trim()))
            {
                MessageBox.Show("请输入正确的账号", "提示信息");
                this.cbbAccount.Focus();
                return;
            }
            if (this.txtPwd.Text.Length == 0)
            {
                MessageBox.Show("请输入密码", "提示信息");
                this.txtPwd.Focus();
                return;
            }

            #endregion

            SysAdmin sysAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.cbbAccount.Text.Trim()),
                LoginPwd = this.txtPwd.Text
            };
            try
            {
                sysAdmin = objAdminService.AdminLogin(sysAdmin);
                if (sysAdmin == null)
                {
                    MessageBox.Show("账号或密码错误！", "登录失败");
                    this.txtPwd.SelectAll();
                    this.txtPwd.Focus();
                }
                else
                {
                    Program.currentAdmin = sysAdmin;
                    //SavePwd();//保存密码
                    SavePwdByXML();//保存密码(XML文件)
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统异常");
            }
        }

        private void CbbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.cbbAccount.Text.Trim().Length != 0 && e.KeyValue == 13)
            {
                this.txtPwd.Focus();
            }
        }

        private void TxtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtPwd.Text.Trim().Length != 0 && e.KeyValue == 13)
            {
                BtnLogin_Click(null, null);
            }
        }

        #region 密码保存 文件流的方式

        //保存密码
        private void SavePwd()
        {
            string fileName = "account.info";
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            List<string> accountInfo = File.ReadAllLines(fileName, Encoding.Default).ToList<string>();
            for (int i = 0; i < accountInfo.Count; i++)
            {
                if (accountInfo[i].StartsWith(this.cbbAccount.Text.Trim() + ":::"))
                {
                    accountInfo.RemoveAt(i);
                }
            }
            if (this.ckbSavePwd.Checked)
            {
                accountInfo.Add(this.cbbAccount.Text.Trim() + ":::" + this.txtPwd.Text);//三个符号隔离密码
            }
            File.WriteAllLines(fileName, accountInfo.ToArray());
        }
        //读取密码
        private Dictionary<string, string> ReadPwd()
        {
            string fileName = "account.info";
            if (!File.Exists(fileName))
            {
                return null;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            while (true)
            {
                string content = sr.ReadLine();
                if (content == null)
                {
                    break;
                }
                string[] info = content.Split(new string[] { ":::" }, StringSplitOptions.None);
                dic.Add(info[0], info[1]);
            }
            sr.Close();
            fs.Close();
            return dic;
        }

        #endregion

        #region 密码保存 XML文件形式

        //保存密码
        private void SavePwdByXML()
        {
            string fileName = "account.xml";
            XmlDocument doc = new XmlDocument();
            XmlElement rootNode = null;
            if (File.Exists(fileName))
            {
                doc.Load(fileName);
                rootNode = doc.DocumentElement;
            }
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                rootNode = doc.CreateElement("SysAdmin");
                doc.AppendChild(rootNode);
            }
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name.Equals("AccountInfo"))
                {
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        if (item.Name.Equals("Account") && item.InnerText == this.cbbAccount.Text.Trim())
                        {
                            rootNode.RemoveChild(node);
                        }
                    }
                }
            }
            if (this.ckbSavePwd.Checked)
            {
                XmlElement newNode = doc.CreateElement("AccountInfo");
                XmlElement newNodeAccount = doc.CreateElement("Account");
                XmlElement newNodePwd = doc.CreateElement("AdminPwd");
                newNodeAccount.InnerText = this.cbbAccount.Text.Trim();
                newNodePwd.InnerText = this.txtPwd.Text;
                newNode.AppendChild(newNodeAccount);
                newNode.AppendChild(newNodePwd);
                rootNode.AppendChild(newNode);
            }
            doc.Save(fileName);
        }
        //读取密码
        private Dictionary<string, string> ReadPwdByXML()
        {
            string fileName = "account.xml";
            if (!File.Exists(fileName))
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement rootNode = doc.DocumentElement;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Name == "AccountInfo")
                {
                    string account = string.Empty;
                    string adminPwd = string.Empty;
                    foreach (XmlNode item in node.ChildNodes)
                    {
                        if (item.Name == "Account")
                        {
                            account = item.InnerText;
                        }
                        if (item.Name == "AdminPwd")
                        {
                            adminPwd = item.InnerText;
                        }
                    }
                    dic.Add(account, adminPwd);
                }
            }
            return dic;
        }

        #endregion
    }
}
