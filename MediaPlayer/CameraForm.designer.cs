namespace MediaPlayer
{
    partial class CameraForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //Download by http://www.codefans.net
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraForm));
            this.btnmin = new System.Windows.Forms.Button();
            this.btnmax = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelCamera = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnmin
            // 
            this.btnmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnmin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmin.BackgroundImage")));
            this.btnmin.Location = new System.Drawing.Point(152, 305);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(64, 26);
            this.btnmin.TabIndex = 17;
            this.btnmin.Text = "最小化";
            this.btnmin.UseVisualStyleBackColor = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnmax
            // 
            this.btnmax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmax.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnmax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmax.BackgroundImage")));
            this.btnmax.Location = new System.Drawing.Point(82, 305);
            this.btnmax.Name = "btnmax";
            this.btnmax.Size = new System.Drawing.Size(64, 26);
            this.btnmax.TabIndex = 16;
            this.btnmax.Text = "最大化";
            this.btnmax.UseVisualStyleBackColor = false;
            this.btnmax.Click += new System.EventHandler(this.btnmax_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclose.BackgroundImage")));
            this.btnclose.Location = new System.Drawing.Point(395, 302);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(64, 25);
            this.btnclose.TabIndex = 15;
            this.btnclose.Text = "退出";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenshot.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnScreenshot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScreenshot.BackgroundImage")));
            this.btnScreenshot.Location = new System.Drawing.Point(231, 305);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(64, 25);
            this.btnScreenshot.TabIndex = 14;
            this.btnScreenshot.Text = "截图";
            this.btnScreenshot.UseVisualStyleBackColor = false;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.Location = new System.Drawing.Point(301, 305);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 25);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.Location = new System.Drawing.Point(12, 304);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(64, 26);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelCamera
            // 
            this.panelCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCamera.BackColor = System.Drawing.Color.SlateBlue;
            this.panelCamera.BackgroundImage = global::MediaPlayer.Properties.Resources.CameraForm;
            this.panelCamera.Location = new System.Drawing.Point(-1, 1);
            this.panelCamera.Name = "panelCamera";
            this.panelCamera.Size = new System.Drawing.Size(473, 295);
            this.panelCamera.TabIndex = 11;
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(471, 356);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnmax);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnScreenshot);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panelCamera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameraForm";
            this.Text = "摄像机";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelCamera;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnmax;
        private System.Windows.Forms.Button btnmin;

    }
}

