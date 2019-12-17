using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateApp
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
            FrmStartUpdate objFrm = new FrmStartUpdate();
            DialogResult result = objFrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmUpdate());
            }
            else
            {
                Application.Exit();
            }            
        }
    }
}
