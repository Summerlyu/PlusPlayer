using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class Tips : Form
    {
        private int heightMax, widthMax;
        public int HeightMax
        {
            set
            {
                heightMax = value;
            }
            get
            {
                return heightMax;
            }
        }

        public int WidthMax
        {
            set
            {
                widthMax = value;
            }
            get
            {
                return widthMax;
            }
        }

        public void ScrollShow()
        {
            this.Width = widthMax;
            this.Height = 0;
            this.Show();
            this.timer1.Enabled = true;
        }

        public int StayTime = 200;
        private void ScrollUp()
        {
            if (this.Height < 280)
            //while(this.Location.Y > 350)
            {
                this.Height += 6;
                this.Location = new Point(this.Location.X, this.Location.Y - 6);


            }
            // if(Height>2)
            //{
            // this.Location = new Point(this.Location.X, this.Location.Y);
            //}
        }

        public Tips()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            ScrollShow();
            RTextBox.Text = pub.text;
            this.TopMost = true;
            Screen[] screens = Screen.AllScreens;
            Screen screen = screens[0];
            this.Location = new Point(screen.WorkingArea.Width - widthMax, screen.WorkingArea.Height);
            this.timer1.Interval = StayTime;
            //timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ScrollUp();

        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void Form2_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
