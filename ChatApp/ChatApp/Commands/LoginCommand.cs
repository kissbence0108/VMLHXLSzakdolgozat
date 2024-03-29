﻿using ChatApp.HelperClasses;
using ChatApp.Resources;
using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        public async void Execute(object parameter)
        {
            await ClientHelper.SendMessage(MessageHandleEnum.LOGIN, Constants.Separator + viewModel.Username + Constants.Separator + ComputeSha256Hash(viewModel.Password));
            Thread.Sleep(2000); // We need this to make sure the server updated the IsLogin value in the client
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

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}