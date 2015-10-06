namespace MediaPlayer
{
    partial class LrcPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tsmiSetBgImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiKanaOK = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSimpleToTra = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiTraToSimple = new System.Windows.Forms.ToolStripMenuItem();
            this.dfsdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平铺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.居中ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.拉伸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放大ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左对齐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景色透明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lrcSetFrm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.显示桌面歌词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullScreenShow = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsmiSetBgImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiSetBgImage
            // 
            this.tsmiSetBgImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKanaOK,
            this.toolStripMenuItem2,
            this.dfsdfToolStripMenuItem,
            this.lrcSetFrm,
            this.toolStripSeparator1,
            this.显示桌面歌词ToolStripMenuItem,
            this.FullScreenShow});
            this.tsmiSetBgImage.Name = "contextMenuStrip1";
            this.tsmiSetBgImage.Size = new System.Drawing.Size(196, 142);
            this.tsmiSetBgImage.Text = "设置背景图片";
            // 
            // tsmiKanaOK
            // 
            this.tsmiKanaOK.Name = "tsmiKanaOK";
            this.tsmiKanaOK.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.tsmiKanaOK.Size = new System.Drawing.Size(195, 22);
            this.tsmiKanaOK.Text = "卡拉OK";
            this.tsmiKanaOK.Click += new System.EventHandler(this.tsmiKanaOK_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSimpleToTra,
            this.tmsiTraToSimple});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem2.Text = "繁简转换";
            // 
            // tsmiSimpleToTra
            // 
            this.tsmiSimpleToTra.Name = "tsmiSimpleToTra";
            this.tsmiSimpleToTra.Size = new System.Drawing.Size(152, 22);
            this.tsmiSimpleToTra.Text = "简体-->繁体";
            this.tsmiSimpleToTra.Click += new System.EventHandler(this.tsmiSimpleToTra_Click);
            // 
            // tmsiTraToSimple
            // 
            this.tmsiTraToSimple.Name = "tmsiTraToSimple";
            this.tmsiTraToSimple.Size = new System.Drawing.Size(152, 22);
            this.tmsiTraToSimple.Text = "繁体-->简体";
            this.tmsiTraToSimple.Click += new System.EventHandler(this.tmsiTraToSimple_Click);
            // 
            // dfsdfToolStripMenuItem
            // 
            this.dfsdfToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择ToolStripMenuItem,
            this.显示方式ToolStripMenuItem,
            this.取消ToolStripMenuItem,
            this.背景色透明ToolStripMenuItem});
            this.dfsdfToolStripMenuItem.Name = "dfsdfToolStripMenuItem";
            this.dfsdfToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dfsdfToolStripMenuItem.Text = "设置背景图片";
            // 
            // 选择ToolStripMenuItem
            // 
            this.选择ToolStripMenuItem.Name = "选择ToolStripMenuItem";
            this.选择ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.选择ToolStripMenuItem.Text = "选择";
            this.选择ToolStripMenuItem.Click += new System.EventHandler(this.选择ToolStripMenuItem_Click);
            // 
            // 显示方式ToolStripMenuItem
            // 
            this.显示方式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.平铺ToolStripMenuItem,
            this.居中ToolStripMenuItem,
            this.拉伸ToolStripMenuItem,
            this.放大ToolStripMenuItem,
            this.左对齐ToolStripMenuItem});
            this.显示方式ToolStripMenuItem.Name = "显示方式ToolStripMenuItem";
            this.显示方式ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.显示方式ToolStripMenuItem.Text = "显示方式";
            // 
            // 平铺ToolStripMenuItem
            // 
            this.平铺ToolStripMenuItem.Name = "平铺ToolStripMenuItem";
            this.平铺ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.平铺ToolStripMenuItem.Text = "平铺";
            this.平铺ToolStripMenuItem.Click += new System.EventHandler(this.平铺ToolStripMenuItem_Click);
            // 
            // 居中ToolStripMenuItem
            // 
            this.居中ToolStripMenuItem.Name = "居中ToolStripMenuItem";
            this.居中ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.居中ToolStripMenuItem.Text = "居中";
            this.居中ToolStripMenuItem.Click += new System.EventHandler(this.居中ToolStripMenuItem_Click);
            // 
            // 拉伸ToolStripMenuItem
            // 
            this.拉伸ToolStripMenuItem.Name = "拉伸ToolStripMenuItem";
            this.拉伸ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.拉伸ToolStripMenuItem.Text = "拉伸";
            this.拉伸ToolStripMenuItem.Click += new System.EventHandler(this.拉伸ToolStripMenuItem_Click);
            // 
            // 放大ToolStripMenuItem
            // 
            this.放大ToolStripMenuItem.Name = "放大ToolStripMenuItem";
            this.放大ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.放大ToolStripMenuItem.Text = "放大";
            this.放大ToolStripMenuItem.Click += new System.EventHandler(this.放大ToolStripMenuItem_Click);
            // 
            // 左对齐ToolStripMenuItem
            // 
            this.左对齐ToolStripMenuItem.Name = "左对齐ToolStripMenuItem";
            this.左对齐ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.左对齐ToolStripMenuItem.Text = "左对齐";
            this.左对齐ToolStripMenuItem.Click += new System.EventHandler(this.左对齐ToolStripMenuItem_Click);
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.取消ToolStripMenuItem.Text = "取消";
            this.取消ToolStripMenuItem.Click += new System.EventHandler(this.取消ToolStripMenuItem_Click);
            // 
            // 背景色透明ToolStripMenuItem
            // 
            this.背景色透明ToolStripMenuItem.Name = "背景色透明ToolStripMenuItem";
            this.背景色透明ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.背景色透明ToolStripMenuItem.Text = "背景色透明";
            this.背景色透明ToolStripMenuItem.Click += new System.EventHandler(this.背景色透明ToolStripMenuItem_Click);
            // 
            // lrcSetFrm
            // 
            this.lrcSetFrm.Name = "lrcSetFrm";
            this.lrcSetFrm.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.lrcSetFrm.Size = new System.Drawing.Size(195, 22);
            this.lrcSetFrm.Text = "设置字体及颜色";
            this.lrcSetFrm.Click += new System.EventHandler(this.lrcSetFrm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // 显示桌面歌词ToolStripMenuItem
            // 
            this.显示桌面歌词ToolStripMenuItem.Name = "显示桌面歌词ToolStripMenuItem";
            this.显示桌面歌词ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.显示桌面歌词ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.显示桌面歌词ToolStripMenuItem.Text = "显示桌面歌词";
            this.显示桌面歌词ToolStripMenuItem.Click += new System.EventHandler(this.显示桌面歌词ToolStripMenuItem_Click);
            // 
            // FullScreenShow
            // 
            this.FullScreenShow.Name = "FullScreenShow";
            this.FullScreenShow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.FullScreenShow.Size = new System.Drawing.Size(195, 22);
            this.FullScreenShow.Text = "全屏显示";
            this.FullScreenShow.Click += new System.EventHandler(this.FullScreenShow_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LrcPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.tsmiSetBgImage;
            this.Name = "LrcPanel";
            this.Size = new System.Drawing.Size(260, 66);
            this.tsmiSetBgImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip tsmiSetBgImage;
        private System.Windows.Forms.ToolStripMenuItem tsmiKanaOK;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSimpleToTra;
        private System.Windows.Forms.ToolStripMenuItem tmsiTraToSimple;
        private System.Windows.Forms.ToolStripMenuItem lrcSetFrm;
        public System.Windows.Forms.ToolStripMenuItem FullScreenShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dfsdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平铺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 居中ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 拉伸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 放大ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左对齐ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景色透明ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 显示桌面歌词ToolStripMenuItem;
    }
}
