using ChatApp.HelperClasses;
using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class TestConnectionCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private LoginViewModel viewModel;
        public TestConnectionCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ClientHelper.InitServer();
            if (ClientHelper.IsServerConnected())
            {
                MessageBox.Show("Successfully connected to the server!");
                viewModel.IsLoginButtonEnabled = true;
                viewModel.IsRegisterButtonEnabled = true;
            }
            else
            {
                MessageBox.Show("Failed to connect to the server!");
                viewModel.IsLoginButtonEnabled = false;
                viewModel.IsRegisterButtonEnabled = false;
            }
        }
    }
}
