using bp_sys_wpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp_sys_wpf.ViewModel
{
    public class NowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private NowModel _NowModel;

        public NowModel NowModel
        {
            get
            {
                if(_NowModel == null)
                {
                    _NowModel = new NowModel();//初始化
                    for (int i = 0; i < 4; i++)
                    {
                        _NowModel.NowPlayer.Add(new NowPlayerInfo());
                    }
                    _NowModel.NowPlayer.Add(new NowPlayerInfo());
                }
                return _NowModel;
            }
            set
            {
                _NowModel = value;
                RaisePropertyChanged("NowModel");
            }
        }

    }
}
