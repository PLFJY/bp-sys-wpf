using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace bp_sys_wpf
{
    /// <summary>
    /// Map_bp.xaml 的交互逻辑
    /// </summary>
    public partial class Map_bp : Window
    {
        public static Map_bp map_bp;
        public Map_bp()
        {
            InitializeComponent();
            map_bp = this;
            MainWindow.mainWindow.Activate();
            this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/map_bp.png"))));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
