using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using Flurl.Http;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static bp_sys_wpf.Views.Pages.InfoPage;
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
        public string latestVersion { get; set; } = string.Empty;
        public static string version { get; set; } = $"当前版本：{Config.version}";

        public UpdateCheck updateCheck = BackWindow.backWindow.updateCheck;
        public InfoPage()
        {
            InitializeComponent();
            this.DataContext = this;
            if (updateCheck.Issuccessful)
            {
                if (version != updateCheck.releaseInfo.tag_name) latestVersion = $"最新版本：{updateCheck.releaseInfo.tag_name}";
                NewVersion.Visibility = (version != updateCheck.releaseInfo.tag_name) ? Visibility.Visible : Visibility.Collapsed;
                newVersionInfo = $"最新版本更新内容：\n{updateCheck.releaseInfo.body}";
                RaisePropertyChanged("InfoPage");
            }
            else
            {
                newVersionInfo = "更新请求失败";
            }
        }

        private List<string> _FrontSize;

        public List<string> FrontSize
        {
            get
            {
                if (_FrontSize == null)
                {
                    _FrontSize = new List<string>();
                    _FrontSize.Add("1440x810（默认）");
                    _FrontSize.Add("1920x1080");
                    _FrontSize.Add("1280x720");
                    _FrontSize.Add("960x540");
                }
                return _FrontSize;
            }
            set { _FrontSize = value; }
        }

        private List<string> _GhUrl;

        public List<string> GhUrl
        {
            get
            {
                if (_GhUrl == null)
                {
                    _GhUrl = new List<string>();
                    _GhUrl.Add("https://ghproxy.net/");
                    _GhUrl.Add("https://www.ghproxy.cn/");
                    _GhUrl.Add("https://mirror.ghproxy.com/");
                    _GhUrl.Add("https://gh-proxy.com/");
                }
                return _GhUrl;
            }
            set { _GhUrl = value; }
        }

        private List<string> _GhMirrorUrl;

        public List<string> GhMirrorUrl
        {
            get
            {
                if (_GhMirrorUrl == null)
                {
                    _GhMirrorUrl = new List<string>();
                    _GhMirrorUrl.Add("无（不推荐）");
                    _GhMirrorUrl.Add("https://kkgithub.com");
                    _GhMirrorUrl.Add("https://github.site");
                    _GhMirrorUrl.Add("https://github.store");
                    _GhMirrorUrl.Add("https://bgithub.xyz");
                }
                return _GhMirrorUrl;
            }
            set { _GhMirrorUrl = value; }
        }

        private async void CheckUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string baseUrl = string.Empty, proxyURL = string.Empty, mirrorURL = string.Empty;
            if (Ghproxy.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
                proxyURL = GhproxySelect.SelectedValue.ToString();
            }
            if (Gitee.IsChecked == true)
            {
                baseUrl = "https://gitee.com/api/v5";
            }
            if (Github.IsChecked == true)
            {
                baseUrl = "https://api.github.com";
                if (GhmirrorSelect.SelectedIndex != 0)
                {
                    mirrorURL = GhmirrorSelect.SelectedValue.ToString();
                    if (GhmirrorSelect.SelectedIndex == 1)
                        baseUrl = mirrorURL.Insert(8, "api.");
                }
            }
            await updateCheck.FetchLatestReleaseInfoAsync(baseUrl);
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
                    if (item.name == "bp-sys-wpf.7z" || item.name == "bp-sys-wpf.zip")
                    {
                        if (mirrorURL != string.Empty) 
                            url = item.browser_download_url.Replace("https://github.com", mirrorURL);
                        else
                            url = proxyURL + item.browser_download_url;
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
                        MessageBox.Show("更新器缺失，请前往Github手动下载完整包体\n若无法正常访问，请在浏览器将github.com改为github.site", "更新提示");
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

        private async void DownLoadFile(string imageUrl, string savePath)
        {
            try
            {
                // 使用Flurl.Http发送GET请求获取图片的字节流
                var response = await imageUrl.GetAsync();
                byte[] imageBytes = await response.ResponseMessage.Content.ReadAsByteArrayAsync();

                // 将字节流写入到本地文件中
                System.IO.File.WriteAllBytes(savePath, imageBytes);

                Debug.WriteLine("图片已成功保存到指定位置！");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"出现错误: {ex.Message}");
            }
        }
        private UIFileInfo[] uIFileInfo = [];
        private async void DownLoadNewFrontUI_Click(object sender, RoutedEventArgs e)
        {
            if (BackWindow.backWindow.IsFrontsChreated)
            {
                DownLoadNewFrontUI.IsEnabled = false;
                DownLoadNewFrontUI.Content = "下载最新前台UI（不可用，请重启软件后在不启动前台的情况下下载）";
                return;
            }
            await FetchNewUIFileInfoAsync("https://api.github.com");
            foreach (var i in uIFileInfo)
            {
                DownLoadFile($"https://ghproxy.net/{i.download_url}", Path.Combine(Environment.CurrentDirectory, "Resource", "gui", i.name));
            }
            MessageBox.Show("请等待UI替换完成，大概率60s后重启应用程序即可完成", "下载提示");
        }
        public class UIFileInfo
        {
            public string name { get; set; }
            public string download_url { get; set; }
        }
        private async Task FetchNewUIFileInfoAsync(string baseUrl)
        {
            var repository = "plfjy/bp-sys-wpf";
            var subDirctory = "bp-sys-wpf/Resource/gui";
            var releasesUrl = $"{baseUrl}/repos/{repository}/contents/{subDirctory}";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Firefox/116.0";
            string responseJson;
            try
            {
                using (HttpClient client = new())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                    client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                    client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                    // 发起GET请求并获取JSON响应内容
                    HttpResponseMessage response = await client.GetAsync(releasesUrl);
                    response.EnsureSuccessStatusCode();
                    responseJson = await response.Content.ReadAsStringAsync();

                }
                // 使用System.Text.Json进行反序列化
                uIFileInfo = JsonSerializer.Deserialize<UIFileInfo[]>(responseJson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"请求失败: {ex.Message}");
            }
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            if (BackWindow.backWindow.IsFrontsChreated)
            {
                DownLoadNewFrontUI.IsEnabled = false;
                DownLoadNewFrontUI.Content = "下载最新前台UI（不可用，请重启软件后在不启动前台的情况下下载）";
            }
            RaisePropertyChanged("InfoPage");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            QGroupUrl.NavigateUri = "https://qm.qq.com/cgi-bin/qm/qr?k=Ji5tmYRE_FYa9iTCft83NZ5dMsP-zWU9&jump_from=webapi&authKey=pb9fAm3bl0TEu9AX/Lf2/dqVCfnE22e/BdP5zenId9uxq7DoCpcHANBIDvJMncMd";
        }

        private void FrontSizeChange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BackWindow.backWindow.IsFrontsChreated)
            {
                switch (FrontSizeChange.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            Front.front.Width = 1440;
                            Front.front.Height = 810;
                            Interlude.interlude.Width = 1440;
                            Interlude.interlude.Height = 810;
                        }
                        catch
                        {
                            BackWindow.backWindow.MessageBar.IsOpen = true;
                            BackWindow.backWindow.Title = "错误";
                            BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                            BackWindow.backWindow.MessageBar.Message = "前台未启动";
                        }
                        break;
                    case 1:
                        try
                        {
                            Front.front.Width = 1920;
                            Front.front.Height = 1080;
                            Interlude.interlude.Width = 1920;
                            Interlude.interlude.Height = 1080;
                        }
                        catch
                        {
                            BackWindow.backWindow.MessageBar.IsOpen = true;
                            BackWindow.backWindow.Title = "错误";
                            BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                            BackWindow.backWindow.MessageBar.Message = "前台未启动";
                        }
                        break;
                    case 2:
                        try
                        {
                            Front.front.Width = 1280;
                            Front.front.Height = 720;
                            Interlude.interlude.Width = 1280;
                            Interlude.interlude.Height = 720;
                        }
                        catch
                        {
                            BackWindow.backWindow.MessageBar.IsOpen = true;
                            BackWindow.backWindow.Title = "错误";
                            BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                            BackWindow.backWindow.MessageBar.Message = "前台未启动";
                        }
                        break;
                    case 3:
                        try
                        {
                            Front.front.Width = 960;
                            Front.front.Height = 540;
                            Interlude.interlude.Width = 960;
                            Interlude.interlude.Height = 540;
                        }
                        catch
                        {
                            BackWindow.backWindow.MessageBar.IsOpen = true;
                            BackWindow.backWindow.Title = "错误";
                            BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                            BackWindow.backWindow.MessageBar.Message = "前台未启动";
                        }
                        break;
                }
            }
        }
    }
}
