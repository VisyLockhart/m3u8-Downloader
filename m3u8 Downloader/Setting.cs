using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using m3u8_Downloader.Helper;
namespace m3u8_Downloader
{
    public static class Setting
    {
        private static string section = "Setting";
        public static string SAVE_PATH
        {
            get { return IniHelper.getIniValue(section, "SAVE_PATH"); }
            set { IniHelper.setIniValue(section, "SAVE_PATH", value); }
        }        
        public static string EXTENSION
        {
            get { return IniHelper.getIniValue(section, "EXTENSION"); }
            set { IniHelper.setIniValue(section, "EXTENSION", value); }
        }
        public static string FFMPEG_FILE_NAME
        {
            get { return IniHelper.getIniValue(section, "FFMPEG_FILE_NAME"); }
            set { IniHelper.setIniValue(section, "FFMPEG_FILE_NAME", value); }
        }

        public static string FFMPEG_FILE_PATH
        {
            get { return IniHelper.getIniValue(section, "FFMPEG_FILE_PATH"); }
            set { IniHelper.setIniValue(section, "FFMPEG_FILE_PATH", value); }
        }
    }
}
