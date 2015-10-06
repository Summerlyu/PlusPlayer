using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MiniFrm : Form
    {
        public Player mainf;
        public MiniFrm()
        {
            InitializeComponent();
        }

        #region -------------------- 移动窗体 -------------------
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

        #region -------------------- 静音 ----------------------
        private void btnSound_Click(object sender, EventArgs e)
        {
            if (mainf.axWmplayer.URL != "")
            {
                if (mainf.axWmplayer.settings.mute == true)
                {
                    mainf.axWmplayer.settings.mute = false;
                    //btnSound.Image = Properties.Resources.sound;
                }
                else if (mainf.axWmplayer.settings.mute == false)
                {
                    mainf.axWmplayer.settings.mute = true;
                    //btnSound.Image = Properties.Resources.soundstop;
                }
            }
            mainf.label1.Focus();
        }

        private void btnSound_MouseEnter(object sender, EventArgs e)
        {
            //btnSound.Image = Properties.Resources.soundover;
            if (mainf.axWmplayer.settings.mute == true)
            {
                mainf.ttControlsShow.SetToolTip(btnSound, "已静音 Ctrl+A");
            }
            else
            {
                mainf.ttControlsShow.SetToolTip(btnSound, "静音 Ctrl+A");
            }
        }

        private void btnSound_MouseLeave(object sender, EventArgs e)
        {
            if (mainf.axWmplayer.settings.mute == false)
            {
               // btnSound.Image = Properties.Resources.sound;
            }
            if (mainf.axWmplayer.settings.mute == true)
            {
               // btnSound.Image = Properties.Resources.soundstop;
            }
        }

        #endregion

        #region ---------------- 声音控制条 --------------------

        Point p = new Point();
        Point p1 = new Point();

        private void picSound_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
            picSound.Image = Properties.Resources.soundbarmousedown;
        }

        private void picSound_MouseLeave(object sender, EventArgs e)
        {
            picSound.Image = Properties.Resources.soundbar;
        }

        private void picSound_MouseMove(object sender, MouseEventArgs e)
        {
            p1 = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (this.picSound.Left >= 0 && this.picSound.Left <= (panel12.Width - picSound.Width))
                {
                    this.picSound.Left += (p1.X - p.X);
                }
                if (this.picSound.Left < 0)
                {
                    this.picSound.Left = 0;
                }
                if (this.picSound.Left >= (panel12.Width - picSound.Width))
                {
                    this.picSound.Left = panel12.Width - picSound.Width;
                }
                double perLeft = (double)(panel12.Width - picSound.Width) / 100;
                mainf.axWmplayer.settings.volume = (int)(this.picSound.Left / perLeft);// (this.picSound.Left * perLeft * (2 / perLeft));
                mainf.ttControlsShow.SetToolTip(picSound, Convert.ToString(mainf.axWmplayer.settings.volume) + "%");
            }
        }

        #endregion

        #region ---------------------播放控制 --------------

        private void btnPlay_Click(object sender, EventArgs e)
        {
            mainf.playOrPause();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            mainf.playPre();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            mainf.PlayNext();
        }

        #endregion

        private void btnNormal_Click(object sender, EventArgs e)
        {
            mainf.Visible = true;
            this.Visible = false;
        }

        private void MiniFrm_Load(object sender, EventArgs e)
        {

        }

    }
}
