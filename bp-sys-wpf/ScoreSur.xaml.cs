using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/score_bg_s.png")))); } catch { }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
