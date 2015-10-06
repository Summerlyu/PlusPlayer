using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace MediaPlayer
{
	/// <summary>
	/// Form1 ��ժҪ˵����

	/// </summary>
	
	public class Notepad : System.Windows.Forms.Form
	{
		public bool issaved;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItemGeshi;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem Mnew;
		private System.Windows.Forms.MenuItem MOpen;
		private System.Windows.Forms.MenuItem Msave;
        private System.Windows.Forms.MenuItem MSaveas;
		private System.Windows.Forms.MenuItem Mprint;
		private System.Windows.Forms.MenuItem Mexit;
		private System.Windows.Forms.MenuItem Mundo;
		private System.Windows.Forms.MenuItem Mcut;
		private System.Windows.Forms.MenuItem Mcopy;
		private System.Windows.Forms.MenuItem Mpaste;
		private System.Windows.Forms.MenuItem Mdelete;
		private System.Windows.Forms.MenuItem Mselectall;
		private System.Windows.Forms.MenuItem Maddtime;
		private System.Windows.Forms.MenuItem Mwrap;
		private System.Windows.Forms.MenuItem Mfont;
		private System.Windows.Forms.MenuItem Mabout;
        private System.Windows.Forms.RichTextBox richtb;
        private MenuItem Mpageset;
        private IContainer components;

		public Notepad()
		{
			
			InitializeComponent();

		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notepad));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.Mnew = new System.Windows.Forms.MenuItem();
            this.MOpen = new System.Windows.Forms.MenuItem();
            this.Msave = new System.Windows.Forms.MenuItem();
            this.MSaveas = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.Mprint = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.Mexit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.Mundo = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.Mcut = new System.Windows.Forms.MenuItem();
            this.Mcopy = new System.Windows.Forms.MenuItem();
            this.Mpaste = new System.Windows.Forms.MenuItem();
            this.Mdelete = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.Mselectall = new System.Windows.Forms.MenuItem();
            this.Maddtime = new System.Windows.Forms.MenuItem();
            this.menuItemGeshi = new System.Windows.Forms.MenuItem();
            this.Mwrap = new System.Windows.Forms.MenuItem();
            this.Mfont = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.Mabout = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.richtb = new System.Windows.Forms.RichTextBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.Mpageset = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemGeshi,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Mnew,
            this.MOpen,
            this.Msave,
            this.MSaveas,
            this.menuItem6,
            this.Mpageset,
            this.Mprint,
            this.menuItem9,
            this.Mexit});
            this.menuItemFile.Text = "�ļ�";
            // 
            // Mnew
            // 
            this.Mnew.Index = 0;
            this.Mnew.Text = "�½�";
            this.Mnew.Click += new System.EventHandler(this.Mnew_Click);
            // 
            // MOpen
            // 
            this.MOpen.Index = 1;
            this.MOpen.Text = "��";
            this.MOpen.Click += new System.EventHandler(this.MOpen_Click);
            // 
            // Msave
            // 
            this.Msave.Index = 2;
            this.Msave.Text = "����";
            this.Msave.Click += new System.EventHandler(this.Msave_Click);
            // 
            // MSaveas
            // 
            this.MSaveas.Index = 3;
            this.MSaveas.Text = "���Ϊ";
            this.MSaveas.Click += new System.EventHandler(this.MSaveas_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // Mprint
            // 
            this.Mprint.Index = 6;
            this.Mprint.Text = "��ӡ";
            this.Mprint.Click += new System.EventHandler(this.Mprint_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 7;
            this.menuItem9.Text = "-";
            // 
            // Mexit
            // 
            this.Mexit.Index = 8;
            this.Mexit.Text = "�˳�";
            this.Mexit.Click += new System.EventHandler(this.Mexit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Mundo,
            this.menuItem13,
            this.Mcut,
            this.Mcopy,
            this.Mpaste,
            this.Mdelete,
            this.menuItem18,
            this.Mselectall,
            this.Maddtime});
            this.menuItemEdit.Text = "�༭";
            // 
            // Mundo
            // 
            this.Mundo.Index = 0;
            this.Mundo.Text = "����";
            this.Mundo.Click += new System.EventHandler(this.Mundo_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Text = "-";
            // 
            // Mcut
            // 
            this.Mcut.Enabled = false;
            this.Mcut.Index = 2;
            this.Mcut.Text = "����";
            this.Mcut.Click += new System.EventHandler(this.Mcut_Click);
            // 
            // Mcopy
            // 
            this.Mcopy.Enabled = false;
            this.Mcopy.Index = 3;
            this.Mcopy.Text = "����";
            this.Mcopy.Click += new System.EventHandler(this.Mcopy_Click);
            // 
            // Mpaste
            // 
            this.Mpaste.Index = 4;
            this.Mpaste.Text = "ճ��";
            this.Mpaste.Click += new System.EventHandler(this.Mpaste_Click);
            // 
            // Mdelete
            // 
            this.Mdelete.Enabled = false;
            this.Mdelete.Index = 5;
            this.Mdelete.Text = "ɾ��";
            this.Mdelete.Click += new System.EventHandler(this.Mdelete_Click);
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 6;
            this.menuItem18.Text = "-";
            // 
            // Mselectall
            // 
            this.Mselectall.Index = 7;
            this.Mselectall.Text = "ȫѡ";
            this.Mselectall.Click += new System.EventHandler(this.Mselectall_Click);
            // 
            // Maddtime
            // 
            this.Maddtime.Index = 8;
            this.Maddtime.Text = "ʱ��/����   &F5";
            this.Maddtime.Click += new System.EventHandler(this.Maddtime_Click);
            // 
            // menuItemGeshi
            // 
            this.menuItemGeshi.Index = 2;
            this.menuItemGeshi.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Mwrap,
            this.Mfont});
            this.menuItemGeshi.Text = "��ʽ";
            // 
            // Mwrap
            // 
            this.Mwrap.Checked = true;
            this.Mwrap.Index = 0;
            this.Mwrap.Text = "�Զ�����";
            this.Mwrap.Click += new System.EventHandler(this.Mwrap_Click);
            // 
            // Mfont
            // 
            this.Mfont.Index = 1;
            this.Mfont.Text = "����";
            this.Mfont.Click += new System.EventHandler(this.Mfont_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 3;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Mabout});
            this.menuItemHelp.Text = "����";
            // 
            // Mabout
            // 
            this.Mabout.Index = 0;
            this.Mabout.Text = "����";
            this.Mabout.Click += new System.EventHandler(this.Mabout_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "*.cs;*.txt|*.*";
            this.saveFileDialog1.Title = "����Ϊ";
            // 
            // richtb
            // 
            this.richtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtb.Location = new System.Drawing.Point(0, 0);
            this.richtb.Name = "richtb";
            this.richtb.Size = new System.Drawing.Size(543, 465);
            this.richtb.TabIndex = 0;
            this.richtb.Text = "";
            this.richtb.SelectionChanged += new System.EventHandler(this.richtb_SelectionChanged);
            // 
            // Mpageset
            // 
            this.Mpageset.Index = 5;
            this.Mpageset.Text = "ҳ������";
            this.Mpageset.Click += new System.EventHandler(this.Mpageset_Click);
            // 
            // Notepad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(543, 465);
            this.Controls.Add(this.richtb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Notepad";
            this.Text = "MyPlayer-���±�";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
			
		static void Main() 
		{
			Application.Run(new Notepad());
		}


		private void Mexit_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("��ȷ��Ҫ�˳���","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) 
			{

				this.Close();
			}
		}
        //�½�
		private void Mnew_Click(object sender, System.EventArgs e)
		{
			
			richtb.Text="";


		}
        //��
		private void MOpen_Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog()==DialogResult.OK)
			{
				StreamReader sr=new StreamReader(openFileDialog1.FileName,System.Text.Encoding.Default);
				richtb.Text=sr.ReadToEnd();
				sr.Close();
			}

		}
        //����
		private void Msave_Click(object sender, System.EventArgs e)
		{
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				StreamWriter sw=new StreamWriter(saveFileDialog1.FileName);
				sw.Write(richtb.Text);
				sw.Close();
				
			}
		}
        //���Ϊ
		private void MSaveas_Click(object sender, System.EventArgs e)
		{
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				StreamWriter sw=new StreamWriter(saveFileDialog1.FileName);
				sw.Write(richtb.Text);
				sw.Close();
				
			}
		}

		private void Mcut_Click(object sender, System.EventArgs e)
		{
			richtb.Cut();
		}
        //����
		private void Mcopy_Click(object sender, System.EventArgs e)
		{
			richtb.Copy();
		}
        //���
		private void Mpaste_Click(object sender, System.EventArgs e)
		{
			richtb.Paste();
		}
        //ȫѡ
		private void Mselectall_Click(object sender, System.EventArgs e)
		{
			richtb.SelectAll();
		}
        //ʱ�������
		private void Maddtime_Click(object sender, System.EventArgs e)
		{
			DateTime dt=DateTime.Now;
			
			richtb.AppendText(dt.ToString());
		}
        //�Զ�����
		private void Mwrap_Click(object sender, System.EventArgs e)
		{
			Mwrap.Checked=!Mwrap.Checked;
			if (Mwrap.Checked==true)
			{
				richtb.WordWrap=true;
			}
			else
				richtb.WordWrap=false;

		}
        //����
		private void Mfont_Click(object sender, System.EventArgs e)
		{
			if(fontDialog1.ShowDialog()==DialogResult.OK)
			{
				richtb.SelectionFont=fontDialog1.Font;
			}

		}


        //����
		private void Mundo_Click(object sender, System.EventArgs e)
		{
			richtb.Undo();
		}

		private void Mdelete_Click(object sender, System.EventArgs e)
		{
			if(richtb.SelectedText!="")
			{
				richtb.SelectedText="";
			}
		}

		private void richtb_SelectionChanged(object sender, System.EventArgs e)
		{
			if(richtb.SelectedText!="")
			{
				Mcut.Enabled=true;
				Mcopy.Enabled=true;
				Mdelete.Enabled=true;
			}
			else
			{
				Mcut.Enabled=false;
				Mcopy.Enabled=false;
				Mdelete.Enabled=false;
			}

		}
        //���ڽ���
        private void Mabout_Click(object sender, EventArgs e)
        {
            About about = new About();

        }
        //ҳ������
        private void Mpageset_Click(object sender, EventArgs e)
        {

        }
        //��ӡ
        private void Mprint_Click(object sender, EventArgs e)
        {

        }
	}
}
