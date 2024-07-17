using bp_sys_wpf.Model;
using bp_sys_wpf.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

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

        public BpShowModel bpShow
        {
            get { return _bpshow; }
            set
            {
                _bpshow = value;
                RaisePropertyChanged("bpShow");
            }
        }

        public BpReceiveModel ReceiveModel { get; set; }

        public void ShowBp(string ComboBoxType, int num)
        {
            GetFilePath getFilePath = new GetFilePath();
            switch (ComboBoxType)
            {
                case "SurBan":
                    bpShow.SurBan[num] = new BitmapImage(new Uri(getFilePath.GetImagePath("surban", ReceiveModel.SurBan[num])));
                    bpShow = bpShow;
                    break;

                case "SurHoleBan":
                    bpShow.SurHoleBan[num] = new BitmapImage(new Uri(getFilePath.GetImagePath("surban", ReceiveModel.SurHoleBan[num])));
                    bpShow = bpShow;
                    break;

                case "HunBan":
                    bpShow.HunBan[num] = new BitmapImage(new Uri(getFilePath.GetImagePath("hunban", ReceiveModel.HunBan[num])));
                    bpShow = bpShow;
                    break;

                case "SurPick":
                    bpShow.SurPick[num].ChartcherHalfImage= new BitmapImage(new Uri(getFilePath.GetImagePath("surhalf", ReceiveModel.SurPick[num])));
                    bpShow.SurPick[num].ChartcherBigImage = new BitmapImage(new Uri(getFilePath.GetImagePath("surBig", ReceiveModel.SurPick[num])));
                    bpShow.SurPick[num].ChartcherHeadImage = new BitmapImage(new Uri(getFilePath.GetImagePath("sur", ReceiveModel.SurPick[num])));
                    bpShow.SurPick[num].ChartcherName = getFilePath.GetComboBoxItemContent(ReceiveModel.SurPick[num]);
                    bpShow = bpShow;
                    break;

                case "HunPick":
                    bpShow.HunPick.ChartcherName = getFilePath.GetComboBoxItemContent(ReceiveModel.HunPick);
                    bpShow.HunPick.ChartcherHalfImage = new BitmapImage(new Uri(getFilePath.GetImagePath("hunhalf", ReceiveModel.HunPick)));
                    bpShow.HunPick.ChartcherBigImage = new BitmapImage(new Uri(getFilePath.GetImagePath("hunBig", ReceiveModel.HunPick)));
                    bpShow.HunPick.ChartcherHeadImage = new BitmapImage(new Uri(getFilePath.GetImagePath("hun", ReceiveModel.HunPick)));
                    bpShow = bpShow;
                    break;
            }

        }
    }
}
