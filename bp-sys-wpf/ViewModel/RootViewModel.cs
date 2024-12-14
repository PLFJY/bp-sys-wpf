using bp_sys_wpf.Model;
using System.ComponentModel;

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

        private TeamInfoViewModel _TeamInfoViewModel = new TeamInfoViewModel();

        public TeamInfoViewModel TeamInfoViewModel
        {
            get { return _TeamInfoViewModel; }
            set
            {
                _TeamInfoViewModel = value;
                RaisePropertyChanged("TeamInfoViewModel");
            }
        }

        private TimmerViewModel _TimmerViewModel = new TimmerViewModel();

        public TimmerViewModel TimmerViewModel
        {
            get { return _TimmerViewModel; }
            set
            {
                _TimmerViewModel = value;
                RaisePropertyChanged("TimmerViewModel");
            }
        }

        private BpShowViewModel _BpShowViewModel = new BpShowViewModel();

        public BpShowViewModel BpShowViewModel
        {
            get { return _BpShowViewModel; }
            set { _BpShowViewModel = value; }
        }

        private ComboBoxItemViewModel myVar = new ComboBoxItemViewModel();

        public ComboBoxItemViewModel ComboBoxItemViewModel
        {
            get { return myVar; }
            set
            {
                myVar = value;
                RaisePropertyChanged("ComboBoxItemViewModel");
            }
        }


        private BpReceiveModel _BpReceiveModel = new BpReceiveModel();

        public BpReceiveModel BpReceiveModel
        {
            get { return _BpReceiveModel; }
            set
            {
                _BpReceiveModel = value;
                RaisePropertyChanged("BpReceiveModel");
            }
        }

        private ScoreGlobalModel _ScoreGlobalViewModel = new ScoreGlobalModel();

        public ScoreGlobalModel ScoreGlobalViewModel
        {
            get { return _ScoreGlobalViewModel; }
            set
            {
                _ScoreGlobalViewModel = value;
                RaisePropertyChanged("ScoreGlobalViewModel");
            }
        }


    }
}
