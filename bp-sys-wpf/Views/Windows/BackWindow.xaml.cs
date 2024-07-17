using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Pages;
using IniParser;
using IniParser.Model;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Diagnostics;

namespace bp_sys_wpf.Views.Windows
{
    /// <summary>
    /// BackWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BackWindow : Window
    {
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
        }
        private void AppInitialize()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\Resource\\Config.ini");
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
            TeamInfoPage.teamInfoPage.viewModel.Swap();
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
                (new Front()).Show();
                (new Interlude()).Show();
                (new Map_bp()).Show();
                (new ScoreHun()).Show();
                (new ScoreSur()).Show();
                (new ScoreHole()).Show();
                IsFrontsChreated = true;
                Thread.Sleep(500);
                backWindow.Activate();
            }
            else
            {
                ErrBar.IsOpen = true;
                ErrBar.Message = "请勿重复启动";
            }
        }
    }
}
