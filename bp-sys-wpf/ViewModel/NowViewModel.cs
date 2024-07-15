using bp_sys_wpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp_sys_wpf.ViewModel
{
    public class NowViewModel
    {
        private NowModel _NowModel;

        public NowModel NowModel
        {
            get
            {
                if (_NowModel == null)
                {
                    _NowModel = new NowModel();//初始化
                    for (int i = 0; i < 4; i++)
                    {
                        _NowModel.NowPlayer.Add(new NowPlayerInfo { Name = "" });
                    }
                    _NowModel.NowPlayer.Add(new NowPlayerInfo() { Name = "" });
                }
                return _NowModel;
            }
            set
            {
                _NowModel = value;
            }
        }

    }
}
