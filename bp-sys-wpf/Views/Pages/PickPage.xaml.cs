using bp_sys_wpf.Model;
using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// PickPage.xaml 的交互逻辑
    /// </summary>
    public partial class PickPage : Page
    {
        RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
        public PickPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }

        private void Sur1And2Border_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (Sur1And2Border.IsChecked == true)
                {
                    Front.front.SurPicking1.Visibility = Visibility.Visible;
                    Front.front.SurPicking2.Visibility = Visibility.Visible;
                    Front.front.SurPicking1.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                    Front.front.SurPicking2.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                else
                {
                    Front.front.SurPicking1.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeOut);
                    Front.front.SurPicking2.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeOut);
                }
            }
            catch { }
        }

        private void Sur3Border_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Sur3Border.IsChecked == true)
                {
                    Front.front.SurPicking3.Visibility = Visibility.Visible;
                    Front.front.SurPicking3.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                else
                {
                    Front.front.SurPicking3.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeOut);
                }
            }
            catch { }
        }

        private void Sur4Border_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Sur4Border.IsChecked == true)
                {
                    Front.front.SurPicking4.Visibility = Visibility.Visible;
                    Front.front.SurPicking4.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                else
                {
                    Front.front.SurPicking4.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeOut);
                }
            }
            catch { }
        }

        private void HunBorder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HunBorder.IsChecked == true)
                {
                    Front.front.HunPicking.Visibility = Visibility.Visible;
                    Front.front.HunPicking.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                else
                {
                    Front.front.HunPicking.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeOut);
                }
            }
            catch { }
        }

        private void Sur_pick_1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Sur_pick_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurPick", 0);
                try
                {
                    Front.front.Sur_pick_1.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_pick_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurPick", 1);
                try
                {
                    Front.front.Sur_pick_2.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_pick_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurPick", 2);
                try
                {
                    Front.front.Sur_pick_3.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_pick_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_pick_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurPick", 3);
                try
                {
                    Front.front.Sur_pick_4.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Hun_pick_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_pick.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("HunPick", 0);
                try
                {
                    Front.front.Hun_pick.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Change_sur1_with_sur2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(0, 1);
        }

        private void Change_sur1_with_sur3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(0, 2);
        }

        private void Change_sur1_with_sur4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(0, 3);
        }

        private void Change_sur2_with_sur1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(1, 0);
        }

        private void Change_sur2_with_sur3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(1, 2);
        }

        private void Change_sur2_with_sur4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(1, 3);
        }

        private void Change_sur3_with_sur1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(2, 0);
        }

        private void Change_sur3_with_sur2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(2, 1);
        }

        private void Change_sur3_with_sur4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(2, 3);
        }

        private void Change_sur4_with_sur1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(3, 0);
        }

        private void Change_sur4_with_sur2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(3, 1);
        }

        private void Change_sur4_with_sur3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpShowViewModel.SwapCharacrer(3, 2);
        }
        private void Swap_sur_player1_with_player2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(0, 1);
        }

        private void Swap_sur_player1_with_player3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(0, 2);
        }

        private void Swap_sur_player1_with_player4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(0, 3);
        }

        private void Swap_sur_player2_with_player1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(1, 0);
        }

        private void Swap_sur_player2_with_player3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(1, 2);
        }

        private void Swap_sur_player2_with_player4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(1, 3);
        }

        private void Swap_sur_player3_with_player1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(2, 0);
        }

        private void Swap_sur_player3_with_player2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(2, 1);
        }

        private void Swap_sur_player3_with_player4_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(2, 3);
        }

        private void Swap_sur_player4_with_player1_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(3, 0);
        }

        private void Swap_sur_player4_with_player2_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(3, 1);
        }

        private void Swap_sur_player4_with_player3_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.TeamInfoViewModel.SwapPlayers(3, 2);
        }

    }
}
