using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MediaPlayer
{
    /*SendMessage（HWND hWnd，UINT Msg，WPARAM wParam，LPARAM IParam）；
        hWnd：其窗口程序将接收消息的窗口的句柄
        Msg：指定被发送的消息。
        wParam：指定附加的消息指定信息。
        IParam：指定附加的消息指定信息。*/

    public partial class CameraForm : Form
    {
        private int hHwnd;//窗口句柄
        private const int port = 2000;
        public CameraForm()
        {
            InitializeComponent();
        }
        public struct videohdr_tag
        {
            public byte[] lpData;
            public int dwBufferLength;
            public int dwBytesUsed;
            public int dwTimeCaptured;
            public int dwUser;
            public int dwFlags;
            public int[] dwReserved;

        }
        public delegate bool CallBack(int hwnd, int lParam);

        //DllImport 作为一种属性提供第二种方法调用不带类型库的 DLL 中的函数。大致与使用 Declare 语句等效

        #region---------------调用不带类型库的 DLL 中的函数---------------------
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszWindowName, int dwStyle, int x, int y, int nWidth, short nHeight, int hWndParent, int nID);
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool capGetDriverDescriptionA(short wDriver, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)]   ref   string lpszVer, int cbVer);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool DestroyWindow(int hndw);
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]   object lParam);
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("vfw32.dll")]
        public static extern string capVideoStreamCallback(int hwnd, videohdr_tag videohdr_tag);
        [DllImport("vicap32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool capSetCallbackOnFrame(int hwnd, string s);
          #endregion

        #region---------------------------捕获视频-------------------------------
        private void OpenCapture()
        {
            int intWidth = this.panelCamera.Width;
            int intHeight = this.panelCamera.Height;
            int intDevice = 0;
            string refDevice = intDevice.ToString();
            //创建视频窗口并得到句柄
            hHwnd = CameraForm.capCreateCaptureWindowA(ref   refDevice, 1342177280, 0, 0, 640, 480, this.panelCamera.Handle.ToInt32(), 0);
            if (CameraForm.SendMessage(hHwnd, 0x40a, intDevice, 0) > 0)
            {//0x435，0x434，0x432是根据前面句柄而随即定义的参数
                CameraForm.SendMessage(this.hHwnd, 0x435, -1, 0);//该函数将指定的消息发送到一个或多个窗口
                CameraForm.SendMessage(this.hHwnd, 0x434, 0x42, 0);
                CameraForm.SendMessage(this.hHwnd, 0x432, -1, 0);
                CameraForm.SetWindowPos(this.hHwnd, 1, 0, 0, intWidth, intHeight, 6);
            }
            else
            {
                CameraForm.DestroyWindow(this.hHwnd);//销毁指定的窗口。
            }
        }
        #endregion

        #region-----------------------------开始---------------------------------
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.OpenCapture();
        }
        #endregion

        #region-----------------------------停止---------------------------------
        private void btnStop_Click(object sender, EventArgs e)
        {
            //停止视频注销视频句柄
            CameraForm.SendMessage(this.hHwnd, 0x40b, 0, 0);
            CameraForm.DestroyWindow(this.hHwnd);
        }
        #endregion

        #region-----------------------------截图---------------------------------
        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                CameraForm.SendMessage(this.hHwnd, 0x41e, 0, 0);
                IDataObject obj1 = Clipboard.GetDataObject();
                if (obj1.GetDataPresent(typeof(Bitmap)))
                {
                    Image image1 = (Image)obj1.GetData(typeof(Bitmap));
                    SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                    SaveFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddhhmmss");//用当前的时间的字符串作为图片的名字避免重复
                    SaveFileDialog1.Filter = "Image Files(*.JPG;*.GIF)|*.JPG;*.GIF|All files (*.*)|*.*";
                    if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        image1.Save(SaveFileDialog1.FileName, ImageFormat.Bmp);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

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

       

       }
}

