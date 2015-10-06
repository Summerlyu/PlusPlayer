using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;
using LrcCollection;

namespace MediaPlayer
{
    public partial class Player : Form
    {
        private string[] args;
        bool isRun = false;
        Color tab = new Color();
       
        MiniFrm M = new MiniFrm();
        LrcFrm lrcFrm;
       

        int playState = 2;//播放状态     0:顺序播放   1:随机   2:全部循环   3:单曲循环
        List<string> strTemp = new List<string>();
        public Player(string[] args)
        {
            InitializeComponent();
            this.args = args;
            Helper.main = this;
            M.mainf = this;
           
        }

        #region ------------------------窗体重绘函数---------------------

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

        #region --------------------关闭 最大化 最小化---------------
        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnmini_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            M.Show();
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.splitContainer1.SplitterDistance = 400;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
                this.splitContainer1.SplitterDistance = 1100;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ttControlsShow.SetToolTip(btnPlay, "退出 Ctrl+X");
        }

       #endregion

        #region -----------------------Tabcontrol 重绘 --------------------

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //获取TabControl主控件的工作区域

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));

            Rectangle rec = tabControl1.ClientRectangle;

            //获取背景图片，我的背景图片在项目资源文件中

            Image backImage = this.BackgroundImage;

            //新建一个StringFormat对象，用于对标签文字的布局设置

            StringFormat StrFormat = new StringFormat();

            StrFormat.LineAlignment = StringAlignment.Center;// 设置文字垂直方向居中

            StrFormat.Alignment = StringAlignment.Center;// 设置文字水平方向居中          

            // 标签背景填充颜色，也可以是图片

            //SolidBrush bru = new SolidBrush(Color.FromArgb(72, 181, 250)); // 设置标签颜色

            Image TieleImage = this.BackgroundImage;
            Color fontcolor = btnLrcFrmShow.ForeColor; //获取标签颜色使之与控件字体颜色相同
            SolidBrush bruFont = new SolidBrush(fontcolor);// 标签字体颜色

            Font font = new System.Drawing.Font("微软雅黑", 9F);//设置标签字体样式

            //绘制主控件的背景
            SolidBrush bru1 = new SolidBrush(Color.FromArgb(141, 193, 36));
            //this.tab = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            SolidBrush ba = new SolidBrush(this.tab);
            e.Graphics.FillRectangle(ba, 0, 0, tabControl1.Width, tabControl1.Height);  //背景颜色

            // e.Graphics.DrawImage(backImage, 0, 0, tabControl1.Width, tabControl1.Height);//背景图片

            //绘制标签样式

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {

                //获取标签头工作区域

                Rectangle recChild = tabControl1.GetTabRect(i);

                //e.Graphics.FillRectangle(ba, recChild);// 绘制标签头的背景颜色 

                //绘制标签头的背景图片
                // e.Graphics.DrawImage(TieleImage, recChild);

                //绘制标签头的文字

                e.Graphics.DrawString(tabControl1.TabPages[i].Text, font, bruFont, recChild, StrFormat);

            }


        }

        #endregion

        #endregion

        #region ---------------------注册热键-----------------------

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
                IntPtr hWnd,　//　handle　to　window　　
                int id,　//　hot　key　identifier　　
                KeyModifiers fsModifiers,　//　key-modifier　options　　
                System.Windows.Forms.Keys vk　//　virtual-key　code　　
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,　//　handle　to　window　　
            int id　//　hot　key　identifier　　
        );
        [Flags]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        private const int WM_HOTKEY = 0x312; //窗口消息-热键
        private const int WM_CREATE = 0x1; //窗口消息-创建
        private const int WM_DESTROY = 0x2; //窗口消息-销毁
        private const int MOD_ALT = 0x1; //ALT
        private const int MOD_CONTROL = 0x2; //CTRL
        private const int MOD_SHIFT = 0x4; //SHIFT
        private const int VK_SPACE = 0x20; //SPACE 

        protected override void WndProc(ref　Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键
                    switch (m.WParam.ToString())
                    {
                        case "1": //热键ID
                            if (this.WindowState == FormWindowState.Normal)
                            {
                                this.WindowState = FormWindowState.Minimized;
                                this.ShowInTaskbar = false;
                            }
                            else
                            {
                                this.WindowState = FormWindowState.Normal;
                                this.ShowInTaskbar = true;
                                this.Activate();
                            }
                            break;
                        case "2":
                            playPre();
                            break;
                        case "3":
                            PlayNext();
                            break;
                        case "4":
                            playOrPause();
                            break;
                        case "5":
                            showLrcFrm();
                            break;
                        case "66":
                            if (axWmplayer.settings.volume < 100)
                            {
                                axWmplayer.settings.volume++;
                                this.picSound.Left += 1;
                                ttControlsShow.SetToolTip(picSound, Convert.ToString(axWmplayer.settings.volume) + "%");
                            }
                            else
                            {
                                axWmplayer.settings.volume = 100;
                                this.picSound.Left = panel12.Width - picSound.Width;
                            }
                            break;
                        case "77":
                            if (axWmplayer.settings.volume > 0)
                            {
                                axWmplayer.settings.volume--;
                                this.picSound.Left -= 1;
                                ttControlsShow.SetToolTip(picSound, Convert.ToString(axWmplayer.settings.volume) + "%");
                            }
                            else
                            {
                                axWmplayer.settings.volume = 0;
                                this.picSound.Left = 0;
                            }

                            break;
                        default:
                            break;
                    }
                    break;

                case WM_CREATE: //窗口消息-创建
                    RegisterHotKey(this.Handle, 1, KeyModifiers.Control | KeyModifiers.Alt, Keys.F3);
                    RegisterHotKey(this.Handle, 2, KeyModifiers.Control, Keys.Left);
                    RegisterHotKey(this.Handle, 3, KeyModifiers.Control, Keys.Right);
                    RegisterHotKey(this.Handle, 4, KeyModifiers.Control | KeyModifiers.Alt, Keys.F5);
                    RegisterHotKey(this.Handle, 5, KeyModifiers.Control | KeyModifiers.Alt, Keys.L);//歌词
                    RegisterHotKey(this.Handle, 66, KeyModifiers.Control | KeyModifiers.Alt, Keys.Up);
                    RegisterHotKey(this.Handle, 77, KeyModifiers.Control | KeyModifiers.Alt, Keys.Down);
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    UnregisterHotKey(this.Handle, 1); //销毁热键
                    UnregisterHotKey(this.Handle, 2);
                    UnregisterHotKey(this.Handle, 3);
                    UnregisterHotKey(this.Handle, 4);
                    UnregisterHotKey(this.Handle, 5);//歌词
                    UnregisterHotKey(this.Handle, 66);
                    UnregisterHotKey(this.Handle, 77);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ----------------------加载配置 load -----------------
        private void Player_Load(object sender, EventArgs e)
        {
            Point p = new Point(105, 80);
            this.DesktopLocation = p;
           
             try
            {
                picSound.Left = Convert.ToInt32(Config.GetValue("sound"));
                axWmplayer.settings.volume = Convert.ToInt32(Config.GetValue("sound")); ;


                string playlist = Application.StartupPath + @"\configure\playlist";
                if (File.Exists(playlist))
                {
                    FileStream fsplaylist = new FileStream(playlist, FileMode.Open);
                    BinaryFormatter bfplaylist = new BinaryFormatter();
                    strTemp = (List<string>)(bfplaylist.Deserialize(fsplaylist));
                    fsplaylist.Close();
                    for (int i = 0; i < strTemp.Count; i++)
                    {
                        string path = strTemp[i];
                        int temp = path.Length;
                        int lastIndex = path.LastIndexOf("\\") + 1;
                        lbPlayerList.Items.Add(path.Substring(lastIndex, temp - lastIndex));
                    }
                    int a = new Random().Next(strTemp.Count);
                   // axWmplayer.URL = strTemp[a];
                    lbPlayerList.SelectedIndex = a;
                }
               
                lrcFrm = new LrcFrm(this.axWmplayer, this.tmrNow);
                lrcFrm.Show();
                LrcConnections.GetLrc(axWmplayer.URL);


                playState = Convert.ToInt32(Config.GetValue("playState"));

                lblSinger.Visible = false;
                lblTime.Visible = false;

                if (playState == 0)
                {
                    tsmiPlayOrder.Checked = true;
                    tsmiPlayRand.Checked = false;
                    tsmiPlayAll.Checked = false;
                    tsmiPlayOne.Checked = false;
                }
                else if (playState == 1)
                {
                    tsmiPlayOrder.Checked = false;
                    tsmiPlayRand.Checked = true;
                    tsmiPlayAll.Checked = false;
                    tsmiPlayOne.Checked = false;
                }
                else if (playState == 2)
                {
                    tsmiPlayOrder.Checked = false;
                    tsmiPlayRand.Checked = false;
                    tsmiPlayAll.Checked = true;
                    tsmiPlayOne.Checked = false;
                }
                else if (playState == 3)
                {
                    tsmiPlayOrder.Checked = false;
                    tsmiPlayRand.Checked = false;
                    tsmiPlayAll.Checked = false;
                    tsmiPlayOne.Checked = true;
                }

            }
            catch
            {
                return;
            }
        }

        
        #endregion

        #region ---------------------播放 暂停 -------------------

        private void btnPlay_Click(object sender, EventArgs e)
        {
            playOrPause();
        }
        public void playOrPause()
        {
            if (isRun == true && axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.pause();
                isRun = false;
                tmrNow.Stop();
                btnPlay.Image = Properties.Resources.Wplay;
                M.btnPlay.BackgroundImage = Properties.Resources.Wplay;
                label1.Focus();
            }
            else if (isRun == false && axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.play();
                LrcConnections.GetLrc(axWmplayer.URL);
                isRun = true;
                tmrNow.Start();
                btnPlay.Image = Properties.Resources.Wpause;
                M.btnPlay.BackgroundImage = Properties.Resources.Wpause;
                label1.Focus();
            }
            lblSinger.Visible = true;
            lblTime.Visible = true;
            label1.Focus();
        }

        #region ------------------ 播放按钮图片 -------------------
        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            if (axWmplayer.URL == "")
            {
                btnPlay.BackgroundImage = Properties.Resources.a1_副本;
            }
            else
            {
                if (isRun == true)
                {
                    btnPlay.BackgroundImage = Properties.Resources.a1_副本;
                }
                else
                {
                    btnPlay.BackgroundImage = Properties.Resources.a1_副本;
                }
            }
            ttControlsShow.SetToolTip(btnPlay, "播放/暂停 Ctrl+F5");
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            if (axWmplayer.URL == "")
            {
                btnPlay.BackgroundImage = Properties.Resources.playB;
            }
            else
            {
                if (isRun == false)
                {
                    btnPlay.BackgroundImage = Properties.Resources.playB;
                }
                else
                {
                    btnPlay.BackgroundImage = Properties.Resources.playB;
                }
            }

        }

        #endregion
        #endregion

        #region ------------------- 播放上一首 ------------------

        private void btnPre_Click(object sender, EventArgs e)
        {
            playPre();
        }
        public void playPre()
        {
            UserHelper.currentLrcIndex = 0;
            try
            {
                if (axWmplayer.URL != "")
                {
                    if (playState == 2)//全部循环
                    {
                        for (int i = 0; i < strTemp.Count; i++)//
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                if (i == 0)
                                {
                                    axWmplayer.URL = strTemp[strTemp.Count - 1];
                                    lbPlayerList.SelectedIndex = strTemp.Count - 1;
                                    break;
                                }
                                else
                                {
                                    axWmplayer.URL = strTemp[i - 1];
                                    lbPlayerList.SelectedIndex = i - 1;
                                    break;
                                }
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 0)//顺序播放
                    {
                        for (int i = 0; i < strTemp.Count; i++)//
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                if (i == 0)
                                {
                                    lbPlayerList.SelectedIndex = 0;
                                    return;
                                }
                                else
                                {
                                    axWmplayer.URL = strTemp[i - 1];
                                    lbPlayerList.SelectedIndex = i - 1;
                                    break;
                                }
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 1)//随机播放
                    {
                        Random random = new Random();
                        int i = random.Next(strTemp.Count);
                        axWmplayer.URL = strTemp[i];
                        lbPlayerList.SelectedIndex = i;

                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 3)//单曲循环
                    {
                        for (int i = 0; i < strTemp.Count; i++)
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                axWmplayer.URL = strTemp[i];
                                lbPlayerList.SelectedIndex = i;
                                break;
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                }
            }
            catch
            {
                return;
            }
            if (lrcFrm != null)
            {
                LrcConnections.GetLrc(axWmplayer.URL);
            }
        }

        private void btnPre_MouseEnter(object sender, EventArgs e)
        {
            ttControlsShow.SetToolTip(btnPre, "上一首 Ctrl+Left");
            btnPre.BackgroundImage = Properties.Resources.bback;
        }

        private void btnPre_MouseLeave(object sender, EventArgs e)
        {
            btnPre.BackgroundImage = null;
        }

        #endregion

        #region ------------------- 停止 ----------------------

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.stop();
                tmrNow.Stop();
                lblSinger.Visible = false;
                lblTime.Visible = false;
                this.picProg.Left = 0;
            }
            label1.Focus();
        }

        private void btnPause_MouseEnter(object sender, EventArgs e)
        {
            btnPause.BackgroundImage = Properties.Resources.bback;
            ttControlsShow.SetToolTip(btnPause, "停止 Ctrl+F5");
        }

        private void btnPause_MouseLeave(object sender, EventArgs e)
        {
            btnPause.BackgroundImage  = null;
        }

        #endregion

        #region -----------------播放下一首 -----------------

        private void btnNext_Click(object sender, EventArgs e)
        {
            PlayNext();
        }
        public void PlayNext()
        {
            UserHelper.currentLrcIndex = 0;
            try
            {
                if (axWmplayer.URL != "")
                {
                    if (playState == 2)//全部循环
                    {
                        for (int i = 0; i < strTemp.Count; i++)
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                if (i == strTemp.Count - 1)
                                {
                                    lbPlayerList.SelectedIndex = 0;
                                    axWmplayer.URL = strTemp[0];
                                    break;
                                }
                                else
                                {
                                    axWmplayer.URL = strTemp[i + 1];
                                    lbPlayerList.SelectedIndex = i + 1;
                                    break;
                                }
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 0)//顺序播放
                    {
                        for (int i = 0; i < strTemp.Count; i++)
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                if (i == strTemp.Count - 1)
                                {
                                    lbPlayerList.SelectedIndex = i;
                                    return;
                                }
                                else
                                {
                                    axWmplayer.URL = strTemp[i + 1];
                                    lbPlayerList.SelectedIndex = i + 1;
                                    break;
                                }
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 1)//随机播放
                    {
                        Random random = new Random();
                        int i = random.Next(strTemp.Count);
                        axWmplayer.URL = strTemp[i];
                        lbPlayerList.SelectedIndex = i;

                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                    else if (playState == 3)//单曲循环
                    {
                        for (int i = 0; i < strTemp.Count; i++)
                        {
                            if (strTemp[i].Equals(axWmplayer.URL))
                            {
                                axWmplayer.URL = strTemp[i];
                                lbPlayerList.SelectedIndex = i;
                                break;
                            }
                        }
                        tmrNow.Start();
                        lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                        lblSinger.Visible = true;
                        lblTime.Visible = true;
                    }
                }
            }
            catch
            {
                //return;
            }
            //lrcFrm.GetLrc(axWmplayer.URL);
            LrcConnections.GetLrc(axWmplayer.URL);
        }

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            ttControlsShow.SetToolTip(btnNext, "下一首 Ctrl+Right");
            btnNext.BackgroundImage = Properties.Resources.bback ;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.BackgroundImage  = null;
        }

        #endregion

        #region --------------------- 静音 -------------------

        private void btnSound_Click(object sender, EventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                if (axWmplayer.settings.mute == true)
                {
                    axWmplayer.settings.mute = false;
                    btnSound.Image = Properties.Resources.Soundqt;
                }
                else if (axWmplayer.settings.mute == false)
                {
                    axWmplayer.settings.mute = true;
                    btnSound.Image = Properties.Resources.SoundOn;
                }
            }
            label1.Focus();
        }

        private void btnSound_MouseEnter(object sender, EventArgs e)
        {
            btnSound.Image = Properties.Resources.Soundqt;
            if (axWmplayer.settings.mute == true)
            {
                ttControlsShow.SetToolTip(btnSound, "已静音 Ctrl+A");
            }
            else
            {
                ttControlsShow.SetToolTip(btnSound, "静音 Ctrl+A");
            }
        }

        private void btnSound_MouseLeave(object sender, EventArgs e)
        {
            if (axWmplayer.settings.mute == false)
            {
                btnSound.Image = Properties.Resources.SoundOn;
            }
            if (axWmplayer.settings.mute == true)
            {
                btnSound.Image = Properties.Resources.Soundqt;
            }
        }

        #endregion

        #region ------------------------ 窗体关闭事件 -------------------
        
        private void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string pathPlayState = Application.StartupPath + @"\configure";//CurrentPath +
                DirectoryInfo fi = new DirectoryInfo(pathPlayState);
                if (fi.Exists == false)
                {
                    fi.Create();
                }
                //存储当前播放状态
                Config.SetValue("playState", playState.ToString());

                //存储当前播放音量
                Config.SetValue("sound", picSound.Left.ToString());
                //存储当前播放列表
                FileStream fs1 = new FileStream(pathPlayState + "\\playlist", FileMode.OpenOrCreate);
                BinaryFormatter bf1 = new BinaryFormatter();
                bf1.Serialize(fs1, strTemp);
                fs1.Close();
            }
            catch
            {
                return;
            }
        }

        #endregion

        #region ------ 判断歌曲是否到达文件末尾的timer,控制显示的歌词------

        private void tmrNow_Tick(object sender, EventArgs e)
        {
            try
            {
                if (axWmplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                    lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                    tmrNow.Start();
                }
                if ((axWmplayer.playState == WMPLib.WMPPlayState.wmppsStopped) && axWmplayer.URL != "")
                {
                    PlayNext();
                }
                //int during = Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(3, 2));
                //double perLeft = during / (panel13.Width - picProg.Width);

                double perLeft = (panel13.Width - picProg.Width) / axWmplayer.currentMedia.duration;
                this.picProg.Left = (int)(this.axWmplayer.Ctlcontrols.currentPosition * perLeft);
                lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                if (lrcFrm != null)
                {
                    LrcConnections.DrawLrcRefresh(this.axWmplayer.Ctlcontrols.currentPositionString);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region ------------------- 播放模式 ---------------------------

        private void labmos_Click(object sender, EventArgs e)
        {
            Point h = new Point(0, labmos.Height);
            cmsPlayState.Show(labmos, h);
        }
        private void labmos_MouseEnter(object sender, EventArgs e)
        {
            labmos.BackgroundImage = Properties.Resources.bback;
            ttControlsShow.SetToolTip(labmos, "播放模式");
        }

        private void labmos_MouseLeave(object sender, EventArgs e)
        {
            labmos.BackgroundImage = null;
        }

        private void tsmiPlayOrder_Click(object sender, EventArgs e)
        {
            playState = 0;
            tsmiPlayOrder.Checked = true;
            tsmiPlayRand.Checked = false;
            tsmiPlayAll.Checked = false;
            tsmiPlayOne.Checked = false;
        }

        private void tsmiPlayRand_Click(object sender, EventArgs e)
        {
            playState = 1;
            tsmiPlayOrder.Checked = false;
            tsmiPlayRand.Checked = true;
            tsmiPlayAll.Checked = false;
            tsmiPlayOne.Checked = false;
        }

        private void tsmiPlayAll_Click(object sender, EventArgs e)
        {
            playState = 2;
            tsmiPlayOrder.Checked = false;
            tsmiPlayRand.Checked = false;
            tsmiPlayAll.Checked = true; ;
            tsmiPlayOne.Checked = false;
        }

        private void tsmiPlayOne_Click(object sender, EventArgs e)
        {
            playState = 3;
            tsmiPlayOrder.Checked = false;
            tsmiPlayRand.Checked = false;
            tsmiPlayAll.Checked = false;
            tsmiPlayOne.Checked = true;
        }

        #endregion

        #region ------------------ 显示歌词 ---------------------

        private void btnLrcFrmShow_Click(object sender, EventArgs e)
        {
            showLrcFrm();
        }
        private void showLrcFrm()
        {
            if (lrcFrm == null)
            {
                lrcFrm = new LrcFrm(this.axWmplayer, this.tmrNow);
                //lrcFrm.mainFrm = this;
                lrcFrm.Show();
            }
            else
            {
                if (lrcFrm.Visible == false)
                {
                    lrcFrm.Visible = true;
                    lrcFrm.Activate();
                }
                else
                {
                    lrcFrm.Visible = false;
                }
            }
        }

        #endregion

        #region ------------------ 声音控制条 ---------------------

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
                axWmplayer.settings.volume = (int)(this.picSound.Left/perLeft);//(int)(this.picSound.Left * perLeft * (2 / perLeft));
                ttControlsShow.SetToolTip(picSound, Convert.ToString(axWmplayer.settings.volume) + "%");
            }
        }

        #endregion

        #region ------------------ 播放进度条 -------------------

        Point proMouseDown = new Point();
        bool isMove = false;

        private void picProg_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            proMouseDown = new Point(e.X, e.Y);
        }

        private void picProg_MouseEnter(object sender, EventArgs e)
        {
            picProg.Image = Properties.Resources.progressmousedown;
        }

        private void picProg_MouseLeave(object sender, EventArgs e)
        {
            picProg.Image = Properties.Resources.progress00;
        }

        private void picProg_MouseMove(object sender, MouseEventArgs e)
        {
            if (axWmplayer.URL != "")
            {    //&& isMove == true
                if (e.Button == MouseButtons.Left)
                {
                    Point proMouseMove = new Point(e.X, e.Y);
                    if (picProg.Left >= 0 && picProg.Left <= panel13.Width - picProg.Width)
                    {
                        picProg.Left += (proMouseMove.X - proMouseDown.X);
                    }
                    else if (picProg.Left < 0)
                    {
                        picProg.Left = 0;
                    }
                    else if (picProg.Left > panel13.Width - picProg.Width)
                    {
                        picProg.Left = panel13.Width - picProg.Width;
                    }
                    isMove = false;
                    axWmplayer.Ctlcontrols.play();
                    tmrNow.Start();
                    // int during = Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(3, 2));
                    double perLeft = (panel13.Width - picProg.Width) / axWmplayer.currentMedia.duration;
                    this.axWmplayer.Ctlcontrols.currentPosition = this.picProg.Left / perLeft;
                    lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                    ttControlsShow.SetToolTip(picProg, (Convert.ToString((int)(axWmplayer.Ctlcontrols.currentPosition / axWmplayer.currentMedia.duration * 100))) + "%");
                    label1.Focus();
                }
            }
            else
            {
                lblTime.Text = "00:00/00:00";
                this.picProg.Left = 0;
            }
        }

        #endregion

        #region --------------- csmiControls 显示 -------------------
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }
        #endregion

        #region ------------------------ notify ----------------

        private void nIMediaPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void nIMediaPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                nIMediaPlayer.Text = "欧式杯小组" + axWmplayer.currentMedia.name;
            }
            else
            {
                nIMediaPlayer.Text = "MyMediaPlayer! music life!";
            }
        }
        
        #endregion

        #region -------------------------播放列表-----------------

        #region --------------------------双击 选定歌曲 ---------------

        private void lbPlayerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.lbPlayerList.SelectedItems[0] != null && File.Exists(strTemp[lbPlayerList.SelectedIndex]))
                {
                    pbmain.Visible = false;
                    btnPlay.Image = Properties.Resources.Wpause;
                    axWmplayer.URL = strTemp[lbPlayerList.SelectedIndex];
                    tmrNow.Start();
                    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                    lblSinger.Visible = true;
                    lblTime.Visible = true;
                    isRun = true;
                    LrcConnections.GetLrc(axWmplayer.URL);
                }
                else 
                {
                   MessageBox.Show("对不起，本地不存在这首歌曲，请重新添加！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                   lbPlayerList.Items.RemoveAt(lbPlayerList.SelectedIndex);
                   
                }
            }
            catch
            {
                return;
            }
        }

        #endregion

        #region -------------------------- 右键 功能 ----------------------

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (lbPlayerList.SelectedIndex >= 0)
            {
                int a = lbPlayerList.SelectedIndex;
                if (axWmplayer.URL == strTemp[a])
                {
                    if (strTemp.Count >= 0)
                    {
                        axWmplayer.URL = strTemp[0];
                    }
                    else
                    {
                        axWmplayer.URL = null;
                    }
                    lblTime.Text = "00:00/00:00";
                    lblSinger.Text = "歌曲";
                    lbPlayerList.Items.RemoveAt(a);
                    strTemp.RemoveAt(a);
                }
            }
        }

        private void tsmiDeleteAll_Click(object sender, EventArgs e)
        {
            lbPlayerList.Items.Clear();
            strTemp.Clear();
            axWmplayer.URL = null;
            lblTime.Text = "00:00/00:00";
            lblSinger.Text = "歌曲";
        }

        private void tsmiLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbPlayerList.SelectedIndex >= 0)
                {
                    int a = lbPlayerList.SelectedIndex;
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + strTemp[a]);
                }
                else
                {
                    MessageBox.Show("请选择歌曲。。。");
                }
            }
            catch
            {
                MessageBox.Show("歌曲不存在！！！");
            }

        }

        #endregion

        #region --------------------- 隐藏播放列表 ------------------
        private void btnPlaylist_Click(object sender, EventArgs e)
        {
              
            if (splitContainer1.SplitterDistance == 599)
            {
                
                splitContainer1.SplitterDistance = 400;
            }
            else if(panelwelcome.Visible != true)
                splitContainer1.SplitterDistance = 600;
            panelwelcome.Visible = false; 
        }

        private void btnPlaylist_MouseEnter(object sender, EventArgs e)
        {
            btnPlaylist.BackgroundImage = Properties.Resources.bback;
            ttControlsShow.SetToolTip(btnPlaylist, "播放列表");
        }

        private void btnPlaylist_MouseLeave(object sender, EventArgs e)
        {
            btnPlaylist.BackgroundImage = null;
        }
        #endregion

        #endregion

        #region ---------------------- 打开文件 ----------------------

        private void 添加文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    axWmplayer.URL = openFileDialog1.FileNames[0];
                    //lrcFrm.GetLrc(axWmplayer.URL);
                    LrcConnections.GetLrc(axWmplayer.URL);
                    isRun = true;
                    axWmplayer.Ctlcontrols.play();
                    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                    lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                    tmrNow.Start();
                    lblSinger.Visible = true;
                    lblTime.Visible = true;
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        string path = openFileDialog1.FileNames.GetValue(i).ToString();
                        int temp = path.Length;
                        int lastIndex = path.LastIndexOf("\\") + 1;
                        strTemp.Add(path);
                        //strSong.Add(path.Substring(lastIndex, temp - lastIndex));
                        lbPlayerList.Items.Add(path.Substring(lastIndex, temp - lastIndex));
                    }
                   // btnPlay.Image = Properties.Resources.stop;
                }
            }
            catch
            {
                return;
            }
            label1.Focus();
        }

        private void 添加文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                    foreach (FileInfo f in dirInfo.GetFiles())
                    {
                        if (f.Name.Length >= 5)
                        {
                            if (f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mpg" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mp4" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".rmvb" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".avi" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mp3" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wma" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wav" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mid" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".midi" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".asf" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wmv")
                            {
                                strTemp.Add(f.FullName);
                                lbPlayerList.Items.Add(f.Name);
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
            label1.Focus();
        }

        private void labOpenFile_Click(object sender, EventArgs e)
        {
            Point h = new Point(0, labOpenFile.Height);
            cmsAddFile.Show(labOpenFile, h);
        }
        private void labOpenFile_MouseEnter(object sender, EventArgs e)
        {
            labOpenFile.BackgroundImage = Properties.Resources.bback;
            ttControlsShow.SetToolTip(labOpenFile, "添加文件");
        }

        private void labOpenFile_MouseLeave(object sender, EventArgs e)
        {
            labOpenFile.BackgroundImage = null;
        }
        #endregion

        #region -------------------- 搜索 ------------------------

        string song = null;
        List<int> songIndex = new List<int>();

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (song != null && song != txtSong.Text.Trim())
            {
                songIndex.Clear();
                song = txtSong.Text.Trim();

            }
            else if (song == null)
            {
                song = txtSong.Text.Trim();
            }
            if (song != null && song != "")
            {

                for (int flag = 0; flag < lbPlayerList.Items.Count; flag++)
                {
                    if (songIndex.Contains(flag))
                    {
                        continue;
                    }
                    if (lbPlayerList.Items[flag].ToString().Contains(txtSong.Text.Trim()))
                    {
                        songIndex.Add(flag);
                        lbPlayerList.SelectedIndex = flag;
                        break;
                    }
                    else
                    {
                        //如果到了末尾，清空集合。下次从新开始
                        if (flag == lbPlayerList.Items.Count - 1)
                        {
                            MessageBox.Show("已经到了末尾...");
                            songIndex.Clear();
                        }
                    }
                }
            }
        }

        #endregion

        #region -------------------- 记事本 ------------------------
        private void btnOpennoteBook_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Notepad notepad = new Notepad();
            notepad.Show();          
        }
        #endregion

        #region --------------------日程安排 ------------------------
        private void btnschedule_Click(object sender, EventArgs e)
        {
            CalenderForm CalenderForm = new CalenderForm();
            CalenderForm.Show();
        }

        #endregion

        #region --------------------定时关机 ------------------------
        private void btnshutdown_Click(object sender, EventArgs e)
        {
            TimerShutdown timerShutdown = new TimerShutdown();
            timerShutdown.Show();
        }
        #endregion

        #region --------------------计算器 ------------------------
        private void btnCalculator_Click(object sender, EventArgs e)
        {
            CalculatorForm calculatorForm = new CalculatorForm();
            calculatorForm.Show();
        }
        #endregion

        #region --------------------常用搜索 ------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ZipCodeForm zipCodeForm = new ZipCodeForm();
            zipCodeForm.Show();
        }
        #endregion

        #region --------------------摄像机 ------------------------
        private void btnCamera_Click(object sender, EventArgs e)
        {
            CameraForm cameraForm = new CameraForm();
            cameraForm.Show();
        }
        #endregion

        #region ------------------------窗体透明度 -------------------

        private void btnOpacity_Click(object sender, EventArgs e)
        {
            Point op = new Point(0, btnOpacity.Height);
            cmsOpacity.Show(btnOpacity, op);
        }

        private void NoOpacity_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
            NoOpacity.Checked = true;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem30.Checked = false;
            toolStripMenuItem50.Checked = false;
            toolStripMenuItem70.Checked = false;
            toolStripMenuItem90.Checked = false;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.1;
            NoOpacity.Checked = false;
            toolStripMenuItem10.Checked = true;
            toolStripMenuItem30.Checked = false;
            toolStripMenuItem50.Checked = false;
            toolStripMenuItem70.Checked = false;
            toolStripMenuItem90.Checked = false;
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.3;
            NoOpacity.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem30.Checked = true;
            toolStripMenuItem50.Checked = false;
            toolStripMenuItem70.Checked = false;
            toolStripMenuItem90.Checked = false;
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            NoOpacity.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem30.Checked = false;
            toolStripMenuItem50.Checked = true;
            toolStripMenuItem70.Checked = false;
            toolStripMenuItem90.Checked = false;
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
            NoOpacity.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem30.Checked = false;
            toolStripMenuItem50.Checked = false;
            toolStripMenuItem70.Checked = true;
            toolStripMenuItem90.Checked = false;
        }

        private void toolStripMenuItem90_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.9;
            NoOpacity.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem30.Checked = false;
            toolStripMenuItem50.Checked = false;
            toolStripMenuItem70.Checked = false;
            toolStripMenuItem90.Checked = true;
        }

        #endregion 

        #region ------------------------ 换 肤 -----------------------

        #region ------------------------ Button -------------------------- 
        private void btnskin_Click(object sender, EventArgs e)
        {
            if (panelskin.Visible == true)
            {
                panelskin.Visible = false;
            }
            else
                panelskin.Visible = true;
        }

        private void btnskinpic_Click(object sender, EventArgs e)
        {
            flpanelpic.Visible = true;
            flpanelcol.Visible = false;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.wall1;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(135)))), ((int)(((byte)(146)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.WallM2;
            M.btnPlay.BackgroundImage = global::MediaPlayer.Properties.Resources.MbtnPlay;
            M.btnPlay.Size = new System.Drawing.Size(60, 60);
            M.btnPlay.Location = new System.Drawing.Point(55, 32);
            M.panel12.Location = new System.Drawing.Point(53, 93);
            M.btnSound.Location = new System.Drawing.Point(17, 83);
            M.btnPre.BackgroundImage = global::MediaPlayer.Properties.Resources.MbtnBack;
            M.btnPre.Location = new System.Drawing.Point(17, 31);
            M.btnPre.Size = new System.Drawing.Size(40, 40);
            M.btnNext.BackgroundImage = global::MediaPlayer.Properties.Resources.MbtnNext1;
            M.btnNext.Location = new System.Drawing.Point(113, 31);
            M.btnNext.Size = new System.Drawing.Size(40, 40);
            M.btnNormal.Location = new System.Drawing.Point(101, 6);
           
        }

        private void btnskincol_Click(object sender, EventArgs e)
        {
            flpanelcol.Visible = true;
            flpanelpic.Visible = false;
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.KittyM;
            M.panel12.Location = new System.Drawing.Point(23, 59);
            M.picSound.Location = new System.Drawing.Point(27, -3);
            M.btnPlay.BackgroundImage = global::MediaPlayer.Properties.Resources.Wplay;
            M.btnPlay.Size = new System.Drawing.Size(24, 22);
            M.btnPlay.Location = new System.Drawing.Point(112, 28);
            M.btnSound.Location = new System.Drawing.Point(13, 17);
            M.btnPre.BackgroundImage = global::MediaPlayer.Properties.Resources.WBack;
            M.btnPre.Location = new System.Drawing.Point(92, 17);
            M.btnPre.Size = new System.Drawing.Size(20, 20);
            M.btnNext.BackgroundImage = global::MediaPlayer.Properties.Resources.WNext;
            M.btnNext.Location = new System.Drawing.Point(138, 34);
            M.btnNext.Size = new System.Drawing.Size(20, 20);
            M.btnNormal.Location = new System.Drawing.Point(135, 6);

        }

        #endregion

        #region--------------------------皮肤  颜色 -------------------------

        private void pbSkinC1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(107)))), ((int)(((byte)(68)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            panelwelcome.BackColor = this.BackColor;
            this.BackgroundImage = null;

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(241)))), ((int)(((byte)(94)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
           
        }

        private void pbSkinC4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(176)))), ((int)(((byte)(111)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(180)))), ((int)(((byte)(177)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC7_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(235)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC8_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
           this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(131)))), ((int)(((byte)(181)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC9_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(95)))), ((int)(((byte)(62)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC10_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(106)))), ((int)(((byte)(121)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC11_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(6)))), ((int)(((byte)(7)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC12_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(99)))), ((int)(((byte)(6)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC13_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(81)))), ((int)(((byte)(7)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC14_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(170)))), ((int)(((byte)(7)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC15_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(115)))), ((int)(((byte)(53)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC16_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(116)))), ((int)(((byte)(112)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC17_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(74)))), ((int)(((byte)(158)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC18_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
             this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(6)))), ((int)(((byte)(101)))));
             this.tab = this.BackColor;
             lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC19_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(6)))), ((int)(((byte)(94)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

        private void pbSkinC20_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Wpause;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(6)))), ((int)(((byte)(83)))));
            this.tab = this.BackColor;
            lrcFrm.BackColor = this.BackColor;
            this.BackgroundImage = null;
            panelwelcome.BackColor = this.BackColor;
        }

       #endregion

        #region--------------------------皮肤  图片--------------------------
        private void pbSkinP1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.wall1;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(135)))), ((int)(((byte)(146)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.WallM2;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(135)))), ((int)(((byte)(146)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }
        

        private void pbSkinP2_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Bluelake;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(141)))), ((int)(((byte)(167)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.BluelakeM;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(141)))), ((int)(((byte)(167)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.GreenLeaf;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(15)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.GreenLeafM;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(200)))), ((int)(((byte)(15)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP8_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.Desert;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(73)))), ((int)(((byte)(3)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.DesertM;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(73)))), ((int)(((byte)(3)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP5_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.greenWall;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(140)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.greenWall_副本7;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(140)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.PinkGift;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(180)))), ((int)(((byte)(196)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.PinkGiftM;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(180)))), ((int)(((byte)(196)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP6_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.SkyGirl;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(147)))), ((int)(((byte)(194)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.SkyGirlM1;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(147)))), ((int)(((byte)(194)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        private void pbSkinP7_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.RedCherry;
            tab = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            M.BackgroundImage = global::MediaPlayer.Properties.Resources.RedCherryM;
            lrcFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(150)))), ((int)(((byte)(133)))));
            panelwelcome.BackColor = lrcFrm.BackColor;
        }

        #endregion

        private void axWmplayer_Enter(object sender, EventArgs e)
        {

        }

        



        #endregion

        private void btnlogo_Click(object sender, EventArgs e)
        {
            Point h = new Point(0, btnlogo.Height);
            cmslogo.Show(btnlogo, h);
        }

        private void 播放ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            playOrPause();
        }

        private void 停止ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.stop();
                tmrNow.Stop();
                lblSinger.Visible = false;
                lblTime.Visible = false;
                this.picProg.Left = 0;
            }
            label1.Focus();
        }

        private void 上一曲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playPre();
        }

        private void 下一曲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayNext();
        }

        private void 立体声ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWmplayer.settings.balance = 0;
            this.立体声ToolStripMenuItem.Checked = true;
            this.右声道ToolStripMenuItem.Checked = false;
            this.左声道ToolStripMenuItem.Checked = false;
        }

        private void 左声道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWmplayer.settings.balance = -10000;
            this.立体声ToolStripMenuItem.Checked = false;
            this.右声道ToolStripMenuItem.Checked = false;
            this.左声道ToolStripMenuItem.Checked = true;
        }

        private void 右声道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWmplayer.settings.balance = 10000;
            this.立体声ToolStripMenuItem.Checked = false;
            this.右声道ToolStripMenuItem.Checked = true;
            this.左声道ToolStripMenuItem.Checked = false;
        }

        private void 顺序播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playState = 0;
        }

        private void 随机播放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playState = 1;
        }

        private void 列表循环ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playState = 2;
        }

        private void 单曲循环ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playState = 3;

        }

        private void 打开文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                    foreach (FileInfo f in dirInfo.GetFiles())
                    {
                        if (f.Name.Length >= 5)
                        {
                            if (f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mpg" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mp4" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".rmvb" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".avi" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mp3" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wma" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wav" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mid" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".midi" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".asf" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wmv")
                            {
                                strTemp.Add(f.FullName);
                                lbPlayerList.Items.Add(f.Name);
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
            label1.Focus();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    axWmplayer.URL = openFileDialog1.FileNames[0];
                    //lrcFrm.GetLrc(axWmplayer.URL);
                    LrcConnections.GetLrc(axWmplayer.URL);
                    isRun = true;
                    axWmplayer.Ctlcontrols.play();
                    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                    lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                    tmrNow.Start();
                    lblSinger.Visible = true;
                    lblTime.Visible = true;
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        string path = openFileDialog1.FileNames.GetValue(i).ToString();
                        int temp = path.Length;
                        int lastIndex = path.LastIndexOf("\\") + 1;
                        strTemp.Add(path);
                        //strSong.Add(path.Substring(lastIndex, temp - lastIndex));
                        lbPlayerList.Items.Add(path.Substring(lastIndex, temp - lastIndex));
                    }
                    // btnPlay.Image = Properties.Resources.stop;
                }
            }
            catch
            {
                return;
            }
            label1.Focus();
        }

        

     



    }
}
