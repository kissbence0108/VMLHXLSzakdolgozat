using ChatApp.ViewModel;
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
    }
}
