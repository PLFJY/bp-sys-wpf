using System.Windows;
using System.Windows.Input;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreSur.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreSur : Window
    {
        public static ScoreSur scoreSur;
        public ScoreSur()
        {
            InitializeComponent();
            scoreSur = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
