﻿using bp_sys_wpf.Views.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Views.Pages
{
    /// <summary>
    /// MapBpPage.xaml 的交互逻辑
    /// </summary>
    public partial class MapBpPage : Page
    {
        public MapBpPage()
        {
            InitializeComponent();
            DataContext = BackWindow.backWindow.rootViewModel;
        }
    }
}
