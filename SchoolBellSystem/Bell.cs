using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolBellSystem
{
    /// <summary>
    /// 闹铃
    /// </summary>
    public class Bell
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int m_iBellID;

        /// <summary>
        /// 闹铃名字
        /// </summary>
        public string m_strBellName;
        
        /// <summary>
        /// 铃声名
        /// </summary>
        public string m_strSoundName;
        
        /// <summary>
        /// 音量
        /// </summary>
        public int m_iBellVolume;
        
        /// <summary>
        /// 响应时间
        /// </summary>
        public string m_strRingTime;

        /// <summary>
        /// 响应的天
        /// </summary>
        public string m_strRingDay;

        /// <summary>
        /// 已关闭
        /// </summary>
        public bool m_bClosed;

        /// <summary>
        /// 构造
        /// </summary>
        public Bell()
        {

        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="tBellID">编号</param>
        public Bell(int bellID)
        {
            m_iBellID = bellID;
            m_strBellName = "";
            m_strSoundName = "";
            m_iBellVolume = 100;
            m_strRingTime = "";
            m_strRingDay = "0000000";
            m_bClosed = false;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="bellName">闹铃名字</param>
        /// <param name="soundName">铃声名</param>
        /// <param name="bellVolume">音量</param>
        /// <param name="ringTime">响应时间</param>
        /// <param name="ringDay">响应的天</param>
        /// <param name="bellID">编号</param>
        public Bell(string bellName, string soundName, int bellVolume, string ringTime, string ringDay, int bellID)
        {
            m_strBellName = bellName;
            m_strSoundName = soundName;
            m_iBellVolume = bellVolume;
            m_strRingTime = ringTime;
            m_strRingDay = ringDay;
            m_iBellID = bellID;
            m_bClosed = false;
        }

        /// <summary>
        /// 排序因子，m_iBellID降序
        /// </summary>
        /// <param name="msgA"></param>
        /// <param name="msgB"></param>
        /// <returns></returns>
        public static int CmpBellIDDESC(Bell a, Bell b)
        {
            int iRet = 0;
            iRet = a.m_iBellID < b.m_iBellID ? 1 : -1;
            return iRet;
        }

        /// <summary>
        /// 排序因子，m_strRingTime升序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CmpRingTimeASC(Bell a, Bell b)
        {
            int iRet = 0;
            iRet = a.m_strRingTime.CompareTo(b.m_strRingTime) <= 0 ? -1 : 1;
            return iRet;
        }
    }
}
