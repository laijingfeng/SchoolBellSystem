using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SchoolBellSystem
{
    /// <summary>
    /// 增加铃声
    /// </summary>
    public partial class AddBell : Form
    {
        /// <summary>
        /// 要修改的ID
        /// </summary>
        public int modifyID = -1;

        public AddBell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取铃声名
        /// </summary>
        /// <returns></returns>
        private string[] GetBellFile()
        {
            List<string> list = new List<string>();
            string[] tmp = System.IO.Directory.GetFiles(MainForm.m_strSoundPath, "*.mp3");
            list.AddRange(tmp);

            tmp = System.IO.Directory.GetFiles(MainForm.m_strSoundPath, "*.wav");
            list.AddRange(tmp);

            tmp = System.IO.Directory.GetFiles(MainForm.m_strSoundPath, "*.wma");
            list.AddRange(tmp);

            tmp = System.IO.Directory.GetFiles(MainForm.m_strSoundPath, "*.midi");
            list.AddRange(tmp);

            tmp = System.IO.Directory.GetFiles(MainForm.m_strSoundPath, "*.mmf");
            list.AddRange(tmp);

            return list.ToArray();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBell_Load(object sender, EventArgs e)
        {
            Sound.Items.Clear();
            string[] strSound = GetBellFile();
            for (int i = 0, imax = strSound.Length; i < imax; i++)
            {
                Sound.Items.Add(strSound[i].Substring(strSound[i].LastIndexOf('\\') + 1));
            }

            if (modifyID == -1)
            {
                this.Text = "增加铃声";
                Delete.Visible = false;
                AddModify.Text = "增加";

                if (Sound.Items.Count > 0)
                {
                    Sound.SetSelected(0, true);
                }
                Useful.Checked = true;
            }
            else
            {
                this.Text = "修改铃声";
                Delete.Visible = true;
                AddModify.Text = "修改";

                Bell oldBell = MainForm.m_BellListMgr.GetBellByID(modifyID);

                if (oldBell != null)
                {
                    Volume.Value = oldBell.m_iBellVolume;

                    if (Sound.Items.Count > 0)
                    {
                        int idx = Sound.Items.IndexOf(oldBell.m_strSoundName);
                        if (idx < 0)
                        {
                            idx = 0;
                        }
                        Sound.SetSelected(idx, true);
                    }

                    string[] timeStr = oldBell.m_strRingTime.Split(':');
                    TimeM.Value = Convert.ToInt32(timeStr[0]);
                    TimeS.Value = Convert.ToInt32(timeStr[1]);

                    BellName.Text = oldBell.m_strBellName;

                    char[] ch = oldBell.m_strRingDay.ToCharArray();
                    Day.SelectedIndices.Clear();
                    for (int i = 0, imax = ch.Length; i < imax; i++)
                    {
                        if (ch[i] == '1')
                        {
                            Day.SetItemChecked(i, true);
                        }
                    }

                    Useful.Checked = !oldBell.m_bClosed;
                }
            }

            WindowAutoAdjust();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            MainForm.m_BellListMgr.DeleteBellByID(modifyID);
            this.Hide();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModify_Click(object sender, EventArgs e)
        {
            Bell newBell = null;
            int id = modifyID;
            if (modifyID == -1)
            {
                id = MainForm.m_BellListMgr.GenerateID();
            }
            newBell = new Bell(id);
            newBell.m_bClosed = !Useful.Checked;
            newBell.m_iBellVolume = Convert.ToInt32(Volume.Value);
            if (Sound.Items.Count > 0)
            {
                newBell.m_strSoundName = Sound.SelectedItem.ToString();
            }
            else
            {
                newBell.m_strSoundName = "未选铃声";
            }
            newBell.m_strRingTime = Convert.ToInt32(TimeM.Value).ToString("D2") + ":" + Convert.ToInt32(TimeS.Value).ToString("D2");
            if (string.IsNullOrEmpty(BellName.Text.Trim()) == false)
            {
                newBell.m_strBellName = BellName.Text.Trim();
            }
            else
            {
                newBell.m_strBellName = "未命名";
            }

            newBell.m_strRingDay = "0000000";
            char[] ch = newBell.m_strRingDay.ToCharArray();
            for (int i = 0; i < Day.Items.Count; i++)
            {
                if (Day.GetItemChecked(i))
                {
                    ch[i] = '1';
                }
            }
            newBell.m_strRingDay = "";
            for (int i = 0, imax = ch.Length; i < imax; i++)
            {
                newBell.m_strRingDay += ch[i];
            }

            MainForm.m_BellListMgr.AddModifyBell(newBell);

            this.Hide();
        }

        #region 窗体缩放调整

        private float X, Y;

        private void WindowAutoAdjust()
        {
            this.Resize += new EventHandler(WindowResize);//窗体调整大小事件时执行的方法
            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            SetTag(this);//调用方法
        }

        private void SetTag(Control cons)
        {
            //遍历窗体中的控件
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);//递归调用
                }
            }
        }

        private void SetControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值
                con.Width = (int)a;//宽度
                a = Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;//左边缘距离
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    SetControls(newx, newy, con);
                }
            }
        }

        /// <summary>
        /// 窗体大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowResize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;//窗体宽度缩放比例
            float newy = this.Height / Y;//窗体高度缩放比例
            SetControls(newx, newy, this);//随窗体改变控件大小
        }

        #endregion

        /// <summary>
        /// 试听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Listen_Click(object sender, EventArgs e)
        {
            if (Sound.SelectedItem == null)
            {
                MessageBox.Show("请选中铃声试听");
                return;
            }

            AxWindowsMediaPlayer.URL = MainForm.m_strSoundPath + Sound.SelectedItem.ToString();
            AxWindowsMediaPlayer.settings.volume = Convert.ToInt32(Volume.Value);
        }

        /// <summary>
        /// 打开Sound目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSound_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MainForm.m_strSoundPath);
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopPlay_Click(object sender, EventArgs e)
        {
            AxWindowsMediaPlayer.Ctlcontrols.stop();
        }

        /// <summary>
        /// 窗体关闭时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBell_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPlay_Click(null, null);
        }
    }
}
