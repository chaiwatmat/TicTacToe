using System;
using System.Windows.Input;

namespace TicTacToe
{
    public class ViewCommand : ICommand
    {
        private Action execute;
        private Action<object> executeWithParam;
        private Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;

        public ViewCommand(Action execute)
        {
            this.execute = execute;
        }

        public ViewCommand(Action<object> executeWithParam)
        {
            this.executeWithParam = executeWithParam;
        }

        public ViewCommand(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public ViewCommand(Action<object> executeWithParam, Predicate<object> canExecute)
        {
            this.executeWithParam = executeWithParam;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                execute?.Invoke();
            }
            else
            {
                executeWithParam?.Invoke(parameter);
            }
        }
    }
}
