using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace MediaPlayer
{
    public partial class CalenderForm : Form
    {
        Hashtable schedules;
        public CalenderForm()
        {
            InitializeComponent();
            schedules = Schedule.getSchedulesFromXML();
            //updateListView(string Date,string Time);
        }
        #region-----------------------更新列表--------------------------
        private void updateListView(string Date,string Time)
        {
            this.listViewAgendaTable.Items.Clear();
            foreach (DictionaryEntry de in schedules)
            {
                Schedule schedule = (Schedule)de.Value;
                ListViewItem listViewItem = new ListViewItem(new string[] {
                    Date,
                    Time,
                    schedule.subject}, -1);
               // MessageBox.Show(schedule.getDate());
                listViewAgendaTable.Items.Add(listViewItem);
            }
        }
        #endregion

        #region----------------------timer1_Tick------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now.TimeOfDay;
            latime.Text = DateTime.Now.ToString("h:mm:ss tt");
            lblmonth.Text = DateTime.Now.Month.ToString() + "月";
            lblyear.Text = DateTime.Now.Day.ToString() + "日 " + DateTime.Now.Year.ToString() + "年";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    lbxingqi.Text = "星期五";
                    break;
                case DayOfWeek.Monday:
                    lbxingqi.Text = "星期一";
                    break;
                case DayOfWeek.Saturday:
                    lbxingqi.Text = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    lbxingqi.Text = "星期日";
                    break;
                case DayOfWeek.Thursday:
                    lbxingqi.Text = "星期四";
                    break;
                case DayOfWeek.Tuesday:
                    lbxingqi.Text = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    lbxingqi.Text = "星期三";
                    break;
            }
        }
        #endregion

        #region-----------------------选择时间--------------------------
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = null;
            string time = null;
            string subject = null;
            Schedule schedule;
            richTBAgenda.Text = "";
            foreach (ListViewItem item in listViewAgendaTable.SelectedItems)
            {
                date = item.Text;
                time = item.SubItems[1].Text;
                subject = item.SubItems[2].Text;
            }

            if (date!=null && time!=null && subject!=null)
            {
                schedule = new Schedule(date, time, subject, "");
                schedule = (Schedule)schedules[schedule.ToString()];

                if (schedule != null)
                {
                    richTBAgenda.Text = schedule.content;
                } 
            }
        }
        #endregion

        #region--------------CalenderForm_FormClosing-------------------
        private void CalenderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string FileName = Application.StartupPath + "\\" + "Schedule.xml";

            StreamWriter sr = new StreamWriter(FileName, false, System.Text.Encoding.UTF8);
            string xmlText = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" +
                                "<schedules>\n\n";

            foreach (DictionaryEntry de in this.schedules)
            {
                Schedule schedule = (Schedule)de.Value;
                xmlText += schedule.xmlText;
            }
            xmlText += "</schedules>";
            sr.WriteLine(xmlText);
            sr.Flush();
            sr.Close();
        }
        #endregion

        #region------------------------退出-----------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region-------------------------修改----------------------------
        private void btnAlter_Click(object sender, EventArgs e)
        {
            string date = null;
            string time = null;
            string subject = null;
            string content = null;
            Schedule schedule = null;
            ModifyScheduleForm dia = new ModifyScheduleForm();

            if (listViewAgendaTable.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在列表框中选择日程然后修改。");
            }
            foreach (ListViewItem item in listViewAgendaTable.SelectedItems)
            {
                date = item.Text;
                time = item.SubItems[1].Text;
                subject = item.SubItems[2].Text;
            
                schedule = new Schedule(date, time, subject, "");
                schedule = (Schedule)schedules[schedule.ToString()];
                

                dia.monthCalendar.SelectionStart = DateTime.ParseExact(schedule.getYear()+schedule.getMonth()+schedule.getDay(),"yyyyMMdd",null);
                dia.comboBox_hour.Text = schedule.getHour();
                dia.comboBox_minute.Text = schedule.getMinute(); ;
                dia.subject.Text = schedule.subject;
                dia.content.Text = schedule.content;


                if (dia.ShowDialog(this) == DialogResult.OK)
                {
                    schedules.Remove(schedule.ToString());
                    date = dia.monthCalendar.SelectionStart.ToString("yyyy-MM-dd");
                    time = dia.comboBox_hour.Text + ":" + dia.comboBox_minute.Text;
                    subject = dia.subject.Text;
                    content = dia.content.Text;
                    schedule = new Schedule(date, time, subject, content);
                    this.schedules.Add(schedule.ToString(), schedule);
                    updateListView(date,time);
                    this.richTBAgenda.Text = content;
                }
                else
                {
                }
                dia.Dispose();
             }
        }
        #endregion

        #region-----------------------添加------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string date = null;
            string time = null;
            string subject = null;
            string content = null;
            Schedule schedule = null;
            AddScheduleForm addScheduleDialog = new AddScheduleForm();
           
            if (addScheduleDialog.ShowDialog(this) == DialogResult.OK)
            {
                date = addScheduleDialog.monthCalendar.SelectionStart.ToString("yyyy-MM-dd");
                time = addScheduleDialog.comboBox_hour.Text + ":" + addScheduleDialog.comboBox_minute.Text;
                subject = addScheduleDialog.subject.Text;
                content = addScheduleDialog.content.Text;
                schedule = new Schedule(date, time, subject, content);
                this.schedules.Add(schedule.ToString(), schedule);
                updateListView(date,time);
   
            }
           else
           {
           }
            addScheduleDialog.Dispose();
        }
        #endregion

        #region-----------------------删除------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date = null;
            string time = null;
            string subject = null;
            Schedule schedule = null;

            foreach (ListViewItem item in listViewAgendaTable.SelectedItems)
            {
                date = item.Text;
                time = item.SubItems[1].Text;
                subject = item.SubItems[2].Text;

                schedule = new Schedule(date, time, subject, "");
                schedule = (Schedule)schedules[schedule.ToString()];
                schedules.Remove(schedule.ToString());
                updateListView(date,time);
                this.richTBAgenda.Text = "";
            }
        }
        #endregion
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

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
