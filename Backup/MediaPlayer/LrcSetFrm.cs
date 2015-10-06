using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LrcCollection;
using AttributeTudou;
using System.Reflection;

namespace MediaPlayer
{
    public partial class LrcSetFrm : Form
    {
        //private Font fontStyle;
        private Color normalColor;
        private Color lightColor;
        private Color backColor;
        private LrcPanel lrcPanel;
        public LrcSetFrm(LrcPanel lrcPanel)
        {
            InitializeComponent();
            this.lrcPanel = lrcPanel;

            tudou = AssemblyTitle;
            this.Text = String.Format("关于 {0}", AssemblyProduct);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (Config.GetValue("FontSize") != null)
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
                font.Font = new Font(Config.GetValue("FontFamily"), float.Parse(Config.GetValue("FontSize")),f);
            }
            if (font.ShowDialog() == DialogResult.OK)
            {
                Config.SetValue("FontFamily", font.Font.FontFamily.Name);
                Config.SetValue("FontSize", font.Font.Size.ToString());
                if (font.Font.Style == FontStyle.Bold)
                {
                    Config.SetValue("FontStyle", "bold");
                }
                else if (font.Font.Style == FontStyle.Italic)
                {
                    Config.SetValue("FontStyle", "italic");
                }
                else if (font.Font.Style == FontStyle.Strikeout)
                {
                    Config.SetValue("FontStyle", "strikeout");
                }
                else if (font.Font.Style == FontStyle.Underline)
                {
                    Config.SetValue("FontStyle", "underline");
                }
                else
                {
                    Config.SetValue("FontStyle", "regular");
                }
                lrcPanel.fontStyle = font.Font;
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            normal.Color = normalColor;
            if (normal.ShowDialog() == DialogResult.OK)
            {
                lrcPanel.BackBrush.Color = normal.Color;
                Config.SetValue("NormalColor", normal.Color.ToArgb().ToString());
                normalColor = normal.Color;
                labNormal.BackColor = normalColor;
            }
        }

        private void btnLight_Click(object sender, EventArgs e)
        {
            normal.Color = lightColor;
            if (normal.ShowDialog() == DialogResult.OK)
            {
                lrcPanel.LightBrush.Color = normal.Color;
                Config.SetValue("LightColor", normal.Color.ToArgb().ToString());
                lightColor = normal.Color;
                labLight.BackColor = lightColor;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            normal.Color = backColor;
            if (normal.ShowDialog() == DialogResult.OK)
            {
                lrcPanel.BackColor = normal.Color;
                Config.SetValue("BackColor", normal.Color.ToArgb().ToString());
                backColor = normal.Color;
                labBack.BackColor = backColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = Config.GetValue("lrcDir");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = folderBrowserDialog1.SelectedPath;
                Config.SetValue("lrcDir", folderBrowserDialog1.SelectedPath);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Lrc歌词|*.lrc;*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LrcConnections.LoadLrc(openFileDialog1.FileName,null);
            }
        }

        private void LrcSetFrm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            this.comboBox1.SelectedIndex = 0;


            labNormal.BackColor =Color.FromArgb(Convert.ToInt32( Config.GetValue("NormalColor")));
            labLight.BackColor = Color.FromArgb(Convert.ToInt32( Config.GetValue("LightColor")));
            labBack.BackColor = Color.FromArgb(Convert.ToInt32( Config.GetValue("BackColor")));

            lblDeskBack.BackColor = Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskBackColor")));
            lblDeskLight.BackColor = Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskLightColor")));
            lblNormal.BackColor = Color.FromArgb(Convert.ToInt32(Config.GetValue("DeskNormalColor")));
            if (LrcConnections.deskLrc != null)
            {
                if (LrcConnections.deskLrc.isDoubleLine == true)
                {
                    this.comboBox1.SelectedIndex = 1;
                }
                else
                {
                    this.comboBox1.SelectedIndex = 0;
                }
            }

            if (LrcConnections.lrcPath != null)
            {
                txtPath.Text = LrcConnections.lrcPath;
            }
            string lrcFile = Config.GetValue("lrcDir");
            if (Directory.Exists(lrcFile))
            {
                this.textBox1.Text = lrcFile;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        private void cboFrmKana_CheckedChanged(object sender, EventArgs e)
        {
            if (cboFrmKana.Checked == true)
            {
                lrcPanel.isKana = true;
            }
            else
            {
                lrcPanel.isKana = false;
            }
        }

        private void btnDeskFont_Click(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                if (Config.GetValue("DeskFontSize") != null)
                {
                    FontStyle f = FontStyle.Regular;
                    if (Config.GetValue("DeskFontStyle")=="bold")
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
                    font.Font = new Font(Config.GetValue("DeskFontFamily"), float.Parse(Config.GetValue("DeskFontSize")), f);
                }
                if (font.ShowDialog() == DialogResult.OK)
                {
                    Config.SetValue("DeskFontFamily", font.Font.FontFamily.Name);
                    Config.SetValue("DeskFontSize", font.Font.Size.ToString());
                    if (font.Font.Style == FontStyle.Bold)
                    {
                        Config.SetValue("DeskFontStyle", "bold");
                    }
                    else if (font.Font.Style == FontStyle.Italic)
                    {
                        Config.SetValue("DeskFontStyle", "italic");
                    }
                    else if (font.Font.Style == FontStyle.Strikeout)
                    {
                        Config.SetValue("DeskFontStyle", "strikeout");
                    }
                    else if (font.Font.Style == FontStyle.Underline)
                    {
                        Config.SetValue("DeskFontStyle", "underline");
                    }
                    else
                    {
                        Config.SetValue("DeskFontStyle", "regular");
                    }
                    LrcConnections.deskLrc.FontSty = font.Font;
                }
            }
        }

        private void btnDeskNormal_Click(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                normal.Color = LrcConnections.deskLrc.BackBrush.Color;
                if (normal.ShowDialog() == DialogResult.OK)
                {
                    Config.SetValue("DeskNormalColor", normal.Color.ToArgb().ToString());
                    LrcConnections.deskLrc.BackBrush.Color = normal.Color;
                    lblNormal.BackColor = normal.Color;
                }
            }
        }

