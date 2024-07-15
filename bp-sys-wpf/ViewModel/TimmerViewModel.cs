using System;
using System.Collections.Generic;
using System.ComponentModel;
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

       


        private int _CountDownTimeSet;

        public int CountDownTimeSet
        {
            get { return _CountDownTimeSet; }
            set { _CountDownTimeSet = Convert.ToInt32(value); }
        }

        private string _CountDownTime;

        public string CountdownTime
        {
            get {
                if (_CountDownTime == null)
                {
                    dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
                    dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
                    dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
                }
                return _CountDownTime; 
            }
            set
            {
                _CountDownTime = value;
                RaisePropertyChanged("Countdown");
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
            }
            else
            {
                _CountDownTime = countdownTime.ToString();
            }
        }
    }
}
