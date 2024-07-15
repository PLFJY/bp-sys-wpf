using bp_sys_wpf.ViewModel;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// PickPage.xaml 的交互逻辑
    /// </summary>
    public partial class PickPage : Page
    {
        ComboBoxItemViewModel comboBoxItemViewModel = new ComboBoxItemViewModel();
        public PickPage()
        {
            InitializeComponent();
            DataContext = comboBoxItemViewModel;
        }
    }
}
