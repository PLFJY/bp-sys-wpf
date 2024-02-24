using Flurl.Http;
using Flurl;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using MahApps.Metro.Controls.Dialogs;
using System.Security.Policy;
using System.Text;

namespace bp_sys_wpf
{
    /// <summary>
    /// AboutThis.xaml 的交互逻辑
    /// </summary>
    public partial class AboutThis : Window
    {
        public AboutThis()
        {
            InitializeComponent();
            NowV.Content = "当前版本：" + Config.version;
        }

        private async void Update_Click(object sender, RoutedEventArgs e)//自动更新在这里
        {
            var req = await $"https://api.idvasg.cn/api/config/api/v1/admin/config/byTitle".WithHeader("Content-Type", "application/json").WithOAuthBearerToken(File.ReadAllText("Token.txt")).PostStringAsync("\"bpsys_v\"");
            var version = await req.GetStringAsync();
            if (version != Config.version)
            {
                MessageBox.Show("检测到新版本，最新版本为" + version + "\n点击确定或关闭该提示执行更新！", "更新提示");
                var req1 = await $"https://api.idvasg.cn/api/config/api/v1/admin/config/byTitle".WithHeader("Content-Type", "application/json").WithOAuthBearerToken(File.ReadAllText("Token.txt")).PostStringAsync("\"bpsys_URL\"");
                var path = await $"{await req1.GetStringAsync()}"
     .DownloadFileAsync(Environment.CurrentDirectory, "new_bpsys.7z");
                NewBat();
                CreateBat();
                Run_cmd();
            }
            else
            {
                MessageBox.Show("当前版本为最新版本", "更新提示");
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
    if /i not ""%%f""==""7z.exe"" if /i not ""%%f""==""7z.dll"" if /i not ""%%f""==""new_bpsys.7z"" if /i not ""%%f""==""Token.txt"" if /i not ""%%f""==""update.bat"" if /i not ""%%f""==""EndAndUpdate.bat"" (    
        echo Deleting file: %%f    
        del ""%%f""    
    )    
)    
    
:: 检查7z.exe是否存在，如果不存在则退出脚本    
if not exist ""7z.exe"" (    
    echo 7z.exe not found. Exiting script.    
    exit /b    
)    
    
:: 使用7z.exe解压new_bpsys.7z文件，使用-y参数自动确认所有操作    
echo Extracting new_bpsys.7z...    
""7z.exe"" x ""new_bpsys.7z"" -o""%~dp0"" -y    
    
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
                File.WriteAllText(batchFilePath, batchFileContent);
                Console.WriteLine("Batch file created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void CreateBat() {
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
                File.WriteAllText(batchFilePath, batchFileContent);
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
    }
}
