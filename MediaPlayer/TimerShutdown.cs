using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace MediaPlayer
{
    public partial class TimerShutdown : Form
    {
        public TimerShutdown()
        {
            InitializeComponent();
        }
        bool begin = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            int hour = (int)numericUpDown1.Value;
            int minute = (int)numericUpDown2.Value;
            int second = (int)numericUpDown3.Value;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            if (begin)
            {
                if (hour == h && minute == m && second == s)
                {
                    pub.text = textBox1.Text.ToString();
                    Tips fm = new Tips();
                    fm.HeightMax = 500;
                    fm.WidthMax = 280;
                    fm.Show();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 1000;
            label3.Text = DateTime.Now.ToLongTimeString();
            label1.Text = DateTime.Now.ToLongTimeString();
            label15.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer4.Enabled = true;
            timer5.Enabled = true;


            //设¦¨¨置?DrawMode 为a OwnerDrawFixed 可¨¦以°?再¨´可¨¦视º¨®化¡¥编À¨¤辑-里¤?设¦¨¨置?
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;

            //设¦¨¨置?Alignment 为a Left/Right 可¨¦以°?再¨´可¨¦视º¨®化¡¥编À¨¤辑-里¤?设¦¨¨置?
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;

            //将?tabcontrol的Ì?drawitem 重?写¡ä 交?给?自Á?己o写¡ä的Ì?DrawItem方¤?法¤¡§
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem); 

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.notifyIcon1.Visible = false;           

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            begin = true;
            MessageBox.Show("保存成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            begin = true;
            MessageBox.Show("保存成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            begin = true;
            MessageBox.Show("保存成功");
        }
        //提示
        private void timer3_Tick_1(object sender, EventArgs e)
        {
            timer3.Interval = 1000;
            int hour2 = (int)numericUpDown6.Value;
            int minute2 = (int)numericUpDown5.Value;
            int second2 = (int)numericUpDown4.Value;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            if (begin)
            {
                if (hour2 == h && minute2 == m && second2 == s)
                {
                    pub.text = textBox2.Text.ToString();
                    Tips fm = new Tips();
                    fm.HeightMax = 500;
                    fm.WidthMax = 280;
                    fm.Show();
                }
            }
        }
        //提示
        private void timer4_Tick_1(object sender, EventArgs e)
        {
            timer4.Interval = 1000;
            int hour3 = (int)numericUpDown9.Value;
            int minute3 = (int)numericUpDown8.Value;
            int second3 = (int)numericUpDown7.Value;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            if (begin)
            {
                if (hour3 == h && minute3 == m && second3 == s)
                {
                    pub.text = textBox3.Text.ToString();
                    Tips fm = new Tips();
                    fm.HeightMax = 500;
                    fm.WidthMax = 280;
                    fm.Show();
                }
            }
        }
        //定时关机
        private void timer5_Tick_1(object sender, EventArgs e)
        {
            int hour = (int)numericUpDown13.Value;
            int minute = (int)numericUpDown12.Value;
            int second = (int)numericUpDown11.Value;
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            if (hour == h && minute == m && second == s)
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine("shutdown -s -t 30 -c \"如果此时不想关机，就点击“取消关机”按钮！\"");
                p.StandardInput.WriteLine("exit");
                string strRst = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (numericUpDown13.Value == 0 && numericUpDown12.Value == 0 && numericUpDown11.Value == 0)
            {

                DialogResult msg = MessageBox.Show("请设置具体关机时间！", "温馨提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (msg == DialogResult.Yes)
                {
                    numericUpDown13.Focus();
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
        }
        //开机启动
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                RegistryKey user = Registry.LocalMachine;
                RegistryKey root = user.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                root.SetValue("myexe", @"C:\Documents and Settings\Administrator\My Documents\Visual Studio 2008\Projects\个人小闹钟\个人小闹钟\bin\Debug\个人小闹钟.exe");
            }
            else
            {
                RegistryKey user = Registry.LocalMachine;
                RegistryKey root = user.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                root.DeleteValue("myexe");
                MessageBox.Show("你已取消了开机启动");
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                panel1.Enabled = true;
                //MessageBox.Show("dsdsa");
            }
            else
            {
                panel1.Enabled = false;
            }
        }
      

        private void 显示程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.notifyIcon1.Visible = false;
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            this.notifyIcon1.Visible = false;
            
        }
        #region----------------------取消关机-------------------------
        private void btnStopShut_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("shutdown -a");
            p.StandardInput.WriteLine("exit");
            string strRst = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
        }
        #endregion

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerShutdown));
            StringFormat sf = new StringFormat();

            // 设¦¨¨置?文?字Á?是º?居¨®中D的Ì?
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            //画-出?选?项?卡¡§文?字Á?

            SolidBrush bruFont = new SolidBrush(System.Drawing.Color.White);// 标签字体颜色
            //SolidBrush ba = new SolidBrush(this.BackColor);
            //e.Graphics.FillRectangle(ba, 0, 0, tabControl1.Width, tabControl1.Height);  //背景颜色


            e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text, System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.FromArgb(141, 193, 36)), e.Bounds, sf);
            
        }

        #region --------------------移动窗体-------------------------
        //移动窗体
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //窗体上鼠标按下时
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                // 移动窗体
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
