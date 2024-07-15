using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp_sys_wpf.Model
{
    public class NowModel
    {
        private List<NowPlayerInfo> _NowPlayer = new List<NowPlayerInfo>();

        public List<NowPlayerInfo> NowPlayer
        {
            get { return _NowPlayer; }
            set { _NowPlayer = value; }
        }
    }
    public class NowPlayerInfo
    {
        private string _name;//选手ID

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _Character;//角色

        public string Character
        {
            get { return _Character; }
            set { _Character = value; }
        }

        private Talents _Talent;//天赋

        public Talents Talent
        {
            get { return _Talent; }
            set { _Talent = value; }
        }
    }
    public class Talents
    {
        bool BorrowedTime { get; set; }
        bool KneeJerkReflex { get; set; }
        bool TideTurner { get; set; }
        bool FlywheelEffect { get; set; }
    }
}
