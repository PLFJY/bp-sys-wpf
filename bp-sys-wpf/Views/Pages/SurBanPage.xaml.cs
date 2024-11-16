using bp_sys_wpf.Model;
using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// SurBanPage.xaml 的交互逻辑
    /// </summary>
    public partial class SurBanPage : Page
    {
        RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
        public SurBanPage()
        {
            InitializeComponent();
            DataContext = rootViewModel;
        }

        private void Sur_ban_1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Sur_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurBan", 0);
                try
                {
                    Front.front.Sur_ban_1.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurBan", 1);
                try
                {
                    Front.front.Sur_ban_2.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurBan", 2);
                try
                {
                    Front.front.Sur_ban_3.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_ban_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_ban_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurBan", 3);
                try
                {
                    Front.front.Sur_ban_4.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Sur_hole_ban_1_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 0);
            }
        }

        private void Sur_hole_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 1);
            }
        }

        private void Sur_hole_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 2);
            }
        }

        private void Sur_hole_ban_4_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_4.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 3);
            }
        }

        private void Sur_hole_ban_5_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_5.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 4);
            }
        }

        private void Sur_hole_ban_6_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_6.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 5);
            }
        }

        private void Sur_hole_ban_7_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_7.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 6);
            }
        }

        private void Sur_hole_ban_8_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_8.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 7);
            }
        }

        private void Sur_hole_ban_9_KeyDown(object sender, KeyEventArgs e)
        {
            Sur_hole_ban_9.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("SurHoleBan", 8);
            }
        }

        private void SurHoleStateChange_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpReceiveModel = rootViewModel.BpReceiveModel;
        }
    }
}
