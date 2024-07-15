using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// InfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public static string version { get; set; } = Config.version;
    }
}
