using ChatApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatApp.View;


namespace ChatApp
{

    public partial class MainWindow : Window
    {

        private MainViewModel _MainViewModel;


        TcpClient _client;
        string username;


        byte[] _buffer = new byte[4096];
        public MainWindow(string user)
        {
            InitializeComponent();
            _MainViewModel = new MainViewModel();
            DataContext = _MainViewModel;
            username = user;
            _client = new TcpClient();


        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                DragMove();

        }



        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }


        private void tgglBttn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bckgrndchangebttn_Click(object sender, RoutedEventArgs e)
        {
            _MainViewModel.DarkMode = !_MainViewModel.DarkMode;
        }
    }
}
