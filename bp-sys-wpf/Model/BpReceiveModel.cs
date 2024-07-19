using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using bp_sys_wpf.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace bp_sys_wpf.Model
{
    public class BpReceiveModel
    {
        private List<string> _SurBan;

        public List<string> SurBan
        {
            get
            {
                if (_SurBan == null)
                {
                    _SurBan = new List<string>();
                    for (int i = 0; i < 4; i++)
                    {
                        _SurBan.Add(null);
                    }
                }
                return _SurBan;
            }
            set { _SurBan = value; }
        }

        private List<string> _SurHoleBan;

        public List<string> SurHoleBan
        {
            get
            {
                if (_SurHoleBan == null)
                {
                    _SurHoleBan = new List<string>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurHoleBan.Add(null);
                    }
                }
                return _SurHoleBan;
            }
            set { _SurHoleBan = value; }
        }

        private List<string> _HunBan;

        public List<string> HunBan
        {
            get
            {
                if (_HunBan == null)
                {
                    _HunBan = new List<string>();
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
                for (int i = 0; i < 4; i++)
                {
                    if (_SurPick[i].Talent.BorrowedTime == true)
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.BorrowedTime = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.BorrowedTime = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.KneeJerkReflex == true)
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.KneeJerkReflex = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.KneeJerkReflex = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.TideTurner == true)
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.TideTurner = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.TideTurner = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.FlywheelEffect == true)
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.FlywheelEffect = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.FlywheelEffect = Visibility.Collapsed;
                    }
                }
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _SurPick;
            }
            set { _SurPick = value; }
        }

        private List<bool> _HunBanLock;

        public List<bool> HunBanLock
        {
            get
            {
                if (_HunBanLock == null)
                {
                    _HunBanLock = new List<bool>();
                    for (int i = 0; i < 3; i++)
                    {
                        _HunBanLock.Add(true);
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    if (_HunBanLock[i] == false)
                    {
                        BpShowViewModel.BpShow.HunBanLock[i] = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.HunBanLock[i] = Visibility.Hidden;
                    }
                }
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _HunBanLock;
            }
            set { _HunBanLock = value; }
        }
        public BpShowViewModel BpShowViewModel { get; set; }

        private List<bool> _SurHoleBanLock;

        public List<bool> SurHoleBanLock
        {
            get
            {
                if (_SurHoleBanLock == null)
                {
                    _SurHoleBanLock = new List<bool>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurHoleBanLock.Add(true);
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    if (_SurHoleBanLock[i] == false)
                    {
                        BpShowViewModel.BpShow.SurHoleBanLock[i] = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurHoleBanLock[i] = Visibility.Hidden;
                    }
                }
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _SurHoleBanLock;
            }
            set { _SurHoleBanLock = value; }
        }

        public string HunPick { get; set; }

        private List<string> _SurHoleBanMainRecord;

        public List<string> SurHoleBanMainRecord
        {
            get
            {
                if (_SurHoleBanMainRecord == null)
                {
                    _SurHoleBanMainRecord = new List<string>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurHoleBanMainRecord.Add(null);
                    }
                }
                return _SurHoleBanMainRecord;
            }
            set { _SurHoleBanMainRecord = value; }
        }

        private List<string> _SurHoleBanAwayRecord;

        public List<string> SurHoleBanAwayRecord
        {
            get
            {
                if (_SurHoleBanAwayRecord == null)
                {
                    _SurHoleBanAwayRecord = new List<string>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurHoleBanAwayRecord.Add(null);
                    }
                }
                return _SurHoleBanAwayRecord;
            }
            set { _SurHoleBanAwayRecord = value; }
        }

        private string _MapPick;

        public string MapPick
        {
            get
            {
                GetFilePath getFilePath = new GetFilePath();
                BpShowViewModel.BpShow.MapPick = getFilePath.GetImage("map", _MapPick);
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _MapPick;
            }
            set { _MapPick = value; }
        }

        private string _MapBan;

        public string MapBan
        {
            get
            {
                GetFilePath getFilePath = new GetFilePath();
                BpShowViewModel.BpShow.MapBan = getFilePath.GetImage("mapBan", _MapBan);
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _MapBan;
            }
            set { _MapBan = value; }
        }
        public class SurPickInfo
        {
            public string CharacterName { get; set; }
            public Talents Talent { get; set; } = new Talents();
        }
        public class Talents
        {
            public bool BorrowedTime { get; set; }
            public bool KneeJerkReflex { get; set; }
            public bool TideTurner { get; set; }
            public bool FlywheelEffect { get; set; }
        }
    }
}
