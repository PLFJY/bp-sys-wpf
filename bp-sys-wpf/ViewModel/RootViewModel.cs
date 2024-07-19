using bp_sys_wpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp_sys_wpf.ViewModel
{
    public class RootViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public TeamInfoViewModel TeamInfoViewModel { get; set; } = new TeamInfoViewModel();
        public TimmerViewModel TimmerViewModel { get; set; } = new TimmerViewModel();
        public BpShowViewModel BpShowViewModel { get; set; } = new BpShowViewModel();
        public ComboBoxItemViewModel ComboBoxItemViewModel { get; set; } = new ComboBoxItemViewModel();
        
        private BpReceiveModel _BpReceiveModel = new BpReceiveModel();

        public BpReceiveModel BpReceiveModel
        {
            get { return _BpReceiveModel; }
            set { _BpReceiveModel = value;
                RaisePropertyChanged("BpReceiveModel");
            }
        }

    }
}
