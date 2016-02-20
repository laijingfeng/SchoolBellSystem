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
    public partial class MainForm : Form
    {
        /// <summary>
        /// 星期
        /// </summary>
        private string[] m_strWeekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

        /// <summary>
        /// 闹铃管理
        /// </summary>
        public static BellListMgr m_BellListMgr = null;
        
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Timer.Interval = 1000;
            Timer.Enabled = true;
            LabelCurDateTime.Text = DateTime.Now.ToString("当前时间：yyyy-MM-dd HH:mm:ss") + " " + m_strWeekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];

            AxWindowsMediaPlayer.Visible = false;

            if(m_BellListMgr == null)
            {
                m_BellListMgr = new BellListMgr("Bell.txt");
                m_BellListMgr.LoadData();
            }

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

        private void Test(string name, int vol)
        {
            AxWindowsMediaPlayer.URL = "Sound/" + name + ".mp3";
            AxWindowsMediaPlayer.settings.volume = vol;
        }

        /// <summary>
        /// 时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            LabelCurDateTime.Text = DateTime.Now.ToString("当前时间：yyyy-MM-dd HH:mm:ss") + " " + m_strWeekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
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
            RefreshBellUI();
        }

        /// <summary>
        /// 刷新UI
        /// </summary>
        private void RefreshBellUI()
        {

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
