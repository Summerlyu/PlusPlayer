using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using LrcCollection;

namespace MediaPlayer
{
    public class LrcConnections
    {
        static Dictionary<int, string> lrcList = new Dictionary<int, string>();//用来保存歌词和时间的集合
        public static Dictionary<int, string> lrcSortedList = new Dictionary<int, string>();//用来保存歌词和时间排序后的集合
        Dictionary<int, string> lrcTemp = new Dictionary<int, string>();//用来保存临时歌词
        static int[] tempTime;
        public static string lrcPath = null;
        public static bool isReading = false;//是否正在读歌词

        public static LrcFrm lrcfrm = null;
        public static LrcPanel lrcPanel = null;
        public static DeskLrcControl deskLrc = null;


        public static void DrawFrmLrc(string position)
        {
            if (lrcPanel.FindForm().Visible == true)//画窗体歌词
            {
                lrcPanel.currentPosition = position;
                lrcPanel.Refresh();
            }
        }
        public static void DrawDeskLrc(string position)
        {
            if (lrcPanel.desk != null)//画桌面歌词
            {
                lrcPanel.desk.deskLrcControl1.currentPosition = position;
                lrcPanel.desk.deskLrcControl1.Refresh();
            }
        }
        public static void DrawLrcRefresh(string position)//重绘,把当前时间传过来
        {
            try
            {
                if (lrcPanel != null)
                {
                    DrawFrmLrc(position);
                    DrawDeskLrc(position);
                }
            }
            catch { }
        }

        public static void GetLrc(string url)//获取歌词
        {
            lrcPath = null;//先清空
            lrcSortedList.Clear();
            lrcPath = GetLrc1(url);
            if (lrcPath != null)
            {
                if (UserHelper.lrc != null)
                {
                    foreach (Control c in UserHelper.lrc.tabPage3.Controls)
                    {
                        if (c.Name.Trim().Equals("txtPath"))
                        {
                            c.Text = lrcPath;
                            break;
                        }
                    }
                }
                LoadLrc(lrcPath,null);
            }
            else
            {
                if (UserHelper.lrc != null)
                {
                    foreach (Control c in UserHelper.lrc.tabPage3.Controls)
                    {
                        if (c.Name.Trim().Equals("txtPath"))
                        {
                            c.Text = null;
                            break;
                        }
                    }
                }
            }
        }

        #region //根据路径获取歌词
        public static string GetLrc1(string url)
        {
            string lrcPath = url.Substring(0, url.LastIndexOf(".")) + ".LRC";
            string so = url.Substring(url.LastIndexOf("\\") + 1, url.LastIndexOf(".") - url.LastIndexOf("\\") - 1);
            FileInfo lrcFile = new FileInfo(lrcPath);
            if (lrcFile.Exists)
            {
                return lrcPath;
            }
            FileInfo lrcFile1 = new FileInfo(lrcPath.Trim());
            if (lrcFile1.Exists)
            {
                return lrcFile1.FullName;
            }
            string songFile = url.Substring(0, url.LastIndexOf("\\"));
            DirectoryInfo f1 = new DirectoryInfo(songFile);
            string singer = "";
            string song = "";
            string hasSongLrc = null;

            foreach (FileInfo f in f1.GetFiles())
            {
                if (!f.Extension.ToUpper().Equals(".LRC"))
                {
                    continue;
                }
                hasSongLrc = searchLrc(f, so, singer, song, url);
                if (hasSongLrc != null)
                {
                    return hasSongLrc;
                }
            }
            string lrcFilePath = Config.GetValue("lrcDir");
            if (lrcFilePath != null)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(lrcFilePath);
                if (!dirInfo.Exists)
                {
                    return null;
                }
                foreach (FileInfo f in dirInfo.GetFiles("*.lrc"))
                {
                    if ((so.Trim() + ".lrc").Equals(f.Name.Trim().ToLower()))
                    {
                        return f.FullName;
                    }
                    if (!f.Extension.ToUpper().Equals(".LRC"))
                    {
                        continue;
                    }
                    hasSongLrc = searchLrc(f, so, singer, song, url);
                    if (hasSongLrc != null)
                    {
                        return hasSongLrc;
                    }
                }
            }
            return null;
        }

