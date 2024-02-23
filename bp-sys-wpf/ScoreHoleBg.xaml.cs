using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// ScoreHoleBg.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreHoleBg : Window
    {
        public static ScoreHoleBg scoreHoleBg;
        private bool[] gameState = new bool[11];
        public string GetAbsoluteFilePath(string filePath)
        {
            // 获取应用程序的运行目录  
            string appDir = Environment.CurrentDirectory; // 在WPF中可以使用Environment.CurrentDirectory获取当前目录  
                                                          // 拼接路径获取绝对路径  
            string absoluteFilePath = Path.Combine(appDir, filePath);
            return absoluteFilePath;
        }
        public BitmapImage ImageGet(string filePath)
        {
            return new BitmapImage(new Uri(GetAbsoluteFilePath(filePath)));
        }
        public ScoreHoleBg()
        {
            InitializeComponent();
            scoreHoleBg = this;
            Bo.SelectedIndex = 0;
            IsGameFinished.IsChecked = gameState[Bo.SelectedIndex];
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Bo.SelectedIndex += 1;
            IsGameFinished.IsChecked = gameState[Bo.SelectedIndex];
            MainTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            AwayTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            ThisGameResults.IsEnabled = gameState[Bo.SelectedIndex];
        }

        private void IsMainSur_Checked(object sender, RoutedEventArgs e)
        {
            IsAwayHun.IsChecked = true;
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo1FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo1FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 1:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo1SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo1SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 2:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo2FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo2FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 3:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo2SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo2SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 4:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo3FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo3FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 5:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo3SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo3SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 6:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo4FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo4FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 7:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo4SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo4SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 8:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo5FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo5FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
                case 9:
                    if ((bool)IsMainSur.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo5SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo5SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                    }
                    break;
            }
        }

        private void Bo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsGameFinished.IsChecked = gameState[Bo.SelectedIndex];
            MainTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            AwayTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            ThisGameResults.IsEnabled = gameState[Bo.SelectedIndex];
            if (Bo.SelectedIndex == 9)
            {
                Next.IsEnabled = false;
            }
            else
            {
                Next.IsEnabled = true;
            }
        }
        private void IsMainHun_Checked(object sender, RoutedEventArgs e)
        {
            IsAwaySur.IsChecked = true;
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo1FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo1FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 1:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo1SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo1SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 2:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo2FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo2FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 3:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo2SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo2SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 4:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo3FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo3FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 5:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo3SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo3SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 6:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo4FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo4FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 7:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo4SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo4SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 8:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo5FIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/hun.png"));
                        ScoreHole.scoreHole.Bo5FIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
                case 9:
                    if ((bool)IsMainHun.IsChecked)
                    {
                        ScoreHole.scoreHole.Bo5SIconMain.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                        ScoreHole.scoreHole.Bo5SIconAway.Source = ImageGet(GetAbsoluteFilePath("gui/sur.png"));
                    }
                    break;
            }
        }

        private void IsAwaySur_Checked(object sender, RoutedEventArgs e)
        {
            IsMainHun.IsChecked = true;
        }

        private void IsAwayHun_Checked(object sender, RoutedEventArgs e)
        {
            IsMainSur.IsChecked = true;
        }

        private void IsGameFinished_Click(object sender, RoutedEventArgs e)
        {
            gameState[Bo.SelectedIndex] = (bool)IsGameFinished.IsChecked;
            MainTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            AwayTeamState.IsEnabled = gameState[Bo.SelectedIndex];
            ThisGameResults.IsEnabled = gameState[Bo.SelectedIndex];
            IsMainSur.IsChecked = false;
            IsMainHun.IsChecked = false;
            IsAwaySur.IsChecked = false;
            IsAwayHun.IsChecked = false;
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo1FIconMain.Source = null;
                        ScoreHole.scoreHole.Bo1FIconAway.Source = null;
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = "-";
                    }
                    break;
                case 1:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo1SIconMain.Source = null;
                        ScoreHole.scoreHole.Bo1SIconAway.Source = null;
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = "-";
                    }
                    break;
                case 2:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo2FIconMain.Source = null;
                        ScoreHole.scoreHole.Bo2FIconAway.Source = null;
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = "-";
                    }
                    break;
                case 3:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo2SIconMain.Source = null;
                        ScoreHole.scoreHole.Bo2SIconAway.Source = null;
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = "-";
                    }
                    break;
                case 4:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo3FIconMain.Source = null;
                        ScoreHole.scoreHole.Bo3FIconAway.Source = null;
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = "-";
                    }
                    break;
                case 5:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo3SIconMain.Source = null;
                        ScoreHole.scoreHole.Bo3SIconAway.Source = null;
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = "-";
                    }
                    break;
                case 6:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo4FIconMain.Source = null;
                        ScoreHole.scoreHole.Bo4FIconAway.Source = null;
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = "-";
                    }
                    break;
                case 7:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo4SIconMain.Source = null;
                        ScoreHole.scoreHole.Bo4SIconAway.Source = null;
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = "-";
                    }
                    break;
                case 8:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo5FIconMain.Source = null;
                        ScoreHole.scoreHole.Bo5FIconAway.Source = null;
                        ScoreHole.scoreHole.Bo5FScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo5FScoreAway.Content = "-";
                    }
                    break;
                case 9:
                    if (!gameState[Bo.SelectedIndex])
                    {
                        ScoreHole.scoreHole.Bo5SIconMain.Source = null;
                        ScoreHole.scoreHole.Bo5SIconAway.Source = null;
                        ScoreHole.scoreHole.Bo5SScoreMain.Content = "-";
                        ScoreHole.scoreHole.Bo5SScoreAway.Content = "-";
                    }
                    break;
            }
        }

        private void Escape4_Click(object sender, RoutedEventArgs e)
        {
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 5;
                    }
                    break;
                case 1:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 5;
                    }
                    break;
                case 2:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 5;
                    }
                    break;
                case 3:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 5;
                    }
                    break;
                case 4:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 5;
                    }
                    break;
                case 5:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 5;
                    }
                    break;
                case 6:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 5;
                    }
                    break;
                case 7:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 5;
                    }
                    break;
                case 8:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo5FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo5FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo5FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo5FScoreAway.Content = 5;
                    }
                    break;
                case 9:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo5SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo5SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo5SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo5SScoreAway.Content = 5;
                    }
                    break;
            }
        }

        private void Escape3_Click(object sender, RoutedEventArgs e)
        {
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 3;
                    }
                    break;
                case 1:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 3;
                    }
                    break;
                case 2:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 3;
                    }
                    break;
                case 3:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 3;
                    }
                    break;
                case 4:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 3;
                    }
                    break;
                case 5:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 3;
                    }
                    break;
                case 6:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 3;
                    }
                    break;
                case 7:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 3;
                    }
                    break;
                case 8:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 3;
                    }
                    break;
                case 9:
                    if (IsMainSur.IsChecked == true)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 3;
                    }
                    break;
            }
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            switch (Bo.SelectedIndex)
            {
                case 0:
                    ScoreHole.scoreHole.Bo1FScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo1FScoreAway.Content = 2;
                    break;
                case 1:
                    ScoreHole.scoreHole.Bo1SScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo1SScoreAway.Content = 2;
                    break;
                case 2:
                    ScoreHole.scoreHole.Bo2FScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo2FScoreAway.Content = 2;
                    break;
                case 3:
                    ScoreHole.scoreHole.Bo2SScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo2SScoreAway.Content = 2;
                    break;
                case 4:
                    ScoreHole.scoreHole.Bo3FScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo3FScoreAway.Content = 2;
                    break;
                case 5:
                    ScoreHole.scoreHole.Bo3SScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo3SScoreAway.Content = 2;
                    break;
                case 6:
                    ScoreHole.scoreHole.Bo4FScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo4FScoreAway.Content = 2;
                    break;
                case 7:
                    ScoreHole.scoreHole.Bo4SScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo4SScoreAway.Content = 2;
                    break;
                case 8:
                    ScoreHole.scoreHole.Bo5FScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo5FScoreAway.Content = 2;
                    break;
                case 9:
                    ScoreHole.scoreHole.Bo5SScoreMain.Content = 2;
                    ScoreHole.scoreHole.Bo5SScoreAway.Content = 2;
                    break;
            }
        }

        private void Out4_Click(object sender, RoutedEventArgs e)
        {
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 5;
                    }
                    break;
                case 1:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 5;
                    }
                    break;
                case 2:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 5;
                    }
                    break;
                case 3:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 5;
                    }
                    break;
                case 4:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 5;
                    }
                    break;
                case 5:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 5;
                    }
                    break;
                case 6:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 5;
                    }
                    break;
                case 7:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 5;
                    }
                    break;
                case 8:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo5FScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo5FScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo5FScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo5FScoreAway.Content = 5;
                    }
                    break;
                case 9:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo5SScoreMain.Content = 5;
                        ScoreHole.scoreHole.Bo5SScoreAway.Content = 0;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo5SScoreMain.Content = 0;
                        ScoreHole.scoreHole.Bo5SScoreAway.Content = 5;
                    }
                    break;
            }
        }

        private void Out3_Click(object sender, RoutedEventArgs e)
        {
            switch (Bo.SelectedIndex)
            {
                case 0:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo1FScoreAway.Content = 3;
                    }
                    break;
                case 1:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo1SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo1SScoreAway.Content = 3;
                    }
                    break;
                case 2:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo2FScoreAway.Content = 3;
                    }
                    break;
                case 3:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo2SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo2SScoreAway.Content = 3;
                    }
                    break;
                case 4:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 3;
                    }
                    break;
                case 5:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 3;
                    }
                    break;
                case 6:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo4FScoreAway.Content = 3;
                    }
                    break;
                case 7:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo4SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo4SScoreAway.Content = 3;
                    }
                    break;
                case 8:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3FScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3FScoreAway.Content = 3;
                    }
                    break;
                case 9:
                    if (IsMainSur.IsChecked == false)
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 3;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 1;
                    }
                    else
                    {
                        ScoreHole.scoreHole.Bo3SScoreMain.Content = 1;
                        ScoreHole.scoreHole.Bo3SScoreAway.Content = 3;
                    }
                    break;
            }
        }
    }
}