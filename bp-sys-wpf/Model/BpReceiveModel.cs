using bp_sys_wpf.ViewModel;
using System.Windows;

namespace bp_sys_wpf.Model
{
    public class BpReceiveModel
    {
        public BpShowViewModel BpShowViewModel { get; set; }//引入BpShowViewModel，内容由BackWindow传入

        private List<string> _SurBan = new List<string>(4) { null, null, null, null };//求生Ban

        public List<string> SurBan
        {
            get { return _SurBan; }
            set { _SurBan = value; }
        }

        private List<string> _SurHoleBan = new List<string>(9) { null, null, null, null, null, null, null, null, null };//全局Ban

        public List<string> SurHoleBan
        {
            get { return _SurHoleBan; }
            set { _SurHoleBan = value; }
        }

        private List<string> _HunBan = new List<string>(3) { null, null, null };//监管Ban

        public List<string> HunBan
        {
            get { return _HunBan; }
            set { _HunBan = value; }
        }

        private List<SurPickInfo> _SurPick = new List<SurPickInfo>(4) { new SurPickInfo(), new SurPickInfo(), new SurPickInfo(), new SurPickInfo() };//求生Pick

        public List<SurPickInfo> SurPick
        {
            get
            {
                for (int i = 0; i < 4; i++)//天赋转换到前台
                {
                    if (_SurPick[i].Talent.BorrowedTime == true)//大心脏
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.BorrowedTime = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.BorrowedTime = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.KneeJerkReflex == true)//双弹
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.KneeJerkReflex = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.KneeJerkReflex = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.TideTurner == true)//搏命
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.TideTurner = Visibility.Visible;
                    }
                    else
                    {
                        BpShowViewModel.BpShow.SurPick[i].Talent.TideTurner = Visibility.Collapsed;
                    }

                    if (_SurPick[i].Talent.FlywheelEffect == true)//飞轮
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

        private List<bool> _HunBanLock;//监管ban位数量设定

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

        private List<bool> _SurHoleBanLock;//全局ban位数量设定

        public List<bool> SurHoleBanLock
        {
            get
            {
                if (_SurHoleBanLock == null)
                {
                    _SurHoleBanLock = new List<bool>();
                    for (int i = 0; i < 9; i++)
                    {
                        _SurHoleBanLock.Add(true);
                    }
                }
                for (int i = 0; i < 9; i++)
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

        public string HunPick { get; set; }//监管Pick

        private List<string> _SurHoleBanMainRecord;

        public List<string> SurHoleBanMainRecord//主队全局Ban记录
        {
            get
            {
                if (_SurHoleBanMainRecord == null)
                {
                    _SurHoleBanMainRecord = new List<string>();
                    for (int i = 0; i < 9; i++)
                    {
                        _SurHoleBanMainRecord.Add(null);
                    }
                }
                return _SurHoleBanMainRecord;
            }
            set { _SurHoleBanMainRecord = value; }
        }

        private List<string> _SurHoleBanAwayRecord;//客队全局Ban记录

        public List<string> SurHoleBanAwayRecord
        {
            get
            {
                if (_SurHoleBanAwayRecord == null)
                {
                    _SurHoleBanAwayRecord = new List<string>();
                    for (int i = 0; i < 9; i++)
                    {
                        _SurHoleBanAwayRecord.Add(null);
                    }
                }
                return _SurHoleBanAwayRecord;
            }
            set { _SurHoleBanAwayRecord = value; }
        }

        private string _MapPick;//地图Pick

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

        private string _MapBan;//地图Ban

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

        private string _Trait;

        public string Trait
        {
            get
            {
                GetFilePath getFilePath = new GetFilePath();
                BpShowViewModel.BpShow.Trait = getFilePath.GetImage("Talent\\Hun\\Trait", _Trait);
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _Trait;
            }
            set { _Trait = value; }
        }

        private bool _TraitState;

        public bool TraitState
        {
            get
            {
                if (_TraitState == true)
                {
                    BpShowViewModel.BpShow.TraitState = Visibility.Visible;
                }
                else
                {
                    BpShowViewModel.BpShow.TraitState = Visibility.Collapsed;
                }
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _TraitState;
            }
            set { _TraitState = value; }
        }

        private HunTalents _HunTalents = new HunTalents();

        public HunTalents HunTalents
        {
            get
            {
                if (_HunTalents.ConfinedSpace == true)//封窗
                {
                    BpShowViewModel.BpShow.HunTalents.ConfinedSpace = Visibility.Visible;
                }
                else
                {
                    BpShowViewModel.BpShow.HunTalents.ConfinedSpace = Visibility.Collapsed;
                }
                if (_HunTalents.Detention == true)//一刀斩
                {
                    BpShowViewModel.BpShow.HunTalents.Detention = Visibility.Visible;
                }
                else
                {
                    BpShowViewModel.BpShow.HunTalents.Detention = Visibility.Collapsed;
                }
                if (_HunTalents.Insolence == true)//张狂
                {
                    BpShowViewModel.BpShow.HunTalents.Insolence = Visibility.Visible;
                }
                else
                {
                    BpShowViewModel.BpShow.HunTalents.Insolence = Visibility.Collapsed;
                }
                if (_HunTalents.TrumpCard == true)//底牌
                {
                    BpShowViewModel.BpShow.HunTalents.TrumpCard = Visibility.Visible;
                }
                else
                {
                    BpShowViewModel.BpShow.HunTalents.TrumpCard = Visibility.Collapsed;
                }
                BpShowViewModel.BpShow = BpShowViewModel.BpShow;
                return _HunTalents;
            }
            set { _HunTalents = value; }
        }

    }
    public class SurPickInfo//求生Pick集合
    {
        public string CharacterName { get; set; }
        public Talents Talent { get; set; } = new Talents();
    }
    public class Talents//天赋
    {
        public bool BorrowedTime { get; set; }
        public bool KneeJerkReflex { get; set; }
        public bool TideTurner { get; set; }
        public bool FlywheelEffect { get; set; }
    }
    public class HunTalents//监管者天赋
    {
        public bool ConfinedSpace { get; set; }
        public bool Detention { get; set; }
        public bool Insolence { get; set; }
        public bool TrumpCard { get; set; }
    }
}
