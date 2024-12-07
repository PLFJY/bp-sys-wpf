using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;

namespace Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String UpdateUrl = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            if (App.Args.Length == 0 || App.Args[0] != "Update") Environment.Exit(0);
            if (App.Args.Length >= 2)
            {
                UpdateUrl = App.Args[1];
                Log.Text = "接收到下载链接，开始下载";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}