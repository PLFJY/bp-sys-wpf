using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Model
{
    public class BpShowModel
    {
        private List<BitmapImage> _SurBan;
        //这里的List存的是BitmapImage类型，能直接绑定给Image的Source
        public List<BitmapImage> SurBan
        {
            get
            {
                if (_SurBan == null)
                {
                    _SurBan = new List<BitmapImage>();
                    for (int i = 0; i < 4; i++)
                    {
                        _SurBan.Add(null);
                    }
                }
                return _SurBan;
            }
            set { _SurBan = value; }
        }

        private List<BitmapImage> _SurHoleBan;

        public List<BitmapImage> SurHoleBan
        {
            get
            {
                if (_SurHoleBan == null)
                {
                    _SurBan = new List<BitmapImage>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurBan.Add(null);
                    }
                }
                return _SurHoleBan;
            }
            set { _SurHoleBan = value; }
        }

        private List<BitmapImage> _HunBan;

        public List<BitmapImage> HunBan
        {
            get {
                if(_HunBan == null)
                {
                    _HunBan = new List<BitmapImage>();
                    for(int i = 0; i < 3; i++)
                    {
                        _HunBan.Add(null);
                    }
                }
                return _HunBan; }
            set { _HunBan = value; }
        }

        private List<SurPickInfo> _SupPick;

        public List<SurPickInfo> SurPick
        {
            get { return _SupPick; }
            set { _SupPick = value; }
        }

        public class SurPickInfo
        {
            public BitmapImage ChartcherImage { get; set; }
            public string ChartcherName { get; set; }
            public Talents Talent { get; set; }

        }
        public class Talents
        {
            bool BorrowedTime { get; set; }
            bool KneeJerkReflex { get; set; }
            bool TideTurner { get; set; }
            bool FlywheelEffect { get; set; }
        }
    }

}
