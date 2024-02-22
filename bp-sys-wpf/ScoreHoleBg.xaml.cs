using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreHoleBg.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHoleBg : Window
    {
        public static ScoreHoleBg scoreHoleBg;
        public ScoreHoleBg()
        {
            InitializeComponent();
            scoreHoleBg = this;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Bo.SelectedIndex += 1;
        }
    }
}
