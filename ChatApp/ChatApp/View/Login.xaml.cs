using ChatApp.ViewModel;
using System.Windows;

namespace ChatApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public const char Separator = (char)007;
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();

        }

        private void LoginPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((LoginViewModel)this.DataContext).Password = LoginPasswordBox.Password;
            }
        }

        private void Register_Page_Click(object sender, RoutedEventArgs e)
        {
            RegisterView rv = new RegisterView();
            rv.ShowDialog();
        }

        private void exitBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
