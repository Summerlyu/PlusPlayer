using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace MediaPlayer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool bExist;
            Mutex MyMutex = new Mutex(true, "TuDouPlayer", out bExist);
            if (bExist)
            {
                Application.Run(new MainFrm(args));
                MyMutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("程序已经运行！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
