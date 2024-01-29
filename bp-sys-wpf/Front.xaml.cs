using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// Front.xaml 的交互逻辑
    /// </summary>
    public partial class Front : Window
    {
        public static Front front;
        public Front()
        {
            InitializeComponent();
            front = this;
            MainWindow.mainWindow.Activate();
            try
            {
                this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/bp.png"))));
                Hun_no_ban_1.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hun_ban.png")));
                Hun_no_ban_2.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hun_ban.png")));
                Hun_no_ban_3.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hun_ban.png")));
                Hole_no_ban_1.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
                Hole_no_ban_2.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
                Hole_no_ban_3.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
                Hole_no_ban_4.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
                Hole_no_ban_5.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
                Hole_no_ban_6.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/no_hole_ban.png")));
            }
            catch { }
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
