using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.IO;
using System;

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
		public int MainWin = 0, MainLose = 0, MainAll = 0, MainS = 0, MainHoleS = 0, AwayWin = 0, AwayLose = 0, AwayAll = 0, AwayS = 0, AwayHoleS = 0;
		private DispatcherTimer dispatcherTimer;
		private int countdownTime;
		private string GetFilePath(string type, string selectedValue)
		{
			string temp = "pack://application:,,,/pic/" + type + "/";
			int spaceIndex = selectedValue.IndexOf(' ');
			selectedValue = selectedValue.Substring(spaceIndex + 1);
			string file_path = temp + selectedValue + ".png";
			return GetAbsoluteFilePath("pic/" + type + "/" + selectedValue + ".png"); ;
		}
		public string GetAbsoluteFilePath(string filePath)

		{
			// 获取应用程序的运行目录  
			string appDir = Environment.CurrentDirectory; // 在WPF中可以使用Environment.CurrentDirectory获取当前目录  
			// 拼接路径获取绝对路径  
			string absoluteFilePath = Path.Combine(appDir, filePath);
			return absoluteFilePath;
		}
		public BitmapImage ImageGet(string type, string selectedValue)
		{
			return new BitmapImage(new Uri(GetFilePath(type, selectedValue)));
		}
        private void Res_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsWindowOpen("Front1"))
            {
                switch (Res.SelectedIndex)
                {
                    case 0:
                        Front.front.Width = 1440;
                        Front.front.Height = 810;
                        break;
                    case 1:
                        Front.front.Width = 960;
                        Front.front.Height = 540;
                        break;
                    case 2:
                        Front.front.Width = 1280;
                        Front.front.Height = 720;
                        break;
                    case 3:
                        Front.front.Width = 1920;
                        Front.front.Height = 1080;
                        break;
                    case 4:
                        Front.front.Width = 2560;
                        Front.front.Height = 1440;
                        break;
                }
            }
            if (IsWindowOpen("Interlude1"))
            {
                switch (Res.SelectedIndex)
                {
                    case 0:
                        Interlude.interlude.Width = 1440;
                        Interlude.interlude.Height = 810;
                        break;
                    case 1:
                        Interlude.interlude.Width = 960;
                        Interlude.interlude.Height = 540;
                        break;
                    case 2:
                        Interlude.interlude.Width = 1280;
                        Interlude.interlude.Height = 720;
                        break;
                    case 3:
                        Interlude.interlude.Width = 1920;
                        Interlude.interlude.Height = 1080;
                        break;
                    case 4:
                        Interlude.interlude.Width = 2560;
                        Interlude.interlude.Height = 1440;
                        break;
                }
            }
        }
        private void Hun_ban_1_KeyDown(object sender, KeyEventArgs e)
		{
			Hun_ban_1.IsDropDownOpen = true;
			if (e.Key == Key.Tab)
			{
				if (this.Hun_ban_1.SelectedItem != null)
				{

					this.Hun_ban_review_1.Source = ImageGet("hunban", Hun_ban_1.SelectedItem.ToString());
					Front.front.Hun_ban_1.Source = ImageGet("hunban", Hun_ban_1.SelectedItem.ToString());
				}
				else
				{
					this.Hun_ban_review_1.Source = null;
					Front.front.Hun_ban_1.Source = null;
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
					this.Hun_ban_review_2.Source = ImageGet("hunban", Hun_ban_2.SelectedItem.ToString());
					Front.front.Hun_ban_2.Source = ImageGet("hunban", Hun_ban_2.SelectedItem.ToString());
				}
				else
				{
					this.Hun_ban_review_2.Source = null;
					Front.front.Hun_ban_2.Source = null;
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
					this.Hun_ban_review_3.Source = ImageGet("hunban", Hun_ban_3.SelectedItem.ToString());
					Front.front.Hun_ban_3.Source = ImageGet("hunban", Hun_ban_3.SelectedItem.ToString());
				}
				else
				{
					this.Hun_ban_review_3.Source = null;
					Front.front.Hun_ban_3.Source = null;
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
					this.Hun_pick_review.Source = ImageGet("hun", Hun_pick.SelectedItem.ToString());
					Front.front.Hun_pick.Source = ImageGet("hunhalf", Hun_pick.SelectedItem.ToString());
					Interlude.interlude.Hun.Source = ImageGet("hunBig", Hun_pick.SelectedItem.ToString());
				}
				else
				{
					this.Hun_pick_review.Source = null;
					Front.front.Hun_pick.Source = null;
					Interlude.interlude.Hun.Source = null;
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
					this.Sur_pick_1_preview.Source = ImageGet("sur", Sur_pick_1.SelectedItem.ToString());
					Front.front.Sur_pick_1.Source = ImageGet("surhalf", Sur_pick_1.SelectedItem.ToString());
					Interlude.interlude.Sur_1.Source = ImageGet("surBig", Sur_pick_1.SelectedItem.ToString());
				}
				else
				{
					this.Sur_pick_1_preview.Source = null;
					Front.front.Sur_pick_1.Source = null;
					Interlude.interlude.Sur_1.Source = null;
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
					this.Sur_pick_2_preview.Source = ImageGet("sur", Sur_pick_2.SelectedItem.ToString());
					Front.front.Sur_pick_2.Source = ImageGet("surhalf", Sur_pick_2.SelectedItem.ToString());
					Interlude.interlude.Sur_2.Source = ImageGet("surBig", Sur_pick_2.SelectedItem.ToString());
				}
				else
				{
					this.Sur_pick_2_preview.Source = null;
					Front.front.Sur_pick_2.Source = null;
					Interlude.interlude.Sur_2.Source = null;
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
					this.Sur_pick_3_preview.Source = ImageGet("sur", Sur_pick_3.SelectedItem.ToString());
					Front.front.Sur_pick_3.Source = ImageGet("surhalf", Sur_pick_3.SelectedItem.ToString());
					Interlude.interlude.Sur_3.Source = ImageGet("surBig", Sur_pick_3.SelectedItem.ToString());
				}
				else
				{
					this.Sur_pick_3_preview.Source = null;
					Front.front.Sur_pick_3.Source = null;
					Interlude.interlude.Sur_3.Source = null;
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
					this.Sur_pick_4_preview.Source = ImageGet("sur", Sur_pick_4.SelectedItem.ToString());
					Front.front.Sur_pick_4.Source = ImageGet("surhalf", Sur_pick_4.SelectedItem.ToString());
					Interlude.interlude.Sur_4.Source = ImageGet("surBig", Sur_pick_4.SelectedItem.ToString());
				}
				else
				{
					this.Sur_pick_4_preview.Source = null;
					Front.front.Sur_pick_4.Source = null;
					Interlude.interlude.Sur_4.Source = null;
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
					this.Sur_ban_review_1.Source = ImageGet("surban", Sur_ban_1.SelectedItem.ToString());
					Front.front.Sur_ban_1.Source = ImageGet("surban", Sur_ban_1.SelectedItem.ToString());
				}
				else
				{
					this.Sur_ban_review_1.Source = null;
					Front.front.Sur_ban_1.Source = null;
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
					this.Sur_ban_review_2.Source = ImageGet("surban", Sur_ban_2.SelectedItem.ToString());
					Front.front.Sur_ban_2.Source = ImageGet("surban", Sur_ban_2.SelectedItem.ToString());
				}
				else
				{
					this.Sur_ban_review_2.Source = null;
					Front.front.Sur_ban_2.Source = null;
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
					this.Sur_ban_review_3.Source = ImageGet("surban", Sur_ban_3.SelectedItem.ToString());
					Front.front.Sur_ban_3.Source = ImageGet("surban", Sur_ban_3.SelectedItem.ToString());
				}
				else
				{
					this.Sur_ban_review_3.Source = null;
					Front.front.Sur_ban_3.Source = null;
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
					this.Sur_ban_review_4.Source = ImageGet("surban", Sur_ban_4.SelectedItem.ToString());
					Front.front.Sur_ban_4.Source = ImageGet("surban", Sur_ban_4.SelectedItem.ToString());
				}
				else
				{
					this.Sur_ban_review_4.Source = null;
					Front.front.Sur_ban_4.Source = null;
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
					this.Sur_hole_ban_1_preview.Source = ImageGet("surban", Sur_hole_ban_1.SelectedItem.ToString());
					Front.front.Hole_ban_1.Source = ImageGet("surban", Sur_hole_ban_1.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_1_preview.Source = null;
					Front.front.Hole_ban_1.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole1.SelectedIndex = Sur_hole_ban_1.SelectedIndex;
				}
				else
				{
					Away_hole1.SelectedIndex = Sur_hole_ban_1.SelectedIndex;
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
					this.Sur_hole_ban_2_preview.Source = ImageGet("surban", Sur_hole_ban_2.SelectedItem.ToString());
					Front.front.Hole_ban_2.Source = ImageGet("surban", Sur_hole_ban_2.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_2_preview.Source = null;
					Front.front.Hole_ban_2.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole2.SelectedIndex = Sur_hole_ban_2.SelectedIndex;
				}
				else
				{
					Away_hole2.SelectedIndex = Sur_hole_ban_2.SelectedIndex;
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
					this.Sur_hole_ban_3_preview.Source = ImageGet("surban", Sur_hole_ban_3.SelectedItem.ToString());
					Front.front.Hole_ban_3.Source = ImageGet("surban", Sur_hole_ban_3.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_3_preview.Source = null;
					Front.front.Hole_ban_3.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole3.SelectedIndex = Sur_hole_ban_3.SelectedIndex;
				}
				else
				{
					Away_hole3.SelectedIndex = Sur_hole_ban_3.SelectedIndex;
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
					this.Sur_hole_ban_4_preview.Source = ImageGet("surban", Sur_hole_ban_4.SelectedItem.ToString());
					Front.front.Hole_ban_4.Source = ImageGet("surban", Sur_hole_ban_4.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_4_preview.Source = null;
					Front.front.Hole_ban_4.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole4.SelectedIndex = Sur_hole_ban_4.SelectedIndex;
				}
				else
				{
					Away_hole4.SelectedIndex = Sur_hole_ban_4.SelectedIndex;
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
					Interlude.interlude.Sur_1_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_1.Text;
					Interlude.interlude.Sur_2_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_2.Text;
					Interlude.interlude.Sur_3_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_3.Text;
					Interlude.interlude.Sur_4_player_name.Content = Main_team_name.Text + "__" + Now_sur_player_4.Text;
					if (IsWindowOpen("ScoreSur1")) ScoreSur.scoreSur.TeamName.Content = Main_team_name.Text;
					if (IsWindowOpen("Score1")) Score.score.ScoreCtrWindowRefresh();
				}
				else
				{
					Front.front.Hun_team_name.Content = Main_team_name.Text;
					Front.front.Hun_player.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
					Interlude.interlude.Hun_team_name.Content = Main_team_name.Text;
					Interlude.interlude.Hun_player_name.Content = Main_team_name.Text + "__" + Now_hun_player.Text;
					if (IsWindowOpen("ScoreHun1")) ScoreHun.scoreHun.TeamName.Content = Main_team_name.Text;
					if (IsWindowOpen("Score1")) Score.score.ScoreCtrWindowRefresh();
				}
				if (IsWindowOpen("ScoreHole1")) ScoreHole.scoreHole.MainName.Content = Main_team_name.Text;
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
					Interlude.interlude.Sur_1_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_1.Text;
					Interlude.interlude.Sur_2_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_2.Text;
					Interlude.interlude.Sur_3_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_3.Text;
					Interlude.interlude.Sur_4_player_name.Content = Away_team_name.Text + "__" + Now_sur_player_4.Text;
					if (IsWindowOpen("ScoreSur1")) ScoreSur.scoreSur.TeamName.Content = Away_team_name.Text;
					if (IsWindowOpen("Score1")) Score.score.ScoreCtrWindowRefresh();
				}
				else
				{
					Front.front.Hun_player.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
					Front.front.Hun_team_name.Content = Away_team_name.Text;
					Interlude.interlude.Hun_team_name.Content = Away_team_name.Text;
					Interlude.interlude.Hun_player_name.Content = Away_team_name.Text + "__" + Now_hun_player.Text;
					if (IsWindowOpen("ScoreHun1")) ScoreHun.scoreHun.TeamName.Content = Away_team_name.Text;
					if (IsWindowOpen("Score1")) Score.score.ScoreCtrWindowRefresh();
				}
				if (IsWindowOpen("ScoreHole1")) ScoreHole.scoreHole.AwayName.Content = Away_team_name.Text;
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

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 弹窗提示是否确定要退出
			MessageBoxResult result = MessageBox.Show("您确定要退出吗？", null, MessageBoxButton.OKCancel, MessageBoxImage.None, MessageBoxResult.Cancel);
			System.Console.WriteLine(result);
			if (result == MessageBoxResult.Cancel)
			{
				e.Cancel = true; // 中断点击事件
			}
		}

		private void Change_sur1_with_sur2_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_1.Text, Sur_pick_2.Text) = (Sur_pick_2.Text, Sur_pick_1.Text);
			(Front.front.Sur_pick_1.Source, Front.front.Sur_pick_2.Source) = (Front.front.Sur_pick_2.Source, Front.front.Sur_pick_1.Source);
			(Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_2.Source) = (Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_1.Source);
			(Sur_pick_1_preview.Source, Sur_pick_2_preview.Source) = (Sur_pick_2_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur1_with_sur3_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_1.Text, Sur_pick_3.Text) = (Sur_pick_3.Text, Sur_pick_1.Text);
			(Front.front.Sur_pick_1.Source, Front.front.Sur_pick_3.Source) = (Front.front.Sur_pick_3.Source, Front.front.Sur_pick_1.Source);
			(Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_3.Source) = (Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_1.Source);
			(Sur_pick_1_preview.Source, Sur_pick_3_preview.Source) = (Sur_pick_3_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur1_with_sur4_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_1.Text, Sur_pick_4.Text) = (Sur_pick_4.Text, Sur_pick_1.Text);
			(Front.front.Sur_pick_1.Source, Front.front.Sur_pick_4.Source) = (Front.front.Sur_pick_4.Source, Front.front.Sur_pick_1.Source);
			(Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_4.Source) = (Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_1.Source);
			(Sur_pick_1_preview.Source, Sur_pick_4_preview.Source) = (Sur_pick_4_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur2_with_sur1_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_1.Text, Sur_pick_2.Text) = (Sur_pick_2.Text, Sur_pick_1.Text);
			(Front.front.Sur_pick_1.Source, Front.front.Sur_pick_2.Source) = (Front.front.Sur_pick_2.Source, Front.front.Sur_pick_1.Source);
			(Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_2.Source) = (Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_1.Source);
			(Sur_pick_1_preview.Source, Sur_pick_2_preview.Source) = (Sur_pick_2_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur2_with_sur3_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_3.Text, Sur_pick_2.Text) = (Sur_pick_2.Text, Sur_pick_3.Text);
			(Front.front.Sur_pick_3.Source, Front.front.Sur_pick_2.Source) = (Front.front.Sur_pick_2.Source, Front.front.Sur_pick_3.Source);
			(Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_2.Source) = (Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_3.Source);
			(Sur_pick_3_preview.Source, Sur_pick_2_preview.Source) = (Sur_pick_2_preview.Source, Sur_pick_3_preview.Source);
		}

		private void Change_sur2_with_sur4_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_4.Text, Sur_pick_2.Text) = (Sur_pick_2.Text, Sur_pick_4.Text);
			(Front.front.Sur_pick_4.Source, Front.front.Sur_pick_2.Source) = (Front.front.Sur_pick_2.Source, Front.front.Sur_pick_4.Source);
			(Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_2.Source) = (Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_4.Source);
			(Sur_pick_4_preview.Source, Sur_pick_2_preview.Source) = (Sur_pick_2_preview.Source, Sur_pick_4_preview.Source);
		}

		private void Change_sur3_with_sur1_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_1.Text, Sur_pick_3.Text) = (Sur_pick_3.Text, Sur_pick_1.Text);
			(Front.front.Sur_pick_1.Source, Front.front.Sur_pick_3.Source) = (Front.front.Sur_pick_3.Source, Front.front.Sur_pick_1.Source);
			(Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_3.Source) = (Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_1.Source);
			(Sur_pick_1_preview.Source, Sur_pick_3_preview.Source) = (Sur_pick_3_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur3_with_sur2_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_2.Text, Sur_pick_3.Text) = (Sur_pick_3.Text, Sur_pick_2.Text);
			(Front.front.Sur_pick_2.Source, Front.front.Sur_pick_3.Source) = (Front.front.Sur_pick_3.Source, Front.front.Sur_pick_2.Source);
			(Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_3.Source) = (Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_2.Source);
			(Sur_pick_2_preview.Source, Sur_pick_3_preview.Source) = (Sur_pick_3_preview.Source, Sur_pick_2_preview.Source);
		}

		private void Change_sur3_with_sur4_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_4.Text, Sur_pick_3.Text) = (Sur_pick_3.Text, Sur_pick_4.Text);
			(Front.front.Sur_pick_4.Source, Front.front.Sur_pick_3.Source) = (Front.front.Sur_pick_3.Source, Front.front.Sur_pick_4.Source);
			(Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_3.Source) = (Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_4.Source);
			(Sur_pick_4_preview.Source, Sur_pick_3_preview.Source) = (Sur_pick_3_preview.Source, Sur_pick_4_preview.Source);
		}

		private void Change_sur4_with_sur1_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_4.Text, Sur_pick_1.Text) = (Sur_pick_1.Text, Sur_pick_4.Text);
			(Front.front.Sur_pick_4.Source, Front.front.Sur_pick_1.Source) = (Front.front.Sur_pick_1.Source, Front.front.Sur_pick_4.Source);
			(Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_1.Source) = (Interlude.interlude.Sur_1.Source, Interlude.interlude.Sur_4.Source);
			(Sur_pick_1_preview.Source, Sur_pick_4_preview.Source) = (Sur_pick_4_preview.Source, Sur_pick_1_preview.Source);
		}

		private void Change_sur4_with_sur2_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_4.Text, Sur_pick_2.Text) = (Sur_pick_2.Text, Sur_pick_4.Text);
			(Front.front.Sur_pick_4.Source, Front.front.Sur_pick_2.Source) = (Front.front.Sur_pick_2.Source, Front.front.Sur_pick_4.Source);
			(Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_2.Source) = (Interlude.interlude.Sur_2.Source, Interlude.interlude.Sur_4.Source);
			(Sur_pick_2_preview.Source, Sur_pick_4_preview.Source) = (Sur_pick_4_preview.Source, Sur_pick_2_preview.Source);
		}

		private void Change_sur4_with_sur3_Click(object sender, RoutedEventArgs e)
		{
			(Sur_pick_4.Text, Sur_pick_3.Text) = (Sur_pick_3.Text, Sur_pick_4.Text);
			(Front.front.Sur_pick_4.Source, Front.front.Sur_pick_3.Source) = (Front.front.Sur_pick_3.Source, Front.front.Sur_pick_4.Source);
			(Interlude.interlude.Sur_4.Source, Interlude.interlude.Sur_3.Source) = (Interlude.interlude.Sur_3.Source, Interlude.interlude.Sur_4.Source);
			(Sur_pick_3_preview.Source, Sur_pick_4_preview.Source) = (Sur_pick_4_preview.Source, Sur_pick_3_preview.Source);
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void About_Click(object sender, RoutedEventArgs e)
		{
			AboutThis aboutThis = new AboutThis();
			aboutThis.ShowDialog();
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
			if (countdownTime < 0)
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
		public bool IsWindowOpen(string windowName)
		{
			return Application.Current.Windows.OfType<Window>().Any(window => window.Name == windowName);
		}

		private void Open_score_Click(object sender, RoutedEventArgs e)
		{
			Front.front.Sur_score.Visibility = Visibility.Visible;
			Front.front.Sur_scoreS.Visibility = Visibility.Visible;
			Front.front.Hun_score.Visibility = Visibility.Visible;
			Front.front.Hun_scoreS.Visibility = Visibility.Visible;
			if (!IsWindowOpen("ScoreSur1"))
			{
				ScoreSur scoreSur = new ScoreSur();
				scoreSur.Show();
			}
			else
			{
				Score.score.Activate();
			}
			if (!IsWindowOpen("ScoreHun1"))
			{
				ScoreHun scoreHun = new ScoreHun();
				scoreHun.Show();
			}
			if (!IsWindowOpen("Score1"))
			{
				Score score = new Score();
				score.Show();
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
					this.Sur_hole_ban_5_preview.Source = ImageGet("surban", Sur_hole_ban_5.SelectedItem.ToString());
					Front.front.Hole_ban_5.Source = ImageGet("surban", Sur_hole_ban_5.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_5_preview.Source = null;
					Front.front.Hole_ban_5.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole5.SelectedIndex = Sur_hole_ban_5.SelectedIndex;
				}
				else
				{
					Away_hole5.SelectedIndex = Sur_hole_ban_5.SelectedIndex;
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
					this.Sur_hole_ban_6_preview.Source = ImageGet("surban", Sur_hole_ban_6.SelectedItem.ToString());
					Front.front.Hole_ban_6.Source = ImageGet("surban", Sur_hole_ban_6.SelectedItem.ToString());
				}
				else
				{
					this.Sur_hole_ban_6_preview.Source = null;
					Front.front.Hole_ban_6.Source = null;
				}
				if (main_states == "sur")
				{
					Main_hole6.SelectedIndex = Sur_hole_ban_6.SelectedIndex;
				}
				else
				{
					Away_hole6.SelectedIndex = Sur_hole_ban_6.SelectedIndex;
				}
			}
		}

		private void Map_pick_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Front.front.Map.Source = ImageGet("map", Map_pick.SelectedItem.ToString());
			Map_bp.map_bp.pick.Source = ImageGet("map", Map_pick.SelectedItem.ToString());
		}

		private void Map_ban_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Map_bp.map_bp.ban.Source = ImageGet("mapban", Map_ban.SelectedItem.ToString());
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
			Front front = new Front();
			front.Show();
			Interlude interlude = new Interlude();
			interlude.Show();
			Map_bp map_Bp = new Map_bp();
			map_Bp.Show();
			for (int i = 0; i < 8; i++)
			{
				main_team_player_state[i] = false;
				away_team_player_state[i] = false;
			}
			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
			dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
			this.Activate();
		}
		public string OpenImageFileDialog()//打开通用对话框选取图片
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "图片文件|*.png;*.jpg"; // 设置过滤器只显示 PNG 和 JPG 文件  
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
					if (IsWindowOpen("ScoreSur1")) ScoreSur.scoreSur.Logo.Source = new BitmapImage(new Uri(logo));
				}
				else
				{
					Front.front.Logo_hun.Source = new BitmapImage(new Uri(logo));
					Interlude.interlude.Hun_logo.Source = new BitmapImage(new Uri(logo));
					if (IsWindowOpen("ScoreHun1")) ScoreHun.scoreHun.Logo.Source = new BitmapImage(new Uri(logo));
				}
				if (IsWindowOpen("ScoreHole1")) ScoreHole.scoreHole.MainLogo.Source = new BitmapImage(new Uri(logo));
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
					if (IsWindowOpen("ScoreHun1")) ScoreHun.scoreHun.Logo.Source = new BitmapImage(new Uri(logo));
				}
				else
				{
					Front.front.Logo_sur.Source = new BitmapImage(new Uri(logo));
					Interlude.interlude.Sur_logo.Source = new BitmapImage(new Uri(logo));
					if (IsWindowOpen("ScoreSur1")) ScoreSur.scoreSur.Logo.Source = new BitmapImage(new Uri(logo));
				}
				if (IsWindowOpen("ScoreHole1")) ScoreHole.scoreHole.AwayLogo.Source = new BitmapImage(new Uri(logo));
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

		public void HoleBanRefresh()
		{
			if (this.Sur_hole_ban_1.SelectedItem != null)
			{
				this.Sur_hole_ban_1_preview.Source = ImageGet("surban", Sur_hole_ban_1.SelectedItem.ToString());
				Front.front.Hole_ban_1.Source = ImageGet("surban", Sur_hole_ban_1.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_1_preview.Source = null;
				Front.front.Hole_ban_1.Source = null;
			}
			if (this.Sur_hole_ban_2.SelectedItem != null)
			{
				this.Sur_hole_ban_2_preview.Source = ImageGet("surban", Sur_hole_ban_2.SelectedItem.ToString());
				Front.front.Hole_ban_2.Source = ImageGet("surban", Sur_hole_ban_2.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_2_preview.Source = null;
				Front.front.Hole_ban_2.Source = null;
			}
			if (this.Sur_hole_ban_3.SelectedItem != null)
			{
				this.Sur_hole_ban_3_preview.Source = ImageGet("surban", Sur_hole_ban_3.SelectedItem.ToString());
				Front.front.Hole_ban_3.Source = ImageGet("surban", Sur_hole_ban_3.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_3_preview.Source = null;
				Front.front.Hole_ban_3.Source = null;
			}
			if (this.Sur_hole_ban_4.SelectedItem != null)
			{
				this.Sur_hole_ban_4_preview.Source = ImageGet("surban", Sur_hole_ban_4.SelectedItem.ToString());
				Front.front.Hole_ban_4.Source = ImageGet("surban", Sur_hole_ban_4.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_4_preview.Source = null;
				Front.front.Hole_ban_4.Source = null;
			}
			if (this.Sur_hole_ban_5.SelectedItem != null)
			{
				this.Sur_hole_ban_5_preview.Source = ImageGet("surban", Sur_hole_ban_5.SelectedItem.ToString());
				Front.front.Hole_ban_5.Source = ImageGet("surban", Sur_hole_ban_5.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_5_preview.Source = null;
				Front.front.Hole_ban_5.Source = null;
			}
			if (this.Sur_hole_ban_6.SelectedItem != null)
			{
				this.Sur_hole_ban_6_preview.Source = ImageGet("surban", Sur_hole_ban_6.SelectedItem.ToString());
				Front.front.Hole_ban_6.Source = ImageGet("surban", Sur_hole_ban_6.SelectedItem.ToString());
			}
			else
			{
				this.Sur_hole_ban_6_preview.Source = null;
				Front.front.Hole_ban_6.Source = null;
			}
		}
		private void Swap_Click(object sender, RoutedEventArgs e)
		{
			(Front.front.Sur_team_name.Content, Front.front.Hun_team_name.Content) = (Front.front.Hun_team_name.Content, Front.front.Sur_team_name.Content);
			(Front.front.Logo_sur.Source, Front.front.Logo_hun.Source) = (Front.front.Logo_hun.Source, Front.front.Logo_sur.Source);
			(Interlude.interlude.Sur_team_name.Content, Interlude.interlude.Hun_team_name.Content) = (Interlude.interlude.Hun_team_name.Content, Interlude.interlude.Sur_team_name.Content);
			(Interlude.interlude.Sur_logo.Source, Interlude.interlude.Hun_logo.Source) = (Interlude.interlude.Hun_logo.Source, Interlude.interlude.Sur_logo.Source);
			if (IsWindowOpen("Score1")) (ScoreSur.scoreSur.Logo.Source, ScoreHun.scoreHun.Logo.Source) = (ScoreHun.scoreHun.Logo.Source, ScoreSur.scoreSur.Logo.Source);
			if (IsWindowOpen("ScoreHun1") && IsWindowOpen("ScoreSur1")) (ScoreSur.scoreSur.TeamName.Content, ScoreHun.scoreHun.TeamName.Content) = (ScoreHun.scoreHun.TeamName.Content, ScoreSur.scoreSur.TeamName.Content);
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
			if (main_states == "sur")
			{
				Sur_hole_ban_1.SelectedIndex = Main_hole1.SelectedIndex;
				Sur_hole_ban_2.SelectedIndex = Main_hole2.SelectedIndex;
				Sur_hole_ban_3.SelectedIndex = Main_hole3.SelectedIndex;
				Sur_hole_ban_4.SelectedIndex = Main_hole4.SelectedIndex;
				Sur_hole_ban_5.SelectedIndex = Main_hole5.SelectedIndex;
				Sur_hole_ban_6.SelectedIndex = Main_hole6.SelectedIndex;
				HoleBanRefresh();
			}
			else
			{
				Sur_hole_ban_1.SelectedIndex = Away_hole1.SelectedIndex;
				Sur_hole_ban_2.SelectedIndex = Away_hole2.SelectedIndex;
				Sur_hole_ban_3.SelectedIndex = Away_hole3.SelectedIndex;
				Sur_hole_ban_4.SelectedIndex = Away_hole4.SelectedIndex;
				Sur_hole_ban_5.SelectedIndex = Away_hole5.SelectedIndex;
				Sur_hole_ban_6.SelectedIndex = Away_hole6.SelectedIndex;
				HoleBanRefresh();
			}
			if (IsWindowOpen("Score1")) Score.score.FrontScoreRefresh();
			if (IsWindowOpen("Score1")) Score.score.ScoreCtrWindowRefresh();
			if (IsWindowOpen("Score1")) Score.score.ScoreWindowRefresh();
		}
	}
}