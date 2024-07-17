using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// SurBanPage.xaml 的交互逻辑
    /// </summary>
    public partial class SurBanPage : Page
    {
        public SurBanPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }
    }
}
