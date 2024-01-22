using System.Windows;

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
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
