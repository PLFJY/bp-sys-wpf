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
            ScoreHole.scoreHole.MainLogo.Source = MainWindow.mainWindow.main_team_logo.Source;
            ScoreHole.scoreHole.MainTeamName.Content = MainWindow.mainWindow.Main_team_name.Text;
            ScoreHole.scoreHole.AwayLogo.Source = MainWindow.mainWindow.away_team_logo.Source;
            ScoreHole.scoreHole.AwayTeamName.Content = MainWindow.mainWindow.Away_team_name.Text;
            try { this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("gui/score_hole.png")))); } catch { }
        }

        private void ScoreHole1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
