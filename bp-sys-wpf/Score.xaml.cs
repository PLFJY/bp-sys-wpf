using System.Windows;

namespace bp_sys_wpf
{
    /// <summary>
    /// Score.xaml 的交互逻辑
    /// </summary>
    public partial class Score : Window
    {
        public static Score score;
        public Score()
        {
            InitializeComponent();
            score = this;
            ScoreWindowRefresh();
            ScoreCtrWindowRefresh();
            if (MainWindow.mainWindow.main_states == "sur")
            {
                ScoreSur.scoreSur.TeamName.Content = MainWindow.mainWindow.Main_team_name.Text;
                ScoreHun.scoreHun.TeamName.Content = MainWindow.mainWindow.Away_team_name.Text;
                ScoreSur.scoreSur.Logo.Source = MainWindow.mainWindow.main_team_logo.Source;
                ScoreHun.scoreHun.Logo.Source = MainWindow.mainWindow.away_team_logo.Source;
                ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.MainWin.ToString();
                ScoreSur.scoreSur.All.Content = MainWindow.mainWindow.MainAll.ToString();
                ScoreSur.scoreSur.Lose.Content = MainWindow.mainWindow.MainLose.ToString();
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS.ToString();
                ScoreHun.scoreHun.Win.Content = MainWindow.mainWindow.AwayWin.ToString();
                ScoreHun.scoreHun.All.Content = MainWindow.mainWindow.AwayAll.ToString();
                ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.AwayLose.ToString();
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.AwayS.ToString();
            }
            else
            {
                ScoreSur.scoreSur.TeamName.Content = MainWindow.mainWindow.Away_team_name.Text;
                ScoreHun.scoreHun.TeamName.Content = MainWindow.mainWindow.Main_team_name.Text;
                ScoreSur.scoreSur.Logo.Source = MainWindow.mainWindow.away_team_logo.Source;
                ScoreHun.scoreHun.Logo.Source = MainWindow.mainWindow.main_team_logo.Source;
                ScoreHun.scoreHun.Win.Content = MainWindow.mainWindow.MainWin.ToString();
                ScoreHun.scoreHun.All.Content = MainWindow.mainWindow.MainAll.ToString();
                ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.MainLose.ToString();
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS.ToString();
                ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.AwayWin.ToString();
                ScoreSur.scoreSur.All.Content = MainWindow.mainWindow.AwayAll.ToString();
                ScoreSur.scoreSur.Lose.Content = MainWindow.mainWindow.AwayLose.ToString();
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.AwayS.ToString();
            }
        }
        public void FrontScoreRefresh()
        {
            if (MainWindow.mainWindow.main_states == "sur")
            {
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
                Front.front.Sur_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                Front.front.Hun_score.Content = "W" + MainWindow.mainWindow.AwayWin.ToString() + " D" + MainWindow.mainWindow.AwayAll.ToString() + " L" + MainWindow.mainWindow.AwayLose.ToString();
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.AwayS;
            }
            else
            {
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;
                Front.front.Hun_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.AwayS;
                Front.front.Sur_score.Content = "W" + MainWindow.mainWindow.AwayWin.ToString() + " D" + MainWindow.mainWindow.AwayAll.ToString() + " L" + MainWindow.mainWindow.AwayLose.ToString();
            }
        }
        public void ScoreWindowRefresh()
        {
            if (MainWindow.mainWindow.main_states == "sur")
            {
                ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.MainWin;
                ScoreSur.scoreSur.All.Content = MainWindow.mainWindow.MainAll;
                ScoreSur.scoreSur.Lose.Content = MainWindow.mainWindow.MainLose;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
                ScoreHun.scoreHun.Win.Content = MainWindow.mainWindow.AwayWin;
                ScoreHun.scoreHun.All.Content = MainWindow.mainWindow.AwayAll;
                ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.AwayLose;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.AwayS;
            }
            else
            {
                ScoreHun.scoreHun.Win.Content = MainWindow.mainWindow.MainWin;
                ScoreHun.scoreHun.All.Content = MainWindow.mainWindow.MainAll;
                ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.MainLose;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
                ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.AwayWin;
                ScoreSur.scoreSur.All.Content = MainWindow.mainWindow.AwayAll;
                ScoreSur.scoreSur.Lose.Content = MainWindow.mainWindow.AwayLose;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.AwayS;
            }
        }
        public void ScoreCtrWindowRefresh()
        {
            MainTeamScore.Content = MainWindow.mainWindow.Main_team_name.Text + "W:" + MainWindow.mainWindow.MainWin.ToString() + " D:" + MainWindow.mainWindow.MainAll.ToString() + " L: " + MainWindow.mainWindow.MainLose.ToString() + "小比分" + MainWindow.mainWindow.MainS.ToString() + "总小比分" + MainWindow.mainWindow.MainHoleS.ToString();
            AwayTeamScore.Content = MainWindow.mainWindow.Away_team_name.Text + "W:" + MainWindow.mainWindow.AwayWin.ToString() + " D:" + MainWindow.mainWindow.AwayAll.ToString() + " L: " + MainWindow.mainWindow.AwayLose.ToString() + "小比分" + MainWindow.mainWindow.AwayS.ToString() + "总小比分" + MainWindow.mainWindow.AwayHoleS.ToString();
        }
        private void Escape4_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.mainWindow.main_states == "sur")
            {
                MainWindow.mainWindow.MainS += 5;
                MainWindow.mainWindow.MainHoleS += 5;
            }
            else
            {
                MainWindow.mainWindow.AwayS += 5;
                MainWindow.mainWindow.AwayHoleS += 5;
                
            }
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void Escape3_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.main_states == "sur")
            {
                MainWindow.mainWindow.MainS += 3;
                MainWindow.mainWindow.MainHoleS += 3;
                MainWindow.mainWindow.AwayS += 2;
                MainWindow.mainWindow.AwayHoleS += 2;
            }
            else
            {
                MainWindow.mainWindow.MainS += 2;
                MainWindow.mainWindow.MainHoleS += 2;
                MainWindow.mainWindow.AwayS += 3;
                MainWindow.mainWindow.AwayHoleS += 3;
                
            }
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainS += 2;
            MainWindow.mainWindow.MainHoleS += 2;
            MainWindow.mainWindow.AwayS += 2;
            MainWindow.mainWindow.AwayHoleS += 2;
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();

        }

        private void Out4_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.main_states == "Hun")
            {
                MainWindow.mainWindow.MainS += 5;
                MainWindow.mainWindow.MainHoleS += 5;
                
            }
            else
            {
                MainWindow.mainWindow.AwayS += 5;
                MainWindow.mainWindow.AwayHoleS += 5;
                
            }
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void Settlement_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.MainS == MainWindow.mainWindow.AwayS)
            {
                MainWindow.mainWindow.MainAll++;
                MainWindow.mainWindow.AwayAll++;
            }
            else
            {
                if (MainWindow.mainWindow.MainS > MainWindow.mainWindow.AwayS)
                {
                    MainWindow.mainWindow.MainWin++;
                    MainWindow.mainWindow.AwayLose++;
                }
                else
                {
                    MainWindow.mainWindow.AwayWin++;
                    MainWindow.mainWindow.MainLose++;
                }
            }
            MainWindow.mainWindow.MainS = 0;
            MainWindow.mainWindow.AwayS = 0;
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //变量清零
            MainWindow.mainWindow.MainWin = 0;
            MainWindow.mainWindow.MainLose = 0;
            MainWindow.mainWindow.MainAll = 0;
            MainWindow.mainWindow.MainS = 0;
            MainWindow.mainWindow.AwayWin = 0;
            MainWindow.mainWindow.AwayAll = 0;
            MainWindow.mainWindow.AwayLose = 0;
            MainWindow.mainWindow.AwayS = 0;
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void Out3_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.main_states == "sur")
            {
                MainWindow.mainWindow.MainS += 2;
                MainWindow.mainWindow.MainHoleS += 2;
                MainWindow.mainWindow.AwayS += 3;
                MainWindow.mainWindow.AwayHoleS += 3;
            }
            else
            {
                MainWindow.mainWindow.MainS += 3;
                MainWindow.mainWindow.MainHoleS += 3;
                MainWindow.mainWindow.AwayS += 2;
                MainWindow.mainWindow.AwayHoleS += 2;

            }
            FrontScoreRefresh();
            ScoreCtrWindowRefresh();
            ScoreWindowRefresh();
        }

        private void Score1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!MainWindow.mainWindow.IsWindowOpen("ScoreHun1"))
            {
                ScoreHun.scoreHun.Close();
            }
            
            if (!MainWindow.mainWindow.IsWindowOpen("Score1"))
            {
                Score.score.Close();
            }
            Front.front.Sur_score.Visibility = Visibility.Hidden;
            Front.front.Sur_scoreS.Visibility = Visibility.Hidden;
            Front.front.Hun_score.Visibility = Visibility.Hidden;
            Front.front.Hun_scoreS.Visibility = Visibility.Hidden;
        }
    }
}