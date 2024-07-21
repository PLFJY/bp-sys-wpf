using System.Windows;
using System.Windows.Media.Animation;

namespace bp_sys_wpf.Model
{
    public static class AnimationSetting
    {
        //淡入
        public static DoubleAnimation fadeIn = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(0.3)));
        //淡出
        public static DoubleAnimation fadeOut = new DoubleAnimation(1, 0, new Duration(TimeSpan.FromSeconds(0.3)));
    }
}