        private void btnDeskLight_Click(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                normal.Color = LrcConnections.deskLrc.LightBrush.Color;
                if (normal.ShowDialog() == DialogResult.OK)
                {
                    Config.SetValue("DeskLightColor", normal.Color.ToArgb().ToString());
                    LrcConnections.deskLrc.LightBrush.Color = normal.Color;
                    lblDeskLight.BackColor = normal.Color;
                }
            }
        }

        private void btnDeskBack_Click(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                normal.Color = LrcConnections.deskLrc.BackColors;
                if (normal.ShowDialog() == DialogResult.OK)
                {
                    Config.SetValue("DeskBackColor", normal.Color.ToArgb().ToString());
                    LrcConnections.deskLrc.BackColors = normal.Color;
                    lblDeskBack.BackColor = normal.Color;
                }
            }
        }

        private void cboDeskKank_CheckedChanged(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                if (cboDeskKank.Checked == true)
                {
                    LrcConnections.deskLrc.isKana = true;
                }
                else
                {
                    LrcConnections.deskLrc.isKana = false;
                }
            }
        }

        private void cboBackColor_CheckedChanged(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                if (cboBackColor.Checked == true)
                {
                    LrcConnections.deskLrc.isTranKey = true;
                }
                else
                {
                    LrcConnections.deskLrc.isTranKey = false;
                }
            }
        }

        private void btnOpenLrc_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim() != "" && txtPath.Text.Trim() != null)
            {
                if (File.Exists(txtPath.Text))
                {
                    System.Diagnostics.Process.Start("NOTEPAD.EXE", txtPath.Text);
                }
                else
                {
                    MessageBox.Show("对不起，不存在该文件！");
                }
            }
        }

        private void btnOpenLrcFile_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox1.Text.Trim() != null)
            {
                if (Directory.Exists(textBox1.Text))
                {
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + textBox1.Text);
                }
                else
                {
                    MessageBox.Show("对不起，不存在该文件夹,请重新指定文件夹！");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LrcConnections.deskLrc != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    LrcConnections.deskLrc.isDoubleLine = false;
                    Config.SetValue("DeskIsDoubleline","false");
                }
                else
                {
                    LrcConnections.deskLrc.isDoubleLine = true;
                    Config.SetValue("DeskIsDoubleline", "true");
                }
            }
        }

        private void LrcSetFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void cboTopmost_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cboTopmost.Checked == true)
            {
                this.lrcPanel.FindForm().TopMost = true;
            }
            else
            {
                this.lrcPanel.FindForm().TopMost = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked == true)
            {
                this.lrcPanel.backTran();
            }
            else
            {
                this.lrcPanel.cancleTran();
            }
        }

        AttibuteTuDou tudou = null;

        #region 程序集属性访问器

        public AttibuteTuDou AssemblyTitle
        {
            get
            {
                Assembly ass = Assembly.Load("AttributeReflection");
                Type[] t = ass.GetTypes();
                foreach (Type type in t)
                {
                    Attribute[] attributes = Attribute.GetCustomAttributes(type);
                    if (attributes.Length > 0)
                    {
                        foreach (Attribute a in attributes)
                        {
                            tudou = (AttibuteTuDou)a;
                            return tudou;
                        }
                    }
                }
                return null;
            }

        }

        public string AssemblyVersion
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.Version;
                }
                return "1.0.0";
            }
        }

        public string AssemblyDescription
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.OtherDesc;
                }
                return "支持作者 支持原创";
            }
        }

        public string AssemblyProduct
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.Producter;
                }
                return "土豆作品";
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.CopyRight;
                }
                return "CopyRights  € 2010";
            }
        }

        public string AssemblyCompany
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.Company;
                }
                return "土豆工作室";
            }
        }

        public string CreateDate
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.CreateDate;
                }
                return null;
            }
        }

        public string LastUpDate
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.LastUpTime;
                }
                return null;
            }
        }

        public string author
        {
            get
            {
                if (tudou != null)
                {
                    return tudou.Author;
                }
                return "很拽の土豆";
            }
        }
        #endregion

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.txtPath.Text != null)
            {
                FileInfo f = new FileInfo(this.txtPath.Text);
                if (f.Exists)
                {
                    if (MessageBox.Show("确认永久删除歌词" + f.FullName + "?","警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        f.Delete();
                    }
                }
            }
        }
    }
}
