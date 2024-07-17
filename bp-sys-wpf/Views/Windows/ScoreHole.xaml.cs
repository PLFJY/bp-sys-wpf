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
            scoreHole = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/score_hole.png")))); } catch { }
            MainName.Foreground = Config.ScoreHole.Color.Name;
            AwayName.Foreground = Config.ScoreHole.Color.Name;
            Bo1FScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo1SScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo1FScoreAway.Foreground = Config.ScoreHole.Color.Score;
            Bo1SScoreAway.Foreground = Config.ScoreHole.Color.Score;

            Bo2FScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo2SScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo2FScoreAway.Foreground = Config.ScoreHole.Color.Score;
            Bo2SScoreAway.Foreground = Config.ScoreHole.Color.Score;

            Bo3FScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo3SScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo3FScoreAway.Foreground = Config.ScoreHole.Color.Score;
            Bo3SScoreAway.Foreground = Config.ScoreHole.Color.Score;

            Bo4FScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo4SScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo4FScoreAway.Foreground = Config.ScoreHole.Color.Score;
            Bo4SScoreAway.Foreground = Config.ScoreHole.Color.Score;

            Bo5FScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo5SScoreMain.Foreground = Config.ScoreHole.Color.Score;
            Bo5FScoreAway.Foreground = Config.ScoreHole.Color.Score;
            Bo5SScoreAway.Foreground = Config.ScoreHole.Color.Score;
        }

        private void ScoreHole1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
