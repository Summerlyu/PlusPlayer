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
            System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LrcFrm));
            this.btnmin = new System.Windows.Forms.Button();
            this.btnmini = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lrcPanel1 = new MediaPlayer.LrcPanel();
            this.SuspendLayout();
            // 
            // btnmin
            // 
            this.btnmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmin.BackColor = System.Drawing.Color.Transparent;
            this.btnmin.FlatAppearance.BorderSize = 0;
            this.btnmin.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmin.Image = global::MediaPlayer.Properties.Resources.Wmin1;
            this.btnmin.Location = new System.Drawing.Point(328, 5);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(18, 18);
            this.btnmin.TabIndex = 14;
            this.btnmin.UseVisualStyleBackColor = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnmini
            // 
            this.btnmini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmini.BackColor = System.Drawing.Color.Transparent;
            this.btnmini.FlatAppearance.BorderSize = 0;
            this.btnmini.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnmini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnmini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnmini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmini.Image = global::MediaPlayer.Properties.Resources.Wmini;
            this.btnmini.Location = new System.Drawing.Point(352, 5);
            this.btnmini.Name = "btnmini";
            this.btnmini.Size = new System.Drawing.Size(18, 18);
            this.btnmini.TabIndex = 12;
            this.btnmini.UseVisualStyleBackColor = false;
            this.btnmini.Click += new System.EventHandler(this.btnmini_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::MediaPlayer.Properties.Resources.Wclose;
            this.btnClose.Location = new System.Drawing.Point(376, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lrcPanel1
            // 
            this.lrcPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lrcPanel1.BackColors = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(254)))));
            this.lrcPanel1.CurrentPosition = null;
            this.lrcPanel1.FontSty = new System.Drawing.Font("幼圆", 14F);
            this.lrcPanel1.Location = new System.Drawing.Point(4, 29);
            this.lrcPanel1.MinimumSize = new System.Drawing.Size(100, 20);
            this.lrcPanel1.Name = "lrcPanel1";
            this.lrcPanel1.Size = new System.Drawing.Size(392, 467);
            stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            this.lrcPanel1.StringFormatter = stringFormat1;
            this.lrcPanel1.TabIndex = 0;
            // 
            // LrcFrm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnmini);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lrcPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LrcFrm";
            this.ShowInTaskbar = false;
            this.Text = "MyPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LrcFrm_FormClosing);
            this.Load += new System.EventHandler(this.LrcFrm_Load);
            this.Resize += new System.EventHandler(this.LrcFrm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public LrcPanel lrcPanel1;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnmini;
        private System.Windows.Forms.Button btnClose;
    }
}