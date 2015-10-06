using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Collections;
using LrcCollection;

namespace MediaPlayer
{
    public partial class LrcPanel : UserControl
    {
        public LrcPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            Components();
            this.MouseDown += new MouseEventHandler(LrcPanel_MouseDown);
            this.MouseMove += new MouseEventHandler(LrcPanel_MouseMove);
            this.MouseUp += new MouseEventHandler(LrcPanel_MouseUp);     
            Size1(new Size(100, 100));

        }

        #region 鼠标释放
        void LrcPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (lrcSortedList.Count > 0)
            {
                if (LrcConnections.lrcfrm.timer.Enabled == false)
                {
                    LrcConnections.lrcfrm.timer.Enabled = true;
                }
                ismouseDown = false;
                if (isMouseMove == true)
                {
                    if (e.Y < p7.Y)
                    {
                        if (currentLrcIndex < lrcSortedList.Count - 1)
                        {
                            currentLrcIndex += li;
                            if (currentLrcIndex >= this.lrcSortedList.Count - 1)
                            {
                                currentLrcIndex = this.lrcSortedList.Count - 1;
                            }
                        }
                    }
                    else if (e.Y > p7.Y)
                    {
                        if (currentLrcIndex > 0)
                        {
                            currentLrcIndex -= li;
                            if (currentLrcIndex <= 0)
                            {
                                currentLrcIndex = 0;
                            }
                        }
                    }
                    if (currentLrcIndex <= 0)
                    {
                        currentLrcIndex = 0;
                    }
                    if (currentLrcIndex >= this.lrcSortedList.Count - 1)
                    {
                        currentLrcIndex = this.lrcSortedList.Count - 1;
                    }
                    LrcConnections.lrcfrm.axWmplayer.Ctlcontrols.currentPosition = getTime();
                    this.Refresh();
                    ChangeSize();
                }
                isMouseMove = false;
            }
        }
        #endregion


        private double getTime()//获取当前正在播放的歌词的时间
        {
            return lrcSortedList.ElementAt(currentLrcIndex).Key;
        }
        bool isMouseMove = false;//记录是否拖动过窗体
        int li = 0;
        #region 拖动歌词窗体
        void LrcPanel_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (Math.Abs(p7.Y - e.Y) > 5)
            {
                if (e.Button == MouseButtons.Left && lrcSortedList.Count > 0)
                {
                    isMouseMove = true;
                    if (LrcConnections.lrcfrm.timer.Enabled == true)
                    {
                        LrcConnections.lrcfrm.timer.Enabled = false;
                    }
                    if (ismouseDown == true)
                    {
                        string currentTime = null;
                        if (e.Y < p7.Y)//下移
                        {
                            li = (int)((p7.Y - e.Y) / this.fontStyle.Height);

                            lines -= li;//下移
                            this.Refresh();

                        }
                        if (e.Y > p7.Y)//上移
                        {
                            //如果上移出界

                            li = (int)((e.Y - p7.Y) / this.fontStyle.Height);
                            lines += li;//上移
                            this.Refresh();
                        }
                        DrawLine();

                        if (e.Y <= this.fontStyle.Height * space)
                        {
                            currentTime = "00:00";
                        }
                        else if (e.Y > this.fontStyle.Height * space && e.Y <= this.fontStyle.Height * (lrcSortedList.Count + space))
                        {
                            if (lrcSortedList.ElementAt(currentLrcIndex).Key < 60)
                            {
                                currentTime = "00:" + lrcSortedList.ElementAt(currentLrcIndex).Key.ToString() + lrcSortedList.ElementAt(currentLrcIndex).Value;
                            }
                            else
                            {
                                int minute = (int)(lrcSortedList.ElementAt(currentLrcIndex).Key / 60);
                                int second = lrcSortedList.ElementAt(currentLrcIndex).Key % 60;
                                if (minute < 10)
                                {
                                    if (second < 10)
                                    {
                                        currentTime = "0" + minute + ":0" + second + lrcSortedList.ElementAt(currentLrcIndex).Value;
                                    }
                                    else
                                    {
                                        currentTime = "0" + minute + ":" + second + lrcSortedList.ElementAt(currentLrcIndex).Value;
                                    }
                                }
                                else
                                {
                                    if (second < 10)
                                    {
                                        currentTime = minute + ":0" + second + lrcSortedList.ElementAt(currentLrcIndex).Value;
                                    }
                                    else
                                    {
                                        currentTime = minute + ":" + second + lrcSortedList.ElementAt(currentLrcIndex).Value;
                                    }
                                }
                            }
                        }
                        else
                        {
                            currentTime = lrcSortedList.ElementAt(lrcSortedList.Count - 1).Key.ToString();
                        }
                        Graphics g = Graphics.FromHwnd(this.Handle);
                        g.DrawString(currentTime, new Font("宋体", 9F, FontStyle.Regular), new SolidBrush(Color.Gray), new PointF(10, p6.Y));
                        g.Dispose();
                    }
                }
            }
        }
        #endregion

        //中间直线
        Point p1;
        Point p2;
        //左边
        Point p3;
        Point p4;
        //右边
        Point p5;
        Point p6;
        Point p7;
        Pen p = new Pen(Color.Gray);

        private void DrawLine()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p3, p4);
            g.DrawLine(p, p5, p6);
            g.Dispose();
        }
        void LrcPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (lrcSortedList.Count > 0)
            {
                p1 = new Point(10, (int)this.Height / 2);
                p2 = new Point(this.Size.Width - 10, (int)this.Height / 2);
                p3 = new Point(10, (int)this.Height / 2 - 10);
                p4 = new Point(10, (int)this.Height / 2 + 10);
                p5 = new Point(this.Size.Width - 10, (int)this.Height / 2 - 10);
                p6 = new Point(this.Size.Width - 10, (int)this.Height / 2 + 10);
                p7 = new Point(e.X, e.Y);
                ismouseDown = true;
            }
        }

        #region 字段
        bool ismouseDown = false;
        public string currentPosition = null;
        private SolidBrush backBrush;
        private SolidBrush lightBrush;
        private Color backColor;
        public Font fontStyle;
        private StringFormat stringFormatter;

        int minute;
        int second;
        int width = 0;
        Bitmap imgBack;
        Bitmap imgLrc;
        Dictionary<int, string> lrcList = new Dictionary<int, string>();//用来保存歌词和时间的集合
        Dictionary<int, string> lrcTemp = new Dictionary<int, string>();//用来保存临时歌词
        public Dictionary<int, string> lrcSortedList = new Dictionary<int, string>();//用来保存歌词和时间排序后的集合
        private ArrayList lrcConfig = new ArrayList();
        int middleTime = -1;
        int lrcTime = 0;
        public int currentLrcIndex = 0;
        int space = 0;
        float lines = 0;
        bool isSimple = true;
        int maxWidth = 0;
        public bool isKana = false;
        [Description("普通歌词颜色"), Category("歌词样式设置")]
        public SolidBrush BackBrush
        {
            get { return backBrush; }
            set { backBrush = value; }
        }
        [Description("高亮歌词颜色"), Category("歌词样式设置")]
        public SolidBrush LightBrush
        {
            get { return lightBrush; }
            set { lightBrush = value; }
        }
        [Description("歌词背景颜色"), Category("歌词样式设置")]
        public Color BackColors
        {
            get { return backColor; }
            set { backColor = value; }
        }
        [Description("当前歌曲时间"), Category("歌词样式设置")]
        public string CurrentPosition
        {
            get { return currentPosition; }
            set { currentPosition = value; }
        }
        [Description("歌词字体样式"), Category("歌词样式设置")]
        public Font FontSty
        {
            get { return fontStyle; }
            set { fontStyle = value; }
        }

        [Description("歌词字体排序"), Category("歌词样式设置")]
        public StringFormat StringFormatter
        {
            get { return stringFormatter; }
            set { stringFormatter = value; }
        }
        public override Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        private void Size2()//窗体最大值
        {
            int tempWidth = 0;
            if (UserHelper.url != null)
            {
                LrcConnections.GetLrc(UserHelper.url);
                this.lrcSortedList = LrcConnections.lrcSortedList;
                if (lrcSortedList.Count > 0)
                {
                    Graphics g = Graphics.FromHwnd(this.tsmiSetBgImage.Handle);
                    for (int i = 0; i <= lrcSortedList.Count - 1; i++)
                    {
                        tempWidth = (int)g.MeasureString(lrcList.ElementAt(i).Value, fontStyle).Width;
                        if (tempWidth > maxWidth)
                        {
                            maxWidth = tempWidth;
                        }
                    }
                    g.Dispose();
                    if (imgBack != null)
                    {
                        imgBack.Dispose();
                    }
                    if (imgLrc != null)
                    {
                        imgLrc.Dispose();
                    }
                    imgBack = new Bitmap(maxWidth, this.Height);
                    imgLrc = new Bitmap(maxWidth, this.Height);
                    this.Refresh();
                }
                else
                {
                    Size1(new Size(100, 50));
                }
            }
        }
        public void Size1(Size s)
        {
            if (imgBack != null)
            {
                imgBack.Dispose();
            }
            if (imgLrc != null)
            {
                imgLrc.Dispose();
            }
            imgBack = new Bitmap(s.Width, s.Height);
            imgLrc = new Bitmap(s.Width, s.Height);
        }

        public void ChangeSize()
        {
            while (this.fontStyle.Height * (currentLrcIndex + space + 1 + lines) < this.Height / 2)//如果Y轴位置高亮显示的歌词
            {
                lines += 1f;//即下移一行
                if (this.fontStyle.Height * (currentLrcIndex + space + 1 + lines) >= this.Height / 2)
                {
                    break;
                }
            }
            while (this.fontStyle.Height * (currentLrcIndex + space + 1 + lines) > this.Height / 2)//如果Y轴位置高亮显示的歌词
            {
                lines -= 1f;//即上移一行
                if (this.fontStyle.Height * (currentLrcIndex + space + 1 + lines) <= this.Height / 2)
                {
                    break;
                }
            }

        }


        public override Size MinimumSize
        {
            get
            {
                return new Size(100, 20);
            }
            set
            {
                base.MinimumSize = value;
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (currentPosition != null)
            {
                if (load == false)
                {
                    Components();
                    load = true;
                }
                DrawString(currentPosition, pe.Graphics, BackBrush, LightBrush,this.fontStyle, BackColor, stringFormatter);
                pe.Dispose();
            }
        }
        bool load = false;
        #region 画歌词
        LinkLabel l = new LinkLabel();
        public string DrawString(string nowTime, Graphics g, SolidBrush backBrush, SolidBrush lightBrush, Font f, Color backColor, StringFormat format)
        {
            if (lrcSortedList.Count > 0 && LrcConnections.lrcPath != null)
            {
                Size1(this.FindForm().Size);//歌词居中
                imgLrc = DrawLrcImg(nowTime, lightBrush, backBrush, f, backColor, format);
                if (isKana == true)
                {
                    imgBack = ShowLrc(backBrush, f, backColor, format);//画背景歌词
                    Rectangle rec = new Rectangle(0, 0, width, this.imgBack.Height);
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    if (imgLrc != null && imgBack != null)
                    {
                        g.DrawImage(imgBack, 0, 0);
                        //画当前高亮显示的歌词，其实就是画歌词图像的一部分，以像素显示会呈现卡拉OK歌词
                        g.DrawImage(imgLrc, 0, 0, rec, GraphicsUnit.Pixel);
                        //g.Flush();
                    }
                }
                else if (imgLrc != null)
                {
                    g.DrawImage(imgLrc, 0, 0);
                    //g.Flush();
                }
            }
            else
            {
                if (LrcConnections.lrcPath == null)
                {
                    Graphics gg = Graphics.FromImage(imgBack);
                    gg.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    gg.CompositingQuality = CompositingQuality.HighQuality;
                    gg.SmoothingMode = SmoothingMode.AntiAlias;
                    SizeF imgSize = gg.MeasureString("对不起,没有找到歌词,您可以手动指定歌词", f);//当前歌词长度
                    //this.FindForm().Size = new Size((int)imgSize.Width + 20, (int)imgSize.Height);
                    Size1(this.Size);
                    gg.Dispose();
                    gg = Graphics.FromImage(imgBack);
                    gg.DrawString("对不起,没有找到歌词,您可以手动指定歌词", f, backBrush, (this.Width - imgSize.Width) / 2, this.Height / 2);
                    gg.Dispose();
                    g.DrawImage(imgBack, 0, 0);
                }
            }
            return null;
        }

        //void l_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Process.Start("mailto:yaerfeng1989@163.com");
        //}
        #endregion

        #region 显示高亮歌词的方法
        int imgLeft = 0;
        private Bitmap DrawLrcImg(string currentTime, SolidBrush lightBrush, SolidBrush backBrush, Font f, Color backColor, StringFormat format)
        {
            if (currentTime == "" || currentTime == null)
            {
                return null;
            }
            space = (int)((this.Size.Height / f.Height) / 2);//画空白行，让歌词居中
            Graphics gra = Graphics.FromImage(imgLrc);
            gra.Clear(backColor);
            minute = Convert.ToInt32(currentTime.Substring(0, 2)) * 60;//分钟转为秒
            second = Convert.ToInt32(currentTime.Substring(3));
            if (f.Height * (currentLrcIndex + space + 1 + lines) > this.imgLrc.Height / 2)//如果Y轴位置高亮显示的歌词
            {
                lines -= 0.08f;//即每隔一秒上移一行，因为此句在100毫秒/次的timer中会执行10次
                if (f.Height * (currentLrcIndex + space + 1 + lines) > this.imgLrc.Height / 4 * 3)//如果超过下面的一半的一半
                {
                    ChangeSize();
                }
            }
            else
            {
                if (f.Height * (currentLrcIndex + space + 1 + lines) < this.imgLrc.Height / 4)//如果超过上面的一半的一半
                {
                    ChangeSize();
                }
            }
            for (int i = 0; i < space; i++)
            {
                gra.DrawString(null, f, lightBrush, this.imgLrc.Width / 2, f.Height * (space + 1), format);
                gra.Dispose();
            }
            int index = 0;
            int lrclines = (int)this.Height / this.fontStyle.Height;//一页歌词总行数
            if (currentLrcIndex <= lrclines / 2)//最上
            {
                //显示歌词
                for (; index < lrclines; index++)
                {
                    Graphics g = Graphics.FromImage(imgLrc);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    if (lrcSortedList.ElementAt(index).Key == (minute + second))//高亮显示当前歌词
                    {
                        currentLrcIndex = index;
                        lrcTime = 0;
                        width = 0;
                        if ((index + 1) <= lrcSortedList.Count)
                        {
                            middleTime = lrcSortedList.ElementAt(index + 1).Key - lrcSortedList.ElementAt(index).Key;
                        }
                        g.DrawString(lrcSortedList.ElementAt(index).Value, f, lightBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                        g.Flush();
                        g.Dispose();
                        continue;
                    }
                    if (currentLrcIndex == index && lrcTime <= middleTime * 1000)//继续画当前歌词
                    {
                        g.DrawString(lrcSortedList.ElementAt(currentLrcIndex).Value, f, lightBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                        imgLeft = (int)g.MeasureString(lrcSortedList.ElementAt(currentLrcIndex).Value, f).Width;//当前歌词长度
                        g.Dispose();
                        lrcTime += 1;
                        if (width == 0)
                        {
                            width += (this.Width - imgLeft) / 2;
                        }
                        width += (int)(imgLeft / (middleTime * 5));//歌词匀速以卡拉OK形式前进,毫秒化为秒
                        continue;

                    }
                    g.DrawString(lrcSortedList.ElementAt(index).Value, f, backBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                    g.Dispose();
                }
            }
            else if (currentLrcIndex > lrclines / 2)//最下和中间
            {
                //显示歌词
                for (index = currentLrcIndex - lrclines / 2 - 1; index < lrcSortedList.Count - 1; index++)
                {
                    Graphics g = Graphics.FromImage(imgLrc);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    if (lrcSortedList.ElementAt(index).Key == (minute + second))//高亮显示当前歌词
                    {
                        currentLrcIndex = index;
                        lrcTime = 0;
                        width = 0;
                        if ((index + 1) <= lrcSortedList.Count)
                        {
                            middleTime = lrcSortedList.ElementAt(index + 1).Key - lrcSortedList.ElementAt(index).Key;
                        }
                        g.DrawString(lrcSortedList.ElementAt(index).Value, f, lightBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                        g.Flush();
                        g.Dispose();
                        continue;
                    }
                    if (currentLrcIndex == index && lrcTime <= middleTime * 1000)//继续画当前歌词
                    {
                        g.DrawString(lrcSortedList.ElementAt(currentLrcIndex).Value, f, lightBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                        imgLeft = (int)g.MeasureString(lrcSortedList.ElementAt(currentLrcIndex).Value, f).Width;//当前歌词长度
                        g.Dispose();
                        lrcTime += 1;
                        if (width == 0)
                        {
                            width += (this.Width - imgLeft) / 2;
                        }
                        width += (int)(imgLeft / (middleTime * 5));//歌词匀速以卡拉OK形式前进,毫秒化为秒
                        continue;
                    }
                    g.DrawString(lrcSortedList.ElementAt(index).Value, f, backBrush, this.imgLrc.Width / 2, f.Height * (index + space + 1 + lines), format);
                    g.Dispose();
                }
            }
            return imgLrc;
        }
        #endregion

        #region 显示背景歌词的方法
        public Bitmap ShowLrc(SolidBrush backBrush, Font f, Color backColor, StringFormat format)
        {
            Graphics gra = Graphics.FromImage(imgBack);
            //gra.CompositingQuality = CompositingQuality.GammaCorrected;
            //gra.SmoothingMode = SmoothingMode.HighSpeed;
            //gra.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            gra.Clear(backColor);
            space = (int)((this.Size.Height / f.Height) / 2);//画空白行，让歌词居中
            for (int i = 0; i < space; i++)
            {
                gra.DrawString(null, f, lightBrush, this.imgBack.Width / 2, f.Height * (space + 1), format);
                gra.Dispose();
            }

            //Font f1 = new Font(f.FontFamily, f.Size + 0.2f, FontStyle.Regular);
            //for (int index = 0; index < lrcSortedList.Count - 1; index++)
            //{
            //    Graphics g = Graphics.FromImage(imgBack);
            //    g.SmoothingMode = SmoothingMode.AntiAlias;
            //    g.DrawString(lrcSortedList.ElementAt(index).Value, f1, new SolidBrush(Color.Blue), this.imgBack.Width / 2, f.Height * (index + space + 1 + lines), format);
            //    g.Dispose();
            //}
            //f1.Dispose();


            int index = 0;
            int lrclines = (int)this.Height / this.fontStyle.Height;//一页歌词总行数
            if (currentLrcIndex <= lrclines / 2)//最上
            {
                //显示歌词
                for (; index < lrclines; index++)
                {
                    Graphics g = Graphics.FromImage(imgBack);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawString(lrcSortedList.ElementAt(index).Value, f, backBrush, this.imgBack.Width / 2, f.Height * (index + space + 1 + lines), format);
                    //g.Flush();
                    g.Dispose();
                }
            }
            else if (currentLrcIndex > lrclines / 2)//最下和中间
            {
                //显示歌词
                for (index = currentLrcIndex - lrclines / 2 - 1; index < lrcSortedList.Count - 1; index++)
                {
                    Graphics g = Graphics.FromImage(imgBack);
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.DrawString(lrcSortedList.ElementAt(index).Value, f, backBrush, this.imgBack.Width / 2, f.Height * (index + space + 1 + lines), format);
                    //g.Flush();
                    g.Dispose();
                    if (index + space + 1 + lines > lrclines)
                    {
                        break;
                    }
                }
            }
            return imgBack;
        }
        #endregion


        #region //初始化
        public void Components()
        {
            try
            {
                backBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32(Config.GetValue("NormalColor"))));
                lightBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32(Config.GetValue("LightColor"))));
                backColor = Color.FromArgb(Convert.ToInt32(Config.GetValue("BackColor")));
                FontStyle f = FontStyle.Regular;
                if (Config.GetValue("FontStyle") == "bold")
                {
                    f = FontStyle.Bold;
                }
                else if (Config.GetValue("FontStyle") == "italic")
                {
                    f = FontStyle.Italic;
                }
                else if (Config.GetValue("FontStyle") == "strikeout")
                {
                    f = FontStyle.Strikeout;
                }
                else if (Config.GetValue("FontStyle") == "underline")
                {
                    f = FontStyle.Underline;
                }
                else
                {
                    f = FontStyle.Regular;
                }
                fontStyle = new Font(Config.GetValue("FontFamily"), float.Parse(Config.GetValue("FontSize")),f);
                stringFormatter = new StringFormat();
                stringFormatter.Alignment = StringAlignment.Center;
                stringFormatter.LineAlignment = StringAlignment.Center;
                stringFormatter.Trimming = StringTrimming.Character;
            }
            catch
            {
                backBrush = new SolidBrush(Color.GreenYellow);
                lightBrush = new SolidBrush(Color.White);
                backColor = Color.Black;
                fontStyle = new Font("幼圆", 14f);
                stringFormatter = new StringFormat();
                stringFormatter.Alignment = StringAlignment.Center;
                stringFormatter.LineAlignment = StringAlignment.Center;
                stringFormatter.Trimming = StringTrimming.Character;
            }
        }
        #endregion

        private void FullScreenShow_Click(object sender, EventArgs e)
        {
            showFullScreen();
        }

        public void showFullScreen()
        {
            if (FullScreenShow.Checked == false)
            {
                fontStyle = new Font("幼圆", 34f);
                this.FindForm().FormBorderStyle = FormBorderStyle.None;
                this.FindForm().WindowState = FormWindowState.Maximized;
                FullScreenShow.Checked = true;
            }
            else
            {
                FontStyle f = FontStyle.Regular;
                if (Config.GetValue("FontStyle") == "bold")
                {
                    f = FontStyle.Bold;
                }
                else if (Config.GetValue("FontStyle") == "italic")
                {
                    f = FontStyle.Italic;
                }
                else if (Config.GetValue("FontStyle") == "strikeout")
                {
                    f = FontStyle.Strikeout;
                }
                else if (Config.GetValue("FontStyle") == "underline")
                {
                    f = FontStyle.Underline;
                }
                else
                {
                    f = FontStyle.Regular;
                }
                fontStyle = new Font("华文新魏", 16f);
                
                this.FindForm().WindowState = FormWindowState.Normal;
                //this.FindForm().FormBorderStyle = FormBorderStyle.Sizable;
                FullScreenShow.Checked = false;
            }
            this.ChangeSize();
        }

        /// <summary>
        /// 简体到繁体转换
        /// </summary>
        /// <param name="simplifiedChinese">简体</param>
        /// <returns>繁体</returns>
        private string SimplifiedToTraditional(string simplifiedChinese)
        {
            string traditionalChinese = string.Empty;
            System.Globalization.CultureInfo vCultureInfo = new System.Globalization.CultureInfo("zh-CN", false);
            traditionalChinese = Microsoft.VisualBasic.Strings.StrConv(simplifiedChinese, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, vCultureInfo.LCID);
            return traditionalChinese;
        }

        /// <summary>
        /// 繁体到简体转换
        /// </summary>
        /// <param name="traditionalChinese">繁体</param>
        /// <returns>简体</returns>
        private string TraditionalToSimplified(string traditionalChinese)
        {
            string simplifiedChinese = string.Empty;
            System.Globalization.CultureInfo vCultureInfo = new System.Globalization.CultureInfo("zh-CN", false);
            simplifiedChinese = Microsoft.VisualBasic.Strings.StrConv(traditionalChinese, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, vCultureInfo.LCID);
            return simplifiedChinese;
        }

        private void tsmiSimpleToTra_Click(object sender, EventArgs e)
        {
            if (lrcSortedList == null || lrcSortedList.Count < 1)
            {
                return;
            }
            lrcTemp = new Dictionary<int, string>();
            if (isSimple)//traition
            {
                for (int i = 0; i < lrcSortedList.Count; i++)
                {
                    string tra = SimplifiedToTraditional(lrcSortedList.ElementAt(i).Value);
                    lrcTemp.Add(lrcSortedList.ElementAt(i).Key, tra);
                }
                lrcSortedList.Clear();
                lrcSortedList = lrcTemp;
                isSimple = false;
            }
        }

        private void tmsiTraToSimple_Click(object sender, EventArgs e)
        {
            if (lrcSortedList == null || lrcSortedList.Count < 1)
            {
                return;
            }
            lrcTemp = new Dictionary<int, string>();
            for (int i = 0; i < lrcSortedList.Count; i++)
            {
                string tra = TraditionalToSimplified(lrcSortedList.ElementAt(i).Value);
                lrcTemp.Add(lrcSortedList.ElementAt(i).Key, tra);
            }
            lrcSortedList.Clear();
            lrcSortedList = lrcTemp;
            isSimple = true;
        }

        private void tsmiKanaOK_Click(object sender, EventArgs e)
        {
            KanaOK();
        }

        public void KanaOK()
        {
            if (isKana == true)
            {
                isKana = false;
                tsmiKanaOK.Checked = false;
            }
            else
            {
                isKana = true;
                tsmiKanaOK.Checked = true;
            }
        }

        LrcSetFrm lrcset = null;
        private void lrcSetFrm_Click(object sender, EventArgs e)
        {
            showLrcSetFrm();
        }

        public void showLrcSetFrm()
        {
            if (lrcset == null)
            {
                lrcset = new LrcSetFrm(this);
                UserHelper.lrc = lrcset;
                lrcset.Show();
            }
            else
            {
                lrcset.Visible = true;
                lrcset.Activate();
            }
        }


        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "图像文件(*.jpg;*.bmp,*.gif,*.png)|*.jpeg;*.bmp,*.gif,*.png;*.jpg;";
            o.Title = "请选择图像";
            if (o.ShowDialog() == DialogResult.OK)
            {
                this.backColor = Color.Transparent;
                LrcConnections.lrcfrm.BackgroundImage = Image.FromFile(o.FileName);
            }
        }

        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LrcConnections.lrcfrm.BackgroundImageLayout = ImageLayout.Tile;//平铺
        }

        private void 拉伸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LrcConnections.lrcfrm.BackgroundImageLayout = ImageLayout.Stretch;//拉伸
        }

        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LrcConnections.lrcfrm.BackgroundImageLayout = ImageLayout.Center;//居中
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImageLayout = ImageLayout.Zoom;//放大
        }

        private void 左对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LrcConnections.lrcfrm.BackgroundImageLayout = ImageLayout.None;//左对齐
        }

        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancleTran();
        }

        public void cancleTran()
        {
            this.backColor = Color.Black;
            this.FindForm().FormBorderStyle = FormBorderStyle.None;
            LrcConnections.lrcfrm.BackgroundImage = null;
        }

        private void 背景色透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backTran();
        }

        public void backTran()
        {
            this.backColor = Color.Transparent;
            this.FindForm().BackColor = Color.Turquoise;
            LrcConnections.lrcfrm.TransparencyKey = Color.Turquoise;
            this.FindForm().FormBorderStyle = FormBorderStyle.None;
            LrcConnections.lrcfrm.BackgroundImage = null;
        }

        int total = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (total == 6)
            {
                timer1.Enabled = false;
                total = 0;
                Cursor.Hide();
                return;
            }
            total++;
        }


        public DeskLrcFrm desk = null;
        private void 显示桌面歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLrc();
        }

        public void showLrc()
        {
            //if (desk == null)
            //{
                desk = new DeskLrcFrm(this);
                desk.TopMost = true;
                LrcConnections.deskLrc = desk.deskLrcControl1;
                desk.Show();
                显示桌面歌词ToolStripMenuItem.Checked = true;
            //}
            //else
            //{

            //    desk.Activate();
            //    desk.TopMost = true;
            //}
            //this.FindForm().Visible = false;//隐藏当前歌词窗体
        }


    }
}
