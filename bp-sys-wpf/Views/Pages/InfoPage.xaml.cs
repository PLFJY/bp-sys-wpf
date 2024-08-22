﻿using Flurl.Http;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using static System.Net.WebRequestMethods;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// InfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            this.DataContext = this;
            JustGetFetchLatestReleaseInfoAsync();
        }
        public static string version { get; set; } = $"当前版本：{Config.version}";

        public class GiteeReleaseInfo
        {
            public string tag_name { get; set; }
            public string body { get; set; }
            public Assets[] assets { get; set; }
            public class Assets
            {
                public string browser_download_url { get; set; }
            }
        }
        public async void JustGetFetchLatestReleaseInfoAsync()
        {
            var baseUrl = "https://gitee.com/api/v5";
            var repository = "plfjy/bp-sys-wpf-update-asg";
            var releasesUrl = $"{baseUrl}/repos/{repository}/releases/latest";
            try
            {
                // 发起GET请求并获取JSON响应内容
                var responseJson = await releasesUrl.GetStringAsync();
                // 使用System.Text.Json进行反序列化
                var releaseInfo = System.Text.Json.JsonSerializer.Deserialize<GiteeReleaseInfo>(responseJson);
                string newVersionInfo = releaseInfo.body;
                NewVersionContant.Text = $"最新版本更新内容：\n{newVersionInfo}";
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine($"请求失败: {ex.Message}");
                NewVersionContant.Text = $"最新版本更新内容：\n请求失败";
            }
            catch (JsonException jex)
            {
                Console.WriteLine($"JSON解析失败: {jex.Message}");
            }
        }

        public async Task<(string latestVersion, string DownloadURL)> FetchLatestReleaseInfoAsync()
        {
            string baseUrl = null, repository = null, releasesUrl = null, mirrorURL = null;
            if (Ghproxy.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
                repository = "plfjy/bp-sys-wpf-update-asg";
                releasesUrl = $"{baseUrl}/repos/{repository}/releases/latest";
                mirrorURL = "https://mirror.ghproxy.com/";
            }
            if (Gitee.IsChecked == true)
            {
                baseUrl = "https://gitee.com/api/v5";
                repository = "plfjy/bp-sys-wpf-update-asg";
                releasesUrl = $"{baseUrl}/repos/{repository}/releases/latest";
            }
            if (Github.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
                repository = "plfjy/bp-sys-wpf-update-asg";
                releasesUrl = $"{baseUrl}/repos/{repository}/releases/latest";
            }
            try
            {
                // 发起GET请求并获取JSON响应内容
                var responseJson = await releasesUrl.GetStringAsync();
                // 使用System.Text.Json进行反序列化
                var releaseInfo = System.Text.Json.JsonSerializer.Deserialize<GiteeReleaseInfo>(responseJson);
                // 提取tag_name和第一个browser_download_url
                string latestVersion = releaseInfo.tag_name;
                string fileUrl = releaseInfo.assets?.Length > 0 ? releaseInfo.assets[0].browser_download_url : null;
                var downloadUrl = mirrorURL + fileUrl;
                return (latestVersion, downloadUrl);
            }
            catch (FlurlHttpException ex)
            {
                Debug.WriteLine($"请求失败: {ex.Message}");
                return ($"请求失败", $"请求失败: {ex.Message}");
            }
            catch (JsonException jex)
            {
                Debug.WriteLine($"JSON解析失败: {jex.Message}");
                return default;
            }
        }

        private async void CheckUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var (version, url) = await FetchLatestReleaseInfoAsync();
            if (version == "请求失败")
            {
                //MessageBox.Show(url, version);
                MessageBoxResult result = MessageBox.Show("请求失败，请手动检查版本并下载更新包与软件目录合并\n如遇到文件冲突直接覆盖\n点击确定跳转到更新包下载页", "更新提示", MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
                else
                {
                    var updateurl = "https://gitee.com/plfjy/bp-sys-wpf-update/releases/latest/";
                    Process.Start("explorer.exe", updateurl);
                }
            }
            else
            {
                if (version != Config.version)
                {
                    MessageBox.Show("检测到新版本，最新版本为" + version + "\n点击确定或关闭该提示执行更新！", "更新提示");
                    label1.Visibility = Visibility.Visible;
                    pbDown.Visibility = Visibility.Visible;
                    NewBat();
                    CreateBat();
                    if (HttpFileExist(url))
                    {
                        DownloadHttpFile(url, "new_bpsys.7z");
                    }
                }
                else
                {
                    MessageBox.Show("当前版本为最新版本", "更新提示");
                }
            }
        }
        public void DownloadHttpFile(String http_url, String save_url)
        {
            WebResponse response = null;
            //获取远程文件
            WebRequest request = WebRequest.Create(http_url);
            response = request.GetResponse();
            if (response == null) return;
            //读远程文件的大小
            pbDown.Maximum = response.ContentLength;
            //下载远程文件
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                Stream netStream = response.GetResponseStream();
                Stream fileStream = new FileStream(save_url, FileMode.Create);
                byte[] read = new byte[1024];
                long progressBarValue = 0;
                int realReadLen = netStream.Read(read, 0, read.Length);
                while (realReadLen > 0)
                {
                    fileStream.Write(read, 0, realReadLen);
                    progressBarValue += realReadLen;
                    pbDown.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue);
                    realReadLen = netStream.Read(read, 0, read.Length);
                }
                netStream.Close();
                fileStream.Close();
            }, null);
        }
        /// <summary>
        ///  判断远程文件是否存在
        /// </summary>
        /// <param name="fileUrl">文件URL</param>
        /// <returns>存在-true，不存在-false</returns>
        private bool HttpFileExist(string http_file_url)
        {
            WebResponse response = null;
            bool result = false;//下载结果
            try
            {
                response = WebRequest.Create(http_file_url).GetResponse();
                result = response == null ? false : true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return result;
        }
        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            //显示进度条
            pbDown.Value = value;
            double persent = (value / pbDown.Maximum) * 100;
            int persentToInt = (int)persent;
            //显示百分比
            label1.Text = $"下载进度：{persentToInt}%";
            if (persentToInt == 100)
            {
                Run_cmd();
            }
        }
        public void NewBat()
        {
            // 定义批处理文件的路径和内容  
            string batchFilePath = Path.Combine(Directory.GetCurrentDirectory(), "update.bat");
            string batchFileContent = @"chcp 65001
@echo off    
setlocal enabledelayedexpansion    
    
:: 设置工作目录为脚本所在的目录    
cd /d ""%~dp0""    
    
:: 删除除了指定文件之外的所有文件    
for %%f in (*) do (    
    if /i not ""%%f""==""7z"" if /i not ""%%f""==""new_bpsys.7z"" if /i not ""%%f""==""update.bat"" if /i not ""%%f""==""EndAndUpdate.bat"" (    
        echo Deleting file: %%f
        del ""%%f""    
    )    
)    
    
:: 检查7z.exe是否存在，如果不存在则退出脚本    
if not exist ""7z/7z.exe"" (    
    echo 7z.exe not found. Exiting script.    
    exit /b    
)    
    
:: 使用7z.exe解压new_bpsys.7z文件，使用-y参数自动确认所有操作    
echo Extracting new_bpsys.7z...    
""7z/7z.exe"" x ""new_bpsys.7z"" -o""%~dp0"" -y    
    
del ""new_bpsys.7z""
mshta vbscript:msgbox(""更新完成"",64,""更新提示"")(window.close)
start bp-sys-wpf.exe

:: 脚本执行完毕，退出    
echo Script execution completed.    
exit /b  
        ";

            // 创建批处理文件并写入内容  
            try
            {
                System.IO.File.WriteAllText(batchFilePath, batchFileContent);
                Console.WriteLine("Batch file created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void CreateBat()
        {
            // 定义批处理文件的路径和内容  
            string batchFilePath = Path.Combine(Directory.GetCurrentDirectory(), "EndAndUpdate.bat");
            string batchFileContent = @"@echo off  
setlocal  
  
:: 查找并结束 bp-sys-wpf.exe 进程  
taskkill /F /IM bp-sys-wpf.exe >nul 2>&1  
  
:: 检查是否成功结束进程  
if %errorlevel% neq 0 (  
    echo Failed to end bp-sys-wpf.exe process.  
    exit /b %errorlevel%  
)  
  
:: 运行根目录下的 update.bat 脚本  
call ""%~dp0update.bat""  
  
:: 脚本执行完毕  
echo Script execution completed.  
exit /b  
        ";

            // 创建批处理文件并写入内容  
            try
            {
                System.IO.File.WriteAllText(batchFilePath, batchFileContent);
                Console.WriteLine("Batch file created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void Run_cmd()
        {
            // 创建ProcessStartInfo对象，设置cmd.exe的参数  

            // 获取程序所在的目录  
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // 批处理文件的完整路径  
            string batchFilePath = Path.Combine(currentDirectory, "EndAndUpdate.bat");

            try
            {
                // 启动一个新的进程  
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // 命令提示符程序  
                    Arguments = "/C " + batchFilePath, // /C 参数告诉cmd执行后关闭，batchFilePath是要运行的批处理文件路径  
                    UseShellExecute = true, // 是否使用操作系统shell启动  
                    CreateNoWindow = true, // 是否创建新窗口  
                    WorkingDirectory = currentDirectory // 设置工作目录为程序所在目录  
                };

                // 启动进程  
                using (Process process = Process.Start(startInfo))
                {
                    // 不需要监听输出，因此不需要process.StandardOutput或process.StandardError  
                    // 等待进程结束  
                    process.WaitForExit();
                }

                Console.WriteLine("Batch file has been executed.");
            }
            catch (Exception ex)
            {
                // 处理任何异常  
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        private void ResetConfig_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resource\\Config.ini");
            System.IO.File.Delete(filePath);

            string batchFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Resource\\Config.ini");
            string batchFileContent = ";一些颜色参考\r\n;黑色#FF000000\r\n;红色#FFFF0000\r\n;白色#FFFFFFFF\r\n;蓝色#FF0000FF\r\n;绿色#FF00FF00\r\n;颜色代号类型：十六进制颜色代码Hex，ARGB或RGB都可（ARGB是带颜色透明度的，RGB则是经典的红绿蓝）\r\n;BP主窗口\r\n[Front_Color]\r\n;队伍名称\r\nteam_name=#FFFFFFFF\r\n;小比分\r\nscoreS=#FFFFFFFF\r\n;大比分\r\nscore=#FFFFFFFF\r\n;计时器\r\ntimmer=#FFFFFFFF\r\n;求生者选手id的队伍名称\r\nSur_team=#FFFFFFFF\r\n;求生者选手id\r\nSur_player=#FFFFFFFF\r\n;监管者选手id\r\nHun_player=#FFFFFFFF\r\n;过场画面\r\n[Interlude_Color]\r\n;队伍名称\r\nteam_name=#FF000000\r\n;选手名称\r\nplayer_name=#FF000000\r\n;游戏内比分\r\n[Score_Color]\r\n;队伍名称\r\nTeamName=#FFFFFFFF\r\n;大比分\r\nScore=#FFFFFFFF\r\n;大比分下面的字\r\nWord=#FFFFFFFF\r\n;小比分\r\nS=#FFFF0000\r\n;分数统计\r\n[ScoreHole_Color]\r\n;队伍名称\r\nName=#FFFFFFFF\r\n;分数\r\nScore=#FFFFFFFF";
            try
            {
                System.IO.File.WriteAllText(batchFilePath, batchFileContent);
                Console.WriteLine("Batch file created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            MessageBox.Show("重置完成，请重启软件", "提示");
        }
    }
}
