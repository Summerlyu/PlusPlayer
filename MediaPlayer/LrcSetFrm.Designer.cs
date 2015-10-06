namespace MediaPlayer
{
    partial class LrcSetFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LrcSetFrm));
            this.font = new System.Windows.Forms.FontDialog();
            this.normal = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpenLrcFile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labNormal = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cboTopmost = new System.Windows.Forms.CheckBox();
            this.cboFrmKana = new System.Windows.Forms.CheckBox();
            this.labBack = new System.Windows.Forms.Label();
            this.labLight = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLight = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cboBackColor = new System.Windows.Forms.CheckBox();
            this.cboDeskKank = new System.Windows.Forms.CheckBox();
            this.lblDeskBack = new System.Windows.Forms.Label();
            this.lblNormal = new System.Windows.Forms.Label();
            this.lblDeskLight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeskBack = new System.Windows.Forms.Button();
            this.btnDeskLight = new System.Windows.Forms.Button();
            this.btnDeskNormal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeskFont = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnOpenLrc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnmin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // normal
            // 
            this.normal.AnyColor = true;
            this.normal.FullOpen = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(410, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 23);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "退出";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpenLrcFile
            // 
            this.btnOpenLrcFile.Location = new System.Drawing.Point(262, 45);
            this.btnOpenLrcFile.Name = "btnOpenLrcFile";
            this.btnOpenLrcFile.Size = new System.Drawing.Size(43, 23);
            this.btnOpenLrcFile.TabIndex = 65;
            this.btnOpenLrcFile.Text = "打开";
            this.btnOpenLrcFile.UseVisualStyleBackColor = true;
            this.btnOpenLrcFile.Click += new System.EventHandler(this.btnOpenLrcFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(4, 82);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(489, 200);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.labNormal);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.cboTopmost);
            this.tabPage1.Controls.Add(this.cboFrmKana);
            this.tabPage1.Controls.Add(this.labBack);
            this.tabPage1.Controls.Add(this.labLight);
            this.tabPage1.Controls.Add(this.btnBack);
            this.tabPage1.Controls.Add(this.btnLight);
            this.tabPage1.Controls.Add(this.btnNormal);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnFont);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(481, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "窗体歌词";
            // 
            // labNormal
            // 
            this.labNormal.AutoSize = true;
            this.labNormal.BackColor = System.Drawing.Color.Yellow;
            this.labNormal.Location = new System.Drawing.Point(114, 107);
            this.labNormal.Name = "labNormal";
            this.labNormal.Size = new System.Drawing.Size(11, 12);
            this.labNormal.TabIndex = 64;
            this.labNormal.Text = " ";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(359, 36);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 63;
            this.checkBox2.Text = "背景透明";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // cboTopmost
            // 
            this.cboTopmost.AutoSize = true;
            this.cboTopmost.Location = new System.Drawing.Point(278, 36);
            this.cboTopmost.Name = "cboTopmost";
            this.cboTopmost.Size = new System.Drawing.Size(60, 16);
            this.cboTopmost.TabIndex = 63;
            this.cboTopmost.Text = "最顶端";
            this.cboTopmost.UseVisualStyleBackColor = true;
            this.cboTopmost.CheckedChanged += new System.EventHandler(this.cboTopmost_CheckedChanged);
            // 
            // cboFrmKana
            // 
            this.cboFrmKana.AutoSize = true;
            this.cboFrmKana.Location = new System.Drawing.Point(202, 36);
            this.cboFrmKana.Name = "cboFrmKana";
            this.cboFrmKana.Size = new System.Drawing.Size(60, 16);
            this.cboFrmKana.TabIndex = 63;
            this.cboFrmKana.Text = "卡拉OK";
            this.cboFrmKana.UseVisualStyleBackColor = true;
            this.cboFrmKana.CheckedChanged += new System.EventHandler(this.cboFrmKana_CheckedChanged);
            // 
            // labBack
            // 
            this.labBack.AutoSize = true;
            this.labBack.BackColor = System.Drawing.SystemColors.ControlText;
            this.labBack.Location = new System.Drawing.Point(305, 108);
            this.labBack.Name = "labBack";
            this.labBack.Size = new System.Drawing.Size(11, 12);
            this.labBack.TabIndex = 48;
            this.labBack.Text = " ";
            // 
            // labLight
            // 
            this.labLight.AutoSize = true;
            this.labLight.BackColor = System.Drawing.Color.Yellow;
            this.labLight.Location = new System.Drawing.Point(211, 109);
            this.labLight.Name = "labLight";
            this.labLight.Size = new System.Drawing.Size(11, 12);
            this.labLight.TabIndex = 47;
            this.labLight.Text = " ";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(298, 103);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 23);
            this.btnBack.TabIndex = 45;
            this.btnBack.Text = "背景";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLight
            // 
            this.btnLight.Location = new System.Drawing.Point(202, 103);
            this.btnLight.Name = "btnLight";
            this.btnLight.Size = new System.Drawing.Size(56, 23);
            this.btnLight.TabIndex = 44;
            this.btnLight.Text = "加亮";
            this.btnLight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLight.UseVisualStyleBackColor = true;
            this.btnLight.Click += new System.EventHandler(this.btnLight_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(106, 102);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(56, 23);
            this.btnNormal.TabIndex = 43;
            this.btnNormal.Text = "普通";
            this.btnNormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "颜    色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "字    体";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(106, 32);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(56, 23);
            this.btnFont.TabIndex = 40;
            this.btnFont.Text = "选择";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.cboBackColor);
            this.tabPage2.Controls.Add(this.cboDeskKank);
            this.tabPage2.Controls.Add(this.lblDeskBack);
            this.tabPage2.Controls.Add(this.lblNormal);
            this.tabPage2.Controls.Add(this.lblDeskLight);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnDeskBack);
            this.tabPage2.Controls.Add(this.btnDeskLight);
            this.tabPage2.Controls.Add(this.btnDeskNormal);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btnDeskFont);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(481, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "桌面歌词";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "单行显示",
            "双行显示"});
            this.comboBox1.Location = new System.Drawing.Point(85, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 63;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cboBackColor
            // 
            this.cboBackColor.AutoSize = true;
            this.cboBackColor.Checked = true;
            this.cboBackColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboBackColor.Location = new System.Drawing.Point(250, 25);
            this.cboBackColor.Name = "cboBackColor";
            this.cboBackColor.Size = new System.Drawing.Size(72, 16);
            this.cboBackColor.TabIndex = 62;
            this.cboBackColor.Text = "背景透明";
            this.cboBackColor.UseVisualStyleBackColor = true;
            this.cboBackColor.CheckedChanged += new System.EventHandler(this.cboBackColor_CheckedChanged);
            // 
            // cboDeskKank
            // 
            this.cboDeskKank.AutoSize = true;
            this.cboDeskKank.Checked = true;
            this.cboDeskKank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboDeskKank.Location = new System.Drawing.Point(172, 25);
            this.cboDeskKank.Name = "cboDeskKank";
            this.cboDeskKank.Size = new System.Drawing.Size(60, 16);
            this.cboDeskKank.TabIndex = 62;
            this.cboDeskKank.Text = "卡拉OK";
            this.cboDeskKank.UseVisualStyleBackColor = true;
            this.cboDeskKank.CheckedChanged += new System.EventHandler(this.cboDeskKank_CheckedChanged);
            // 
            // lblDeskBack
            // 
            this.lblDeskBack.AutoSize = true;
            this.lblDeskBack.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblDeskBack.Location = new System.Drawing.Point(259, 67);
            this.lblDeskBack.Name = "lblDeskBack";
            this.lblDeskBack.Size = new System.Drawing.Size(11, 12);
            this.lblDeskBack.TabIndex = 59;
            this.lblDeskBack.Text = " ";
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.BackColor = System.Drawing.Color.Yellow;
            this.lblNormal.Location = new System.Drawing.Point(96, 67);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(11, 12);
            this.lblNormal.TabIndex = 58;
            this.lblNormal.Text = " ";
            // 
            // lblDeskLight
            // 
            this.lblDeskLight.AutoSize = true;
            this.lblDeskLight.BackColor = System.Drawing.Color.Yellow;
            this.lblDeskLight.Location = new System.Drawing.Point(180, 67);
            this.lblDeskLight.Name = "lblDeskLight";
            this.lblDeskLight.Size = new System.Drawing.Size(11, 12);
            this.lblDeskLight.TabIndex = 58;
            this.lblDeskLight.Text = " ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(84, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 12);
            this.label7.TabIndex = 57;
            // 
            // btnDeskBack
            // 
            this.btnDeskBack.Location = new System.Drawing.Point(250, 62);
            this.btnDeskBack.Name = "btnDeskBack";
            this.btnDeskBack.Size = new System.Drawing.Size(56, 23);
            this.btnDeskBack.TabIndex = 56;
            this.btnDeskBack.Text = "背景";
            this.btnDeskBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeskBack.UseVisualStyleBackColor = true;
            this.btnDeskBack.Click += new System.EventHandler(this.btnDeskBack_Click);
            // 
            // btnDeskLight
            // 
            this.btnDeskLight.Location = new System.Drawing.Point(172, 62);
            this.btnDeskLight.Name = "btnDeskLight";
            this.btnDeskLight.Size = new System.Drawing.Size(56, 23);
            this.btnDeskLight.TabIndex = 55;
            this.btnDeskLight.Text = "加亮";
            this.btnDeskLight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeskLight.UseVisualStyleBackColor = true;
            this.btnDeskLight.Click += new System.EventHandler(this.btnDeskLight_Click);
            // 
            // btnDeskNormal
            // 
            this.btnDeskNormal.Location = new System.Drawing.Point(87, 62);
            this.btnDeskNormal.Name = "btnDeskNormal";
            this.btnDeskNormal.Size = new System.Drawing.Size(56, 23);
            this.btnDeskNormal.TabIndex = 54;
            this.btnDeskNormal.Text = "普通";
            this.btnDeskNormal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeskNormal.UseVisualStyleBackColor = true;
            this.btnDeskNormal.Click += new System.EventHandler(this.btnDeskNormal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 53;
            this.label5.Text = "显示方式:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "颜    色:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "字    体:";
            // 
            // btnDeskFont
            // 
            this.btnDeskFont.Location = new System.Drawing.Point(85, 18);
            this.btnDeskFont.Name = "btnDeskFont";
            this.btnDeskFont.Size = new System.Drawing.Size(56, 23);
            this.btnDeskFont.TabIndex = 51;
            this.btnDeskFont.Text = "选择";
            this.btnDeskFont.UseVisualStyleBackColor = true;
            this.btnDeskFont.Click += new System.EventHandler(this.btnDeskFont_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(373, 18);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(45, 23);
            this.btnDel.TabIndex = 65;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnOpenLrc
            // 
            this.btnOpenLrc.Location = new System.Drawing.Point(262, 16);
            this.btnOpenLrc.Name = "btnOpenLrc";
            this.btnOpenLrc.Size = new System.Drawing.Size(43, 23);
            this.btnOpenLrc.TabIndex = 65;
            this.btnOpenLrc.Text = "打开";
            this.btnOpenLrc.UseVisualStyleBackColor = true;
            this.btnOpenLrc.Click += new System.EventHandler(this.btnOpenLrc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "歌词路径";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "指定文件夹";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(94, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(162, 21);
            this.txtPath.TabIndex = 37;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(162, 21);
            this.textBox1.TabIndex = 36;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(311, 16);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 23);
            this.btnOpen.TabIndex = 39;
            this.btnOpen.Text = "浏览...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(311, 45);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(56, 23);
            this.btnFile.TabIndex = 38;
            this.btnFile.Text = "浏览...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnOpenLrcFile);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnFile);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnOpenLrc);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 318);
            this.panel1.TabIndex = 70;
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
            this.btnmin.Location = new System.Drawing.Point(437, 6);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(18, 18);
            this.btnmin.TabIndex = 69;
            this.btnmin.UseVisualStyleBackColor = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
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
            this.btnClose.Location = new System.Drawing.Point(474, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(18, 18);
            this.btnClose.TabIndex = 67;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LrcSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LrcSetFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LrcSetFrm_FormClosing);
            this.Load += new System.EventHandler(this.LrcSetFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog font;
        private System.Windows.Forms.ColorDialog normal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpenLrcFile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labNormal;
        private System.Windows.Forms.CheckBox cboFrmKana;
        private System.Windows.Forms.Label labBack;
        private System.Windows.Forms.Label labLight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLight;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cboBackColor;
        private System.Windows.Forms.CheckBox cboDeskKank;
        private System.Windows.Forms.Label lblDeskBack;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblDeskLight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeskBack;
        private System.Windows.Forms.Button btnDeskLight;
        private System.Windows.Forms.Button btnDeskNormal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDeskFont;
        private System.Windows.Forms.Button btnOpenLrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox cboTopmost;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
    }
}