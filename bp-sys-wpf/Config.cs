﻿using System.Windows.Media;

namespace bp_sys_wpf
{
    public static class Config
    {
        public static string version { get; set; } = "V4.0.8";
        public static bool Border { get; set; }
        public static class Front
        {
            public static class Color
            {
                public static SolidColorBrush team_name { get; set; }
                public static SolidColorBrush scoreS { get; set; }
                public static SolidColorBrush score { get; set; }
                public static SolidColorBrush timmer { get; set; }
                public static SolidColorBrush Sur_player { get; set; }
                public static SolidColorBrush Hun_player { get; set; }
            }
        }
        public static class Interlude
        {
            public static class Color
            {
                public static SolidColorBrush team_name { get; set; }
                public static SolidColorBrush player_name { get; set; }
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
        }
        public static class ScoreGlobal
        {
            public static class Color
            {
                public static SolidColorBrush Name { get; set; }
                public static SolidColorBrush Score { get; set; }
            }
        }
    }
}
