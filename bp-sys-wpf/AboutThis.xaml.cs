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
        }

        private async void Update_Click(object sender, RoutedEventArgs e)//自动更新在这里
        {
            var req = await $"https://api.idvasg.cn/api/config/api/v1/admin/config/byTitle".WithOAuthBearerToken(File.ReadAllText("Token.txt")).PostStringAsync("bpsys_v");
            var version = await req.GetStringAsync();
            if (version != "2.1.0")
            {
                MessageBox.Show("检测到新版本，即将更新！", "更新提示");
                var req1 = await $"https://api.idvasg.cn/api/config/api/v1/admin/config/byTitle".WithOAuthBearerToken(File.ReadAllText("Token.txt")).PostStringAsync("bpsys_URL");

                var path = await $"{await req1.GetStringAsync()}"
     .DownloadFileAsync(Environment.CurrentDirectory, "new_bpsys.zip");
                System.IO.Compression.ZipFile.ExtractToDirectory($"{Environment.CurrentDirectory}/new_bpsys.zip", Environment.CurrentDirectory);
            }
            else
            {
                MessageBox.Show("当前版本为最新版本", "更新提示");


            }
        }
    }
}
