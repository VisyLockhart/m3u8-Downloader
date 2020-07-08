using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace m3u8_Downloader.Helper
{
    public static class IniHelper
    {
        #region private members
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private static string INI_PATH = Environment.CurrentDirectory + @"\setting.ini";
        #endregion

        /// <summary>
        /// 讀取ini設定檔的值
        /// </summary>
        public static string getIniValue(string section, string key, string path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = INI_PATH;
            }

            StringBuilder str = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", str, 255, path);
            return str.ToString(); ;
        }

        /// <summary>
        /// 寫入ini設定檔的值
        /// </summary>
        public static void setIniValue(string section, string key, string value, string path = null)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = INI_PATH;
            }

            WritePrivateProfileString(section, key, value, path);
        }
    }
}