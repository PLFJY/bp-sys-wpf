using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreHole.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHole : Window
    {
        public static ScoreHole scoreHole;
        public ScoreHole()
        {
            InitializeComponent();
            GetFilePath getFilePath = new GetFilePath();
            DataContext = BackWindow.backWindow.rootViewModel;
            scoreHole = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/score_hole.png")))); } catch { }
            MainName.Foreground = Config.ScoreHole.Color.Name;
            AwayName.Foreground = Config.ScoreHole.Color.Name;
            ScoreMain0.Foreground = Config.ScoreHole.Color.Score;
            ScoreMain1.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway0.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway1.Foreground = Config.ScoreHole.Color.Score;

            ScoreMain2.Foreground = Config.ScoreHole.Color.Score;
            ScoreMain3.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway2.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway3.Foreground = Config.ScoreHole.Color.Score;

            ScoreMain4.Foreground = Config.ScoreHole.Color.Score;
            ScoreMain5.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway4.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway5.Foreground = Config.ScoreHole.Color.Score;

            ScoreMain6.Foreground = Config.ScoreHole.Color.Score;
            ScoreMain7.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway6.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway7.Foreground = Config.ScoreHole.Color.Score;

            ScoreMain8.Foreground = Config.ScoreHole.Color.Score;
            ScoreMain9.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway8.Foreground = Config.ScoreHole.Color.Score;
            ScoreAway9.Foreground = Config.ScoreHole.Color.Score;
        }

        private void ScoreHole1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
