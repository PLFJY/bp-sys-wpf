using System.Windows;
using System.Windows.Input;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreHun.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHun : Window
    {
        public static ScoreHun scoreHun;
        public ScoreHun()
        {
            InitializeComponent();
            scoreHun = this;
        }

        private void ScoreHun1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
