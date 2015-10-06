namespace MediaPlayer
{
    partial class MiniFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniFrm));
            this.panel12 = new System.Windows.Forms.Panel();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.BackgroundImage = global::MediaPlayer.Properties.Resources.bback;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel12.Controls.Add(this.picSound);
            this.panel12.Location = new System.Drawing.Point(12, 64);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(100, 10);
            this.panel12.TabIndex = 64;
            // 
            // picSound
            // 
            this.picSound.Image = global::MediaPlayer.Properties.Resources.soundbar;
            this.picSound.Location = new System.Drawing.Point(27, -3);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(12, 13);
            this.picSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSound.TabIndex = 1;
            this.picSound.TabStop = false;
            this.picSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSound_MouseDown);
            this.picSound.MouseLeave += new System.EventHandler(this.picSound_MouseLeave);
            this.picSound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSound_MouseMove);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.BackgroundImage = global::MediaPlayer.Properties.Resources.Wplay;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlay.CausesValidation = false;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(113, 29);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(20, 20);
            this.btnPlay.TabIndex = 69;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSound
            // 
            this.btnSound.BackColor = System.Drawing.Color.Transparent;
            this.btnSound.BackgroundImage = global::MediaPlayer.Properties.Resources.MbtnSound;
            this.btnSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSound.FlatAppearance.BorderSize = 0;
            this.btnSound.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Location = new System.Drawing.Point(11, 17);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(30, 30);
            this.btnSound.TabIndex = 72;
            this.btnSound.UseVisualStyleBackColor = false;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            this.btnSound.MouseEnter += new System.EventHandler(this.btnSound_MouseEnter);
            this.btnSound.MouseLeave += new System.EventHandler(this.btnSound_MouseLeave);
            // 
            // btnPre
            // 
            this.btnPre.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPre.BackColor = System.Drawing.Color.Transparent;
            this.btnPre.BackgroundImage = global::MediaPlayer.Properties.Resources.WBack;
            this.btnPre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPre.FlatAppearance.BorderSize = 0;
            this.btnPre.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPre.Location = new System.Drawing.Point(90, 13);
            this.btnPre.Margin = new System.Windows.Forms.Padding(0);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(20, 20);
            this.btnPre.TabIndex = 70;
            this.btnPre.UseVisualStyleBackColor = false;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = global::MediaPlayer.Properties.Resources.WNext;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(140, 35);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(20, 20);
            this.btnNext.TabIndex = 71;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.Transparent;
            this.btnNormal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNormal.BackgroundImage")));
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Location = new System.Drawing.Point(136, 7);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(18, 18);
            this.btnNormal.TabIndex = 73;
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // MiniFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::MediaPlayer.Properties.Resources.KittyM;
            this.ClientSize = new System.Drawing.Size(170, 145);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSound);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panel12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MiniFrm";
            this.Text = "MiniFrm";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.MiniFrm_Load);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel12;
        public System.Windows.Forms.PictureBox picSound;
        public System.Windows.Forms.Button btnPlay;
        public System.Windows.Forms.Button btnSound;
        public System.Windows.Forms.Button btnPre;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnNormal;
    }
}