using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            DataContext = BackWindow.backWindow.rootViewModel;
            GetFilePath getFilePath = new GetFilePath();
            map_bp = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/map_bp.png")))); } catch { }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
