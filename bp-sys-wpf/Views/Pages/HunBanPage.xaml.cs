using bp_sys_wpf.Model;
using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// HunBanPage.xaml 的交互逻辑
    /// </summary>
    public partial class HunBanPage : Page
    {
        RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
        public HunBanPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }

        private void Hun_ban_1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Hun_ban_1.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("HunBan", 0);
                try
                {
                    Front.front.Hun_ban_1.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Hun_ban_2_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_ban_2.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("HunBan", 1);
                try
                {
                    Front.front.Hun_ban_2.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void Hun_ban_3_KeyDown(object sender, KeyEventArgs e)
        {
            Hun_ban_3.IsDropDownOpen = true;
            if (e.Key == Key.Tab)
            {
                rootViewModel.BpShowViewModel.ShowBp("HunBan", 2);
                try
                {
                    Front.front.Hun_ban_3.BeginAnimation(UIElement.OpacityProperty, AnimationSetting.fadeIn);
                }
                catch { }
            }
        }

        private void HunBanStateChange_Click(object sender, RoutedEventArgs e)
        {
            rootViewModel.BpReceiveModel = rootViewModel.BpReceiveModel;
        }
    }
}
