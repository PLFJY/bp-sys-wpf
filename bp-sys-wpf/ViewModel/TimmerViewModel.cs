using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace bp_sys_wpf.ViewModel
{
    public class TimmerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _CountDownTimeSet = 30;

        public int CountdownTimeSet
        {
            get { return _CountDownTimeSet; }
            set { _CountDownTimeSet = Convert.ToInt32(value); }
        }

        private string _CountdownTime = "VS";

        public string CountdownTime
        {
            get
            {
                if (_CountdownTime == null || _CountdownTime=="VS")
                {
                    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                    dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                    dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
                }
                return _CountdownTime;
            }
            set
            {
                _CountdownTime = value;
                RaisePropertyChanged("CountdownTime");
            }
        }
        private bool _IsCountDownStart;

        public bool IsCountDownStart
        {
            get { return _IsCountDownStart; }
            set
            {
                _IsCountDownStart = value;
                if (value == true)
                {
                    countdownTime = CountdownTimeSet;
                    CountdownTime = countdownTime.ToString();
                    dispatcherTimer.Start();
                }
                else
                {
                    dispatcherTimer.Stop();
                    CountdownTime = "VS";
                }
            }
        }


        private int countdownTime;
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            countdownTime--;
            if (countdownTime < 0)
            {
                dispatcherTimer.Stop();
                CountdownTime = "VS";
            }
            else
            {
                CountdownTime = countdownTime.ToString();
            }
        }
    }
}
