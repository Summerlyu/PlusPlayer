namespace MediaPlayer
{
    partial class DeskLrcFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskLrcFrm));
            this.deskLrcControl1 = new MediaPlayer.DeskLrcControl();
            this.SuspendLayout();
            // 
            // deskLrcControl1
            // 
            this.deskLrcControl1.BackColor = System.Drawing.Color.Black;
            this.deskLrcControl1.BackColors = System.Drawing.Color.Black;
            this.deskLrcControl1.CurrentPosition = null;
            this.deskLrcControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deskLrcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deskLrcControl1.FontSty = new System.Drawing.Font("幼圆", 34F);
            this.deskLrcControl1.Location = new System.Drawing.Point(0, 0);
            this.deskLrcControl1.MinimumSize = new System.Drawing.Size(200, 20);
            this.deskLrcControl1.Name = "deskLrcControl1";
            this.deskLrcControl1.Size = new System.Drawing.Size(492, 88);
            stringFormat1.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            this.deskLrcControl1.StringFormatter = stringFormat1;
            this.deskLrcControl1.TabIndex = 0;
            this.deskLrcControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.deskLrcControl1_MouseMove);
            this.deskLrcControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deskLrcControl1_MouseDown);
            // 
            // DeskLrcFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(492, 88);
            this.Controls.Add(this.deskLrcControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeskLrcFrm";
            this.ShowInTaskbar = false;
            this.Text = "土豆桌面歌词  V1.0.0";
            this.Load += new System.EventHandler(this.DeskLrcFrm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeskLrcFrm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public DeskLrcControl deskLrcControl1;





    }
}