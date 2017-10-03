using System;
using System.Windows.Forms;

namespace UnicodeTranslate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "高&#40175;琴";
            int hasUnicode = str.IndexOf("&#");
            if (hasUnicode > -1)
            {
                var getEncode = str.Split(new string[] { "&#" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < getEncode.Length; i++)
                {
                    var sp = getEncode[i];
                    if (sp.IndexOf(';') > -1)
                    {
                        var s = sp.Substring(0, sp.IndexOf(';'));
                    }
                }
            }
            string outStr = "";

            if (!string.IsNullOrEmpty(str))
            {
                //輸入格式 #xxxxx#xxxxxx 所以要切開
                string[] strlist = str.Split('#');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        // 輸入的為16進制的文字
                        // outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                        // 輸入的為10進制整數
                        outStr += (char)int.Parse(strlist[i]);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
        }

        /// <summary>
        /// UNICODE轉中文
        /// </summary>
        /// <param name="strUnicode"></param>
        /// <returns></returns>
        public static string UnicodeToString(string strUnicode)
        {
            string str = strUnicode;
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                //輸入格式 #xxxxx#xxxxxx 所以要切開
                string[] strlist = str.Split('#');
                try
                {
                    for (int i = 1; i < strlist.Length; i++)
                    {
                        // 輸入的為16進制的文字
                        // outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                        // 輸入的為10進制整數
                        outStr += (char)int.Parse(strlist[i]);
                    }
                }
                catch (FormatException ex)
                {
                    outStr = ex.Message;
                }
            }
            return outStr;
        }

        /// <summary>
        /// 中文轉為UNICODE
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string StringToUnicode(string strSource)
        {
            //中文轉為UNICODE
            string str = strSource;
            string outStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    //以# 隔開。
                    //輸出的為16進制的文字
                    //outStr += "#" + ((int)str[i]).ToString("x");
                    //輸出的為10進制的文字
                    outStr += "#" + ((int)str[i]).ToString();
                }
            }
            return outStr;
        }
    }
}