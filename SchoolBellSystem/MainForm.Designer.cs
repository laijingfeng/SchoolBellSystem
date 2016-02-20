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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
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
            this.AddBell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddBell.Location = new System.Drawing.Point(614, 218);
            this.AddBell.Name = "AddBell";
            this.AddBell.Size = new System.Drawing.Size(40, 32);
            this.AddBell.TabIndex = 1;
            this.AddBell.Text = "+";
            this.AddBell.UseVisualStyleBackColor = false;
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
            this.LabelCurDateTime.ForeColor = System.Drawing.Color.Blue;
            this.LabelCurDateTime.Location = new System.Drawing.Point(12, 228);
            this.LabelCurDateTime.Name = "LabelCurDateTime";
            this.LabelCurDateTime.Size = new System.Drawing.Size(71, 12);
            this.LabelCurDateTime.TabIndex = 4;
            this.LabelCurDateTime.Text = "CurDateTime";
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.Location = new System.Drawing.Point(14, 25);
            this.DGV.Name = "DGV";
            this.DGV.RowTemplate.Height = 23;
            this.DGV.Size = new System.Drawing.Size(640, 187);
            this.DGV.TabIndex = 5;
            this.DGV.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_RowHeaderMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "铃声列表(双击行头修改)：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGV);
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
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
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
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Label label1;

    }
}

