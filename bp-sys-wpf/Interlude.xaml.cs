using System.Windows;
using System.Windows.Input;

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
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
