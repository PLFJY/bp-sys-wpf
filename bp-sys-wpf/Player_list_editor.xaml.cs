using Flurl.Http;
using System.Windows;
namespace bp_sys_wpf
{
    /// <summary>
    /// Player_list_editor.xaml 的交互逻辑
    /// </summary>
    public partial class Player_list_editor : Window
    {
        public string team, teamName;
        public Player_list_editor(string teamm, string teamNamee)
        {
            InitializeComponent();
            team = teamm;
            teamName = teamNamee;
            if (team == "main")
            {
                Sur_player_1.Text = MainWindow.mainWindow.main_team_player_list[0];
                Sur_player_2.Text = MainWindow.mainWindow.main_team_player_list[1];
                Sur_player_3.Text = MainWindow.mainWindow.main_team_player_list[2];
                Sur_player_4.Text = MainWindow.mainWindow.main_team_player_list[3];
                Sur_player_5.Text = MainWindow.mainWindow.main_team_player_list[4];
                Sur_player_6.Text = MainWindow.mainWindow.main_team_player_list[5];
                Hun_player_1.Text = MainWindow.mainWindow.main_team_player_list[6];
                Hun_player_2.Text = MainWindow.mainWindow.main_team_player_list[7];
                if (MainWindow.mainWindow.main_team_player_state[0] == true)
                {
                    this.player_1_play.IsEnabled = false;
                    this.player_1_down.IsEnabled = true;
                }
                else
                {
                    this.player_1_play.IsEnabled = true;
                    this.player_1_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[1] == true)
                {
                    this.player_2_play.IsEnabled = false;
                    this.player_2_down.IsEnabled = true;
                }
                else
                {
                    this.player_2_play.IsEnabled = true;
                    this.player_2_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[2] == true)
                {
                    this.player_3_play.IsEnabled = false;
                    this.player_3_down.IsEnabled = true;
                }
                else
                {
                    this.player_3_play.IsEnabled = true;
                    this.player_3_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[3] == true)
                {
                    this.player_4_play.IsEnabled = false;
                    this.player_4_down.IsEnabled = true;
                }
                else
                {
                    this.player_4_play.IsEnabled = true;
                    this.player_4_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[4] == true)
                {
                    this.player_5_play.IsEnabled = false;
                    this.player_5_down.IsEnabled = true;
                }
                else
                {
                    this.player_5_play.IsEnabled = true;
                    this.player_5_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[5] == true)
                {
                    this.player_6_play.IsEnabled = false;
                    this.player_6_down.IsEnabled = true;
                }
                else
                {
                    this.player_6_play.IsEnabled = true;
                    this.player_6_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[6] == true)
                {
                    this.player_7_play.IsEnabled = false;
                    this.player_7_down.IsEnabled = true;
                }
                else
                {
                    this.player_7_play.IsEnabled = true;
                    this.player_7_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.main_team_player_state[7] == true)
                {
                    this.player_8_play.IsEnabled = false;
                    this.player_8_down.IsEnabled = true;
                }
                else
                {
                    this.player_8_play.IsEnabled = true;
                    this.player_8_down.IsEnabled = false;
                }
            }
            else
            {
                Sur_player_1.Text = MainWindow.mainWindow.away_team_player_list[0];
                Sur_player_2.Text = MainWindow.mainWindow.away_team_player_list[1];
                Sur_player_3.Text = MainWindow.mainWindow.away_team_player_list[2];
                Sur_player_4.Text = MainWindow.mainWindow.away_team_player_list[3];
                Sur_player_5.Text = MainWindow.mainWindow.away_team_player_list[4];
                Sur_player_6.Text = MainWindow.mainWindow.away_team_player_list[5];
                Hun_player_1.Text = MainWindow.mainWindow.away_team_player_list[6];
                Hun_player_2.Text = MainWindow.mainWindow.away_team_player_list[7];
                if (MainWindow.mainWindow.away_team_player_state[0] == true)
                {
                    this.player_1_play.IsEnabled = false;
                    this.player_1_down.IsEnabled = true;
                }
                else
                {
                    this.player_1_play.IsEnabled = true;
                    this.player_1_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[1] == true)
                {
                    this.player_2_play.IsEnabled = false;
                    this.player_2_down.IsEnabled = true;
                }
                else
                {
                    this.player_2_play.IsEnabled = true;
                    this.player_2_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[2] == true)
                {
                    this.player_3_play.IsEnabled = false;
                    this.player_3_down.IsEnabled = true;
                }
                else
                {
                    this.player_3_play.IsEnabled = true;
                    this.player_3_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[3] == true)
                {
                    this.player_4_play.IsEnabled = false;
                    this.player_4_down.IsEnabled = true;
                }
                else
                {
                    this.player_4_play.IsEnabled = true;
                    this.player_4_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[4] == true)
                {
                    this.player_5_play.IsEnabled = false;
                    this.player_5_down.IsEnabled = true;
                }
                else
                {
                    this.player_5_play.IsEnabled = true;
                    this.player_5_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[5] == true)
                {
                    this.player_6_play.IsEnabled = false;
                    this.player_6_down.IsEnabled = true;
                }
                else
                {
                    this.player_6_play.IsEnabled = true;
                    this.player_6_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[6] == true)
                {
                    this.player_7_play.IsEnabled = false;
                    this.player_7_down.IsEnabled = true;
                }
                else
                {
                    this.player_7_play.IsEnabled = true;
                    this.player_7_down.IsEnabled = false;
                }
                if (MainWindow.mainWindow.away_team_player_state[7] == true)
                {
                    this.player_8_play.IsEnabled = false;
                    this.player_8_down.IsEnabled = true;
                }
                else
                {
                    this.player_8_play.IsEnabled = true;
                    this.player_8_down.IsEnabled = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_list[0] = Sur_player_1.Text;
                MainWindow.mainWindow.main_team_player_list[1] = Sur_player_2.Text;
                MainWindow.mainWindow.main_team_player_list[2] = Sur_player_3.Text;
                MainWindow.mainWindow.main_team_player_list[3] = Sur_player_4.Text;
                MainWindow.mainWindow.main_team_player_list[4] = Sur_player_5.Text;
                MainWindow.mainWindow.main_team_player_list[5] = Sur_player_6.Text;
                MainWindow.mainWindow.main_team_player_list[6] = Hun_player_1.Text;
                MainWindow.mainWindow.main_team_player_list[7] = Hun_player_2.Text;
            }
            else
            {
                MainWindow.mainWindow.away_team_player_list[0] = Sur_player_1.Text;
                MainWindow.mainWindow.away_team_player_list[1] = Sur_player_2.Text;
                MainWindow.mainWindow.away_team_player_list[2] = Sur_player_3.Text;
                MainWindow.mainWindow.away_team_player_list[3] = Sur_player_4.Text;
                MainWindow.mainWindow.away_team_player_list[4] = Sur_player_5.Text;
                MainWindow.mainWindow.away_team_player_list[5] = Sur_player_6.Text;
                MainWindow.mainWindow.away_team_player_list[6] = Hun_player_1.Text;
                MainWindow.mainWindow.away_team_player_list[7] = Hun_player_2.Text;
            }
            this.Close();
        }
        private void Player_play_main_window(string player_name, string type)
        {
            if (type == "sur")
            {
                if (MainWindow.mainWindow.Now_sur_player_1.Text == "")
                {
                    MainWindow.mainWindow.Now_sur_player_1.Text = player_name;
                }
                else
                {
                    if (MainWindow.mainWindow.Now_sur_player_2.Text == "")
                    {
                        MainWindow.mainWindow.Now_sur_player_2.Text = player_name;
                    }
                    else
                    {
                        if (MainWindow.mainWindow.Now_sur_player_3.Text == "")
                        {
                            MainWindow.mainWindow.Now_sur_player_3.Text = player_name;
                        }
                        else
                        {
                            if (MainWindow.mainWindow.Now_sur_player_4.Text == "")
                            {
                                MainWindow.mainWindow.Now_sur_player_4.Text = player_name;
                            }
                        }
                    }
                }
            }
            else
            {
                if (MainWindow.mainWindow.Now_hun_player.Text == "")
                {
                    MainWindow.mainWindow.Now_hun_player.Text = player_name;
                }
            }
        }
        private void Player_down_main_window(string player_name, string type)
        {
            if (type == "sur")
            {
                if (MainWindow.mainWindow.Now_sur_player_1.Text == player_name)
                {
                    MainWindow.mainWindow.Now_sur_player_1.Text = "";
                }
                else
                {
                    if (MainWindow.mainWindow.Now_sur_player_2.Text == player_name)
                    {
                        MainWindow.mainWindow.Now_sur_player_2.Text = "";
                    }
                    else
                    {
                        if (MainWindow.mainWindow.Now_sur_player_3.Text == player_name)
                        {
                            MainWindow.mainWindow.Now_sur_player_3.Text = "";
                        }
                        else
                        {
                            if (MainWindow.mainWindow.Now_sur_player_4.Text == player_name)
                            {
                                MainWindow.mainWindow.Now_sur_player_4.Text = "";
                            }
                        }
                    }
                }
            }
            else
            {
                if (MainWindow.mainWindow.Now_hun_player.Text == player_name)
                {
                    MainWindow.mainWindow.Now_hun_player.Text = "";
                }
            }
        }
        //上场下场按钮
        private void player_1_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[0] = true;
                    this.player_1_play.IsEnabled = false;
                    this.player_1_down.IsEnabled = true;
                    MainWindow.mainWindow.count_main_sur += 1;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_1.Text, "sur");
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.away_team_player_state[0] = true;
                    this.player_1_play.IsEnabled = false;
                    this.player_1_down.IsEnabled = true;
                    MainWindow.mainWindow.count_away_sur += 1;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_1.Text, "sur");
                }
            }
        }
        private void player_1_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[0] = false;
                this.player_1_play.IsEnabled = true;
                this.player_1_down.IsEnabled = false;
                MainWindow.mainWindow.count_main_sur -= 1;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_1.Text, "sur");
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[0] = false;
                this.player_1_play.IsEnabled = true;
                this.player_1_down.IsEnabled = false;
                MainWindow.mainWindow.count_away_sur -= 1;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_1.Text, "sur");
            }
        }

        private void player_2_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[1] = true;
                    this.player_2_play.IsEnabled = false;
                    this.player_2_down.IsEnabled = true;
                    MainWindow.mainWindow.count_main_sur += 1;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_2.Text, "sur");
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.count_away_sur += 1;
                    MainWindow.mainWindow.away_team_player_state[1] = true;
                    this.player_2_play.IsEnabled = false;
                    this.player_2_down.IsEnabled = true;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_2.Text, "sur");
                }
            }
        }
        private void player_2_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[1] = false;
                this.player_2_play.IsEnabled = true;
                this.player_2_down.IsEnabled = false;
                MainWindow.mainWindow.count_main_sur -= 1;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_2.Text, "sur");
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[1] = false;
                this.player_2_play.IsEnabled = true;
                this.player_2_down.IsEnabled = false;
                MainWindow.mainWindow.count_away_sur -= 1;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_2.Text, "sur");
            }
        }

        private void player_3_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[2] = true;
                    this.player_3_play.IsEnabled = false;
                    this.player_3_down.IsEnabled = true;
                    MainWindow.mainWindow.count_main_sur += 1;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_3.Text, "sur");
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.away_team_player_state[2] = true;
                    this.player_3_play.IsEnabled = false;
                    this.player_3_down.IsEnabled = true;
                    MainWindow.mainWindow.count_away_sur += 1;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_3.Text, "sur");
                }
            }
        }

        private void player_3_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[2] = false;
                this.player_3_play.IsEnabled = true;
                this.player_3_down.IsEnabled = false;
                MainWindow.mainWindow.count_main_sur -= 1;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_3.Text, "sur");
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[2] = false;
                this.player_3_play.IsEnabled = true;
                this.player_3_down.IsEnabled = false;
                MainWindow.mainWindow.count_away_sur -= 1;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_3.Text, "sur");
            }
        }

        private void player_4_play_Click(object sender, RoutedEventArgs e)
        {

            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[3] = true;
                    this.player_4_play.IsEnabled = false;
                    this.player_4_down.IsEnabled = true;
                    MainWindow.mainWindow.count_main_sur += 1;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_4.Text, "sur");
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.away_team_player_state[3] = true;
                    this.player_4_play.IsEnabled = false;
                    this.player_4_down.IsEnabled = true;
                    MainWindow.mainWindow.count_away_sur += 1;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_4.Text, "sur");
                }
            }
        }

        private void player_4_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[3] = false;
                this.player_4_play.IsEnabled = true;
                this.player_4_down.IsEnabled = false;
                MainWindow.mainWindow.count_main_sur -= 1;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_4.Text, "sur");
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[3] = false;
                this.player_4_play.IsEnabled = true;
                this.player_4_down.IsEnabled = false;
                MainWindow.mainWindow.count_away_sur -= 1;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_4.Text, "sur");
            }
        }

        private void player_5_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[4] = true;
                    this.player_5_play.IsEnabled = false;
                    this.player_5_down.IsEnabled = true;
                    MainWindow.mainWindow.count_main_sur += 1;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_5.Text, "sur");
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.away_team_player_state[4] = true;
                    this.player_5_play.IsEnabled = false;
                    this.player_5_down.IsEnabled = true;
                    MainWindow.mainWindow.count_away_sur += 1;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_5.Text, "sur");
                }
            }
        }

        private void player_5_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[4] = false;
                this.player_5_play.IsEnabled = true;
                this.player_5_down.IsEnabled = false;
                MainWindow.mainWindow.count_main_sur -= 1;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_5.Text, "sur");
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[4] = false;
                this.player_5_play.IsEnabled = true;
                this.player_5_down.IsEnabled = false;
                MainWindow.mainWindow.count_away_sur -= 1;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_5.Text, "sur");
            }
        }

        private void player_6_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_sur < 4)
                {
                    MainWindow.mainWindow.main_team_player_state[5] = true;
                    this.player_6_play.IsEnabled = false;
                    this.player_6_down.IsEnabled = true;
                    if (MainWindow.mainWindow.main_states == "sur") Player_play_main_window(this.Sur_player_6.Text, "sur");
                    MainWindow.mainWindow.count_main_sur += 1;
                }

            }
            else
            {
                if (MainWindow.mainWindow.count_away_sur < 4)
                {
                    MainWindow.mainWindow.away_team_player_state[5] = true;
                    this.player_6_play.IsEnabled = false;
                    this.player_6_down.IsEnabled = true;
                    if (MainWindow.mainWindow.away_states == "sur") Player_play_main_window(this.Sur_player_6.Text, "sur");
                    MainWindow.mainWindow.count_away_sur += 1;
                }
            }
        }

        private void player_6_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[5] = false;
                this.player_6_play.IsEnabled = true;
                this.player_6_down.IsEnabled = false;
                if (MainWindow.mainWindow.main_states == "sur") Player_down_main_window(this.Sur_player_6.Text, "sur");
                MainWindow.mainWindow.count_main_sur -= 1;
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[5] = false;
                this.player_6_play.IsEnabled = true;
                this.player_6_down.IsEnabled = false;
                if (MainWindow.mainWindow.away_states == "sur") Player_down_main_window(this.Sur_player_6.Text, "sur");
                MainWindow.mainWindow.count_away_sur -= 1;
            }
        }

        private void player_7_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_hun < 1)
                {
                    MainWindow.mainWindow.main_team_player_state[6] = true;
                    this.player_7_play.IsEnabled = false;
                    this.player_7_down.IsEnabled = true;
                    if (MainWindow.mainWindow.main_states == "hun") Player_play_main_window(this.Hun_player_1.Text, "hun");
                    MainWindow.mainWindow.count_main_hun += 1;
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_hun < 1)
                {
                    MainWindow.mainWindow.away_team_player_state[6] = true;
                    this.player_7_play.IsEnabled = false;
                    this.player_7_down.IsEnabled = true;
                    if (MainWindow.mainWindow.away_states == "hun") Player_play_main_window(this.Hun_player_1.Text, "hun");
                    MainWindow.mainWindow.count_away_hun += 1;
                }
            }
        }

        private void player_7_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[6] = false;
                this.player_7_play.IsEnabled = true;
                this.player_7_down.IsEnabled = false;
                if (MainWindow.mainWindow.main_states == "hun") Player_down_main_window(this.Hun_player_1.Text, "hun");
                MainWindow.mainWindow.count_main_hun -= 1;
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[6] = false;
                this.player_7_play.IsEnabled = true;
                this.player_7_down.IsEnabled = false;
                if (MainWindow.mainWindow.away_states == "hun") Player_down_main_window(this.Hun_player_1.Text, "hun");
                MainWindow.mainWindow.count_away_hun -= 1;
            }
        }

        private void player_8_play_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                if (MainWindow.mainWindow.count_main_hun < 1)
                {
                    MainWindow.mainWindow.main_team_player_state[7] = true;
                    this.player_8_play.IsEnabled = false;
                    this.player_8_down.IsEnabled = true;
                    if (MainWindow.mainWindow.main_states == "hun") Player_play_main_window(this.Hun_player_2.Text, "hun");
                    MainWindow.mainWindow.count_main_hun += 1;
                }
            }
            else
            {
                if (MainWindow.mainWindow.count_away_hun < 1)
                {
                    MainWindow.mainWindow.away_team_player_state[7] = true;
                    this.player_8_play.IsEnabled = false;
                    this.player_8_down.IsEnabled = true;
                    if (MainWindow.mainWindow.away_states == "hun") Player_play_main_window(this.Hun_player_2.Text, "hun");
                    MainWindow.mainWindow.count_away_hun += 1;
                }
            }
        }

        private void player_8_down_Click(object sender, RoutedEventArgs e)
        {
            if (team == "main")
            {
                MainWindow.mainWindow.main_team_player_state[7] = false;
                this.player_8_play.IsEnabled = true;
                this.player_8_down.IsEnabled = false;
                if (MainWindow.mainWindow.main_states == "hun") Player_down_main_window(this.Hun_player_2.Text, "hun");
                MainWindow.mainWindow.count_main_hun -= 1;
            }
            else
            {
                MainWindow.mainWindow.away_team_player_state[7] = false;
                this.player_8_play.IsEnabled = true;
                this.player_8_down.IsEnabled = false;
                if (MainWindow.mainWindow.away_states == "hun") Player_down_main_window(this.Hun_player_2.Text, "hun");
                MainWindow.mainWindow.count_away_hun -= 1;
            }
        }

        private async void ApiGet_Click(object sender, RoutedEventArgs e)
        {
            List<string> qsz = new List<string>();
            List<string> qsz1 = new List<string>();
            List<string> jgz = new List<string>();
            List<string> jgz1 = new List<string>();
            try
            {
                var req = $"https://api.idvasg.cn/api/v1/form/{MainWindow.mainWindow.Main_team_name.Text}";
                var json = await req.GetJsonAsync<List<Form>>();
                json[0].role.Select(x => new { x.role_name, x.role_lin }).ToList().ForEach(x =>
                {
                    if (x.role_lin == "求生者")
                    {
                        qsz.Add(x.role_name);
                    }
                    else if (x.role_lin == "监管者")
                    {
                        jgz.Add(x.role_name);
                    }
                });
            }
            catch { }
            try
            {
                var req1 = $"https://api.idvasg.cn/api/v1/form/{MainWindow.mainWindow.Away_team_name.Text}";
                var json1 = await req1.GetJsonAsync<List<Form>>();
                json1[0].role.Select(x => new { x.role_name, x.role_lin }).ToList().ForEach(x =>
                {
                    if (x.role_lin == "求生者")
                    {
                        qsz1.Add(x.role_name);
                    }
                    else if (x.role_lin == "监管者")
                    {
                        jgz1.Add(x.role_name);
                    }
                });
            }
            catch { }

            if (team == "main")
            {
                try { Sur_player_1.Text = qsz[0]; } catch { Sur_player_1.Text = null; };
                try { Sur_player_2.Text = qsz[1]; } catch { Sur_player_2.Text = null; };
                try { Sur_player_3.Text = qsz[2]; } catch { Sur_player_3.Text = null; };
                try { Sur_player_4.Text = qsz[3]; } catch { Sur_player_4.Text = null; };
                try { Sur_player_5.Text = qsz[4]; } catch { Sur_player_5.Text = null; };
                try { Sur_player_6.Text = qsz[5]; } catch { Sur_player_6.Text = null; };
                try { Hun_player_1.Text = jgz[0]; } catch { Hun_player_1.Text = null; };
                try { Hun_player_2.Text = jgz[1]; } catch { Hun_player_2.Text = null; };
            }
            else
            {
                try { Sur_player_1.Text = qsz1[0]; } catch { Sur_player_1.Text = null; };
                try { Sur_player_2.Text = qsz1[1]; } catch { Sur_player_2.Text = null; };
                try { Sur_player_3.Text = qsz1[2]; } catch { Sur_player_3.Text = null; };
                try { Sur_player_4.Text = qsz1[3]; } catch { Sur_player_4.Text = null; };
                try { Sur_player_5.Text = qsz1[4]; } catch { Sur_player_5.Text = null; };
                try { Sur_player_6.Text = qsz1[5]; } catch { Sur_player_6.Text = null; };
                try { Hun_player_1.Text = jgz1[0]; } catch { Hun_player_1.Text = null; };
                try { Hun_player_2.Text = jgz1[1]; } catch { Hun_player_2.Text = null; };
            }
        }
        public class Events
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string is_over { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string opentime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<string> forms { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string events_rule_uri { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string promChart { get; set; }

        }


        public class Form
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int piaoshu { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string time { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string team_name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string team_password { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string team_tel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string logo_uri { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Events events { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public List<RoleItem> role { get; set; }

        }



        public class RoleItem
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public Form form { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string role_id { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string role_name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string game_Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string role_lin { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string id_Card { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string common_Roles { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string phone_Number { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string id_Card_Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int historical_Ranks { get; set; }

        }
    }
}