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
    /// ScoreHole.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHole : Window
    {
        public static ScoreHole scoreHole;
        public ScoreHole()
        {
            InitializeComponent();
            scoreHole = this;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/score_hole.png")))); } catch { }
            MainLogo.Source = MainWindow.mainWindow.main_team_logo.Source;
            MainName.Content = MainWindow.mainWindow.Main_team_name.Text;
            AwayLogo.Source = MainWindow.mainWindow.away_team_logo.Source;
            AwayName.Content = MainWindow.mainWindow.Away_team_name.Text;
        }

        private void ScoreHole1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
