using System.Windows.Media;

namespace bp_sys_wpf
{
    public static class Config
    {
        public static string version { get; set; } = "V1.8";
        public static bool Border { get; set; }
        public static class Front
        {
            public static class Color
            {
                public static SolidColorBrush team_name { get; set; }
                public static SolidColorBrush scoreS { get; set; }
                public static SolidColorBrush score { get; set; }
                public static SolidColorBrush timmer { get; set; }
                public static SolidColorBrush Sur_team { get; set; }
                public static SolidColorBrush Sur_player { get; set; }
                public static SolidColorBrush Hun_player { get; set; }
            }
            public static class Fonts
            {
                public static FontFamily team_name { get; set; }
                public static FontFamily scoreS { get; set; }
                public static FontFamily score { get; set; }
                public static FontFamily timmer { get; set; }
                public static FontFamily Sur_team { get; set; }
                public static FontFamily Sur_player { get; set; }
                public static FontFamily Hun_player { get; set; }
            }
        }
        public static class Interlude
        {
            public static class Color
            {
                public static SolidColorBrush team_name { get; set; }
                public static SolidColorBrush player_name { get; set; }
            }
            public static class Fonts
            {
                public static FontFamily team_name { get; set; }
                public static FontFamily player_name { get; set; }
            }
        }
        public static class Score
        {
            public static class Color
            {
                public static SolidColorBrush TeamName { get; set; }
                public static SolidColorBrush Score { get; set; }
                public static SolidColorBrush Word { get; set; }
                public static SolidColorBrush S { get; set; }
            }
            public static class Fonts
            {
                public static FontFamily TeamName { get; set; }
                public static FontFamily Score { get; set; }
                public static FontFamily Word { get; set; }
                public static FontFamily S { get; set; }
            }
        }
        public static class ScoreHole
        {
            public static class Color
            {
                public static SolidColorBrush Name { get; set; }
                public static SolidColorBrush Score { get; set; }
            }
            public static class Fonts
            {
                public static FontFamily Name { get; set; }
                public static FontFamily Score { get; set; }
            }
        }
    }
}
