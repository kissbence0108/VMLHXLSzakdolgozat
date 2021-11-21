using ChatApp.Commands;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand RegisterCommand { get; set; }

        public string Username { get { return username; } set { username = value; } }

        public string Password { get { return password; } set { password = value; } }

        public string PasswordConfirm { get { return passwordConfirmed; } set { passwordConfirmed = value; } }
        private string username { get; set; }
        private string password { get; set; }
        private string passwordConfirmed { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        }


    
    }
}
