using bp_sys_wpf.Model;
using bp_sys_wpf.Views.Windows;
using System.ComponentModel;

namespace bp_sys_wpf.ViewModel
{
    public class BpShowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private BpShowModel _bpshow = new BpShowModel();

        public BpShowModel BpShow
        {
            get
            {
                return _bpshow;
            }
            set
            {
                _bpshow = value;
                RaisePropertyChanged("BpShow");
            }
        }
        private BpReceiveModel _ReceiveModel;

        public BpReceiveModel ReceiveModel
        {
            get
            {
                return _ReceiveModel;
            }
            set
            {
                _ReceiveModel = value;
                RaisePropertyChanged("ReceiveModel");
            }
        }

        public void SwapCharacrer(int num1, int num2)
        {
            (BpShow.SurPick[num1], BpShow.SurPick[num2]) = (BpShow.SurPick[num2], BpShow.SurPick[num1]);
            (ReceiveModel.SurPick[num1], ReceiveModel.SurPick[num2]) = (ReceiveModel.SurPick[num2], ReceiveModel.SurPick[num1]);
            BpShow = BpShow;
            BackWindow.backWindow.rootViewModel.BpReceiveModel = BackWindow.backWindow.rootViewModel.BpReceiveModel;
        }
        public void ShowBp(string ComboBoxType, int num)
        {
            GetFilePath getFilePath = new GetFilePath();
            switch (ComboBoxType)
            {
                case "SurBan":
                    BpShow.SurBan[num] = getFilePath.GetImage("surban", ReceiveModel.SurBan[num]);
                    BpShow = BpShow;
                    break;
                case "SurGlobalBan":
                    BpShow.SurGlobalBan[num] = getFilePath.GetImage("surban", ReceiveModel.SurGlobalBan[num]);
                    BpShow = BpShow;
                    break;
                case "HunBan":
                    BpShow.HunBan[num] = getFilePath.GetImage("hunban", ReceiveModel.HunBan[num]);
                    BpShow = BpShow;
                    break;
                case "SurPick":
                    BpShow.SurPick[num].ChartcherHalfImage = getFilePath.GetImage("surhalf", ReceiveModel.SurPick[num].CharacterName);
                    BpShow.SurPick[num].ChartcherBigImage = getFilePath.GetImage("surBig", ReceiveModel.SurPick[num].CharacterName);
                    BpShow.SurPick[num].ChartcherHeadImage = getFilePath.GetImage("sur", ReceiveModel.SurPick[num].CharacterName);
                    BpShow.SurPick[num].ChartcherName = ReceiveModel.SurPick[num].CharacterName;
                    BpShow = BpShow;
                    break;
                case "HunPick":
                    BpShow.HunPick.ChartcherName = ReceiveModel.HunPick;
                    BpShow.HunPick.ChartcherHalfImage = getFilePath.GetImage("hunhalf", ReceiveModel.HunPick);
                    BpShow.HunPick.ChartcherBigImage = getFilePath.GetImage("hunBig", ReceiveModel.HunPick);
                    BpShow.HunPick.ChartcherHeadImage = getFilePath.GetImage("hun", ReceiveModel.HunPick);
                    BpShow = BpShow;
                    break;
            }

        }
    }
}
