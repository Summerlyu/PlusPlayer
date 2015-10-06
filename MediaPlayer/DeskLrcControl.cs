using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using LrcCollection;

namespace MediaPlayer
{
    public partial class DeskLrcControl : UserControl
    {
        public DeskLrcControl()
        {
            InitializeComponent();
            Size1(this.Size);
            Components();
            this.DoubleBuffered = true;
        }

        #region 字段
        public LrcPanel lrcPanel = null;
        private ArrayList lrcConfig = new ArrayList();
        int width = 0;
        Bitmap imgBack;
        Bitmap imgLrc;
        int middleTime = 0;
        public string currentPosition = null;
        int minute;
        int second;
        
        public Dictionary<int, string> lrcSortedList = new Dictionary<int, string>();//用来保存歌词和时间排序后的集合

        private SolidBrush backBrush;
        private SolidBrush lightBrush;
        private Color backColor;
        private Font fontStyle;
        private StringFormat stringFormatter;
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

            //maxWidth = 0;
            //lrcSortedList.Clear();
            //Graphics g = Graphics.FromHwnd(this.contextMenuStrip1.Handle);
            //for (int i = 0; i < tempTime.Length; i++)
            //{
            //    if (i + 1 < tempTime.Length)
            //    {
            //        if (g.MeasureString(lrcList.ElementAt(i).Value, fontStyle).Width > maxWidth)
            //        {
            //            maxWidth = (int)g.MeasureString(lrcList.ElementAt(i).Value, fontStyle).Width;
            //        }
            //    }
            //    lrcSortedList.Add(tempTime[i], lrcList[tempTime[i]]);
            //}
            //g.Dispose();
            //imgBack = new Bitmap(maxWidth + 2, this.Height);
            //imgLrc = new Bitmap(maxWidth + 2, this.Height); 
            //this.Refresh();
        }

        public override Size MinimumSize
        {
            get
            {
                return new Size(200, 20);
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
                DrawString(currentPosition, pe.Graphics, BackBrush, LightBrush, this.fontStyle, this.BackColor, stringFormatter);
                pe.Dispose();
            }
        }

