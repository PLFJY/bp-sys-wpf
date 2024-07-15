using bp_sys_wpf.ViewModel;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// HunBanPage.xaml 的交互逻辑
    /// </summary>
    public partial class HunBanPage : Page
    {
        ComboBoxItemViewModel comboBoxItemViewModel = new ComboBoxItemViewModel();
        public HunBanPage()
        {
            InitializeComponent();
            DataContext = comboBoxItemViewModel;
        }
    }
}
