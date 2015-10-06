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
    public partial class MainFrm : Form
    {
        private string[] args;
        bool isRun = false;
        LrcFrm lrcFrm;
        int playState = 2;//播放状态     0:顺序播放   1:随机   2:全部循环   3:单曲循环
        List<string> strTemp = new List<string>();
        public MainFrm(string[] args)
        {
            InitializeComponent();
            this.args = args;
            Helper.main = this;
        }

        #region //注册热键

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
                    RegisterHotKey(this.Handle, 2, KeyModifiers.Control , Keys.Left);
                    RegisterHotKey(this.Handle, 3, KeyModifiers.Control , Keys.Right);
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

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            //this.tableLayoutPanel2.Size = this.Size;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }


        //Point thesizex = new Point(0, 0);
        private void plRight_MouseDown(object sender, MouseEventArgs e)
        {
            // thesizex = new Point(e.X, e.Y);
        }

        private void plRight_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    this.Width += e.X - thesizex.X;
            //}
        }

        private void tableLayoutPanel5_DoubleClick(object sender, EventArgs e)
        {
            //if (this.WindowState != FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Size = new Size(454, 400);
            //}
        }

        Point mouse = new Point(0, 0);
        private void tableLayoutPanel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//left表示单击
            {
                this.Left += e.X - mouse.X;
                this.Top += e.Y - mouse.Y;
                //if (lrcFrm.Location.X == this.Location.X + this.Width)
                //{
                //    lrcFrm.Left += e.X - mouse.X;
                //    lrcFrm.Top += e.Y - mouse.Y;
                //}
                //else if (lrcFrm.Location.X - this.Location.X - this.Width <= 5 && lrcFrm.Location.X - this.Location.X - this.Width>=0)
                //{
                //    lrcFrm.Location = new Point(this.Location.X + this.Width, lrcFrm.Location.Y);
                //    //lrcFrm.Left += e.X - mouse.X;
                //    //lrcFrm.Top += e.Y - mouse.Y;
                //}
                Application.DoEvents();
            }
        }

        private void tableLayoutPanel5_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = new Point(e.X, e.Y);
            button5.Focus();
        }

        #region 加载配置
        private void MainFrm_Load(object sender, EventArgs e)
        {
            //RegistryKey key;
            //RegistryKey subkey;
            try
            {
                //if (this.args[0].Length != 0)
                //{
                //    string path = this.args[0];
                //    int temp = path.Length;
                //    int lastIndex = path.LastIndexOf("\\") + 1;
                //    strTemp.Add(path);
                //    lbPlayerList.Items.Add(path.Substring(lastIndex, temp - lastIndex));
                //    isRun = true;
                //    axWmplayer.URL = path;
                //    axWmplayer.Ctlcontrols.play();
                //    tmrNow.Start();
                //    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                //    lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                //    lblSinger.Visible = true;
                //    lblTime.Visible = true;
                //}
                //string expath = Application.ExecutablePath;
                //key = Registry.ClassesRoot.CreateSubKey("QQMusic." + "mp3" + "");
                //key.SetValue("", "QQMusic-" + "mp3" + "");
                //key = key.CreateSubKey("DefaultIcon");
                //key.SetValue("", expath + "," + 0);
                //key = Registry.ClassesRoot.CreateSubKey("QQMusic." + "mp3" + "");
                ////
                //key = key.CreateSubKey("shell");
                //subkey = key;

                //key = subkey.CreateSubKey("Enqueue");
                //key.SetValue("", "添加到QQMusic播放列表(&Q)");
                //key = key.CreateSubKey("command");
                //key.SetValue("", '"' + expath + '"' + "/ADD" + '"' + "%1" + '"');

                //key = subkey;
                //key = key.CreateSubKey("open");
                //key = key.CreateSubKey("command");
                //key.SetValue("", '"' + expath + '"' + '"' + " %1" + '"');


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
                    axWmplayer.URL = strTemp[a];
                    lbPlayerList.SelectedIndex = a;
                }
                lrcFrm = new LrcFrm(this.axWmplayer, this.tmrNow);
                //lrcFrm.mainFrm = this;
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


        #region 播放 暂停
        private void btnPlay_Click(object sender, EventArgs e)
        {
            playOrPause();
        }

        private void playOrPause()
        {
            if (isRun == true && axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.pause();
                isRun = false;
                tmrNow.Stop();
                btnPlay.Image = Properties.Resources.playmouseover;
                label1.Focus();
            }
            else if (isRun == false && axWmplayer.URL != "")
            {
                axWmplayer.Ctlcontrols.play();
                LrcConnections.GetLrc(axWmplayer.URL);
                isRun = true;
                tmrNow.Start();
                btnPlay.Image = Properties.Resources.stopmouseover;
                label1.Focus();
            }
            lblSinger.Visible = true;
            lblTime.Visible = true;
            label1.Focus();
        }
        #endregion

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            if (axWmplayer.URL == "")
            {
                btnPlay.Image = Properties.Resources.playmouseover;
            }
            else
            {
                if (isRun == true)
                {
                    btnPlay.Image = Properties.Resources.stopmouseover;
                }
                else
                {
                    btnPlay.Image = Properties.Resources.playmouseover;
                }
            }
            ttControlsShow.SetToolTip(btnPlay, "播放/暂停 Ctrl+F5");
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            if (axWmplayer.URL == "")
            {
                btnPlay.Image = Properties.Resources.playmousedown;
            }
            else
            {
                if (isRun == false)
                {
                    btnPlay.Image = Properties.Resources.playmousedown;
                }
                else
                {
                    btnPlay.Image = Properties.Resources.stopmousedown;
                }
            }
        }

        #region 播放上一首歌
        private void btnPre_Click(object sender, EventArgs e)
        {
            playPre();
        }
        #endregion

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
            btnPre.Image = Properties.Resources.pravmouseover;
        }

        private void btnPre_MouseLeave(object sender, EventArgs e)
        {
            btnPre.Image = Properties.Resources.prav;
        }

        #region 停止
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
        #endregion

        private void btnPause_MouseEnter(object sender, EventArgs e)
        {
            btnPause.Image = Properties.Resources.pausemouseover;
            ttControlsShow.SetToolTip(btnPause, "停止 Ctrl+F5");
        }

        private void btnPause_MouseLeave(object sender, EventArgs e)
        {
            btnPause.Image = Properties.Resources.pause;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            PlayNext();
        }


        #region 播放下一首歌
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
        #endregion

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            ttControlsShow.SetToolTip(btnNext, "下一首 Ctrl+Right");
            btnNext.Image = Properties.Resources.nextmouseover;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.Image = Properties.Resources.next;
        }

        #region 是否静音
        private void btnSound_Click(object sender, EventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                if (axWmplayer.settings.mute == true)
                {
                    axWmplayer.settings.mute = false;
                    btnSound.Image = Properties.Resources.sound;
                }
                else if (axWmplayer.settings.mute == false)
                {
                    axWmplayer.settings.mute = true;
                    btnSound.Image = Properties.Resources.soundstop;
                }
            }
            label1.Focus();
        }
        #endregion

        private void btnSound_MouseEnter(object sender, EventArgs e)
        {
            btnSound.Image = Properties.Resources.soundover;
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
                btnSound.Image = Properties.Resources.sound;
            }
            if (axWmplayer.settings.mute == true)
            {
                btnSound.Image = Properties.Resources.soundstop;
            }
        }


        private void labmos_Click(object sender, EventArgs e)
        {
            Point h = new Point(0, labmos.Height);
            cmsPlayState.Show(labmos, h);
        }

        #region 窗体关闭事件
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
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

        #region 判断歌曲是否到文件末尾的timer,控制显示的歌词
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
                if (axWmplayer.playState == WMPLib.WMPPlayState.wmppsStopped && axWmplayer.URL != "")
                {
                    PlayNext();
                }
                //int during = Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(0, 2)) * 60 + Convert.ToInt32(axWmplayer.currentMedia.durationString.Substring(3, 2));
                //double perLeft = during / (panel13.Width - picProg.Width);

                double perLeft = (panel13.Width - picProg.Width) / axWmplayer.currentMedia.duration;
                this.picProg.Left = (int)(this.axWmplayer.Ctlcontrols.currentPosition / perLeft);
                lblTime.Text = axWmplayer.Ctlcontrols.currentPositionString + "/" + axWmplayer.currentMedia.durationString;
                if (lrcFrm != null)
                {
                    LrcConnections.DrawLrcRefresh(this.axWmplayer.Ctlcontrols.currentPositionString);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 播放状态的4种情况
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
                axWmplayer.settings.volume = (int)(this.picSound.Left * perLeft * (2 / perLeft));
                ttControlsShow.SetToolTip(picSound, Convert.ToString(axWmplayer.settings.volume) + "%");
            }
        }

        Point proMouseDown = new Point();
        bool isMove = false;
        private void picProg_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            proMouseDown = new Point(e.X, e.Y);
        }

        private void picProg_MouseMove(object sender, MouseEventArgs e)
        {
            if (axWmplayer.URL != "")
            {//&& isMove == true
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
                    this.axWmplayer.Ctlcontrols.currentPosition = this.picProg.Left * perLeft;
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

        private void picProg_MouseEnter(object sender, EventArgs e)
        {
            picProg.Image = Properties.Resources.progressmousedown;
        }

        private void picProg_MouseLeave(object sender, EventArgs e)
        {
            picProg.Image = Properties.Resources.progress00;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void nIMediaPlayer_MouseMove(object sender, MouseEventArgs e)
        {
            if (axWmplayer.URL != "")
            {
                nIMediaPlayer.Text = "雅风随风--" + axWmplayer.currentMedia.name;
            }
            else
            {
                nIMediaPlayer.Text = "雅风播放器,我本风雅!";
            }
        }

        private void nIMediaPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void lbPlayerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.lbPlayerList.SelectedItems[0] != null)
                {
                    axWmplayer.URL = strTemp[lbPlayerList.SelectedIndex];
                    tmrNow.Start();
                    lblSinger.Text = "歌曲:" + axWmplayer.currentMedia.name;
                    lblSinger.Visible = true;
                    lblTime.Visible = true;
                    isRun = true;
                    LrcConnections.GetLrc(axWmplayer.URL);
                }
            }
            catch
            {
                return;
            }
        }

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


        #region 打开文件
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
                    btnPlay.Image = Properties.Resources.stop;
                }
            }
            catch
            {
                return;
            }
            label1.Focus();
        }
        #endregion

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
                            if (f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mp3" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wma" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wav" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".mid" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".midi" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".asf" || f.Name.Substring(f.Name.Length - 4, 4).ToLower() == ".wmv")
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

        private void label6_Click(object sender, EventArgs e)
        {
            Point h = new Point(0, label6.Height);
            cmsAddFile.Show(label6, h);
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ttControlsShow.SetToolTip(btnPlay, "退出 Ctrl+X");
        }

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
    }
}
