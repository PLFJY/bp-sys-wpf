using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp_sys_wpf.ViewModel
{
    public class RootViewModel
    {
        public TeamInfoViewModel TeamInfoViewModel { get; set; } = new TeamInfoViewModel();
        public TimmerViewModel TimmerViewModel { get; set; } = new TimmerViewModel();
    }
}
