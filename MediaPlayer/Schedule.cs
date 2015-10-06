using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;

namespace MediaPlayer
{
    class Schedule
    {
        protected static string FileName = Application.StartupPath + "\\" + "Schedule.xml";

        private DateTime datetime ;
        public string subject;
        public string content;
        public string xmlText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("\t<schedule>");
                sb.AppendLine("\t\t<date>" + this.datetime.ToString("yyyy-MM-dd") + "</date>");
                sb.AppendLine("\t\t<time>" + this.datetime.ToString("HH:mm") + "</time>");
                sb.AppendLine("\t\t<subject>" + this.subject + "</subject>");
                sb.AppendLine("\t\t<content>" + this.content + "</content>");
                sb.AppendLine("\t</schedule>");

                return sb.ToString();
            }
        }


        public Schedule(string date, string time, string subject, string content)
        {
            this.subject = subject;
            this.content = content;
        }

        public string getDate()
        {
            return datetime.ToShortDateString();
        }
        public string getYear()
        {
            return datetime.ToString("yyyy");
        }
        public string getMonth()
        {
            return datetime.ToString("MM");
        }
        public string getDay()
        {
            return datetime.ToString("dd");
        }

        public string getTime()
        {
            return datetime.ToString("HH:mm");
        }
        public string getHour()
        {
            return datetime.ToString("HH");
        }
        public string getMinute()
        {
            return datetime.ToString("mm");
        }
        public static Hashtable getSchedulesFromXML()
        {
            Hashtable schedules = new Hashtable();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(FileName);
                XmlNodeList xschedules = xmlDoc.SelectSingleNode("schedules").ChildNodes;
                if (xschedules != null)
                {
                        foreach (XmlNode xschedule in xschedules)
                        {
                            string date = xschedule.SelectSingleNode("date").InnerText;
                            string time = xschedule.SelectSingleNode("time").InnerText;
                            string subject = xschedule.SelectSingleNode("subject").InnerText;
                            string content = xschedule.SelectSingleNode("content").InnerText;
                            Schedule s = new Schedule(date, time, subject, content);

                            try
                            {
                                schedules.Add(s.ToString(), s);
                            }
                            catch (ArgumentException)
                            {
                            }

                        }
                    
                }



            }
            catch (FileNotFoundException)
            {
                //MessageBox.Show("Cannot open file\n" + e.Message);
            }
            return schedules;
        }

        public override bool Equals(object obj)
        {
            Schedule s = (Schedule)obj;
            if(s.getDate().Equals(this.getDate())  && s.getTime().Equals(this.getTime()) 
                && s.subject.Equals(this.subject) )
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return datetime.ToString("yyyy-MM-dd,HH:mm") + subject;
        }

    }
}
