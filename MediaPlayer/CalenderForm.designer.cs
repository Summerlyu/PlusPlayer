namespace MediaPlayer
{
    partial class CalenderForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAlter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTBAgenda = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewAgendaTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelHead = new System.Windows.Forms.Panel();
            this.btnmin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.latime = new System.Windows.Forms.Label();
            this.lbxingqi = new System.Windows.Forms.Label();
            this.lblyear = new System.Windows.Forms.Label();
            this.lblmonth = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.monthCalendar1);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnAlter);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.richTBAgenda);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.listViewAgendaTable);
            this.panel3.Location = new System.Drawing.Point(6, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(672, 448);
            this.panel3.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(325, 408);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("宋体", 11F);
            this.monthCalendar1.Location = new System.Drawing.Point(9, 9);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(221, 408);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(122, 408);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAlter
            // 
            this.btnAlter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlter.Location = new System.Drawing.Point(18, 408);
            this.btnAlter.Name = "btnAlter";
            this.btnAlter.Size = new System.Drawing.Size(75, 23);
            this.btnAlter.TabIndex = 5;
            this.btnAlter.Text = "修改";
            this.btnAlter.UseVisualStyleBackColor = true;
            this.btnAlter.Click += new System.EventHandler(this.btnAlter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "日程内容:";
            // 
            // richTBAgenda
            // 
            this.richTBAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTBAgenda.Location = new System.Drawing.Point(9, 223);
            this.richTBAgenda.Name = "richTBAgenda";
            this.richTBAgenda.Size = new System.Drawing.Size(648, 179);
            this.richTBAgenda.TabIndex = 3;
            this.richTBAgenda.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "日程表:";
            // 
            // listViewAgendaTable
            // 
            this.listViewAgendaTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAgendaTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewAgendaTable.FullRowSelect = true;
            this.listViewAgendaTable.GridLines = true;
            this.listViewAgendaTable.Location = new System.Drawing.Point(353, 24);
            this.listViewAgendaTable.Name = "listViewAgendaTable";
            this.listViewAgendaTable.Size = new System.Drawing.Size(304, 160);
            this.listViewAgendaTable.TabIndex = 1;
            this.listViewAgendaTable.UseCompatibleStateImageBehavior = false;
            this.listViewAgendaTable.View = System.Windows.Forms.View.Details;
            this.listViewAgendaTable.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日期";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "时间";
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "主题";
            this.columnHeader3.Width = 108;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelHead
            // 
            this.panelHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHead.BackgroundImage = global::MediaPlayer.Properties.Resources.GreenLeaf;
            this.panelHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHead.Controls.Add(this.btnmin);
            this.panelHead.Controls.Add(this.button1);
            this.panelHead.Controls.Add(this.latime);
            this.panelHead.Controls.Add(this.lbxingqi);
            this.panelHead.Controls.Add(this.lblyear);
            this.panelHead.Controls.Add(this.lblmonth);
            this.panelHead.Location = new System.Drawing.Point(6, 6);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(672, 57);
            this.panelHead.TabIndex = 3;
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
            this.btnmin.Location = new System.Drawing.Point(622, 3);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(18, 18);
            this.btnmin.TabIndex = 12;
            this.btnmin.UseVisualStyleBackColor = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::MediaPlayer.Properties.Resources.Wclose;
            this.button1.Location = new System.Drawing.Point(649, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(18, 18);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // latime
            // 
            this.latime.AutoSize = true;
            this.latime.BackColor = System.Drawing.Color.Transparent;
            this.latime.Font = new System.Drawing.Font("宋体", 30F);
            this.latime.ForeColor = System.Drawing.Color.White;
            this.latime.Location = new System.Drawing.Point(281, 7);
            this.latime.Name = "latime";
            this.latime.Size = new System.Drawing.Size(237, 40);
            this.latime.TabIndex = 3;
            this.latime.Text = "12:00:30 PM";
            // 
            // lbxingqi
            // 
            this.lbxingqi.AutoSize = true;
            this.lbxingqi.BackColor = System.Drawing.Color.Transparent;
            this.lbxingqi.Font = new System.Drawing.Font("华文新魏", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbxingqi.ForeColor = System.Drawing.Color.White;
            this.lbxingqi.Location = new System.Drawing.Point(136, 33);
            this.lbxingqi.Name = "lbxingqi";
            this.lbxingqi.Size = new System.Drawing.Size(70, 21);
            this.lbxingqi.TabIndex = 2;
            this.lbxingqi.Text = "星期日";
            this.lbxingqi.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblyear
            // 
            this.lblyear.AutoSize = true;
            this.lblyear.BackColor = System.Drawing.Color.Transparent;
            this.lblyear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblyear.Font = new System.Drawing.Font("宋体", 13F);
            this.lblyear.ForeColor = System.Drawing.Color.White;
            this.lblyear.Location = new System.Drawing.Point(114, 7);
            this.lblyear.Name = "lblyear";
            this.lblyear.Size = new System.Drawing.Size(107, 18);
            this.lblyear.TabIndex = 1;
            this.lblyear.Text = "12日 2010年";
            this.lblyear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblmonth
            // 
            this.lblmonth.AutoSize = true;
            this.lblmonth.BackColor = System.Drawing.Color.Transparent;
            this.lblmonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblmonth.Font = new System.Drawing.Font("宋体", 30F);
            this.lblmonth.ForeColor = System.Drawing.Color.White;
            this.lblmonth.Location = new System.Drawing.Point(23, 7);
            this.lblmonth.Name = "lblmonth";
            this.lblmonth.Size = new System.Drawing.Size(97, 40);
            this.lblmonth.TabIndex = 0;
            this.lblmonth.Text = "12月";
            this.lblmonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CalenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(193)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(685, 520);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalenderForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalenderForm_FormClosing);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Label lblmonth;
        private System.Windows.Forms.Label lblyear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbxingqi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTBAgenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewAgendaTable;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAlter;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label latime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button button1;

    }
}