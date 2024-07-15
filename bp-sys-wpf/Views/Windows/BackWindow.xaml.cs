using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Pages;
using System.Windows;

namespace bp_sys_wpf.Views.Windows
{
    /// <summary>
    /// BackWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BackWindow : Window
    {
        public static BackWindow backWindow = new BackWindow();
        public BackWindow()
        {
            InitializeComponent();
            backWindow = this;
        }
        private void RootNavigation_Loaded(object sender, RoutedEventArgs e)
        {
            RootNavigation.Navigate(typeof(HomePage));
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            TeamInfoPage.teamInfoPage.viewModel.Swap();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
