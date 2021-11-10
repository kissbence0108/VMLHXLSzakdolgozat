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
            username = user;
            _client = new TcpClient();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);


            _client.Connect("localhost", 54000);
            _client.GetStream().BeginRead(_buffer,
                                            0,
                                            _buffer.Length,
                                            Server_MessageReceived,
                                            null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                ["username"] = username,
                ["message"] = textbox1.Text
            };



            var msg = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
           
            _client.GetStream().Write(msg, 0, msg.Length);


            textbox1.Text = "";
            textbox1.Focus();

        }




        private void Server_MessageReceived(IAsyncResult ar)
        {
            if (ar.IsCompleted)
            {
                var bytesIn = _client.GetStream().EndRead(ar);
                if (bytesIn > 0)
                {

                    var tmp = new byte[bytesIn];
                    Array.Copy(_buffer, 0, tmp, 0, bytesIn);
                    var str = Encoding.UTF8.GetString(tmp);


                    

                   
                    Dispatcher.BeginInvoke(new Action(delegate ()
                    {
                        listBox1.Items.Add(str);
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }));
            }


                Array.Clear(_buffer, 0, _buffer.Length);
                _client.GetStream().BeginRead(_buffer,
                                                0,
                                                _buffer.Length,
                                                Server_MessageReceived,
                                                null);
            }
        }

        
    }
}
