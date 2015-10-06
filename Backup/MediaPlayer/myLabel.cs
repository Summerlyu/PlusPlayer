using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class myLabel : UserControl
    {
         public myLabel()
        {
            InitializeComponent();
            Timer t = new Timer();
            this.DoubleBuffered = true;
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Draw(pe.Graphics);
            pe.Dispose();
        }


        //程序人生 人生如戏 戏如人生 却不能游戏人生
        void t_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Font f = new Font("华文行楷", 35F, FontStyle.Italic);
            SolidBrush fontB = new SolidBrush(Color.Gray);
            SolidBrush fontA = new SolidBrush(Color.Red);

            //先画阴影，坐标偏移5
            g.DrawString("程序", f, fontB, 15, 30);
            g.DrawString("人生", f, fontB, 15, this.Size.Height / 2 + 15);
            //再画字体
            g.DrawString("程序", f, fontA, 0, 15);
            g.DrawString("人生", f, fontA, 0, this.Size.Height / 2);
        }

            //Font f1 = new Font("幼圆", 15F, FontStyle.Regular);
            //SolidBrush fontC = new SolidBrush(Color.LightGray);
            //for (int i = 0; i <= 360; i += 60)
            //{
            //    //平移Graphics对象到窗体中心
            //    g.TranslateTransform(this.Width / 2, this.Height / 2);
            //    //设置Graphics对象的输出角度
            //    g.RotateTransform(i);
            //    //设置文字填充颜色
            //    //旋转显示文字
            //    g.DrawString("土豆水印", f1, fontC, 10, 10);
            //    //恢复全局变换矩阵
            //    g.ResetTransform();
            //}
    }
}
