using System;
using System.Windows.Threading;
using System.Diagnostics;
using TimerLordViewModel;

namespace TimerLord
{
    class StopwatchModel : ObservableObject
    {
        Stopwatch stopwatch = new Stopwatch();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        TimeSpan timeSpan = new TimeSpan();

        private string _elapsedTime2;

        public string ElapsedTime2
        {
            get
            {
                return _elapsedTime2;
            }
            set
            {
                _elapsedTime2 = value;
                NotifyPropertyChanged("ElapsedTime2");
            }
        }


        public StopwatchModel()
        {
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);
        }

        public void StartStopwatch()
        {
            if (!stopwatch.IsRunning)
            {
                dispatcherTimer.Start();
                stopwatch.Start();
            }
            else
            {
                dispatcherTimer.Stop();
                stopwatch.Stop();
            }
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            timeSpan = stopwatch.Elapsed;
            ElapsedTime2 = timeSpan.ToString(@"mm\:ss\.ff");
        }
    }
}