using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            QA qA = new QA();
            qA.Show();
            qA.Texts.Text = "Q：选择了角色没反应怎么办？\nA：你试试按一下Tab";
        }
    }
}
