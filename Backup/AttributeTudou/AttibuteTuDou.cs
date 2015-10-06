using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributeTudou
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]//允许多个访问，可以对任何应用程序的元素应用此特性
    public class AttibuteTuDou : Attribute
    {
        public AttibuteTuDou()
        {
        }

        public AttibuteTuDou(string author,string createDate,string lastUpDate,string comp,string producter,string version,string copyRight,string otherDesc)
        {
            this.Author = author;
            this.CreateDate = createDate;
            this.LastUpTime = lastUpDate;
            this.Company = comp;
            this.Producter = producter;
            this.Version = version;
            this.CopyRight = copyRight;
            this.OtherDesc =otherDesc;
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string createDate;

        public string CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        private string lastUpTime;

        public string LastUpTime
        {
            get { return lastUpTime; }
            set { lastUpTime = value; }
        }
        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string company;

        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        private string producter;

        public string Producter
        {
            get { return producter; }
            set { producter = value; }
        }

        private string otherDesc;

        public string OtherDesc
        {
            get { return otherDesc; }
            set { otherDesc = value; }
        }

        private string copyRight;

        public string CopyRight
        {
            get { return copyRight; }
            set { copyRight = value; }
        }
    }
}
