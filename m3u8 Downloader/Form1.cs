using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using m3u8_Downloader.Extension;

namespace m3u8_Downloader
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            InitForm();
        }

        public void InitForm()
        {
            lbExtension.Text = $@".{Setting.EXTENSION}";
            lbFfmpegPath.Text = $@"{Setting.FFMPEG_FILE_NAME}啟動位置";
            if (!string.IsNullOrWhiteSpace(Setting.SAVE_PATH))
            {
                tbSavePath.Text = Setting.SAVE_PATH;
            }
            if (!string.IsNullOrWhiteSpace(Setting.FFMPEG_FILE_PATH))
            {
                tbFfmpegPath.Text = Setting.FFMPEG_FILE_PATH;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();            
            dlg.Description = @"請選擇儲存位置";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dlg.SelectedPath))
                {
                    MessageBox.Show(this, "資料夾路徑不能為空", "提示");
                    return;
                }
                else
                {
                    Setting.SAVE_PATH = tbSavePath.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            #region 檢查必填
            if (string.IsNullOrWhiteSpace(Setting.FFMPEG_FILE_PATH))
            {
                MessageBox.Show(this, $"請選擇{Setting.FFMPEG_FILE_NAME}啟動位置", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(Setting.SAVE_PATH))
            {
                MessageBox.Show(this, "請選擇儲存位置", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbSourceUrl.Text))
            {
                MessageBox.Show(this, "請輸入m3u8檔案網址", "提示");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbFileName.Text))
            {
                MessageBox.Show(this, "請輸入檔案名稱", "提示");
                return;
            }
            var dirInfo = new DirectoryInfo(Setting.SAVE_PATH);
            if(dirInfo.GetFiles().Any(x => x.Name.Equals($@"{tbFileName.Text}.{Setting.EXTENSION}")))
            {
                MessageBox.Show(this, "在儲存位置已有相同名稱的檔案", "提示");
                return;
            }
            pbDownload.Value = 0;            
            #endregion
            #region 組合參數
            //ffmpeg -i "m3u8網址" -c copy media.mp4
            var saveFullPath = Path.Combine(tbSavePath.Text, $@"{tbFileName.Text}.{Setting.EXTENSION}");
            var args = $@"-i {tbSourceUrl.Text} -c copy {saveFullPath}";
            #endregion
            #region 呼叫ffmpeg
            try
            {
                btnDownload.Enabled = false;
                using (Process ffmpeg = new Process())
                {
                    var ffmepgFullPath = Path.Combine(Setting.FFMPEG_FILE_PATH, Setting.FFMPEG_FILE_NAME);
                    ffmpeg.StartInfo.FileName = ffmepgFullPath;
                    ffmpeg.StartInfo.Arguments = args;
                    //將ffmpeg的輸出導回到目前執行的process, 但UseShellExecute必須設定為false
                    ffmpeg.StartInfo.RedirectStandardError = true;
                    //UseShellExecute設定為false, ProcessWindowStyle.Hidden會失效
                    ffmpeg.StartInfo.UseShellExecute = false;
                    ffmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //設定CreateNoWindow為true, 可同時隱藏執行視窗又輸出訊息
                    ffmpeg.StartInfo.CreateNoWindow = true;
                    var IsStart = ffmpeg.Start();
                    if (!IsStart)
                    {
                        throw new Exception($@"啟動ffmpeg錯誤或找不到ffmpeg執行檔 : 
                            {Environment.NewLine}{ffmepgFullPath}");
                    }

                    #region progressbar                    
                    //邏輯: 每次下載中, ffmpeg在前兩個.ts檔會解析出 Duration (影片總長度),
                    //在之後的.ts檔案中均會輸出time=xx:xx:xx, 此為該檔案可播放到的影片長度,
                    //將 time/Duration 就可以做出進度條                    
                    string line;
                    double duration, time;
                    //regex time format => dd:dd:dd.dd
                    var rx = new Regex(@"\d{2}\:\d{2}\:\d{2}\.\d{2}");
                    while ((line = ffmpeg.StandardError.ReadLine()) != null)
                    {                        
                        if (line.Contains("Duration"))
                        {
                            //取得影片總長度
                            duration = TimeStringToSecond(rx.Match(line).Value);
                            var pbMaximun = Convert.ToInt32(Math.Floor(duration));
                            pbDownload.InvokeIfRequired(() => { pbDownload.Maximum = pbMaximun; });                            
                        }
                        else if (line.Contains("time="))
                        {
                            //取得目前下載檔案可播放到的影片長度
                            time = TimeStringToSecond(rx.Match(line).Value);                            
                            var pbValue = Convert.ToInt32(Math.Floor(time));
                            pbDownload.InvokeIfRequired(() => { pbDownload.Value = pbValue; });                            
                        }
                    }
                    #endregion

                    ffmpeg.WaitForExit();
                    btnDownload.Enabled = true;
                }
            }
            catch (Exception err)
            {
                btnDownload.Enabled = true;
                MessageBox.Show(this, $@"下載檔案發生不明錯誤 :
                            {Environment.NewLine}{err.Message}:
                            {Environment.NewLine}{err.StackTrace}", "錯誤");
                return;
            }
            #endregion
            MessageBox.Show(this, "下載完成!", "提示");
        }

        private double TimeStringToSecond(string strTime)
        {
            var times = strTime.Split(':');
            double result = 0;
            double d;
            if(double.TryParse(times.ElementAt(0), out d))
            {
                result += d * 360;
            }
            if (double.TryParse(times.ElementAt(1), out d))
            {
                result += d * 60;
            }
            if (double.TryParse(times.ElementAt(2), out d))
            {
                result += d;
            }

            return result;
        }

        private void btnFfmpegPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = @"請選擇ffmpeg所在目錄";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dlg.SelectedPath))
                {
                    MessageBox.Show(this, "目錄路徑不能為空", "提示");
                    return;
                }
                else if (!(new DirectoryInfo(dlg.SelectedPath)).GetFiles().Any(x => x.Name.Equals(Setting.FFMPEG_FILE_NAME)))
                {
                    MessageBox.Show(this, $"目錄下找不到檔案名稱為{Setting.FFMPEG_FILE_NAME}的檔案", "提示");
                    return;
                }
                else
                {
                    Setting.FFMPEG_FILE_PATH = tbFfmpegPath.Text = dlg.SelectedPath;
                }
            }
        }
    }
}
