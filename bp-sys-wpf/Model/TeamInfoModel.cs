using System.ComponentModel;
using System.Windows.Media;

namespace bp_sys_wpf.Model
{
    public class TeamInfoModel
    {
        private List<Player> _MainTeamPlayer = new List<Player>();//主队选手列表

        public List<Player> MainTeamPlayer
        {
            get { return _MainTeamPlayer; }
            set { _MainTeamPlayer = value; }
        }

        private List<Player> _AwayTeamPlayer = new List<Player>();//客队选手列表

        public List<Player> AwayTeamPlayer
        {
            get { return _AwayTeamPlayer; }
            set { _AwayTeamPlayer = value; }
        }

        private Team _MainTeamInfo = new Team();//主队信息&状态

        public Team MainTeamInfo
        {
            get { return _MainTeamInfo; }
            set { _MainTeamInfo = value; }
        }

        private Team _AwayTeamInfo = new Team();//客队状态&信息

        public Team AwayTeamInfo
        {
            get { return _AwayTeamInfo; }
            set { _AwayTeamInfo = value; }
        }


        private NowTeam _NowSurTeam;

        public NowTeam NowSurTeam
        {
            get { return _NowSurTeam; }
            set { _NowSurTeam = value; }
        }

        private NowTeam _NowHunTeam;

        public NowTeam NowHunTeam
        {
            get { return _NowHunTeam; }
            set { _NowHunTeam = value; }
        }

    }
    public class TeamInfoPageButtonModel
    {
        private List<TeamInfoPageButton> _MainButtonState = new List<TeamInfoPageButton>();

        public List<TeamInfoPageButton> MainButtonState
        {
            get { return _MainButtonState; }
            set { _MainButtonState = value; }
        }

        private List<TeamInfoPageButton> _AwayButtonState = new List<TeamInfoPageButton>();

        public List<TeamInfoPageButton> AwayButtonState
        {
            get { return _AwayButtonState; }
            set { _AwayButtonState = value; }
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

        private ImageBrush _Logo;

        public ImageBrush LOGO
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

    }
    public class Team
    {
        private string _name;
        private string _state;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
    }

    public class Player
    {
        private string _name;
        private string _state;
        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private bool _IsPlayerTakeTheField;

        public bool IsPlayerTakeTheField
        {
            get { return _IsPlayerTakeTheField; }
            set { _IsPlayerTakeTheField = value; }
        }
    }

    public class TeamInfoPageButton
    {
        private string _content = "上场";

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private Wpf.Ui.Controls.SymbolIcon _icon= new Wpf.Ui.Controls.SymbolIcon
        {
            Symbol= Wpf.Ui.Controls.SymbolRegular.ArrowExportUp24
        };

        public Wpf.Ui.Controls.SymbolIcon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private bool _isEnabled = true;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        private SolidColorBrush _Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00FF00"));

        public SolidColorBrush Background
        {
            get { return _Background; }
            set { _Background = value; }
        }
    }
}
