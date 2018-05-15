using System;
using System.Windows.Input;

namespace KimzWpfCommon.Utils
{
    public class RelayCommand<T1, T2> : ICommand
    {
        private readonly Action _functionWithoutParam;
        private readonly Action<T1> _function;
        private readonly Func<T2, bool> _predicate;

        public RelayCommand(Action functionWithoutParam)
        {
            this._functionWithoutParam = functionWithoutParam;
        }

        public RelayCommand(Action<T1> function)
        {
            this._function = function;
        }

        public RelayCommand(Action functionWithoutParam, Func<T2, bool> predicate)
        {
            this._functionWithoutParam = functionWithoutParam;
            this._predicate = predicate;
        }

        public RelayCommand(Action<T1> function, Func<T2, bool> predicate)
        {
            this._function = function;
            this._predicate = predicate;
        }

        public bool CanExecute(T2 parameter)
        {
            if (_predicate != null)
            {
                return _predicate(parameter);
            }

            return true;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute((T2) parameter);
        }

        public void Execute(T1 parameter)
        {
            _function?.Invoke(parameter);
            _functionWithoutParam?.Invoke();
        }

        public void Execute(object parameter)
        {
            Execute((T1)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