        bool load = false;
        #region //初始化
        public void Components()
        {
            try
            {
                backBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskNormalColor"))));
                lightBrush = new SolidBrush(Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskLightColor"))));
                backColor = Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskBackColor")));
                FontStyle f = FontStyle.Regular;
                if (Config.GetValue("DeskFontStyle") == "bold")
                {
                    f = FontStyle.Bold;
                }
                else if (Config.GetValue("DeskFontStyle") == "italic")
                {
                    f = FontStyle.Italic;
                }
                else if (Config.GetValue("DeskFontStyle") == "strikeout")
                {
                    f = FontStyle.Strikeout;
                }
                else if (Config.GetValue("DeskFontStyle") == "underline")
                {
                    f = FontStyle.Underline;
                }
                else
                {
                    f = FontStyle.Regular;
                }
                fontStyle = new Font(Config.GetValue("DeskFontFamily"), float.Parse(Config.GetValue("DeskFontSize")),f);
                if (Config.GetValue("DeskIsDoubleline") != null)
                {
                    isDoubleLine = Convert.ToBoolean(Config.GetValue("DeskIsDoubleline"));
                }

                stringFormatter = new StringFormat();
                stringFormatter.Alignment = StringAlignment.Center;
                stringFormatter.LineAlignment = StringAlignment.Center;
                stringFormatter.Trimming = StringTrimming.Character;
            }
            catch
            {
                backBrush = new SolidBrush(Color.Blue);
                lightBrush = new SolidBrush(Color.Red);
                backColor = Color.Black;
                fontStyle = new Font("幼圆", 34f);
                stringFormatter = new StringFormat();
                stringFormatter.Alignment = StringAlignment.Center;
                stringFormatter.LineAlignment = StringAlignment.Center;
                stringFormatter.Trimming = StringTrimming.Character;
            }
        }
        #endregion


        #region 画歌词
        public bool isKana = true;
        public bool isTranKey = true;
        public bool isDoubleLine = true;
        SizeF imgSize = SizeF.Empty;
        SizeF img1 = SizeF.Empty;
        public string DrawString(string nowTime, Graphics g, SolidBrush backBrush, SolidBrush lightBrush, Font f, Color backColor, StringFormat format)
        {
            if (isTranKey == true)
            {
                this.BackColors = Color.Transparent;
                this.FindForm().BackColor = Color.Turquoise;
                this.FindForm().TransparencyKey = Color.Turquoise;
            }
            if (lrcSortedList.Count > 0 && LrcConnections.lrcPath != null)
            {
                Size1(this.FindForm().Size);//歌词居中
                imgLrc = DrawLrcImg(nowTime, lightBrush, backBrush, f, backColor, format);
                if (isKana == true)
                {
                    imgBack = ShowLrc(backBrush, f, backColor, format);//画背景歌词
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                    if (imgLrc != null && imgBack != null)
                    {
                        Rectangle rec = new Rectangle(0, 0, width, this.imgLrc.Height);
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
                    this.FindForm().Size = new Size((int)imgSize.Width, (int)imgSize.Height);
                    Size1(this.Size);

                    gg.Dispose();
                    gg = Graphics.FromImage(imgBack);
                    gg.DrawString("对不起,没有找到歌词,您可以手动指定歌词", f, backBrush, 0, 0);
                    gg.Dispose();
                    g.DrawImage(imgBack, 0, 0);
                }
            }
            return null;
        }

        #endregion

        #region 显示高亮歌词的方法
        private Bitmap DrawLrcImg(string currentTime, SolidBrush lightBrush, SolidBrush backBrush, Font f, Color backColor, StringFormat format)
        {
            if (currentTime == "" || currentTime == null)
            {
                return null;
            }
            if (imgLrc == null)
            {
                return null;
            }
            Graphics gra = Graphics.FromImage(imgLrc);
            gra.Clear(backColor);

            minute = Convert.ToInt32(currentTime.Substring(0, 2)) * 60;//分钟转为秒
            second = Convert.ToInt32(currentTime.Substring(3));

            for (int i = 0; i < lrcSortedList.Count - 1; i++)
            {
                if (lrcSortedList.ElementAt(i).Key == (minute + second))//高亮显示当前歌词
                {
                    //float lrcWidth = g.MeasureString(lrcSortedList.ElementAt(i).Value, f).Width;
                    UserHelper.currentLrcIndex = i;
                    width = 0;
                    break;
                }
            }
            if ((UserHelper.currentLrcIndex + 1) <= lrcSortedList.Count)
            {
                middleTime = lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Key - lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Key;
            }

            imgSize = gra.MeasureString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f);//当前歌词长度
            if (isDoubleLine == false)
            {
                this.FindForm().Size = new Size((int)imgSize.Width, (int)imgSize.Height);
                Size1(this.Size);
            }
            else//如果是双行的话
            {
                if (UserHelper.currentLrcIndex < lrcSortedList.Count - 1)
                {
                    img1 = gra.MeasureString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Value, f);
                }

                if (imgSize.Width > img1.Width)
                {
                    this.FindForm().Size = new Size((int)imgSize.Width, (int)imgSize.Height * 2);
                    Size1(this.Size);
                }
                else
                {
                    this.FindForm().Size = new Size((int)img1.Width, (int)img1.Height * 2);
                    Size1(this.Size);
                }
                gra.Dispose();
            }
            if (width == 0)
            {
                width++;
            }
            else
            {
                width += (int)(imgSize.Width / (middleTime * 6));//歌词匀速以卡拉OK形式前进,毫秒化为秒
            }
            Graphics g = Graphics.FromImage(imgLrc);
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (isDoubleLine == false)
            {
                g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, lightBrush, 0, 0);
            }
            else
            {
                if (UserHelper.currentLrcIndex % 2 == 0)
                {
                    g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, lightBrush, 0, 0);
                    if (UserHelper.currentLrcIndex < lrcSortedList.Count - 1)
                    {
                        g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Value, f, backBrush, 0, f.Height);
                    }
                }
                else
                {
                    if (UserHelper.currentLrcIndex < lrcSortedList.Count - 1)
                    {
                        g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Value, f, backBrush, 0, 0);
                    }
                    g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, lightBrush, 0, f.Height);
                }
            }
            //g.Flush();
            g.Dispose();
            return imgLrc;
        }
        #endregion

        #region 显示背景歌词的方法
        public Bitmap ShowLrc(SolidBrush backBrush, Font f, Color backColor, StringFormat format)
        {
            Graphics gra = Graphics.FromImage(imgBack);
            gra.Clear(backColor);
            //Font f1 = new Font(f.FontFamily, f.Size + 0.2f, FontStyle.Regular);
            //for (int index = 0; index < lrcSortedList.Count - 1; index++)
            //{
            //    Graphics g = Graphics.FromImage(imgBack);
            //    g.SmoothingMode = SmoothingMode.AntiAlias;
            //    g.DrawString(lrcSortedList.ElementAt(index).Value, f1, new SolidBrush(Color.Blue), this.imgBack.Width / 2, f.Height * (index + space + 1 + lines), format);
            //    g.Dispose();
            //}
            //f1.Dispose();
            //显示歌词
            Graphics g = Graphics.FromImage(imgBack);
            g.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (isDoubleLine == false)
            {
                g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, backBrush, 0, 0);
            }
            else
            {
                if (UserHelper.currentLrcIndex % 2 == 0)
                {
                    g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, backBrush, 0, 0);
                    if (UserHelper.currentLrcIndex < lrcSortedList.Count - 1)
                    {
                        g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Value, f, backBrush, 0, f.Height);
                    }
                }
                else
                {
                    g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex + 1).Value, f, backBrush, 0, 0);
                    g.DrawString(lrcSortedList.ElementAt(UserHelper.currentLrcIndex).Value, f, backBrush, 0, f.Height);
                }
            }
            //g.Flush();
            g.Dispose();
            return imgBack;
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
