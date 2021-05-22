using System;
using System.Windows.Input;

using Prism.Commands;

using VNC;
using VNC.Core.Mvvm;

namespace WPFTestBed.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Constructors, Initialization, and Load

        public MainViewModel()
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_CATEGORY);

            Button1Command = new DelegateCommand(Button1Execute);
            Button2Command = new DelegateCommand(Button2Execute);
            Button3Command = new DelegateCommand(Button3Execute);

            Log.CONSTRUCTOR("Exit", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

        #region Fields and Properties

        private string _title = "IntroToLogging - MainWindow";

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _message = "Initial Message";

        public string Message
        {
            get => _message;
            set
            {
                if (_message == value)
                    return;
                _message = value;
                OnPropertyChanged();
            }
        }

        private int _numerator = 10;
        public int Numerator
        {
            get => _numerator;
            set
            {
                if (_numerator == value)
                    return;
                _numerator = value;
                OnPropertyChanged();
            }
        }

        private int _denominator = 2;
        public int Denominator
        {
            get => _denominator;
            set
            {
                if (_denominator == value)
                    return;
                _denominator = value;
                OnPropertyChanged();
            }
        }

        private string _answer = "???";

        public string Answer
        {
            get => _answer;
            set
            {
                if (_answer == value)
                    return;
                _answer = value;
                OnPropertyChanged();
            }
        }

        public ICommand Button1Command { get; private set; }
        public ICommand Button2Command { get; private set; }
        public ICommand Button3Command { get; private set; }

        #endregion

        #region Private Methods

        private void Button1Execute()
        {
            Int64 startTicks = Log.Info("Enter", "WHOISTHIS");

            Message = "Button1 Clicked";

            Log.Info("End", "WHOISTHIS", startTicks);
        }

        private void Button2Execute()
        {
            Int64 startTicks = Log.Debug("Enter", Common.LOG_CATEGORY);

            Message = "Button2 Clicked";

            Log.Debug("End", Common.LOG_CATEGORY, startTicks);
        }

        private void Button3Execute()
        {
            Int64 startTicks = Log.Trace("Enter", Common.LOG_CATEGORY);

            Message = "Button3 Clicked";

            try
            {
                method1();
            }
            catch (Exception ex)
            {
                Log.Error(ex, Common.LOG_CATEGORY);
                Log.Error(ex, "BOOM");
            }

            Log.Trace("End", Common.LOG_CATEGORY, startTicks);
        }

        private void method1()
        {
            Int64 startTicks = Log.Trace1("Enter", Common.LOG_CATEGORY);

            method2();

            Log.Trace1("End", Common.LOG_CATEGORY, startTicks);
        }

        private void method2()
        {
            Int64 startTicks = Log.Trace2("Enter", Common.LOG_CATEGORY);

            method3();

            Log.Trace2("End", Common.LOG_CATEGORY, startTicks);
        }

        private void method3()
        {
            Int64 startTicks = Log.Trace3("Enter", Common.LOG_CATEGORY);

            method4();

            Log.Trace3("End", Common.LOG_CATEGORY, startTicks);
        }

        private void method4()
        {
            Int64 startTicks = Log.Trace4("Enter", Common.LOG_CATEGORY);

            method5();

            Log.Trace4("End", Common.LOG_CATEGORY, startTicks);
        }

        private void method5()
        {
            Int64 startTicks = Log.Trace5("Enter", Common.LOG_CATEGORY);


            int answer = Numerator / Denominator;

            Answer = answer.ToString();

            Log.Trace5("End", Common.LOG_CATEGORY, startTicks);
        }

        #endregion

    }
}
