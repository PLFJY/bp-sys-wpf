using bp_sys_wpf.Views.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// TalentPage.xaml 的交互逻辑
    /// </summary>
    public partial class TalentPage : Page
    {
        public TalentPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }
    }
}
