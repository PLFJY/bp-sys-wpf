using bp_sys_wpf.Views.Pages;
using System.Windows;

namespace bp_sys_wpf.Views.Windows
{
    /// <summary>
    /// BackWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BackWindow : Window
    {
        public BackWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void RootNavigation_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate(typeof(HomePage));
        }
    }
}
