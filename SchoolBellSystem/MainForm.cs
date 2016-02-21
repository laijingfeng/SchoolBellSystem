using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SchoolBellSystem
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// 星期
        /// </summary>
        public static string[] m_strWeekdaysShort = { "一", "二", "三", "四", "五", "六", "日" };

        /// <summary>
        /// 闹铃管理
        /// </summary>
        public static BellListMgr m_BellListMgr = null;

        /// <summary>
        /// 单例
        /// </summary>
        private static MainForm m_instance = null;

        /// <summary>
        /// 单例
        /// </summary>
        public static MainForm Instance
        {
            get
            {
                return m_instance;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            if (m_instance == null)
            {
                m_instance = this;
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists("Sound") == false)
            {
                System.IO.Directory.CreateDirectory("Sound");
            }

            Timer.Interval = 1000;
            Timer.Enabled = true;
            LabelCurDateTime.Text = DateTime.Now.ToString("当前时间：yyyy-MM-dd HH:mm:ss") + " 星期" + m_strWeekdaysShort[(Convert.ToInt32(DateTime.Now.DayOfWeek) + 6) % 7];

            AxWindowsMediaPlayer.Visible = false;

            m_BellListMgr = new BellListMgr("Bell.txt");
            m_BellListMgr.LoadData();

            RefreshBellUI();

            WindowAutoAdjust();
        }

        /// <summary>
        /// 最小化到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeToTray_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 点击最小化按钮时，最小化到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        /// <summary>
        /// 托盘双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                HideMainForm();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                ShowMainForm();
            }
        }

        /// <summary>
        /// 托盘菜单，显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Show_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        /// <summary>
        /// 托盘菜单，退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.NotifyIcon.Visible = false;
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// 定义显示方法
        /// </summary>
        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        /// <summary>
        /// 定义最小化方法
        /// </summary>
        private void HideMainForm()
        {
            this.Hide();
        }

        /// <summary>
        /// 响铃
        /// </summary>
        /// <param name="bell"></param>
        private void RingBell(Bell bell)
        {
            if (bell == null)
            {
                return;
            }

            if (bell.m_strRingDay.Equals("0000000"))
            {
                bell.m_bClosed = true;
                m_BellListMgr.AddModifyBell(bell);
            }

            if (System.IO.File.Exists("Sound/" + bell.m_strSoundName))
            {
                AxWindowsMediaPlayer.URL = "Sound/" + bell.m_strSoundName;
                AxWindowsMediaPlayer.settings.volume = bell.m_iBellVolume;
            }
        }

        /// <summary>
        /// 时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            LabelCurDateTime.Text = time.ToString("当前时间：yyyy-MM-dd HH:mm:ss") + " 星期" + m_strWeekdaysShort[(Convert.ToInt32(time.DayOfWeek) + 6) % 7];

            RingBell(m_BellListMgr.TryRingBell(time));
        }

        /// <summary>
        /// 增加闹铃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBell_Click(object sender, EventArgs e)
        {
            DoAddModifyBell();
        }

        /// <summary>
        /// 进行增/改闹铃
        /// </summary>
        /// <param name="tModifyID"></param>
        private void DoAddModifyBell(int tModifyID = -1)
        {
            this.Hide();
            AddBell addBell = new AddBell();
            addBell.modifyID = tModifyID;
            addBell.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 刷新UI
        /// </summary>
        public void RefreshBellUI()
        {
            if(m_BellListMgr.m_listBell.Count <= 0)
            {
                EmptyTip.Visible = true;
                DGV.Visible = false;
                ListTip.Visible = false;
                return;
            }

            EmptyTip.Visible = false;
            DGV.Visible = true;
            ListTip.Visible = true;

            m_BellListMgr.Sort();

            DGV.Columns.Clear();
            DGV.Columns.Add("BellName", "名称"); DGV.Columns[0].Width = 140;
            DGV.Columns.Add("RingTime", "时间"); DGV.Columns[1].Width = 55;
            DGV.Columns.Add("RingDay", "重复"); DGV.Columns[2].Width = 140;
            DGV.Columns.Add("SoundName", "铃声");
            DGV.Columns.Add("Volume", "音量"); DGV.Columns[4].Width = 35;
            DGV.Columns.Add("State", "状态"); DGV.Columns[5].Width = 55;

            if (m_BellListMgr.m_listBell.Count <= 0)
            {
                return;
            }

            DGV.Rows.Clear();
            DGV.Rows.Add(m_BellListMgr.m_listBell.Count);

            Bell bell;
            for (int i = 0, imax = m_BellListMgr.m_listBell.Count; i < imax; i++)
            {
                bell = m_BellListMgr.m_listBell[i];
                DGV.Rows[i].Cells[0].Value = bell.m_strBellName;
                DGV.Rows[i].Cells[1].Value = bell.m_strRingTime;

                string days = "只响一次";
                if (bell.m_strRingDay.Equals("0000000") == false)
                {
                    days = "";
                    for (int j = 0, jmax = bell.m_strRingDay.Length; j < jmax; j++)
                    {
                        if (bell.m_strRingDay[j] == '1')
                        {
                            if (string.IsNullOrEmpty(days) == false)
                            {
                                days += '|';
                            }
                            else
                            {
                                days += "周";
                            }
                            days += m_strWeekdaysShort[j];
                        }
                    }
                }
                DGV.Rows[i].Cells[2].Value = days;

                DGV.Rows[i].Cells[3].Value = bell.m_strSoundName;
                DGV.Rows[i].Cells[4].Value = bell.m_iBellVolume;
                DGV.Rows[i].Cells[5].Value = bell.m_bClosed ? "关闭" : "开启";
            }
        }

        /// <summary>
        /// 双击行头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= m_BellListMgr.m_listBell.Count
                || e.RowIndex < 0)
            {
                return;
            }

            DoAddModifyBell(m_BellListMgr.m_listBell[e.RowIndex].m_iBellID);
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
    }
}
