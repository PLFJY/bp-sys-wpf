using System.Windows;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Model
{
    public class BpShowModel
    {
        private List<BitmapImage> _SurBan = new List<BitmapImage>(4) { null, null, null, null };
        public List<BitmapImage> SurBan
        {
            get { return _SurBan; }
            set { _SurBan = value; }
        }

        private List<BitmapImage> _SurHoleBan = new List<BitmapImage>(9) { null, null, null, null, null, null, null, null, null };

        public List<BitmapImage> SurHoleBan
        {
            get { return _SurHoleBan; }
            set { _SurHoleBan = value; }
        }

        private List<BitmapImage> _HunBan = new List<BitmapImage>(3) { null, null, null };

        public List<BitmapImage> HunBan
        {
            get { return _HunBan; }
            set { _HunBan = value; }
        }

        private List<SurPickShowInfo> _SurPick = new List<SurPickShowInfo>(4) { new SurPickShowInfo(), new SurPickShowInfo(), new SurPickShowInfo(), new SurPickShowInfo() };

        public List<SurPickShowInfo> SurPick
        {
            get { return _SurPick; }
            set { _SurPick = value; }
        }

        public HunPickShowInfo HunPick { get; set; } = new HunPickShowInfo();

        private List<Visibility> _HunBanLock;

        public List<Visibility> HunBanLock
        {
            get
            {
                if (_HunBanLock == null)
                {
                    _HunBanLock = new List<Visibility>();
                    for (int i = 0; i < 3; i++)
                    {
                        _HunBanLock.Add(Visibility.Hidden);
                    }
                }
                return _HunBanLock;
            }
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
                    for (int i = 0; i < 9; i++)
                    {
                        _SurHoleBanLock.Add(Visibility.Hidden);
                    }
                }
                return _SurHoleBanLock;
            }
            set { _HunBanLock = value; }
        }

        public BitmapImage MapPick { get; set; }

        public BitmapImage MapBan { get; set; }

        public BitmapImage Trait { get; set; }

        public Visibility TraitState { get; set; } = Visibility.Collapsed;

        public HunTalentsShow HunTalents { get; set; } = new HunTalentsShow();
    }
    public class SurPickShowInfo
    {
        public BitmapImage ChartcherHalfImage { get; set; }
        public BitmapImage ChartcherBigImage { get; set; }
        public BitmapImage ChartcherHeadImage { get; set; }
        public string ChartcherName { get; set; }
        public TalentsShow Talent { get; set; } = new TalentsShow();

    }
    public class TalentsShow
    {
        public Visibility BorrowedTime { get; set; } = Visibility.Collapsed;
        public Visibility KneeJerkReflex { get; set; } = Visibility.Collapsed;
        public Visibility TideTurner { get; set; } = Visibility.Collapsed;
        public Visibility FlywheelEffect { get; set; } = Visibility.Collapsed;
    }

    public class HunPickShowInfo
    {
        public BitmapImage ChartcherHalfImage { get; set; }
        public BitmapImage ChartcherBigImage { get; set; }
        public BitmapImage ChartcherHeadImage { get; set; }
        public string ChartcherName { get; set; }
    }
    public class HunTalentsShow//监管者天赋
    {
        public Visibility ConfinedSpace { get; set; } = Visibility.Collapsed;
        public Visibility Detention { get; set; } = Visibility.Collapsed;
        public Visibility Insolence { get; set; } = Visibility.Collapsed;
        public Visibility TrumpCard { get; set; } = Visibility.Collapsed;
    }
}
