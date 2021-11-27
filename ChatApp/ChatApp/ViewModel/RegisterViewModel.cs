using ChatApp.Commands;
using System.Security;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }

        public string Username { get { return username; } set { username = value; } }

        public SecureString Password { get { return password; } set { password = value; } }

        public SecureString PasswordConfirm { get { return passwordConfirmed; } set { passwordConfirmed = value; } }
        private string username { get; set; }
        private SecureString password { get; set; }
        private SecureString passwordConfirmed { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        }


    
    }
}
