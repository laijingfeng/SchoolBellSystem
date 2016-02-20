using System;
using System.Collections.Generic;
using System.Linq;
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
        public string m_strFileName;

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
                return;
            }

            m_listBell.Clear();

            try
            {
                StreamReader streamReader = File.OpenText(m_strFileName);
                m_BellArr = LitJson.JsonMapper.ToObject<BellArr>(streamReader.ReadToEnd());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("error");
                return;
            }

            for (int i = 0, imax = (m_BellArr.m_arrBellList == null) ? 0 : m_BellArr.m_arrBellList.Length; i < imax; i++)
            {
                m_listBell.Add(m_BellArr.m_arrBellList[i]);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void SaveData()
        {
            try
            {
                string jdata = LitJson.JsonMapper.ToJson(m_BellArr);

                FileStream fileStream = new FileStream(m_strFileName, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);

                streamWriter.Write(jdata);

                streamWriter.Close();
            }
            catch (System.Exception ex)
            {

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
            if(m_listBell.Count <= 0)
            {
                return 1;
            }

            m_listBell.Sort(Bell.CmpBellIDDESC);

            return m_listBell[0].m_iBellID + 1;
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        /// <returns></returns>
        private string TestJsonData()
        {
            string data = @"
            {
                ""bellList"" : [
                    {
                        ""bellID"" : 1,
                        ""bellName"" : ""lai""
                    },
                    {
                        ""bellID"" : 2,
                        ""bellName"" : ""jing""
                    }
                ]
            }";
            return data;
        }
    }
}
