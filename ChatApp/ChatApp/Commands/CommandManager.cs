using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class CommandManager : ICommand
    {
        private Action action;

        public CommandManager(Action action) => this.action = action;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) => action();
        
    }
}
