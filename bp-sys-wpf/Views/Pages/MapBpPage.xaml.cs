using bp_sys_wpf.Views.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// MapBpPage.xaml 的交互逻辑
    /// </summary>
    public partial class MapBpPage : Page
    {
        public MapBpPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }

        private void GameProgressCheck_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Front.front.GameProgress.Text = GameProgressEdit.Text;
            }
            catch
            {
                BackWindow.backWindow.MessageBar.IsOpen = true;
                BackWindow.backWindow.MessageBar.Title = "错误";
                BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                BackWindow.backWindow.MessageBar.Message = "请先启动前台";
            }
        }
    }
}
