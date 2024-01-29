using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreHun.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHun : Window
    {
        public static ScoreHun scoreHun;
        public ScoreHun()
        {
            InitializeComponent();
            scoreHun = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/score_bg_h.png")))); } catch { }
        }
        private void ScoreHun1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
