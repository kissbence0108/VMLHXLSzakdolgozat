using ChatApp.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private variables

        private string username;
        private string password;
        private bool isLoginButtonEnabled;
        private bool isRegisterButtonEnabled;

        #endregion

        #region Public variables

        public ICommand TestConnectionCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                SendPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                SendPropertyChanged(nameof(Password));
            }
        }

        public bool IsLoginButtonEnabled
        {
            get { return isLoginButtonEnabled; }
            set
            {
                isLoginButtonEnabled = value;
                SendPropertyChanged(nameof(IsLoginButtonEnabled));
            }
        }

        public bool IsRegisterButtonEnabled
        {
            get { return isRegisterButtonEnabled; }
            set
            {
                isRegisterButtonEnabled = value;
                SendPropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }



        #endregion

        #region Constructor
        public LoginViewModel()
        {
            Init();
        }

        #endregion

        #region Methods

        private void Init()
        {
            Username = "admin";
            Password = "admin";
            IsLoginButtonEnabled = false;
            IsRegisterButtonEnabled = false;
            TestConnectionCommand = new TestConnectionCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        #endregion


    }
}
