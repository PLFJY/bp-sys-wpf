using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Model
{
    public class ScoreHoleModel
    {
        private List<GameResault> _ScoreHoleShow;

        public List<GameResault> ScoreHoleShow
        {
            get
            {
                if (_ScoreHoleShow == null)
                {
                    _ScoreHoleShow = new List<GameResault>();
                    for (int i = 0; i < 10; i++)
                    {
                        _ScoreHoleShow.Add(new GameResault());
                    }
                }
                return _ScoreHoleShow;
            }
            set { _ScoreHoleShow = value; }
        }
    }
    public class GameResault
    {
        public string MainScore { get; set; } = "-";
        public string AwayScore { get; set; } = "-";
        public string MainTeamState { get; set; } = string.Empty;
        public string AwayTeamState { get; set; } = string.Empty;
        public BitmapImage MainIcon { get; set; }
        public BitmapImage AwayIcon { get; set; }
        public RadioButtonState RadioButtonState { get; set; } = new RadioButtonState();
        public bool IsGameFinished { get; set; }

    }
    public class RadioButtonState
    {
        public bool Escape4 { get; set; }
        public bool Escape3 { get; set; }
        public bool Tie { get; set; }
        public bool Out3 { get; set; }
        public bool Out4 { get; set; }
    }
}
