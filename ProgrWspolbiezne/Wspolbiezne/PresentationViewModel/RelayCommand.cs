using System;
using System.Windows.Input;

namespace PresentationViewModel
{
    public class RelayCommand : ICommand
    {
        private Action _Execute;
        private Func<bool> _CanExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute)
        {
            _Execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {

            return _CanExecute == null || _CanExecute();
        }

        public void Execute(object parameter)
        {
            _Execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}