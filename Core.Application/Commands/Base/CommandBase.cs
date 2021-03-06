using System;
using System.Windows.Input;

namespace Core.Application.Commands
{
    public abstract class CommandBase : ICommand
    {
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this,new EventArgs());
        }

        public event EventHandler? CanExecuteChanged;
    }
}