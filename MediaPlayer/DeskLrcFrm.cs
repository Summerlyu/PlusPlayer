using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace MediaPlayer
{
    public partial class DeskLrcFrm : Form
    {
        public LrcPanel lrcPanel;
        public DeskLrcFrm(LrcPanel lrc)
        {
            InitializeComponent();
            this.lrcPanel = lrc;
            this.DoubleBuffered = true;
        }

        private void loadLrc()
        {
            int i = 0;
            while (LrcConnections.isReading == true)
            {
                Thread.Sleep(2000);
                if (LrcConnections.isReading == false || i == 5)
                {
                    break;
                }
            }
            if (LrcConnections.isReading == false)
            {
                this.deskLrcControl1.lrcSortedList = LrcConnections.lrcSortedList;
            }
            Thread.CurrentThread.Abort();
        }

        #region  //拖动无标题窗体
        Point startPlace = new Point();
        private void deskLrcControl1_MouseDown(object sender, MouseEventArgs e)
        {
            startPlace = new Point(e.X, e.Y);
        }

        private void deskLrcControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - startPlace.X;
                this.Top += e.Y - startPlace.Y;
            }
        }
        #endregion

        private void DeskLrcFrm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 4, Screen.PrimaryScreen.WorkingArea.Height - 100);
            this.deskLrcControl1.lrcPanel = this.lrcPanel;

            Thread t = new Thread(loadLrc);
            t.IsBackground = true;
            t.Start();
        }

        private void DeskLrcFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //存储当前状态
           
        }

    }
}
