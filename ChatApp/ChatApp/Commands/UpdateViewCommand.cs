using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class UpdateViewCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            if (parameter.ToString() == "Messages")
            {
                viewModel.SelectedViewModel = new MessagesViewModel();
            }

        }
    }
}
