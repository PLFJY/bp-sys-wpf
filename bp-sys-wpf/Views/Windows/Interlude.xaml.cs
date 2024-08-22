using bp_sys_wpf.ViewModel;
using bp_sys_wpf.Views.Windows;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            GetFilePath getFilePath = new GetFilePath();
            DataContext = BackWindow.backWindow.rootViewModel;
            interlude = this;
            try
            {
                this.Background = new ImageBrush(new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/interlude_bg.png"))));
                Bottom.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/bottom.png")));
                NameImage.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("Resource/gui/name.png")));
                
                BorrowedTime1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/BorrowedTime.png")));
                BorrowedTime2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/BorrowedTime.png")));
                BorrowedTime3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/BorrowedTime.png")));
                BorrowedTime4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/BorrowedTime.png")));
                
                KneeJerkReflex1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/KneeJerkReflex.png")));
                KneeJerkReflex2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/KneeJerkReflex.png")));
                KneeJerkReflex3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/KneeJerkReflex.png")));
                KneeJerkReflex4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/KneeJerkReflex.png")));
                
                TideTurner1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/TideTurner.png")));
                TideTurner2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/TideTurner.png")));
                TideTurner3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/TideTurner.png")));
                TideTurner4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/TideTurner.png")));
                
                FlywheelEffect1.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/FlywheelEffect.png")));
                FlywheelEffect2.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/FlywheelEffect.png")));
                FlywheelEffect3.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/FlywheelEffect.png")));
                FlywheelEffect4.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Sur/FlywheelEffect.png")));

                ConfinedSpace.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Hun/ConfinedSpace.png")));
                Detention.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Hun/Detention.png")));
                Insolence.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Hun/Insolence.png")));
                TrumpCard.Source = new BitmapImage(new Uri(getFilePath.GetAbsoluteFilePath("pic/Talent/Hun/TrumpCard.png")));
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
