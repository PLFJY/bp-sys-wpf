using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf
{
    /// <summary>
    /// Front.xaml 的交互逻辑
    /// </summary>
    public partial class Front : Window
    {
        public static Front front;
        RootViewModel rootViewModel = BackWindow.backWindow.rootViewModel;
        public Front()
        {
            InitializeComponent();
            front = this;
            DataContext = rootViewModel;
            try
            {
                GetFilePath getFilePath = new GetFilePath();
                this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/bp.png"))));
                Hun_no_ban_1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hun_ban.png")));
                Hun_no_ban_2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hun_ban.png")));
                Hun_no_ban_3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hun_ban.png")));
                Hole_no_ban_1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_5.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_6.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_7.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_8.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                Hole_no_ban_9.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/no_hole_ban.png")));
                SurPicking1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/SurPicking.png")));
                SurPicking2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/SurPicking.png")));
                SurPicking3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/SurPicking.png")));
                SurPicking4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/SurPicking.png")));
                HunPicking.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/HunPicking.png")));
            }
            catch { }
            Sur_team_name.Foreground = Config.Front.Color.team_name;
            Hun_team_name.Foreground = Config.Front.Color.team_name;
            timmer.Foreground = Config.Front.Color.timmer;
            Sur_1_player.Foreground = Config.Front.Color.Sur_player;
            Sur_2_player.Foreground = Config.Front.Color.Sur_player;
            Sur_3_player.Foreground = Config.Front.Color.Sur_player;
            Sur_4_player.Foreground = Config.Front.Color.Sur_player;
            Sur_1_team.Foreground = Config.Front.Color.Sur_team;
            Sur_2_team.Foreground = Config.Front.Color.Sur_team;
            Sur_3_team.Foreground = Config.Front.Color.Sur_team;
            Sur_4_team.Foreground = Config.Front.Color.Sur_team;
            Hun_player.Foreground = Config.Front.Color.Hun_player;
            Sur_score.Foreground = Config.Front.Color.score;
            Hun_score.Foreground = Config.Front.Color.score;
            Sur_scoreS.Foreground = Config.Front.Color.scoreS;
            Hun_scoreS.Foreground = Config.Front.Color.scoreS;
        }
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
