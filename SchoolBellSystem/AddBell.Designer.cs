namespace SchoolBellSystem
{
    partial class AddBell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBell));
            this.label1 = new System.Windows.Forms.Label();
            this.BellName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeM = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeS = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Day = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Volume = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Sound = new System.Windows.Forms.ListBox();
            this.Delete = new System.Windows.Forms.Button();
            this.AddModify = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Listen = new System.Windows.Forms.Button();
            this.AxWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.Useful = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimeM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // BellName
            // 
            this.BellName.Location = new System.Drawing.Point(89, 7);
            this.BellName.MaxLength = 20;
            this.BellName.Name = "BellName";
            this.BellName.Size = new System.Drawing.Size(120, 21);
            this.BellName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "时间：";
            // 
            // TimeM
            // 
            this.TimeM.Location = new System.Drawing.Point(89, 33);
            this.TimeM.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.TimeM.Name = "TimeM";
            this.TimeM.Size = new System.Drawing.Size(36, 21);
            this.TimeM.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "时";
            // 
            // TimeS
            // 
            this.TimeS.Location = new System.Drawing.Point(153, 33);
            this.TimeS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.TimeS.Name = "TimeS";
            this.TimeS.Size = new System.Drawing.Size(36, 21);
            this.TimeS.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "重复：";
            // 
            // Day
            // 
            this.Day.FormattingEnabled = true;
            this.Day.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.Day.Location = new System.Drawing.Point(89, 61);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(120, 116);
            this.Day.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "音量：";
            // 
            // Volume
            // 
            this.Volume.Location = new System.Drawing.Point(89, 304);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(47, 21);
            this.Volume.TabIndex = 7;
            this.Volume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "铃声：";
            // 
            // Sound
            // 
            this.Sound.FormattingEnabled = true;
            this.Sound.ItemHeight = 12;
            this.Sound.Items.AddRange(new object[] {
            "s1.mp3",
            "s2.mp3",
            "s3.mp3",
            "s4.mp3"});
            this.Sound.Location = new System.Drawing.Point(89, 204);
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(120, 76);
            this.Sound.TabIndex = 5;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Location = new System.Drawing.Point(26, 352);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(70, 30);
            this.Delete.TabIndex = 10;
            this.Delete.Text = "删除";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // AddModify
            // 
            this.AddModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AddModify.Location = new System.Drawing.Point(175, 352);
            this.AddModify.Name = "AddModify";
            this.AddModify.Size = new System.Drawing.Size(70, 30);
            this.AddModify.TabIndex = 9;
            this.AddModify.Text = "增加";
            this.AddModify.UseVisualStyleBackColor = false;
            this.AddModify.Click += new System.EventHandler(this.AddModify_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "启用：";
            // 
            // Listen
            // 
            this.Listen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Listen.Location = new System.Drawing.Point(36, 219);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(47, 23);
            this.Listen.TabIndex = 6;
            this.Listen.Text = "试听";
            this.Listen.UseVisualStyleBackColor = false;
            this.Listen.Click += new System.EventHandler(this.Listen_Click);
            // 
            // AxWindowsMediaPlayer
            // 
            this.AxWindowsMediaPlayer.Enabled = true;
            this.AxWindowsMediaPlayer.Location = new System.Drawing.Point(2, 1);
            this.AxWindowsMediaPlayer.Name = "AxWindowsMediaPlayer";
            this.AxWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWindowsMediaPlayer.OcxState")));
            this.AxWindowsMediaPlayer.Size = new System.Drawing.Size(8, 8);
            this.AxWindowsMediaPlayer.TabIndex = 20;
            this.AxWindowsMediaPlayer.Visible = false;
            // 
            // Useful
            // 
            this.Useful.AutoSize = true;
            this.Useful.Location = new System.Drawing.Point(89, 331);
            this.Useful.Name = "Useful";
            this.Useful.Size = new System.Drawing.Size(48, 16);
            this.Useful.TabIndex = 8;
            this.Useful.Text = "启用";
            this.Useful.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label9.Location = new System.Drawing.Point(87, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "不选则只响一次";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label10.Location = new System.Drawing.Point(87, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "铃声放安装目录的Sound文件夹";
            // 
            // AddBell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 387);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Useful);
            this.Controls.Add(this.AxWindowsMediaPlayer);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddModify);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Sound);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BellName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBell";
            this.Text = "增/改铃声";
            this.Load += new System.EventHandler(this.AddBell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BellName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TimeM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TimeS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox Day;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Volume;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox Sound;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button AddModify;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Listen;
        private AxWMPLib.AxWindowsMediaPlayer AxWindowsMediaPlayer;
        private System.Windows.Forms.CheckBox Useful;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}