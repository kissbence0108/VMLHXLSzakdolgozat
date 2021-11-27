using ChatApp.Resources;
using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class RegisterCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private RegisterViewModel viewModel;
        public RegisterCommand(RegisterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string password = new System.Net.NetworkCredential(string.Empty, viewModel.Password).Password;
            string confirmPassword = new System.Net.NetworkCredential(string.Empty, viewModel.PasswordConfirm).Password;
            if (!ContainsUpperLetter(password))
            {
                MessageBox.Show("fk u ,review ur password!");
            }
            else if(!ContainsSpecialCharacter(password))
            {
                MessageBox.Show("fk u ,review ur password!");
            }
            else
            {
                if (password == confirmPassword)
                {
                    HelperClasses.ClientHelper.SendMessage(HelperClasses.MessageHandleEnum.REGISTER, Constants.Separator + viewModel.Username + Constants.Separator + ComputeSha256Hash(password));
                }
            }
        }
        public bool ContainsUpperLetter(string content)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(content);
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 64 && asciiBytes[i] < 91)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsSpecialCharacter(string content)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(content);
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] > 32 && asciiBytes[i] < 48)
                {
                    return true;
                }
            }
            return false;
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
