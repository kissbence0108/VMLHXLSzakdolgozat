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

        TcpClient _client;
        string username;


        byte[] _buffer = new byte[4096];
        public MainWindow(string user)
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            username = user;
            _client = new TcpClient();
            
        }


       



 

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void closeBttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tgglBttn_Unchecked(object sender, RoutedEventArgs e)
        {

        }


    }
}
