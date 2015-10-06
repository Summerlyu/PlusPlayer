namespace MediaPlayer
{
    partial class ZipCodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.province = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.zipcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.arecode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "省份：";
            // 
            // province
            // 
            this.province.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.province.FormattingEnabled = true;
            this.province.Location = new System.Drawing.Point(100, 25);
            this.province.Name = "province";
            this.province.Size = new System.Drawing.Size(113, 20);
            this.province.TabIndex = 1;
            this.province.Text = "北京";
            this.province.SelectedIndexChanged += new System.EventHandler(this.province_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "市、县：";
            // 
            // city
            // 
            this.city.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.city.FormattingEnabled = true;
            this.city.Location = new System.Drawing.Point(348, 21);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(121, 20);
            this.city.TabIndex = 3;
            this.city.Text = "北京";
            this.city.SelectedIndexChanged += new System.EventHandler(this.city_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "邮政编码：";
            // 
            // zipcode
            // 
            this.zipcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.zipcode.Location = new System.Drawing.Point(100, 75);
            this.zipcode.Name = "zipcode";
            this.zipcode.ReadOnly = true;
            this.zipcode.Size = new System.Drawing.Size(113, 21);
            this.zipcode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "长途区号：";
            // 
            // arecode
            // 
            this.arecode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.arecode.Location = new System.Drawing.Point(348, 72);
            this.arecode.Name = "arecode";
            this.arecode.ReadOnly = true;
            this.arecode.Size = new System.Drawing.Size(113, 21);
            this.arecode.TabIndex = 7;
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
            this.btnClose.Location = new System.Drawing.Point(464, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.city);
            this.panel1.Controls.Add(this.arecode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.zipcode);
            this.panel1.Controls.Add(this.province);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 121);
            this.panel1.TabIndex = 9;
            // 
            // ZipCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(489, 150);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ZipCodeForm";
            this.Text = "邮编/区号查询";
            this.Load += new System.EventHandler(this.ZipCodeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox province;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox city;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zipcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arecode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}