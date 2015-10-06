using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MediaPlayer
{
    public partial class LrcFrm : Form
    {

        public AxWMPLib.AxWindowsMediaPlayer axWmplayer;
        public System.Windows.Forms.Timer timer;

        //动画窗体调用
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        const int AW_HOR_POSITIVE = 0x0002;
        const int AW_HOR_NEGATIVE = 0x0004;
        const int AW_VER_POSITIVE = 0x0008;
        const int AW_VER_NEGATIVE = 0x00016;
        const int AW_CENTER = 0x0010;
        const int AW_HIDE = 0x10000;
        const int AW_ACTIVATE = 0x20000;
        const int AW_SLIDE = 0x20000;
        const int AW_BLEND = 0x80000;
        public LrcFrm(AxWMPLib.AxWindowsMediaPlayer axWmplayer,System.Windows.Forms.Timer timer)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            LrcConnections.lrcfrm = this;
            LrcConnections.lrcPanel = this.lrcPanel1;
            this.axWmplayer = axWmplayer;
            this.timer = timer;
        }

        #region 字段
        public override Size MinimumSize
        {
            get
            {
                return new Size(100, 100);
            }
            set
            {
                base.MinimumSize = value;
            }
        }
        #endregion

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
            //base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键
                    switch (m.WParam.ToString())
                    {
                        case "1989":
                            this.lrcPanel1.showFullScreen();
                            break;
                        case "11": //热键ID
                            this.lrcPanel1.KanaOK();
                            break;
                        case "12":
                            this.lrcPanel1.showLrcSetFrm();
                            break;
                        case "13":
                            this.lrcPanel1.showLrc();
                            break;
                        case "14":
                            this.lrcPanel1.showFullScreen();
                            break;
                        case "15": //热键ID
                            Helper.main.PlayNext();
                            break;
                        case "16":
                            Helper.main.playPre();
                            break;
                        //case "17":
                        //    this.lrcPanel1.showLrc();
                        //    break;
                        //case "18":
                        //    this.lrcPanel1.showFullScreen();
                        //    break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    RegisterHotKey(this.Handle, 1989, KeyModifiers.None, Keys.Escape);
                    RegisterHotKey(this.Handle, 11, KeyModifiers.Control | KeyModifiers.Alt, Keys.K);
                    RegisterHotKey(this.Handle, 12, KeyModifiers.Control | KeyModifiers.Alt, Keys.G);
                    RegisterHotKey(this.Handle, 13, KeyModifiers.Control | KeyModifiers.Alt, Keys.D);
                    RegisterHotKey(this.Handle, 14, KeyModifiers.Control | KeyModifiers.Alt, Keys.F);
                    //播放控制
                    //下一首
                    RegisterHotKey(this.Handle, 15, KeyModifiers.Control | KeyModifiers.Alt, Keys.Right);
                    //上一首
                    RegisterHotKey(this.Handle, 16, KeyModifiers.Control | KeyModifiers.Alt, Keys.Left);
                    //音量加
                   // RegisterHotKey(this.Handle, 17, KeyModifiers.Control | KeyModifiers.Alt, Keys.Up);
                    //音量减
                  //  RegisterHotKey(this.Handle, 18, KeyModifiers.Control | KeyModifiers.Alt, Keys.Down);
                  
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    UnregisterHotKey(this.Handle, 1989);
                    UnregisterHotKey(this.Handle, 11); //销毁热键
                    UnregisterHotKey(this.Handle, 12);
                    UnregisterHotKey(this.Handle, 13);
                    UnregisterHotKey(this.Handle, 14);
                    UnregisterHotKey(this.Handle, 15);
                    UnregisterHotKey(this.Handle, 16);
                  //  UnregisterHotKey(this.Handle, 17);
                   // UnregisterHotKey(this.Handle, 18);
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

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

        #region --------------------------最大化 最小化 关闭 -------------------

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        private void LrcFrm_Load(object sender, EventArgs e)
        {
            Point p = new Point(705, 80);
            this.DesktopLocation = p;
            Thread t = new Thread(loadLrc);
            t.IsBackground = true;
            t.Start();
            //动画由小渐大,现在取消
            AnimateWindow(this.Handle, 2000, AW_CENTER | AW_ACTIVATE);
        }

        private void loadLrc()
        {
            int i = 0;
            while (LrcConnections.isReading == true)
            {
                Thread.Sleep(1000);
                i++;
                if (LrcConnections.isReading == false || i == 5)
                {
                    break;
                }
            }
            if (LrcConnections.isReading == false)
            {
                this.lrcPanel1.lrcSortedList = LrcConnections.lrcSortedList;
            }
            Thread.CurrentThread.Abort();
        }

        #region//改变窗体大小时  歌词面板改变
        private void LrcFrm_Resize(object sender, EventArgs e)
        {
            this.lrcPanel1.Size1(this.Size);//歌词居中
            this.lrcPanel1.ChangeSize();
        }
        #endregion

        private void LrcFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;

            //存储当前状态
        }
        private void btnmini_Click(object sender, EventArgs e)
        {
           
        }
    }
}
