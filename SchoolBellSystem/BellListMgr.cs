using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SchoolBellSystem
{
    /// <summary>
    /// 闹铃列表管理
    /// </summary>
    public class BellListMgr
    {
        /// <summary>
        /// 闹铃数组，用来解析文件
        /// </summary>
        private BellArr m_BellArr;

        /// <summary>
        /// 闹铃列表，用来使用方便，内容引用m_BellArr里的
        /// </summary>
        public List<Bell> m_listBell;

        /// <summary>
        /// 文件名
        /// </summary>
        private string m_strFileName;

        public BellListMgr(string fileName)
        {
            m_strFileName = fileName;
            m_BellArr = new BellArr();
            m_listBell = new List<Bell>();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void LoadData()
        {
            FileInfo fileInfo = new FileInfo(m_strFileName);
            if (!fileInfo.Exists)
            {
                Console.WriteLine("file not exists");
                return;
            }

            m_listBell.Clear();

            try
            {
                StreamReader streamReader = File.OpenText(m_strFileName);
                m_BellArr = LitJson.JsonMapper.ToObject<BellArr>(streamReader.ReadToEnd());
                streamReader.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("error " + ex);
                return;
            }

            if (m_BellArr == null)
            {
                m_BellArr = new BellArr();
            }

            if (m_BellArr.m_arrBellList != null)
            {
                m_listBell.AddRange(m_BellArr.m_arrBellList);
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Sort()
        {
            if (m_listBell.Count <= 0)
            {
                return;
            }

            m_listBell.Sort(Bell.CmpRingTimeASC);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void SaveData()
        {
            MainForm.Instance.RefreshBellUI();

            try
            {
                m_BellArr.m_arrBellList = m_listBell.ToArray();

                string jdata = LitJson.JsonMapper.ToJson(m_BellArr);
                
                FileStream fileStream = new FileStream(m_strFileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.Write(jdata);

                streamWriter.Close();
                fileStream.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("save data error: " + ex.ToString());
            }
        }

        /// <summary>
        /// 获取闹铃通过ID
        /// </summary>
        /// <param name="bellID"></param>
        /// <returns></returns>
        public Bell GetBellByID(int bellID)
        {
            for (int i = 0, imax = m_listBell.Count; i < imax; i++)
            {
                if (m_listBell[i].m_iBellID == bellID)
                {
                    return m_listBell[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bellID"></param>
        public void DeleteBellByID(int bellID)
        {
            Bell bell = m_listBell.Find(x=>x.m_iBellID == bellID);
            if(bell == null)
            {
                return;
            }
            m_listBell.Remove(bell);
            SaveData();
        }

        /// <summary>
        /// 增改闹铃
        /// </summary>
        /// <param name="bell"></param>
        public void AddModifyBell(Bell bell)
        {
            Bell oldBell = null;
            oldBell = m_listBell.Find(x => x.m_iBellID == bell.m_iBellID);
            if (oldBell != null)
            {
                m_listBell.Remove(oldBell);
            }

            m_listBell.Add(bell);

            SaveData();
        }

        /// <summary>
        /// 生成一个ID
        /// </summary>
        /// <returns></returns>
        public int GenerateID()
        {
            int id = 0;
            for(int i=0,imax=m_listBell.Count;i<imax;i++)
            {
                if (m_listBell[i].m_iBellID > id)
                {
                    id = m_listBell[i].m_iBellID;
                }
            }
            return id + 1;
        }

        /// <summary>
        /// 尝试响铃
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Bell TryRingBell(DateTime time)
        {
            Bell ringBell = null;

            string strTime = time.ToString("HH:mm:ss");
            int week = (Convert.ToInt32(time.DayOfWeek) + 6) % 7;

            ringBell = m_listBell.Find(x => (x.m_bClosed == false && strTime.Equals(x.m_strRingTime + ":00") && (x.m_strRingDay.Equals("0000000") || x.m_strRingDay[week] == '1') ));

            return ringBell;
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        /// <returns></returns>
        private string TestJsonData()
        {
            string data = @"
            {
                ""m_arrBellList"" : [
                    {
                        ""m_iBellID"" : 1,
                        ""m_strBellName"" : ""lai""
                    },
                    {
                        ""m_iBellID"" : 2,
                        ""m_strBellName"" : ""jing""
                    }
                ]
            }";
            return data;
        }
    }
}
