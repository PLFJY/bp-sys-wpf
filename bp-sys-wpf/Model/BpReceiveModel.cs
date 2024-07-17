using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static bp_sys_wpf.Model.BpShowModel;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using bp_sys_wpf.ViewModel;
using System.Windows;

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
                    _SurBan = new List<string>();
                    for (int i = 0; i < 6; i++)
                    {
                        _SurBan.Add(null);
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

        private List<string> _SurPick;

        public List<string> SurPick
        {
            get
            {
                if (_SurPick == null)
                {
                    _SurPick = new List<string>();
                    for (int i = 0; i < 4; i++)
                    {
                        _SurPick.Add(null);
                    }
                }
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
                        BpShowViewModel.bpShow.HunBanLock[i] = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.bpShow.HunBanLock[i] = Visibility.Hidden;
                    }
                }
                BpShowViewModel.bpShow = BpShowViewModel.bpShow;
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
                        BpShowViewModel.bpShow.SurHoleBanLock[i] = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.bpShow.SurHoleBanLock[i] = Visibility.Hidden;
                    }
                }
                BpShowViewModel.bpShow = BpShowViewModel.bpShow;
                return _SurHoleBanLock;
            }
            set { _SurHoleBanLock = value; }
        }

        private List<bool> _SurPicking;

        public List<bool> SurPicking
        {
            get
            {
                if (_SurPicking == null)
                {
                    _SurPicking = new List<bool>();
                    for (int i = 0; i < 3; i++)
                    {
                        _SurPicking.Add(false);
                    }
                }
                return _SurPicking;
            }
            set { _SurPicking = value; }
        }

        public string HunPick { get; set; }
    }
}
