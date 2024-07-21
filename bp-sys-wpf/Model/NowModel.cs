using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Model
{
    public class NowModel
    {
        private List<string> _NowPlayer;

        public List<string> NowPlayer
        {
            get
            {
                if (_NowPlayer == null)
                {
                    _NowPlayer = new List<string>();
                    for (int i = 0; i < 4; i++)
                    {
                        _NowPlayer.Add("");
                    }
                    _NowPlayer.Add("");
                }
                return _NowPlayer;
            }
            set
            {
                _NowPlayer = value;
            }
        }
        public string NowHunPlayerId { get; set; }

        private List<string> _NowSurPlayerId;

        public List<string> NowSurPlayerId
        {
            get
            {
                if (_NowSurPlayerId == null)
                {
                    _NowSurPlayerId = new List<string>();
                    for (int i = 0; i < 4; i++)
                    {
                        _NowSurPlayerId.Add(null);
                    }
                }
                return _NowSurPlayerId;
            }
            set
            {
                _NowSurPlayerId = value;
            }
        }

        private NowTeam _NowSurTeam = new NowTeam();

        public NowTeam NowSurTeam
        {
            get { return _NowSurTeam; }
            set
            {
                _NowSurTeam = value;
            }
        }

        private NowTeam _NowHunTeam = new NowTeam();

        public NowTeam NowHunTeam
        {
            get { return _NowHunTeam; }
            set
            {
                _NowHunTeam = value;
            }
        }

    }
    public class NowTeam
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private BitmapImage _Logo;

        public BitmapImage LOGO
        {
            get { return _Logo; }
            set { _Logo = value; }
        }
        public Score Score { get; set; }
    }
    public class Score
    {
        public int W { get; set; } = 0;
        public int D { get; set; } = 0;
        public int L { get; set; } = 0;
        public int S { get; set; } = 0;
        public string BackView { get; set; } = "W:0 D:0 L:0 小比分:0";
        public string FrontView { get; set; } = "W0 D0 L0";
    }
}
