using System.Windows;

namespace bp_sys_wpf
{
    /// <summary>
    /// Manual.xaml 的交互逻辑
    /// </summary>
    public partial class Manual : Window
    {
        public Manual()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            Score.score.FrontScoreRefresh();
            Score.score.ScoreCtrWindowRefresh();
            Score.score.ScoreWindowRefresh();
        }
        private void MainWinAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainWin++;
            Refresh();
        }

        private void MainWinMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainWin--;
            Refresh();
        }

        private void MainAllAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainAll++;
            Refresh();
        }

        private void MainLoseMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainLose--;
            Refresh();
        }

        private void MainLoseAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainLose++;
            Refresh();
        }

        private void MainAllMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainAll--;
            Refresh();
        }

        private void MainSAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainS++;
            Refresh();
        }

        private void MainSMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainS--;
            Refresh();
        }

        private void AwayWinAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayWin++;
            Refresh();
        }

        private void AwayWinMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayWin--;
            Refresh();
        }

        private void AwayAllAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayLose++;
            Refresh();
        }

        private void AwayLoseMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayLose--;
            Refresh();
        }

        private void AwayLoseAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayAll++;
            Refresh();
        }

        private void AwayAllMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayAll--;
            Refresh();
        }

        private void AwaySAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayS++;
            Refresh();
        }

        private void AwaySMinus_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.AwayS--;
            Refresh();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainS = 0;
            MainWindow.mainWindow.AwayS = 0;
            Refresh();
        }
    }
}
