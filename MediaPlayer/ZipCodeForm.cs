using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace MediaPlayer
{
    public partial class ZipCodeForm : Form
    {
        Hashtable ptoc = new Hashtable();
        
        Hashtable pandctoz = new Hashtable();
        public ZipCodeForm()
        {
            InitializeComponent();
        }
        private void ZipCodeForm_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("zipcode.txt"))
            {
                string line;
                
           
                while ((line = sr.ReadLine()) != null)
                {
                    string [] ss = line.Split('\t');
                    ZipCode zipcode = new ZipCode(ss[0], ss[1], ss[2], ss[3]);
                    List<string> cities = (List<string>)(ptoc[zipcode.province]);
                    if (cities == null)
                    {
                        cities = new List<string>();
                        ptoc.Add(zipcode.province, cities);
                        this.province.Items.Add(zipcode.province);
                    }
                    cities.Add(zipcode.city);
                    pandctoz.Add(zipcode.ToString(), zipcode);

                }
            }

        }
        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.zipcode.Text = ((ZipCode)pandctoz[province.Text + "," + city.Text]).zipcode;
            this.arecode.Text = ((ZipCode)pandctoz[province.Text + "," + city.Text]).areacode;
        }

        private void province_SelectedIndexChanged(object sender, EventArgs e)
        {
            city.Items.Clear();
            List<string> cities = (List<string>)(ptoc[province.Text]);
            foreach (string city1 in cities)
            {
                this.city.Items.Add(city1);
            }
            city.Text = city.Items[0].ToString();
        }

        #region --------------------------- 移动窗体 ----------------------------
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