        private static string searchLrc(FileInfo f, string so, string singer, string song, string url)
        {
            try
            {
                if (f.Name.Contains("[") && f.Name.Contains("]") && !f.Name.Contains("-") && !so.Contains("-"))
                {
                    singer = f.Name.Trim().Substring(f.Name.Trim().IndexOf("[") + 1, f.Name.Trim().LastIndexOf("]") - 1);
                    song = f.Name.Trim().Substring(f.Name.Trim().LastIndexOf("]") + 1, f.Name.Trim().LastIndexOf(".") - f.Name.Trim().LastIndexOf("]") - 1);
                    song = song.Trim();
                    singer = singer.Trim();
                    so = so.Trim();
                    if (so.Substring(f.Name.Trim().IndexOf("["), url.Trim().LastIndexOf("]")).Equals(singer) && so.Substring(f.Name.Trim().LastIndexOf("]")).Equals(song))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(f.Name.Trim().IndexOf("["), url.Trim().LastIndexOf("]")).Equals(song) && so.Substring(f.Name.Trim().LastIndexOf("]")).Equals(singer))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(f.Name.Trim().IndexOf("["), url.Trim().LastIndexOf("]")).Equals(singer) || so.Substring(f.Name.Trim().LastIndexOf("]")).Equals(song))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(f.Name.Trim().IndexOf("["), url.Trim().LastIndexOf("]")).Equals(song) || so.Substring(f.Name.Trim().LastIndexOf("]")).Equals(singer))
                    {
                        return f.FullName;
                    }
                }
                else if (f.Name.Contains("-"))
                {
                    singer = f.Name.Trim().Substring(0, f.Name.Trim().IndexOf("-"));
                    song = f.Name.Trim().Substring(f.Name.Trim().LastIndexOf("-") + 1, f.Name.Trim().LastIndexOf(".") - f.Name.Trim().LastIndexOf("-") - 1);
                    song = song.Trim();
                    singer = singer.Trim();
                    so = so.Trim();
                    //if (song.Equals(so.Substring(so.LastIndexOf("-") + 1)))
                    //{
                    //    MessageBox.Show(song);
                    //}
                    //if (singer.Equals(so.Substring(0, so.IndexOf("-"))))
                    //{
                    //    MessageBox.Show(singer+"111");
                    //}

                    if (so.Substring(0, so.IndexOf("-")).Equals(singer) && so.Substring(so.LastIndexOf("-") + 1).Equals(song))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(0, so.IndexOf("-")).Equals(song) && so.Substring(so.LastIndexOf("-") + 1).Equals(singer))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(0, so.IndexOf("-")).Equals(singer) || so.Substring(so.LastIndexOf("-") + 1).Equals(song))
                    {
                        return f.FullName;
                    }
                    if (so.Substring(0, so.IndexOf("-")).Equals(song) || so.Substring(so.LastIndexOf("-") + 1).Equals(singer))
                    {
                        return f.FullName;
                    }

                    ////MessageBox.Show(f.FullName);
                }
            }
            catch { }
            return null;
        }
        #endregion

        #region 获得歌词的方法
        public static void GetLrc()
        {
            tempTime = new int[lrcList.Count];
            int m = 0;
            foreach (int t in lrcList.Keys)
            {
                tempTime[m] = t;
                m++;
            }

            //对集合进行排序
            for (int i = 0; i < tempTime.Length - 2; i++)//减2
            {
                for (int j = 0; j < tempTime.Length - 1 - i; j++)
                {
                    if (tempTime[j] > tempTime[j + 1])
                    {
                        int temp = tempTime[j];
                        tempTime[j] = tempTime[j + 1];
                        tempTime[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < tempTime.Length; i++)
            {
                lrcSortedList.Add(tempTime[i], lrcList[tempTime[i]]);
            }
            isReading = false;
        }
        #endregion

        #region 加载歌词的方法
        static bool isHas = false;
        public static void LoadLrc(string lrcFile,Encoding enc)
        {
            try
            {
                if (enc == null)
                {
                    enc = Encoding.Default;
                }
                lrcPath = lrcFile;
                isReading = true;
                lrcSortedList.Clear();
                lrcList.Clear();
                FileStream fs = new FileStream(lrcFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                StreamReader reader = new StreamReader(fs, Encoding.Default);
                string lrcTemp = reader.ReadLine();//读取一行歌词
                string lrcString;
                bool blag;
                int first = 0;
                while (reader.EndOfStream == false)
                {
                    blag = true;
                    lrcString = lrcTemp;
                    while (blag)
                    {
                        int l = lrcTemp.IndexOf("[");//第一个左[
                        int r = lrcTemp.IndexOf("]");//第一个右]
                        int la = lrcTemp.LastIndexOf("]");//最后一个]
                        string is_Time = lrcTemp.Substring(l + 1, r - 1);//获取第一个时间
                        if (isTime(is_Time))
                        {
                            int last = lrcTemp.LastIndexOf("]");//最后一个]
                            lrcString = lrcTemp.Substring(last + 1);//获取歌词
                            if (lrcString.Trim() == "" || lrcString == null)//获取当前歌词对应的所有时间并保存在集合中
                            {
                                if (first == 0)
                                {
                                    lrcString = "土豆音乐   因你而变";
                                }
                                else if (first == 3)
                                {
                                    lrcString = "很拽の土豆  QQ:475589699";
                                }
                                else
                                {
                                    lrcString = "Music...";
                                }
                                first++;
                            }
                            string minute = is_Time.Substring(0, is_Time.IndexOf(":"));//分
                            string second = is_Time.Substring(is_Time.IndexOf(":") + 1, 2);//秒
                            //string millSecond = is_Time.Substring(is_Time.IndexOf(".") + 1);//毫秒
                            //int timeNow = Convert.ToInt32(minute) * 6000 + Convert.ToInt32(second) * 100 + Convert.ToInt32(millSecond);
                            int timeNow = Convert.ToInt32(minute) * 60 + Convert.ToInt32(second);
                            //lrcString = Microsoft.VisualBasic.Strings.StrConv(lrcString, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0);
                            for (int i = 0; i < lrcList.Count; i++)
                            {
                                if (lrcList.ElementAt(i).Key == timeNow)//是否有重复的键存在
                                {
                                    if (lrcList.ElementAt(i).Value == null || lrcList.ElementAt(i).Value.Trim() == "")//如果没有歌词则去掉这句
                                    {
                                        lrcList.Remove(timeNow);

                                    }
                                    else if (lrcString == null || lrcString.Trim() == "")
                                    {
                                        isHas = true;
                                    }
                                    else
                                    {
                                        isHas = true;
                                    }
                                    break;
                                }
                            }
                            if (isHas == false)
                            {
                                lrcList.Add(timeNow, lrcString);//将对应歌词和时间保存
                            }
                            isHas = false;
                        }
                        if (r != la)//中间还有时间的话
                        {
                            lrcTemp = lrcTemp.Substring(lrcTemp.IndexOf("]") + 1);
                            continue;
                        }
                        else
                        {
                            blag = false;
                        }
                    }
                    lrcTemp = reader.ReadLine();
                    while (lrcTemp.Trim() == "" || lrcTemp == null)
                    {
                        lrcTemp = reader.ReadLine();
                    }
                }
                reader.Close();
                fs.Close();
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            GetLrc();
        }
        #endregion

        #region //判断是否是时间
        public static bool isTime(string time)
        {
            if (time.Contains(":"))
            {
                string str = time.Substring(0, time.IndexOf(":"));//截取:前部分
                Char[] t = str.ToCharArray();
                foreach (char ch in t)
                {
                    if (Char.IsDigit(ch) == false)
                    {
                        return false;
                    }
                }
            }
            if (time.Contains("."))
            {
                string s = time.Substring(time.IndexOf(Convert.ToChar(".")) + 1);
                Char[] t1 = s.ToCharArray();
                foreach (char ch in t1)
                {
                    if (Char.IsDigit(ch) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
