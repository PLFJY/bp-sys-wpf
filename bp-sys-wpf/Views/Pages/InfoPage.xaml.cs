using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using Flurl.Http;
using System;
using System.ComponentModel;
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
    public partial class InfoPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public string newVersionInfo { get; set; }
        public string latestVersion { get; set; }
        public static string version { get; set; } = $"当前版本：{Config.version}";

        public UpdateCheck updateCheck = BackWindow.backWindow.updateCheck;
        public InfoPage()
        {
            InitializeComponent();
            if (updateCheck.Issuccessful)
            {
                latestVersion = version == updateCheck.releaseInfo.tag_name ? string.Empty : updateCheck.releaseInfo.tag_name;
                NewVersion.Visibility = version == updateCheck.releaseInfo.tag_name ? Visibility.Visible : Visibility.Collapsed;
                newVersionInfo = $"最新版本更新内容：\n{updateCheck.releaseInfo.body}";
            }
            else
            {
                newVersionInfo = "更新请求失败";
            }
            this.DataContext = this;
        }

        private async void CheckUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string baseUrl = string.Empty, mirrorURL = string.Empty;
            if (Ghproxy.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
                mirrorURL = "https://ghproxy.net/";
            }
            if (Gitee.IsChecked == true)
            {
                baseUrl = "https://gitee.com/api/v5";
            }
            if (Github.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
            }
            await updateCheck.FetchLatestReleaseInfoAsync(baseUrl, mirrorURL);
            if (!updateCheck.Issuccessful)
            {
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
                var version = updateCheck.releaseInfo.tag_name;
                var assets = updateCheck.releaseInfo.assets;
                string url = string.Empty;
                foreach (var item in assets)
                {
                    if (item.name == "bp-sys-wpf.7z")
                    {
                        url = mirrorURL + item.browser_download_url;
                        break;
                    }
                }
                if (version != Config.version)
                {
                    MessageBox.Show("检测到新版本，最新版本为" + version + "\n点击确定或关闭该提示执行更新！", "更新提示");
                    var updaterPath = Path.Combine(Environment.CurrentDirectory, "Updater.exe");
                    if (System.IO.File.Exists(updaterPath))
                    {
                        var updater = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                FileName = updaterPath,
                                Arguments = $"Update {url}"
                            }
                        };
                        updater.Start();
                        Environment.Exit(0);
                    }
                    else
                    {
                        MessageBox.Show("更新器缺失，请前往Github手动下载完整包体\n若无法正常访问，请在浏览器将github.com改为kkgithub.com", "更新提示");
                        var updateurl = "https://github.com/PLFJY/bp-sys-wpf/releases/latest";
                        Process.Start("explorer.exe", updateurl);
                    }
                }
                else
                {
                    MessageBox.Show("当前版本为最新版本", "更新提示");
                }
            }
        }
    }
}
