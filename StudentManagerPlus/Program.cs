using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace StudentManagerPlus
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmUserLogin frmUserLogin = new FrmUserLogin();
            DialogResult result = frmUserLogin.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain2());//启动的是树形菜单主界面
            }            
        }

        public static SysAdmin currentAdmin = null;
    }
}
