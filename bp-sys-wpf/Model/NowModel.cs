using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace bp_sys_wpf.Model
{
    public class NowModel
    {
        private List<string?> _NowPlayer = new List<string?>();

        public List<string?> NowPlayer
        {
            get { return _NowPlayer; }
            set { _NowPlayer = value; }
        }
        private NowTeam _NowSurTeam = new NowTeam();

        public NowTeam NowSurTeam
        {
            get { return _NowSurTeam; }
            set { _NowSurTeam = value; }
        }

        private NowTeam _NowHunTeam = new NowTeam();

        public NowTeam NowHunTeam
        {
            get { return _NowHunTeam; }
            set { _NowHunTeam = value; }
        }
    }
    public class NowTeam
    {
        private string? _Name;

        public string? Name
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

    }
}
