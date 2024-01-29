using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace bp_sys_wpf
{
    /// <summary>
    /// Interlude.xaml 的交互逻辑
    /// </summary>
    public partial class Interlude : Window
    {
        public static Interlude interlude;
        public Interlude()
        {
            InitializeComponent();
            interlude = this;
            MainWindow.mainWindow.Activate();
            try
            {
                this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/interlude_bg.png"))));
                Bottom.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/bottom.png")));
                NameImage.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/name.png")));
            }
            catch { }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
