using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreGlobal.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreGlobal : Window
    {
        public static ScoreGlobal scoreGlobal;
        public ScoreGlobal()
        {
            InitializeComponent();
            GetFilePath getFilePath = new GetFilePath();
            DataContext = BackWindow.backWindow.rootViewModel;
            scoreGlobal = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/score_global.png")))); } catch { }
            MainName.Foreground = Config.ScoreGlobal.Color.Name;
            AwayName.Foreground = Config.ScoreGlobal.Color.Name;
            ScoreMain0.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreMain1.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway0.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway1.Foreground = Config.ScoreGlobal.Color.Score;

            ScoreMain2.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreMain3.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway2.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway3.Foreground = Config.ScoreGlobal.Color.Score;

            ScoreMain4.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreMain5.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway4.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway5.Foreground = Config.ScoreGlobal.Color.Score;

            ScoreMain6.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreMain7.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway6.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway7.Foreground = Config.ScoreGlobal.Color.Score;

            ScoreMain8.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreMain9.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway8.Foreground = Config.ScoreGlobal.Color.Score;
            ScoreAway9.Foreground = Config.ScoreGlobal.Color.Score;
        }

        private void ScoreGlobal1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
