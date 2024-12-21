using Downloader;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
        static string GetFileNameFromUrl(string url)
        {
            int lastSlashIndex = url.LastIndexOf('/');
            if (lastSlashIndex >= 0 && lastSlashIndex < url.Length - 1)
            {
                return url.Substring(lastSlashIndex + 1);
            }
            return null;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Text = $"接收到下载链接：\"{UpdateUrl}\"，开始下载\n";

            temp_directory = CurrentDirectory + "\\Temp";
            if (!Directory.Exists(temp_directory))
            {
                Directory.CreateDirectory(temp_directory);//创建Temp目录
            }
            else
            {
                Directory.Delete(temp_directory, true);
                Directory.CreateDirectory(temp_directory);
            }

            save_directory = Path.Combine(CurrentDirectory, "Temp", GetFileNameFromUrl(UpdateUrl));

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
                Log.Text += $"错误 {ex.ToString()}\n";
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
                    Log.Text += "下载完成，开始解压\n";
                    try
                    {
                        var unzipResult = UnzipFile();
                        if (unzipResult == 0)
                        {
                            Progress.Text = "解压完成";
                            Log.Text += $"解压完成，开始尝试移动和覆盖文件\n";
                            MoveContentsToCurrentDirectory();
                            Progress.Text = "更新完成，即将启动新版应用程序";
                            string newAppFile = Path.Combine(CurrentDirectory, "bp-sys-wpf.exe");
                            // 构建7-Zip解压命令
                            string arguments = $"x \"{save_directory}\" -o\"{temp_directory}\"";
                            var process = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = newAppFile,
                                }
                            };
                            Thread.Sleep(2000);
                            process.Start();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Progress.Text = "解压出错";
                            Log.Text += $"7z解压出现问题，返回码: {unzipResult}\n";
                        }
                    }
                    catch (Exception ex)
                    {
                        Progress.Text = "解压出错";
                        Log.Text += $"{ex.Message}";
                    }
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    Progress.Text = "下载失败";
                    Log.Text += $"下载出错: {e.Error.Message}\n";
                });
            }
        }

        private void MoveContentsToCurrentDirectory()
        {
            // 确保目标文件夹（CurrentDirectory）已存在，若不存在则创建它
            Directory.CreateDirectory(CurrentDirectory);

            // 遍历temp_directory下的所有文件和文件夹（使用EnumerateFileSystemEntries提高效率）
            foreach (var entry in Directory.EnumerateFileSystemEntries(temp_directory))
            {
                string entryName = Path.GetFileName(entry);
                string targetEntry = Path.Combine(CurrentDirectory, entryName);
                if (File.Exists(entry) && entryName != GetFileNameFromUrl(UpdateUrl))
                {
                    try
                    {
                        File.Copy(entry, targetEntry, true);
                    }
                    catch { }
                    // 复制文件到目标文件夹并覆盖已有文件
                    File.Delete(entry); // 删除源文件
                }
                else if (Directory.Exists(entry))
                {
                    MoveDirectory(entry, targetEntry); // 递归处理子文件夹
                }
            }

            // 最后删除源文件夹（temp_directory），前提是里面内容都已成功移动
            Directory.Delete(temp_directory, true);
        }

        private void MoveDirectory(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            foreach (var file in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(file);
                string targetFilePath = Path.Combine(targetDir, fileName);
                File.Copy(file, targetFilePath, true);
                File.Delete(file);
            }
            foreach (var subDir in Directory.GetDirectories(sourceDir))
            {
                string subDirName = Path.GetFileName(subDir);
                string targetSubDir = Path.Combine(targetDir, subDirName);
                MoveDirectory(subDir, targetSubDir);
            }
            Directory.Delete(sourceDir);
        }

        private int UnzipFile()
        {
            string sevenZipPath = Path.Combine(CurrentDirectory, "7z", "7z.exe");
            if (!File.Exists(sevenZipPath))
            {
                Progress.Text = "解压失败";
                Log.Text += $"7z.exe not found in the specified directory.\n";
                return 2;
            }
            // 构建7-Zip解压命令
            string arguments = $"x \"{save_directory}\" -o\"{temp_directory}\"";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = sevenZipPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            try
            {
                process.Start();
                // 可以读取并处理标准输出和错误输出（这里简单示例，可按需完善）
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();
                int exitCode = process.ExitCode;
                if (exitCode == 0)
                {
                    return exitCode;
                }
                return exitCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during operation: {ex.Message}");
            }
        }
    }
}