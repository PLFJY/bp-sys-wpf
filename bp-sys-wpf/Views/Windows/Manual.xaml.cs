using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;

namespace bp_sys_wpf
{
    /// <summary>
    /// Manual.xaml 的交互逻辑
    /// </summary>
    public partial class Manual : Window
    {
        RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
        public Manual()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            rootViewModel.TeamInfoViewModel.ScoreViewRefresh();
            rootViewModel.TeamInfoViewModel.RefreshNow();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.S = 0;
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.S = 0;
            Refresh();
        }

        private void MainWinAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.W++;
            Refresh();
        }

        private void MainTieAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.D++;
            Refresh();
        }

        private void MainLoseAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.L++;
            Refresh();
        }

        private void MainSAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.S++;
            Refresh();
        }

        private void MainWinMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.W--;
            Refresh();
        }

        private void MainTieMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.D--;
            Refresh();
        }

        private void MainLoseMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.L--;
            Refresh();
        }

        private void MainSMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.MainTeamInfo.Score.S--;
            Refresh();
        }

        private void AwayWinAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.W++;
            Refresh();
        }

        private void AwayLoseAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.D++;
            Refresh();
        }

        private void AwayTieAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.L++;
            Refresh();
        }

        private void AwaySAdd_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.S++;
            Refresh();
        }

        private void AwayWinMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.W--;
            Refresh();
        }

        private void AwayTieMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.D--;
            Refresh();
        }

        private void AwayLoseMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.L--;
            Refresh();
        }

        private void AwaySMinus_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.TeamInfoModel.AwayTeamInfo.Score.S--;
            Refresh();
        }
    }
}
