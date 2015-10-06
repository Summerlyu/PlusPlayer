namespace MediaPlayer
{
    partial class LrcFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LrcFrm));
            this.lrcPanel1 = new MediaPlayer.LrcPanel();
            this.SuspendLayout();
            // 
            // lrcPanel1
            // 
            this.lrcPanel1.BackColors = System.Drawing.Color.Black;
            this.lrcPanel1.CurrentPosition = null;
            this.lrcPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lrcPanel1.FontSty = new System.Drawing.Font("幼圆", 14F);
            this.lrcPanel1.Location = new System.Drawing.Point(0, 0);
            this.lrcPanel1.MinimumSize = new System.Drawing.Size(100, 20);
            this.lrcPanel1.Name = "lrcPanel1";
            this.lrcPanel1.Size = new System.Drawing.Size(324, 324);
            stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            this.lrcPanel1.StringFormatter = stringFormat1;
            this.lrcPanel1.TabIndex = 0;
            // 
            // LrcFrm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(324, 324);
            this.Controls.Add(this.lrcPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LrcFrm";
            this.ShowInTaskbar = false;
            this.Text = "土豆歌词 V1.0.0";
            this.Load += new System.EventHandler(this.LrcFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LrcFrm_FormClosing);
            this.Resize += new System.EventHandler(this.LrcFrm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public LrcPanel lrcPanel1;
    }
}