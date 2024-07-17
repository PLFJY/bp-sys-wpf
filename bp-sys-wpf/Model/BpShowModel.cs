using bp_sys_wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            get
            {
                if (_HunBan == null)
                {
                    _HunBan = new List<BitmapImage>();
                    for (int i = 0; i < 3; i++)
                    {
                        _HunBan.Add(null);
                    }
                }
                return _HunBan;
            }
            set { _HunBan = value; }
        }

        private List<SurPickInfo> _SurPick;

        public List<SurPickInfo> SurPick
        {
            get
            {
                if (_SurPick == null)
                {
                    _SurPick = new List<SurPickInfo>();
                    for (int i = 0; i < 4; i++)
                    {
                        _SurPick.Add(new SurPickInfo());
                    }
                }
                return _SurPick;
            }
            set { _SurPick = value; }
        }

        public HunPickInfo HunPick { get; set; }

        private List<Visibility> _PickingBorder;
        
        public List<Visibility> PickingBorder
        {
            get
            {
                if (_PickingBorder == null)
                {
                    _PickingBorder = new List<Visibility>();
                    for (int i = 0; i < 4; i++)
                    {
                        _PickingBorder.Add(Visibility.Hidden);
                    }
                }
                return _PickingBorder;
            }
            set { _PickingBorder = value; }
        }

        private List<Visibility> _HunBanLock;

        public List<Visibility> HunBanLock
        {
            get { 
                if(_HunBanLock == null)
                {
                    _HunBanLock = new List<Visibility>();
                    for(int i = 0; i < 3; i++)
                    {
                        _HunBanLock.Add(Visibility.Hidden);
                    }
                }
                return _HunBanLock; }
            set { _HunBanLock = value; }
        }

        private List<Visibility> _SurHoleBanLock;

        public List<Visibility> SurHoleBanLock
        {
            get
            {
                if (_SurHoleBanLock == null)
                {
                    _SurHoleBanLock = new List<Visibility>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurHoleBanLock.Add(Visibility.Hidden);
                    }
                }
                return _SurHoleBanLock;
            }
            set { _HunBanLock = value; }
        }

        public class SurPickInfo
        {
            public BitmapImage ChartcherHalfImage { get; set; }
            public BitmapImage ChartcherBigImage { get; set; }
            public BitmapImage ChartcherHeadImage { get; set; }
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

        public class HunPickInfo
        {
            public BitmapImage ChartcherHalfImage { get; set; }
            public BitmapImage ChartcherBigImage { get; set; }
            public BitmapImage ChartcherHeadImage { get; set; }
            public string ChartcherName { get; set; }
        }
    }

}
