using bp_sys_wpf.ViewModel;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// SurBanPage.xaml 的交互逻辑
    /// </summary>
    public partial class SurBanPage : Page
    {
        ComboBoxItemViewModel comboBoxItemViewModel = new ComboBoxItemViewModel();
        public SurBanPage()
        {
            InitializeComponent();
            DataContext = comboBoxItemViewModel;
        }
    }
}
