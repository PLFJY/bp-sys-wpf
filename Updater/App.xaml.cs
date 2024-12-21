using System.Windows;

namespace Updater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string[] Args;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // 接收参数数组
            var args = e.Args;
            Args = e.Args;
        }
    }
}
