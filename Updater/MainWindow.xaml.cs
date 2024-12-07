using Downloader;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows;

namespace Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string UpdateUrl = string.Empty;//下载链接
        public string CurrentDirectory = Environment.CurrentDirectory;//获取到的路径形如 C:\Windows\System32
        public string save_directory, temp_directory;
        public MainWindow()
        {
            InitializeComponent();
            if (App.Args.Length == 0 || App.Args[0] != "Update") Environment.Exit(0);//判断是否获得启动参数并且是否由程序发起
            if (App.Args.Length >= 2)
            {
                UpdateUrl = App.Args[1];//将下载链接添加到变量
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Text = $"接收到下载链接：\"{UpdateUrl}\"，开始下载";

            temp_directory = CurrentDirectory + "\\Temp";
            if (Directory.Exists(temp_directory))
                Directory.CreateDirectory(temp_directory);//创建Temp目录

            save_directory = CurrentDirectory + "\\Temp\\new_bpsys.7z";

            //下载
            var downloadOpt = new DownloadConfiguration()
            {
                ChunkCount = 8, // Number of file parts, default is 1
                ParallelDownload = true // Download parts in parallel (default is false)
            };
            var downloader = new DownloadService(downloadOpt);
            downloader.DownloadProgressChanged += OnDownloadProgressChanged;
            downloader.DownloadFileCompleted += OnDownloadFileCompleted;
            try
            {
                await downloader.DownloadFileTaskAsync(UpdateUrl, save_directory);
            }
            catch (Exception ex)
            {
                Progress.Text = "下载失败，请关闭后重新尝试";
                Log.Text += "错误" + ex.ToString();
            }

        }
        private void OnDownloadProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
        {
            //显示进度条
            PbBar.Dispatcher.Invoke(() =>
            {
                PbBar.Value = e.ProgressPercentage;
            });
            //显示百分比
            Progress.Dispatcher.Invoke(() =>
            {
                Progress.Text = $"正在下载：{e.ProgressPercentage:F2}%";
            });
        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Progress.Text = "下载完成";
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Progress.Text = "下载失败";
                    Log.Text += $"下载出错: {e.Error.Message}";
                });
            }
        }
    }
}