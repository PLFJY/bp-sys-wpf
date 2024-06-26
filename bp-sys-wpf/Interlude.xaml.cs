﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace bp_sys_wpf
{
    /// <summary>
    /// Interlude.xaml 的交互逻辑
    /// </summary>
    public partial class Interlude : Window
    {
        public static Interlude interlude;
        public Interlude()
        {
            InitializeComponent();
            interlude = this;
            MainWindow.mainWindow.Activate();
            try
            {
                this.Background = new ImageBrush(new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("Resource/gui/interlude_bg.png"))));
                Bottom.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("Resource/gui/bottom.png")));
                NameImage.Source = new BitmapImage(new Uri(MainWindow.mainWindow.GetAbsoluteFilePath("Resource/gui/name.png")));
            }
            catch { }
            Hun_team_name.Foreground = Config.Interlude.Color.team_name;
            Sur_team_name.Foreground = Config.Interlude.Color.team_name;
            Hun_player_name.Foreground = Config.Interlude.Color.player_name;
            Sur_1_player_name.Foreground = Config.Interlude.Color.player_name;
            Sur_2_player_name.Foreground = Config.Interlude.Color.player_name;
            Sur_3_player_name.Foreground = Config.Interlude.Color.player_name;
            Sur_4_player_name.Foreground = Config.Interlude.Color.player_name;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
