using EvanDangol.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EvanDangol.Tutorial.Wpf
{
    public class RelayCommandTutorial
    {
        [runnable]
        public static void Run()
        {

            MyCommand = _mycommand = new NormalRelayCommand(executefunction);
            MyCommand.Execute(5);
        }

        private static NormalRelayCommand _mycommand;

        public static NormalRelayCommand MyCommand
        {
            get
            {

                return _mycommand;
            }
            set
            {
                _mycommand = value;
            }

        }

        public static void executefunction(object a)
        {
            Console.WriteLine((int)a + (int)a);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static void Notify(string prop)
        {
            RelayCommandTutorial tc = new RelayCommandTutorial();
            PropertyChangedEventHandler handler = tc.PropertyChanged;
            if (handler != null)
            {
                handler(null, new PropertyChangedEventArgs(prop));
            }
        }
    }

    public class NormalRelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion // Fields

        #region Constructors

        public NormalRelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public NormalRelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        ;

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

}

