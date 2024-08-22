using bp_sys_wpf.Model;
using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Pages;
using Flurl.Http;
using IniParser;
using IniParser.Model;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Views.Windows
{
    /// <summary>
    /// BackWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BackWindow : Window
    {
        public class GiteeReleaseInfo
        {
            public string tag_name { get; set; }
            public Assets[] assets { get; set; }
            public class Assets
            {
                public string browser_download_url { get; set; }
            }
        }
        public static BackWindow backWindow;
        public RootViewModel rootViewModel = new RootViewModel();
        public GetFilePath GetFilePath = new GetFilePath();
        private bool IsFrontsChreated;
        public BackWindow()
        {
            InitializeComponent();
            backWindow = this;
            DataContext = rootViewModel;
            AppInitialize();
            UpdateCheck();
            DeleteFiles();
        }
        private void DeleteFiles()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DeleteFilesIfExist(currentDirectory, "update.bat");
            DeleteFilesIfExist(currentDirectory, "EndAndUpdate.bat");
            DeleteFilesIfExist(currentDirectory, "new_bpsys.7z");
        }
        private void DeleteFilesIfExist(string directory, string fileName)
        {
            string filePath = Path.Combine(directory, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch { }
            }
        }
        private void AppInitialize()
        {
            var parser = new FileIniDataParser();
            IniData data = new IniData();
            try
            {
                data = parser.ReadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\Resource\\Config.ini");
            }
            catch
            {
                MessageBox.Show("缺少Resource下的Config.ini文件\n已生成默认文件，请重启该软件", "配置文件加载错误");
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
                Environment.Exit(0);
            }
            Config.Front.Color.team_name = ConvertHexStringToBrush(data["Front_Color"]["team_name"].ToString());
            Config.Front.Color.scoreS = ConvertHexStringToBrush(data["Front_Color"]["scoreS"].ToString());
            Config.Front.Color.score = ConvertHexStringToBrush(data["Front_Color"]["score"].ToString());
            Config.Front.Color.timmer = ConvertHexStringToBrush(data["Front_Color"]["timmer"].ToString());
            Config.Front.Color.Sur_team = ConvertHexStringToBrush(data["Front_Color"]["Sur_team"].ToString());
            Config.Front.Color.Sur_player = ConvertHexStringToBrush(data["Front_Color"]["Sur_player"].ToString());
            Config.Front.Color.Hun_player = ConvertHexStringToBrush(data["Front_Color"]["Hun_player"].ToString());

            Config.Interlude.Color.team_name = ConvertHexStringToBrush(data["Interlude_Color"]["team_name"].ToString());
            Config.Interlude.Color.player_name = ConvertHexStringToBrush(data["Interlude_Color"]["player_name"].ToString());

            Config.Score.Color.TeamName = ConvertHexStringToBrush(data["Score_Color"]["TeamName"].ToString());
            Config.Score.Color.Score = ConvertHexStringToBrush(data["Score_Color"]["Score"].ToString());
            Config.Score.Color.Word = ConvertHexStringToBrush(data["Score_Color"]["Word"].ToString());
            Config.Score.Color.S = ConvertHexStringToBrush(data["Score_Color"]["S"].ToString());

            Config.ScoreHole.Color.Name = ConvertHexStringToBrush(data["ScoreHole_Color"]["Name"].ToString());
            Config.ScoreHole.Color.Score = ConvertHexStringToBrush(data["ScoreHole_Color"]["Score"].ToString());
            
            rootViewModel.BpShowViewModel.ReceiveModel = rootViewModel.BpReceiveModel;
            rootViewModel.BpReceiveModel.BpShowViewModel = rootViewModel.BpShowViewModel;
            rootViewModel.TeamInfoViewModel = rootViewModel.TeamInfoViewModel;
            rootViewModel.TeamInfoViewModel.NowModel = rootViewModel.TeamInfoViewModel.NowModel;
            rootViewModel.TeamInfoViewModel.TeamInfoModel = rootViewModel.TeamInfoViewModel.TeamInfoModel;
            rootViewModel.TimmerViewModel = rootViewModel.TimmerViewModel;
            rootViewModel.ScoreHoleViewModel = rootViewModel.ScoreHoleViewModel;
        }

        public static SolidColorBrush ConvertHexStringToBrush(string hexColor)
        {
            // 移除#号，如果存在的话  
            if (hexColor.StartsWith("#"))
            {
                hexColor = hexColor.Substring(1);
            }
            // 检查长度是否为6或8  
            if (hexColor.Length != 6 && hexColor.Length != 8)
            {
                MessageBox.Show("Config.ini设置的颜色代号格式不合法. 应该为 #RRGGBB 或 #AARRGGBB.", "配置文件加载错误");
                Environment.Exit(0);
            }
            // 根据长度确定是否有透明度部分  
            bool hasAlpha = hexColor.Length == 8;
            // 将十六进制字符串转换为字节数组  
            byte a = hasAlpha ? Convert.ToByte(hexColor.Substring(0, 2), 16) : (byte)255; // 透明度  
            byte r = Convert.ToByte(hexColor.Substring(hasAlpha ? 2 : 0, 2), 16); // 红色  
            byte g = Convert.ToByte(hexColor.Substring(hasAlpha ? 4 : 2, 2), 16); // 绿色  
            byte b = Convert.ToByte(hexColor.Substring(hasAlpha ? 6 : 4, 2), 16); // 蓝色  
            // 创建Color对象  
            Color color = Color.FromArgb(a, r, g, b);
            // 创建SolidColorBrush对象  
            SolidColorBrush solidColorBrush = new SolidColorBrush(color);
            return solidColorBrush;
        }
        private void RootNavigation_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate(typeof(HomePage));
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.Swap();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TimmerStart_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Timmer.Text, out int number))
            {
                rootViewModel.TimmerViewModel.IsCountDownStart = true;
            }
            else
            {
                MessageBox.Show("时间格式错误，请输入数字");
            }
        }

        private void TimmerClose_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TimmerViewModel.IsCountDownStart = false;
        }

        private void StartFronts_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFrontsChreated)
            {
                (new ScoreHun()).Show();
                (new ScoreSur()).Show();
                (new ScoreHole()).Show();
                (new Map_bp()).Show();
                (new Interlude()).Show();
                (new Front()).Show();
                IsFrontsChreated = true;
                Thread.Sleep(500);
                backWindow.Activate();
            }
            else
            {
                MessageBar.IsOpen = true;
                MessageBar.Title = "错误";
                MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                MessageBar.Message = "请勿重复启动";
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)//重置
        {
            //BpReceiveModel
            rootViewModel.BpReceiveModel.SurBan = new List<string>(4) { null, null, null, null };
            rootViewModel.BpReceiveModel.HunBan = new List<string>(3) { null, null, null };
            rootViewModel.BpReceiveModel.SurPick = new List<SurPickInfo>(4) { new SurPickInfo(), new SurPickInfo(), new SurPickInfo(), new SurPickInfo() };
            rootViewModel.BpReceiveModel.HunPick = null;

            //BpShowModel
            rootViewModel.BpShowViewModel.BpShow.SurBan = new List<BitmapImage>(4) { null, null, null, null };
            rootViewModel.BpShowViewModel.BpShow.HunBan = new List<BitmapImage>(3) { null, null, null };
            rootViewModel.BpShowViewModel.BpShow.SurPick = new List<SurPickShowInfo>(4) { new SurPickShowInfo(), new SurPickShowInfo(), new SurPickShowInfo(), new SurPickShowInfo() };
            rootViewModel.BpShowViewModel.BpShow.HunPick = new HunPickShowInfo();

            rootViewModel.BpShowViewModel.BpShow = rootViewModel.BpShowViewModel.BpShow;
            rootViewModel.BpReceiveModel = rootViewModel.BpReceiveModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 弹窗提示是否确定要退出
            MessageBoxResult result = MessageBox.Show("您确定要退出吗？", "关闭提示", MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
            System.Console.WriteLine(result);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true; // 中断点击事件
            }
        }
        public async void UpdateCheck()
        {
            var (version, url) = await FetchLatestReleaseInfoAsync();
            if(version == "请求失败")
            {
                MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Warning;
                MessageBar.Title = "更新提示";
                MessageBar.Message = $"更新获取失败";
                MessageBar.IsOpen = true;
            }
            else
            {
                if (version != Config.version)
                {
                    MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Success;
                    MessageBar.Title = "更新提示";
                    MessageBar.Message = $"检测到新版本，最新版本为{version} 请去关于界面获取更新！";
                    MessageBar.IsOpen = true;
                }
            }
        }
        public async Task<(string latestVersion, string DownloadURL)> FetchLatestReleaseInfoAsync()
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
                // 提取tag_name和第一个browser_download_url
                string latestVersion = releaseInfo.tag_name;
                string downloadUrl = releaseInfo.assets?.Length > 0 ? releaseInfo.assets[0].browser_download_url : null;
                return (latestVersion, downloadUrl);
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine($"请求失败: {ex.Message}");
                return ($"请求失败", ex.Message);
            }
            catch (JsonException jex)
            {
                Console.WriteLine($"JSON解析失败: {jex.Message}");
                return default;
            }
        }
    }
}
