using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using TimerLord;

namespace TimerLordViewModel
{
    public class StopwatchViewModel : ObservableObject
    {
        private StopwatchModel stopwatchModel;

        public StopwatchViewModel()
        {
            stopwatchModel = new StopwatchModel();
            stopwatchModel.PropertyChanged += OnModelChanged;
            ElapsedTime = "00:00.00";
            ButtonStartStopText = "Start";
            ButtonResetEnabled = true;
        }

        private void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ElapsedTime2")
            {
                NotifyPropertyChanged("ElapsedTime");
                NotifyPropertyChanged("ElapsedHundreths");
            }
        }

        private string _buttonStartStopText;
        private bool _buttonResetEnabled;

        public string ElapsedTime
        {
            get
            {
                return stopwatchModel.ElapsedTime2.Substring(0, 5);
            }
            set
            {
                stopwatchModel.ElapsedTime2 = value;
            }
        }

        public string ElapsedHundreths
        {
            get
            {
                return stopwatchModel.ElapsedTime2.Substring(5, 3);
            }
            set
            {
                stopwatchModel.ElapsedTime2 = value;
            }
        }

        public string ButtonStartStopText
        {
            get
            {
                return _buttonStartStopText;
            }
            set
            {
                _buttonStartStopText = value;
                NotifyPropertyChanged("ButtonStartStopText");
            }
        }

        public bool ButtonResetEnabled
        {
            get
            {
                return _buttonResetEnabled;
            }
            set
            {
                _buttonResetEnabled = value;
                NotifyPropertyChanged("ButtonResetEnabled");
            }
        }

        public ICommand ButtonStartStop
        {
            get
            {
                return new RelayCommand(param => StartCounting(), param => true);
            }
        }

        public ICommand ButtonReset
        {
            get
            {
                return new RelayCommand(param => ResetStopwatch(), param => true);
            }
        }

        public ICommand ButtonClose
        {
            get
            {
                return new RelayCommand(param => Close(), param => true);
            }
        }

        private void StartCounting()
        {
            stopwatchModel.StartStopwatch();

            if (ButtonStartStopText == "Start")
            {
                ButtonStartStopText = "Stop";
                ButtonResetEnabled = false;
            }
            else if (ButtonStartStopText == "Stop")
            {
                ButtonStartStopText = "Start";
                ButtonResetEnabled = true;
            }
        }

        private void ResetStopwatch()
        {
            stopwatchModel = new StopwatchModel();
            stopwatchModel.PropertyChanged += OnModelChanged;
            ElapsedTime = "00:00.00";
        }

        private void Close()
        {
            Application.Current.Shutdown();
        }
    }
}