﻿using ChatApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp.View
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();
        }

        private void exitBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegisterPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterViewModel).Password = ((PasswordBox)sender).SecurePassword;
        }

        private void RegisterPasswordConfirmBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterViewModel).PasswordConfirm = ((PasswordBox)sender).SecurePassword;
        }
    }
}