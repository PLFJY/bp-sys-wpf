using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// ScoreControlPage.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreControlPage : Page
    {
        RootViewModel RootViewModel = BackWindow.backWindow.rootViewModel;
        private int num = 0;
        public ScoreControlPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.DataContext;
            Bo.SelectedIndex = 0;
            Bo.ItemsSource = RootViewModel.ComboBoxItemViewModel.BoList5;
            CheckFormatChangeIsAvailable();
        }
        private void CheckFormatChangeIsAvailable()
        {
            string runDir = Environment.CurrentDirectory;
            if (File.Exists($"{runDir}\\Resource\\gui\\score_hole_bo3.png"))
            {
                FormatChangeGroup.Visibility = Visibility.Visible;
            }
            else
            {
                FormatChangeGroup.Visibility = Visibility.Collapsed;
            }
        }
        private void Escape4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ScoreSSet("sur", 4);
        }

        private void Out4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ScoreSSet("hun", 4);
        }

        private void Escape3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ScoreSSet("sur", 3);
        }

        private void Out3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ScoreSSet("hun", 3);
        }

        private void Tie_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ScoreSSet("", 2);
        }

        private void Settlement_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.BigScoreSettlement();
        }

        private void Clear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.TeamInfoViewModel.ClearScoreAll();
        }
        private void Manual_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (new Manual()).ShowDialog();
        }
        private void Bo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            num = Bo.SelectedIndex;
            IsGameFinished.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            MainTeamState.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            AwayTeamState.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            GameResult.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            Statistics_Escape4.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape4;
            Statistics_Escape3.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape3;
            Statistics_Tie.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Tie;
            Statistics_Out4.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out4;
            Statistics_Out3.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out3;
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == "sur")
            {
                IsMainSur.IsChecked = true;
                IsAwayHun.IsChecked = true;
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState == "sur")
            {
                IsMainHun.IsChecked = true;
                IsAwaySur.IsChecked = true;
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == string.Empty)
            {
                IsMainSur.IsChecked = false;
                IsMainHun.IsChecked = false;

                IsAwayHun.IsChecked = false;
                IsAwaySur.IsChecked = false;
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }
        private void NextGame_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Bo.SelectedIndex++;
            num = Bo.SelectedIndex;
        }
        private void IsGameFinished_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished = (bool)IsGameFinished.IsChecked;
            MainTeamState.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            AwayTeamState.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            GameResult.IsEnabled = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished;
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].IsGameFinished == false)
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num] = new Model.GameResault();
                IsMainSur.IsChecked = false;
                IsAwaySur.IsChecked = false;
                IsMainHun.IsChecked = false;
                IsAwayHun.IsChecked = false;
                Statistics_Escape4.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape4;
                Statistics_Escape3.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape3;
                Statistics_Tie.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Tie;
                Statistics_Out4.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out4;
                Statistics_Out3.IsChecked = RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out3;
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void IsMainSur_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GetFilePath getFilePath = new GetFilePath();
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState = "sur";
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState = "hun";
            IsAwayHun.IsChecked = true;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/sur.png")));
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/hun.png")));
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void IsMainHun_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GetFilePath getFilePath = new GetFilePath();
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState = "hun";
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState = "sur";
            IsAwaySur.IsChecked = true;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/hun.png")));
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/sur.png")));
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void IsAwaySur_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GetFilePath getFilePath = new GetFilePath();
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState = "hun";
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState = "sur";
            IsMainHun.IsChecked = true;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/hun.png")));
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/sur.png")));
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void IsAwayHun_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            GetFilePath getFilePath = new GetFilePath();
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState = "sur";
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState = "hun";
            IsMainSur.IsChecked = true;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/sur.png")));
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayIcon = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/hun.png")));
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void RadioButtonStateChange()
        {
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape4 = (bool)Statistics_Escape4.IsChecked;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Escape3 = (bool)Statistics_Escape3.IsChecked;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Tie = (bool)Statistics_Tie.IsChecked;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out3 = (bool)Statistics_Out3.IsChecked;
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].RadioButtonState.Out4 = (bool)Statistics_Out4.IsChecked;
        }
        private void Statistics_Escape4_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButtonStateChange();
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == "sur")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "5";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "0";
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState == "sur")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "0";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "5";
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void Statistics_Escape3_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButtonStateChange();
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == "sur")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "3";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "1";
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState == "sur")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "1";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "3";
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void Statistics_Tie_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButtonStateChange();
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "2";
            RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "2";
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void Statistics_Out4_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButtonStateChange();
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == "hun")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "5";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "0";
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState == "hun")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "0";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "5";
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void Statistics_Out3_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButtonStateChange();
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainTeamState == "hun")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "3";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "1";
            }
            if (RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayTeamState == "hun")
            {
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].MainScore = "1";
                RootViewModel.ScoreHoleViewModel.ScoreHoleShow[num].AwayScore = "3";
            }
            RootViewModel.ScoreHoleViewModel = RootViewModel.ScoreHoleViewModel;
        }

        private void FormatChange_Click(object sender, RoutedEventArgs e)
        {
            string runDir = Environment.CurrentDirectory;
            if (Format.Text == "赛制：BO5")
            {
                try
                {
                    ScoreHole.scoreHole.Background = new ImageBrush(new BitmapImage(new Uri($"{runDir}\\Resource\\gui\\score_hole_bo3.png")));
                    Format.Text = "赛制：BO3";
                    Bo.ItemsSource = RootViewModel.ComboBoxItemViewModel.BoList3;
                }
                catch
                {
                    BackWindow.backWindow.MessageBar.IsOpen = true;
                    BackWindow.backWindow.MessageBar.Title = "错误";
                    BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                    BackWindow.backWindow.MessageBar.Message = "前台窗口未启动";
                }
            }
            else
            {
                try
                {
                    ScoreHole.scoreHole.Background = new ImageBrush(new BitmapImage(new Uri($"{runDir}\\Resource\\gui\\score_hole.png")));
                    Format.Text = "赛制：BO5";
                    Bo.ItemsSource = RootViewModel.ComboBoxItemViewModel.BoList5;
                }
                catch
                {
                    BackWindow.backWindow.MessageBar.IsOpen = true;
                    BackWindow.backWindow.MessageBar.Title = "错误";
                    BackWindow.backWindow.MessageBar.Severity = Wpf.Ui.Controls.InfoBarSeverity.Error;
                    BackWindow.backWindow.MessageBar.Message = "前台窗口未启动";
                }
            }
        }

    }
}
