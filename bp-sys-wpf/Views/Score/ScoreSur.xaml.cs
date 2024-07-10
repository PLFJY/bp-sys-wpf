using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreSur.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreSur : Window
    {
        public static ScoreSur scoreSur;
        public ScoreSur()
        {
            InitializeComponent();
            scoreSur = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("Resource/gui/score_bg_s.png")))); } catch { }
            TeamName.Foreground = Config.Score.Color.TeamName;
            S.Foreground = Config.Score.Color.S;
            Win.Foreground = Config.Score.Color.Score;
            Lose.Foreground = Config.Score.Color.Score;
            All.Foreground = Config.Score.Color.Score;
            WinWord.Foreground = Config.Score.Color.Word;
            LoseWord.Foreground = Config.Score.Color.Word;
            AllWord.Foreground = Config.Score.Color.Word;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
