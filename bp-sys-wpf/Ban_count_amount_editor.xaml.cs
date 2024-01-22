using System.Windows;

namespace bp_sys_wpf
{
    /// <summary>
    /// Ban_count_amount_editor.xaml 的交互逻辑
    /// </summary>
    public partial class Ban_count_amount_editor : Window
    {
        public Ban_count_amount_editor()
        {
            InitializeComponent();
        }
        private void Hun_ban_state_1_Click(object sender, RoutedEventArgs e)
        {
            if (this.Hun_ban_state_1.IsChecked == false)
            {
                MainWindow.mainWindow.hun_ban_state_1 = false;
                MainWindow.mainWindow.Hun_ban_1.IsEnabled = false;
                Front.front.Hun_no_ban_1.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.hun_ban_state_1 = true;
                MainWindow.mainWindow.Hun_ban_1.IsEnabled = true;
                Front.front.Hun_no_ban_1.Visibility = Visibility.Hidden;
            }
        }

        private void Hun_ban_state_2_Click(object sender, RoutedEventArgs e)
        {
            if (this.Hun_ban_state_2.IsChecked == false)
            {
                MainWindow.mainWindow.hun_ban_state_2 = false;
                MainWindow.mainWindow.Hun_ban_2.IsEnabled = false;
                Front.front.Hun_no_ban_2.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.hun_ban_state_2 = true;
                MainWindow.mainWindow.Hun_ban_2.IsEnabled = true;
                Front.front.Hun_no_ban_2.Visibility = Visibility.Hidden;
            }
        }

        private void Hun_ban_state_3_Click(object sender, RoutedEventArgs e)
        {
            if (this.Hun_ban_state_3.IsChecked == false)
            {
                MainWindow.mainWindow.hun_ban_state_3 = false;
                MainWindow.mainWindow.Hun_ban_3.IsEnabled = false;
                Front.front.Hun_no_ban_3.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.hun_ban_state_3 = true;
                MainWindow.mainWindow.Hun_ban_3.IsEnabled = true;
                Front.front.Hun_no_ban_3.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_1_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_1.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_1 = false;
                MainWindow.mainWindow.Sur_hole_ban_1.IsEnabled = false;
                Front.front.Hole_no_ban_1.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_1 = true;
                MainWindow.mainWindow.Sur_hole_ban_1.IsEnabled = true;
                Front.front.Hole_no_ban_1.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_2_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_2.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_2 = false;
                MainWindow.mainWindow.Sur_hole_ban_2.IsEnabled = false;
                Front.front.Hole_no_ban_2.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_2 = true;
                MainWindow.mainWindow.Sur_hole_ban_2.IsEnabled = true;
                Front.front.Hole_no_ban_2.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_3_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_3.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_3 = false;
                MainWindow.mainWindow.Sur_hole_ban_3.IsEnabled = false;
                Front.front.Hole_no_ban_3.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_3 = true;
                MainWindow.mainWindow.Sur_hole_ban_3.IsEnabled = true;
                Front.front.Hole_no_ban_3.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_4_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_4.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_4 = false;
                MainWindow.mainWindow.Sur_hole_ban_4.IsEnabled = false;
                Front.front.Hole_no_ban_4.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_4 = true;
                MainWindow.mainWindow.Sur_hole_ban_4.IsEnabled = true;
                Front.front.Hole_no_ban_4.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_5_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_5.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_5 = false;
                MainWindow.mainWindow.Sur_hole_ban_5.IsEnabled = false;
                Front.front.Hole_no_ban_5.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_5 = true;
                MainWindow.mainWindow.Sur_hole_ban_5.IsEnabled = true;
                Front.front.Hole_no_ban_5.Visibility = Visibility.Hidden;
            }
        }

        private void All_ban_state_6_Click(object sender, RoutedEventArgs e)
        {
            if (this.All_ban_state_6.IsChecked == false)
            {
                MainWindow.mainWindow.all_ban_state_6 = false;
                MainWindow.mainWindow.Sur_hole_ban_6.IsEnabled = false;
                Front.front.Hole_no_ban_6.Visibility = Visibility.Visible;
            }
            else
            {
                MainWindow.mainWindow.all_ban_state_6 = true;
                MainWindow.mainWindow.Sur_hole_ban_6.IsEnabled = true;
                Front.front.Hole_no_ban_6.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hun_ban_state_1.IsChecked = MainWindow.mainWindow.hun_ban_state_1;
            Hun_ban_state_2.IsChecked = MainWindow.mainWindow.hun_ban_state_2;
            Hun_ban_state_3.IsChecked = MainWindow.mainWindow.hun_ban_state_3;
            All_ban_state_1.IsChecked = MainWindow.mainWindow.all_ban_state_1;
            All_ban_state_2.IsChecked = MainWindow.mainWindow.all_ban_state_2;
            All_ban_state_3.IsChecked = MainWindow.mainWindow.all_ban_state_3;
            All_ban_state_4.IsChecked = MainWindow.mainWindow.all_ban_state_4;
            All_ban_state_5.IsChecked = MainWindow.mainWindow.all_ban_state_5;
            All_ban_state_6.IsChecked = MainWindow.mainWindow.all_ban_state_6;
        }
    }
}
