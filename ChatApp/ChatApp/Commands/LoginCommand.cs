using ChatApp.HelperClasses;
using ChatApp.Resources;
using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class LoginCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private LoginViewModel viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
             ClientHelper.SendMessage(MessageHandleEnum.LOGIN, Constants.Separator + viewModel.Username + Constants.Separator + viewModel.Password);
            if (ClientHelper.IsLoginValid())
            {
                Application.Current.Properties["username"] = viewModel.Username;
                MainWindow mainWindow = new MainWindow(viewModel.Username);
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username/password are wrong!");
            }
        }
    }
}