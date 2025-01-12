﻿using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// TeamInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class TeamInfoPage : Page
    {
        public TeamInfoViewModel viewModel = BackWindow.backWindow.rootViewModel.TeamInfoViewModel;
        public static TeamInfoPage teamInfoPage;
        public TeamInfoPage()
        {
            InitializeComponent();
            teamInfoPage = this;
            DataContext = viewModel;
        }
        private void StateChangeMainSur1_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur1.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(0, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(0, "Main", "求生者");
            }
        }

        private void StateChangeMainSur2_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur2.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(1, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(1, "Main", "求生者");
            }
        }

        private void StateChangeMainSur3_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur3.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(2, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(2, "Main", "求生者");
            }
        }

        private void StateChangeMainSur4_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur4.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(3, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(3, "Main", "求生者");
            }
        }

        private void StateChangeMainSur5_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur5.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(4, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(4, "Main", "求生者");
            }
        }

        private void StateChangeMainSur6_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainSur6.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(5, "Main", "求生者");
            }
            else
            {
                viewModel.PlayerOff(5, "Main", "求生者");
            }
        }

        private void StateChangeMainHun1_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainHun1.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(6, "Main", "监管者");
            }
            else
            {
                viewModel.PlayerOff(6, "Main", "监管者");
            }
        }

        private void StateChangeMainHun2_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainHun2.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(7, "Main", "监管者");
            }
            else
            {
                viewModel.PlayerOff(7, "Main", "监管者");
            }
        }

        private void StateChangeMainHun3_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeMainHun3.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(8, "Main", "监管者");
            }
            else
            {
                viewModel.PlayerOff(8, "Main", "监管者");
            }
        }

        private void StateChangeAwaySur1_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur1.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(0, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(0, "Away", "求生者");
            }
        }

        private void StateChangeAwaySur2_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur2.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(1, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(1, "Away", "求生者");
            }
        }

        private void StateChangeAwaySur3_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur3.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(2, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(2, "Away", "求生者");
            }
        }

        private void StateChangeAwaySur4_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur4.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(3, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(3, "Away", "求生者");
            }
        }

        private void StateChangeAwaySur5_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur5.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(4, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(4, "Away", "求生者");
            }
        }

        private void StateChangeAwaySur6_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwaySur6.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(5, "Away", "求生者");
            }
            else
            {
                viewModel.PlayerOff(5, "Away", "求生者");
            }
        }

        private void StateChangeAwayHun1_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwayHun1.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(6, "Away", "监管者");
            }
            else
            {
                viewModel.PlayerOff(6, "Away", "监管者");
            }
        }

        private void StateChangeAwayHun2_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwayHun2.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(7, "Away", "监管者");
            }
            else
            {
                viewModel.PlayerOff(7, "Away", "监管者");
            }
        }

        private void StateChangeAwayHun3_Click(object sender, RoutedEventArgs e)
        {
            if (StateChangeAwayHun3.Content.ToString() == "上场")
            {
                viewModel.PlayersTakeTheField(8, "Away", "监管者");
            }
            else
            {
                viewModel.PlayerOff(8, "Away", "监管者");
            }
        }

        private void TeamNameCheck_Click(object sender, RoutedEventArgs e)
        {
            viewModel.TeamInfoModel = viewModel.TeamInfoModel;
            viewModel.NowModel = viewModel.NowModel;
        }

        private void Swap_sur_player1_with_player2_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(0, 1);
        }

        private void Swap_sur_player1_with_player3_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(0, 2);
        }

        private void Swap_sur_player1_with_player4_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(0, 3);
        }

        private void Swap_sur_player2_with_player1_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(1, 0);
        }

        private void Swap_sur_player2_with_player3_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(1, 2);
        }

        private void Swap_sur_player2_with_player4_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(1, 3);
        }

        private void Swap_sur_player3_with_player1_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(2, 0);
        }

        private void Swap_sur_player3_with_player2_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(2, 1);
        }

        private void Swap_sur_player3_with_player4_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(2, 3);
        }

        private void Swap_sur_player4_with_player1_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(3, 0);
        }

        private void Swap_sur_player4_with_player2_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(3, 1);
        }

        private void Swap_sur_player4_with_player3_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SwapPlayers(3, 2);
        }

        private void Change_main_team_logo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SetTeamLOGO("main");
        }

        private void Change_away_team_logo_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SetTeamLOGO("away");
        }

        private void ImportMainInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.ImportTeamInfoFromJson("main");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入出错" + ex.Message);

            }
        }

        private void ImportAwayInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewModel.ImportTeamInfoFromJson("away");
            }
            catch (Exception ex)
            {
                MessageBox.Show("导入出错" + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QA qA = new QA();
            qA.Show();
            qA.Texts.Text = "这是用于快速导入队伍信息使用的，示例文件在软件目录下的TeamInfoExample.json，里面都写好注释了，照着写就完事了";
        }
    }
}