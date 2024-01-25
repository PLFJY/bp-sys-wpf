using Microsoft.Win32;
using System.Diagnostics;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Timers;
using System.Linq;

namespace bp_sys_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public string main_states = "sur", away_states = "hun";
        public bool hun_ban_state_1 = true, hun_ban_state_2 = true, hun_ban_state_3 = true, all_ban_state_1 = true, all_ban_state_2 = true, all_ban_state_3 = true, all_ban_state_4 = true, all_ban_state_5 = true, all_ban_state_6 = true;
        public string[] main_team_player_list = new string[8], away_team_player_list = new string[8];
        public bool[] main_team_player_state = new bool[8], away_team_player_state = new bool[8];
        public int count_main_sur = 0, count_away_sur = 0, count_main_hun = 0, count_away_hun = 0;
        private DispatcherTimer dispatcherTimer;
        private int countdownTime;
        private string GetFilePath(string type, string selectedValue)
        {
            string temp = "pack://application:,,,/pic/" + type + "/";
            int spaceIndex = selectedValue.IndexOf(' ');
            selectedValue = selectedValue.Substring(spaceIndex + 1);
            string file_path = temp + selectedValue + ".png";
            return file_path;
        }
        private void Hun_ban_1_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Hun_ban_1.SelectedItem != null)
                {

                    this.Hun_ban_review_1.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_1.SelectedItem.ToString())));
                    Front.front.Hun_ban_1.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_1.SelectedItem.ToString())));
                }
            }
        }
        private void Hun_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Hun_ban_2.SelectedItem != null)
                {
                    this.Hun_ban_review_2.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_2.SelectedItem.ToString())));
                    Front.front.Hun_ban_2.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_2.SelectedItem.ToString())));
                }
            }
        }

        private void Hun_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Hun_ban_3.SelectedItem != null)
                {
                    this.Hun_ban_review_3.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_3.SelectedItem.ToString())));
                    Front.front.Hun_ban_3.Source = new BitmapImage(new Uri(GetFilePath("hunban", Hun_ban_3.SelectedItem.ToString())));
                }
            }
        }

        private void Hun_pick_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_pick.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Hun_pick.SelectedItem != null)
                {
                    this.Hun_pick_review.Source = new BitmapImage(new Uri(GetFilePath("hun", Hun_pick.SelectedItem.ToString())));
                    Front.front.Hun_pick.Source = new BitmapImage(new Uri(GetFilePath("hunhalf", Hun_pick.SelectedItem.ToString())));
                    Interlude.interlude.Hun.Source = new BitmapImage(new Uri(GetFilePath("hunBig", Hun_pick.SelectedItem.ToString())));
                }
            }
        }
        private void Sur_pick_1_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_pick_1.SelectedItem != null)
                {
                    this.Sur_pick_1_preview.Source = new BitmapImage(new Uri(GetFilePath("sur", Sur_pick_1.SelectedItem.ToString())));
                    Front.front.Sur_pick_1.Source = new BitmapImage(new Uri(GetFilePath("surhalf", Sur_pick_1.SelectedItem.ToString())));
                    Interlude.interlude.Sur_1.Source = new BitmapImage(new Uri(GetFilePath("surBig", Sur_pick_1.SelectedItem.ToString())));
                }
            }
        }
        private void Sur_pick_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_pick_2.SelectedItem != null)
                {
                    this.Sur_pick_2_preview.Source = new BitmapImage(new Uri(GetFilePath("sur", Sur_pick_2.SelectedItem.ToString())));
                    Front.front.Sur_pick_2.Source = new BitmapImage(new Uri(GetFilePath("surhalf", Sur_pick_2.SelectedItem.ToString())));
                    Interlude.interlude.Sur_2.Source = new BitmapImage(new Uri(GetFilePath("surBig", Sur_pick_2.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_pick_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_pick_3.SelectedItem != null)
                {
                    this.Sur_pick_3_preview.Source = new BitmapImage(new Uri(GetFilePath("sur", Sur_pick_3.SelectedItem.ToString())));
                    Front.front.Sur_pick_3.Source = new BitmapImage(new Uri(GetFilePath("surhalf", Sur_pick_3.SelectedItem.ToString())));
                    Interlude.interlude.Sur_3.Source = new BitmapImage(new Uri(GetFilePath("surBig", Sur_pick_3.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_pick_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_pick_4.SelectedItem != null)
                {
                    this.Sur_pick_4_preview.Source = new BitmapImage(new Uri(GetFilePath("sur", Sur_pick_4.SelectedItem.ToString())));
                    Front.front.Sur_pick_4.Source = new BitmapImage(new Uri(GetFilePath("surhalf", Sur_pick_4.SelectedItem.ToString())));
                    Interlude.interlude.Sur_4.Source = new BitmapImage(new Uri(GetFilePath("surBig", Sur_pick_4.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_ban_1_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_ban_1.SelectedItem != null)
                {
                    this.Sur_ban_review_1.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_1.SelectedItem.ToString())));
                    Front.front.Sur_ban_1.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_1.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_ban_2.SelectedItem != null)
                {
                    this.Sur_ban_review_2.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_2.SelectedItem.ToString())));
                    Front.front.Sur_ban_2.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_2.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_ban_3.SelectedItem != null)
                {
                    this.Sur_ban_review_3.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_3.SelectedItem.ToString())));
                    Front.front.Sur_ban_3.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_3.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_ban_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_ban_4.SelectedItem != null)
                {
                    this.Sur_ban_review_4.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_4.SelectedItem.ToString())));
                    Front.front.Sur_ban_4.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_ban_4.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_hole_ban_1_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_1.SelectedItem != null)
                {
                    this.Sur_hole_ban_1_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_1.SelectedItem.ToString())));
                    Front.front.Hole_ban_1.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_1.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_hole_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_2.SelectedItem != null)
                {
                    this.Sur_hole_ban_2_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_2.SelectedItem.ToString())));
                    Front.front.Hole_ban_2.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_2.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_hole_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_3.SelectedItem != null)
                {
                    this.Sur_hole_ban_3_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_3.SelectedItem.ToString())));
                    Front.front.Hole_ban_3.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_3.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_hole_ban_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_4.SelectedItem != null)
                {
                    this.Sur_hole_ban_4_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_4.SelectedItem.ToString())));
                    Front.front.Hole_ban_4.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_4.SelectedItem.ToString())));
                }
            }
        }

        private void Now_sur_player_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Front.front.Sur_1_player.Content = Now_sur_player_1.Text;
            if (main_states == "sur")
            {
                Interlude.interlude.Sur_1_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_1.Text;
            }
            else
            {
                Interlude.interlude.Sur_1_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_1.Text;
            }
        }

        private void Now_sur_player_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Front.front.Sur_2_player.Content = Now_sur_player_2.Text;
            if (main_states == "sur")
            {
                Interlude.interlude.Sur_2_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_2.Text;
            }
            else
            {
                Interlude.interlude.Sur_2_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_2.Text;
            }
        }

        private void Now_sur_player_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            Front.front.Sur_3_player.Content = Now_sur_player_3.Text;
            if (main_states == "sur")
            {
                Interlude.interlude.Sur_3_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_3.Text;
            }
            else
            {
                Interlude.interlude.Sur_3_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_3.Text;
            }
        }

        private void Now_sur_player_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            Front.front.Sur_4_player.Content = Now_sur_player_4.Text;
            if (main_states == "sur")
            {
                Interlude.interlude.Sur_4_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_4.Text;
            }
            else
            {
                Interlude.interlude.Sur_4_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_4.Text;
            }
        }
        private void Now_hun_player_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (main_states == "hun")
            {
                Front.front.Hun_player.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
                Interlude.interlude.Hun_player_name.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
            }
            else
            {
                Front.front.Hun_player.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
                Interlude.interlude.Hun_player_name.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
            }
        }

        private void Main_team_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (main_states == "sur")
                {
                    Front.front.Sur_team_name.Content = Main_team_name.Text;
                    Front.front.Sur_1_team.Content = Main_team_name.Text;
                    Front.front.Sur_2_team.Content = Main_team_name.Text;
                    Front.front.Sur_3_team.Content = Main_team_name.Text;
                    Front.front.Sur_4_team.Content = Main_team_name.Text;
                    Interlude.interlude.Sur_team_name.Content = Main_team_name.Text;
                    Interlude.interlude.Sur_1_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_1;
                    Interlude.interlude.Sur_2_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_2;
                    Interlude.interlude.Sur_3_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_3;
                    Interlude.interlude.Sur_4_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_4;
                }
                else
                {
                    Front.front.Hun_team_name.Content = Main_team_name.Text;
                    Front.front.Hun_player.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
                    Interlude.interlude.Hun_team_name.Content = Main_team_name.Text;
                    Interlude.interlude.Hun_player_name.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
                }
            }
        }

        private void Away_team_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (away_states == "sur")
                {
                    Front.front.Sur_team_name.Content = Away_team_name.Text;
                    Front.front.Sur_1_team.Content = Away_team_name.Text;
                    Front.front.Sur_2_team.Content = Away_team_name.Text;
                    Front.front.Sur_3_team.Content = Away_team_name.Text;
                    Front.front.Sur_4_team.Content = Away_team_name.Text;
                    Interlude.interlude.Sur_team_name.Content = Away_team_name.Text;
                    Interlude.interlude.Sur_1_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_1;
                    Interlude.interlude.Sur_2_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_2;
                    Interlude.interlude.Sur_3_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_3;
                    Interlude.interlude.Sur_4_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_4;
                }
                else
                {
                    Front.front.Hun_player.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
                    Front.front.Hun_team_name.Content = Away_team_name.Text;
                    Interlude.interlude.Hun_team_name.Content = Away_team_name.Text;
                    Interlude.interlude.Hun_player_name.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
                }
            }
        }

        private void Swap_sur_player1_with_player2_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_1.Text, Now_sur_player_2.Text) = (Now_sur_player_2.Text, Now_sur_player_1.Text);
        }

        private void Swap_sur_player1_with_player3_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_1.Text, Now_sur_player_3.Text) = (Now_sur_player_3.Text, Now_sur_player_1.Text);
        }

        private void Swap_sur_player1_with_player4_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_1.Text, Now_sur_player_4.Text) = (Now_sur_player_4.Text, Now_sur_player_1.Text);
        }

        private void Swap_sur_player2_with_player1_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_2.Text, Now_sur_player_1.Text) = (Now_sur_player_1.Text, Now_sur_player_2.Text);
        }

        private void Swap_sur_player2_with_player3_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_2.Text, Now_sur_player_3.Text) = (Now_sur_player_3.Text, Now_sur_player_2.Text);
        }

        private void Swap_sur_player2_with_player4_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_2.Text, Now_sur_player_4.Text) = (Now_sur_player_4.Text, Now_sur_player_2.Text);
        }

        private void Swap_sur_player3_with_player1_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_3.Text, Now_sur_player_1.Text) = (Now_sur_player_1.Text, Now_sur_player_3.Text);
        }

        private void Swap_sur_player3_with_player2_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_3.Text, Now_sur_player_2.Text) = (Now_sur_player_2.Text, Now_sur_player_3.Text);
        }

        private void Swap_sur_player3_with_player4_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_3.Text, Now_sur_player_4.Text) = (Now_sur_player_4.Text, Now_sur_player_3.Text);
        }

        private void Swap_sur_player4_with_player1_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_4.Text, Now_sur_player_1.Text) = (Now_sur_player_1.Text, Now_sur_player_4.Text);
        }

        private void Swap_sur_player4_with_player2_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_4.Text, Now_sur_player_2.Text) = (Now_sur_player_2.Text, Now_sur_player_4.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Countdown_set.Text, out int number))
            {
                Front.front.timmer.Content = Countdown_set.Text;
                countdownTime = Convert.ToInt32(Countdown_set.Text);
                dispatcherTimer.Start();
            }
            else
            {
                Countdown_set.Text = null;
            }
        }
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            countdownTime--;
            if (countdownTime <= 0)
            {
                dispatcherTimer.Stop();
            }
            else
            {
                Front.front.timmer.Content = countdownTime.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            Front.front.timmer.Content = "VS";
        }
        bool IsWindowOpen(string windowName)
        {
            return Application.Current.Windows.OfType<Window>().Any(window => window.Name == windowName);
        }

        private void Open_score_Click(object sender, RoutedEventArgs e)
        {
            if (!IsWindowOpen("Score1"))
            {
                Score score = new Score();
                score.Show();
            }
            if (!IsWindowOpen("ScoreSur1"))
            {
                ScoreSur scoreSur = new ScoreSur();
                scoreSur.Show();
            }
            if (!IsWindowOpen("ScoreHun1"))
            {
                ScoreHun scoreHun = new ScoreHun();
                scoreHun.Show();
            }
        }

        private void Swap_sur_player4_with_player3_Click(object sender, RoutedEventArgs e)
        {
            (Now_sur_player_4.Text, Now_sur_player_3.Text) = (Now_sur_player_3.Text, Now_sur_player_4.Text);
        }

        private void Sur_hole_ban_5_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_5.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_5.SelectedItem != null)
                {
                    this.Sur_hole_ban_5_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_5.SelectedItem.ToString())));
                    Front.front.Hole_ban_5.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_5.SelectedItem.ToString())));
                }
            }
        }

        private void Sur_hole_ban_6_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_6.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                if (this.Sur_hole_ban_6.SelectedItem != null)
                {
                    this.Sur_hole_ban_6_preview.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_6.SelectedItem.ToString())));
                    Front.front.Hole_ban_6.Source = new BitmapImage(new Uri(GetFilePath("surban", Sur_hole_ban_6.SelectedItem.ToString())));
                }
            }
        }

        private void Map_pick_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Front.front.Map.Source = new BitmapImage(new Uri(GetFilePath("map", Map_pick.SelectedItem.ToString())));
            Map_bp.map_bp.pick.Source = new BitmapImage(new Uri(GetFilePath("map", Map_pick.SelectedItem.ToString())));
        }

        private void Map_ban_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Map_bp.map_bp.ban.Source = new BitmapImage(new Uri(GetFilePath("mapban", Map_ban.SelectedItem.ToString())));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            //combobox rest
            Hun_ban_1.SelectedItem = null;
            Hun_ban_2.SelectedItem = null;
            Hun_ban_3.SelectedItem = null;
            Hun_pick.SelectedItem = null;
            Sur_ban_1.SelectedItem = null;
            Sur_ban_2.SelectedItem = null;
            Sur_ban_3.SelectedItem = null;
            Sur_ban_4.SelectedItem = null;
            Sur_pick_1.SelectedItem = null;
            Sur_pick_2.SelectedItem = null;
            Sur_pick_3.SelectedItem = null;
            Sur_pick_4.SelectedItem = null;
            Sur_hole_ban_1.SelectedItem = null;
            Sur_hole_ban_2.SelectedItem = null;
            Sur_hole_ban_3.SelectedItem = null;
            Sur_hole_ban_4.SelectedItem = null;
            Sur_hole_ban_5.SelectedItem = null;
            Sur_hole_ban_6.SelectedItem = null;
            // image rest
            this.Hun_ban_review_1.Source = null;
            Front.front.Hun_ban_1.Source = null;
            this.Hun_ban_review_2.Source = null;
            Front.front.Hun_ban_2.Source = null;
            this.Hun_ban_review_3.Source = null;
            Front.front.Hun_ban_3.Source = null;
            this.Hun_pick_review.Source = null;
            Front.front.Hun_pick.Source = null;
            Interlude.interlude.Hun.Source = null;
            this.Sur_pick_1_preview.Source = null;
            Front.front.Sur_pick_1.Source = null;
            Interlude.interlude.Sur_1.Source = null;
            this.Sur_pick_2_preview.Source = null;
            Front.front.Sur_pick_2.Source = null;
            Interlude.interlude.Sur_2.Source = null;
            this.Sur_pick_3_preview.Source = null;
            Front.front.Sur_pick_3.Source = null;
            Interlude.interlude.Sur_3.Source = null;
            this.Sur_pick_4_preview.Source = null;
            Front.front.Sur_pick_4.Source = null;
            Interlude.interlude.Sur_4.Source = null;
            this.Sur_ban_review_1.Source = null;
            Front.front.Sur_ban_1.Source = null;
            this.Sur_ban_review_2.Source = null;
            Front.front.Sur_ban_2.Source = null;
            this.Sur_ban_review_3.Source = null;
            Front.front.Sur_ban_3.Source = null;
            this.Sur_ban_review_4.Source = null;
            Front.front.Sur_ban_4.Source = null;
            this.Sur_hole_ban_1_preview.Source = null;
            Front.front.Hole_ban_1.Source = null;
            this.Sur_hole_ban_2_preview.Source = null;
            Front.front.Hole_ban_2.Source = null;
            this.Sur_hole_ban_3_preview.Source = null;
            Front.front.Hole_ban_3.Source = null;
            this.Sur_hole_ban_4_preview.Source = null;
            Front.front.Hole_ban_4.Source = null;
            this.Sur_hole_ban_5_preview.Source = null;
            Front.front.Hole_ban_5.Source = null;
            this.Sur_hole_ban_6_preview.Source = null;
            Front.front.Hole_ban_6.Source = null;
        }
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            for (int i = 0; i < 8; i++)
            {
                main_team_player_state[i] = false;
                away_team_player_state[i] = false;
            }
            Front front = new Front();
            front.Show();
            Interlude interlude = new Interlude();
            interlude.Show();
            Map_bp map_Bp = new Map_bp();
            map_Bp.Show();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
        }
        public string OpenImageFileDialog()//打开通用对话框选取图片
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.png;*.jpg"; // 设置过滤器只显示 PNG 和 JPG 文件  
            openFileDialog.Multiselect = false; // 设置只能选择一个文件  

            if (openFileDialog.ShowDialog() == true)
            {
                string FilePath = openFileDialog.FileName; // 获取选定的文件路径
                Debug.WriteLine(FilePath);
                return FilePath;
            }
            return "0";
        }

        private void Change_Main_Team_Logo_Click(object sender, RoutedEventArgs e)
        {
            string logo = OpenImageFileDialog();
            if (logo != "0")
            {
                main_team_logo.Source = new BitmapImage(new Uri(logo));
                if (main_states == "sur")
                {
                    Front.front.Logo_sur.Source = new BitmapImage(new Uri(logo));
                    Interlude.interlude.Sur_logo.Source = new BitmapImage(new Uri(logo));
                }
                else
                {
                    Front.front.Logo_hun.Source = new BitmapImage(new Uri(logo));
                    Interlude.interlude.Hun_logo.Source = new BitmapImage(new Uri(logo));
                }
            }
        }

        private void Change_away_team_logo_Click(object sender, RoutedEventArgs e)
        {
            string logo = OpenImageFileDialog();
            if (logo != "0")
            {
                away_team_logo.Source = new BitmapImage(new Uri(logo));
                if (main_states == "sur")
                {
                    Front.front.Logo_hun.Source = new BitmapImage(new Uri(logo));
                    Interlude.interlude.Hun_logo.Source = new BitmapImage(new Uri(logo));
                }
                else
                {
                    Front.front.Logo_sur.Source = new BitmapImage(new Uri(logo));
                    Interlude.interlude.Sur_logo.Source = new BitmapImage(new Uri(logo));
                }
            }
        }

        private void Edit_main_player_list_Click(object sender, RoutedEventArgs e)
        {
            Player_list_editor player_List_Editor = new Player_list_editor("main");
            player_List_Editor.ShowDialog();
        }

        private void Edit_away_player_list_Click(object sender, RoutedEventArgs e)
        {
            Player_list_editor player_List_Editor = new Player_list_editor("away");
            player_List_Editor.ShowDialog();
        }

        private void Ban_count_amount_Click(object sender, RoutedEventArgs e)
        {
            Ban_count_amount_editor ban_count_amount_editor = new Ban_count_amount_editor();
            ban_count_amount_editor.ShowDialog();

        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            (Front.front.Sur_team_name.Content, Front.front.Hun_team_name.Content) = (Front.front.Hun_team_name.Content, Front.front.Sur_team_name.Content);
            (Front.front.Logo_sur.Source, Front.front.Logo_hun.Source) = (Front.front.Logo_hun.Source, Front.front.Logo_sur.Source);
            (Interlude.interlude.Sur_team_name.Content, Interlude.interlude.Hun_team_name.Content) = (Interlude.interlude.Hun_team_name.Content, Interlude.interlude.Sur_team_name.Content);
            (Interlude.interlude.Sur_logo.Source, Interlude.interlude.Hun_logo.Source) = (Interlude.interlude.Hun_logo.Source, Interlude.interlude.Sur_logo.Source);
            if ((string)this.main_state.Content == "求生者")
            {
                main_state.Content = "监管者";
                main_states = "hun";
                away_state.Content = "求生者";
                away_states = "sur";
                Front.front.Sur_1_team.Content = Away_team_name.Text;
                Front.front.Sur_2_team.Content = Away_team_name.Text;
                Front.front.Sur_3_team.Content = Away_team_name.Text;
                Front.front.Sur_4_team.Content = Away_team_name.Text;
                int flag1 = 1, flag2 = 1, flag3 = 1, flag4 = 1, flag5 = 1;
                for (int i = 0, j = 1; i < 6; i++)
                {
                    if (away_team_player_state[i] == true)
                    {
                        switch (j)
                        {
                            case 1:
                                Now_sur_player_1.Text = away_team_player_list[i];
                                j++;
                                flag1 = 0;
                                break;
                            case 2:
                                Now_sur_player_2.Text = away_team_player_list[i];
                                j++;
                                flag2 = 0;
                                break;
                            case 3:
                                Now_sur_player_3.Text = away_team_player_list[i];
                                j++;
                                flag3 = 0;
                                break;
                            case 4:
                                Now_sur_player_4.Text = away_team_player_list[i];
                                j++;
                                flag4 = 0;
                                break;
                        }
                    }
                }
                if (flag1 == 1) Now_sur_player_1.Text = null;
                if (flag2 == 1) Now_sur_player_2.Text = null;
                if (flag3 == 1) Now_sur_player_3.Text = null;
                if (flag4 == 1) Now_sur_player_4.Text = null;
                if (main_team_player_state[6] == true)
                {
                    Now_hun_player.Text = main_team_player_list[6];
                    flag5 = 0;
                }
                if (main_team_player_state[7] == true)
                {
                    Now_hun_player.Text = main_team_player_list[7];
                    flag5 = 0;
                }
                if (flag5 == 1) Now_hun_player.Text = null;
            }
            else
            {
                main_state.Content = "求生者";
                main_states = "sur";
                away_state.Content = "监管者";
                away_states = "hun";
                Front.front.Sur_1_team.Content = Main_team_name.Text;
                Front.front.Sur_2_team.Content = Main_team_name.Text;
                Front.front.Sur_3_team.Content = Main_team_name.Text;
                Front.front.Sur_4_team.Content = Main_team_name.Text;
                int flag1 = 1, flag2 = 1, flag3 = 1, flag4 = 1, flag5 = 1;
                for (int i = 0, j = 1; i < 6; i++)
                {
                    if (main_team_player_state[i] == true)
                    {
                        switch (j)
                        {
                            case 1:
                                Now_sur_player_1.Text = main_team_player_list[i];
                                j++;
                                flag1 = 0;
                                break;
                            case 2:
                                Now_sur_player_2.Text = main_team_player_list[i];
                                j++;
                                flag2 = 0;
                                break;
                            case 3:
                                Now_sur_player_3.Text = main_team_player_list[i];
                                j++;
                                flag3 = 0;
                                break;
                            case 4:
                                Now_sur_player_4.Text = main_team_player_list[i];
                                j++;
                                flag4 = 0;
                                break;
                        }
                    }
                }
                if (flag1 == 1) Now_sur_player_1.Text = null;
                if (flag2 == 1) Now_sur_player_2.Text = null;
                if (flag3 == 1) Now_sur_player_3.Text = null;
                if (flag4 == 1) Now_sur_player_4.Text = null;
                if (away_team_player_state[6] == true)
                {
                    Now_hun_player.Text = away_team_player_list[6];
                    flag5 = 0;
                }
                if (away_team_player_state[7] == true)
                {
                    Now_hun_player.Text = away_team_player_list[7];
                    flag5 = 0;
                }
                if (flag5 == 1) Now_hun_player.Text = null;
            }
        }
    }
}