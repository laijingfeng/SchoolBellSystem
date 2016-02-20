namespace SchoolBellSystem
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Eixt = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.AxWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.AddBell = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LabelCurDateTime = new System.Windows.Forms.Label();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.BackColor = System.Drawing.Color.Red;
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Show,
            this.MenuItem_Eixt});
            this.ContextMenuStrip.Name = "ContextMenuStrip";
            this.ContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // MenuItem_Show
            // 
            this.MenuItem_Show.Name = "MenuItem_Show";
            this.MenuItem_Show.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Show.Text = "显示";
            this.MenuItem_Show.Click += new System.EventHandler(this.MenuItem_Show_Click);
            // 
            // MenuItem_Eixt
            // 
            this.MenuItem_Eixt.Name = "MenuItem_Eixt";
            this.MenuItem_Eixt.Size = new System.Drawing.Size(100, 22);
            this.MenuItem_Eixt.Text = "退出";
            this.MenuItem_Eixt.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "校园铃声系统";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // AxWindowsMediaPlayer
            // 
            this.AxWindowsMediaPlayer.Enabled = true;
            this.AxWindowsMediaPlayer.Location = new System.Drawing.Point(-2, 0);
            this.AxWindowsMediaPlayer.Name = "AxWindowsMediaPlayer";
            this.AxWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWindowsMediaPlayer.OcxState")));
            this.AxWindowsMediaPlayer.Size = new System.Drawing.Size(10, 10);
            this.AxWindowsMediaPlayer.TabIndex = 1;
            this.AxWindowsMediaPlayer.Visible = false;
            // 
            // AddBell
            // 
            this.AddBell.Location = new System.Drawing.Point(50, 213);
            this.AddBell.Name = "AddBell";
            this.AddBell.Size = new System.Drawing.Size(40, 32);
            this.AddBell.TabIndex = 2;
            this.AddBell.Text = "+";
            this.AddBell.UseVisualStyleBackColor = true;
            this.AddBell.Click += new System.EventHandler(this.AddBell_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LabelCurDateTime
            // 
            this.LabelCurDateTime.AutoSize = true;
            this.LabelCurDateTime.Location = new System.Drawing.Point(54, 118);
            this.LabelCurDateTime.Name = "LabelCurDateTime";
            this.LabelCurDateTime.Size = new System.Drawing.Size(71, 12);
            this.LabelCurDateTime.TabIndex = 4;
            this.LabelCurDateTime.Text = "CurDateTime";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.LabelCurDateTime);
            this.Controls.Add(this.AddBell);
            this.Controls.Add(this.AxWindowsMediaPlayer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "校园铃声系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.ContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Show;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Eixt;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private AxWMPLib.AxWindowsMediaPlayer AxWindowsMediaPlayer;
        private System.Windows.Forms.Button AddBell;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LabelCurDateTime;

    }
}

