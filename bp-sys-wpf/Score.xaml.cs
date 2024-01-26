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
    /// Score.xaml 的交互逻辑
    /// </summary>
    public partial class Score : Window
    {
        public static Score score;
        public Score()
        {
            InitializeComponent();
            score = this;
        }

        private void OpenManual_Click(object sender, RoutedEventArgs e)
        {
            Manual manual = new Manual();
            manual.ShowDialog();
        }

        private void Escape4_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.mainWindow.main_states == "sur")
            {
                MainWindow.mainWindow.MainS += 5;
                MainWindow.mainWindow.MainHoleS += 5;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
            }
            else
            {
                MainWindow.mainWindow.AwayS += 5;
                MainWindow.mainWindow.AwayHoleS += 5;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
            }
        }

        private void Escape3_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.main_states == "sur")
            {
                MainWindow.mainWindow.MainS += 3;
                MainWindow.mainWindow.MainHoleS += 3;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
                MainWindow.mainWindow.AwayS += 2;
                MainWindow.mainWindow.AwayHoleS += 2;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;
            }
            else
            {
                MainWindow.mainWindow.MainS += 2;
                MainWindow.mainWindow.MainHoleS += 2;
                ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
                MainWindow.mainWindow.AwayS += 3;
                MainWindow.mainWindow.AwayHoleS += 3;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;
            }
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.MainS += 2;
            MainWindow.mainWindow.MainHoleS += 2;
            ScoreSur.scoreSur.S.Content = MainWindow.mainWindow.MainS;
            Front.front.Sur_scoreS.Content = MainWindow.mainWindow.MainS;
            MainWindow.mainWindow.AwayS += 2;
            MainWindow.mainWindow.AwayHoleS += 2;
            ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
            Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;

        }

        private void Out4_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.main_states == "Hun")
            {
                MainWindow.mainWindow.MainS += 5;
                MainWindow.mainWindow.MainHoleS += 5;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;
            }
            else
            {
                MainWindow.mainWindow.AwayS += 5;
                MainWindow.mainWindow.AwayHoleS += 5;
                ScoreHun.scoreHun.S.Content = MainWindow.mainWindow.MainS;
                Front.front.Hun_scoreS.Content = MainWindow.mainWindow.MainS;
            }
        }

        private void Settlement_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.MainS == MainWindow.mainWindow.AwayS)
            {
                MainWindow.mainWindow.MainAll++;
                MainWindow.mainWindow.AwayAll++;
                ScoreSur.scoreSur.All.Content = MainWindow.mainWindow.MainAll;
                ScoreHun.scoreHun.All.Content = MainWindow.mainWindow.AwayAll;
                if (MainWindow.mainWindow.main_states == "sur")
                {
                    Front.front.Sur_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                }
                else
                {
                    Front.front.Hun_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                }
            }
            else
            {
                if (MainWindow.mainWindow.MainS > MainWindow.mainWindow.AwayS)
                {
                    MainWindow.mainWindow.MainWin++;
                    MainWindow.mainWindow.AwayLose++;
                    if (MainWindow.mainWindow.main_states == "sur")
                    {
                        ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.MainWin;
                        ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.AwayLose;
                        Front.front.Sur_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                    }
                    else
                    {
                        ScoreSur.scoreSur.Lose.Content = MainWindow.mainWindow.AwayLose;
                        ScoreHun.scoreHun.Win.Content = MainWindow.mainWindow.MainWin;
                        Front.front.Hun_score.Content = "W" + MainWindow.mainWindow.MainWin.ToString() + " D" + MainWindow.mainWindow.MainAll.ToString() + " L" + MainWindow.mainWindow.MainLose.ToString();
                    }
                }
                else
                {
                    MainWindow.mainWindow.AwayWin++;
                    MainWindow.mainWindow.MainLose++;
                    if (MainWindow.mainWindow.away_states == "sur")
                    {
                        ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.AwayWin;
                        ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.MainWin;
                        Front.front.Sur_score.Content = "W" + MainWindow.mainWindow.AwayWin.ToString() + " D" + MainWindow.mainWindow.AwayAll.ToString() + " L" + MainWindow.mainWindow.AwayLose.ToString();
                    }
                    else
                    {
                        ScoreSur.scoreSur.Win.Content = MainWindow.mainWindow.AwayWin;
                        ScoreHun.scoreHun.Lose.Content = MainWindow.mainWindow.MainLose;
                        Front.front.Hun_score.Content = "W" + MainWindow.mainWindow.AwayWin.ToString() + " D" + MainWindow.mainWindow.AwayAll.ToString() + " L" + MainWindow.mainWindow.AwayLose.ToString();
                    }
                }
            }
            MainWindow.mainWindow.MainS = 0;
            MainWindow.mainWindow.AwayS = 0;
            ScoreSur.scoreSur.S.Content = "0";
            ScoreHun.scoreHun.S.Content = "0";
            Front.front.Hun_scoreS.Content = "0";
            Front.front.Sur_scoreS.Content = "0";
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
            //前台界面归零
            ScoreSur.scoreSur.Win.Content = "0";
            ScoreSur.scoreSur.Lose.Content = "0";
            ScoreSur.scoreSur.All.Content = "0";
            ScoreSur.scoreSur.S.Content = "0";
            Front.front.Sur_score.Content = "W0 D0 L0";
            Front.front.Sur_scoreS.Content = "0";
            ScoreHun.scoreHun.Win.Content = "0";
            ScoreHun.scoreHun.Lose.Content = "0";
            ScoreHun.scoreHun.All.Content = "0";
            ScoreHun.scoreHun.S.Content = "0";
            Front.front.Hun_score.Content = "W0 D0 L0";
            Front.front.Hun_scoreS.Content = "0";
        }
    }
}