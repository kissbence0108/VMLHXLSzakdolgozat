using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class SendMessageCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private MessagesViewModel viewModel;
        public SendMessageCommand(MessagesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SendMessage();
        }
    }
}
