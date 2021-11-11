using ChatApp.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ChatApp.ViewModel
{
    public class MessagesViewModel : BaseViewModel
    {
        TcpClient _client;
        string username;
        byte[] _buffer = new byte[4096];

        public ICommand SendMessageCommand { get; set; }


        public string Text1
        {
            get { return _text1; }
            set { _text1 = value; }
        }

        private string _text1 { get; set; }


        public List<string> List1
        {
            get { return _list1; }
            set { _list1 = value;
                SendPropertyChanged(nameof(List1));
            }
        }


private List<string> _list1 { get; set; }


        public void InitServer()
        {

            SendMessageCommand = new SendMessageCommand(this);

            List1 = new List<string>();

            _client = new TcpClient();
            username = Application.Current.Properties["username"].ToString();

            



            _client.Connect("localhost", 54000);
            _client.GetStream().BeginRead(_buffer,
                                            0,
                                            _buffer.Length,
                                            Server_MessageReceived,
                                            null);
        }

        

        public void SendMessage()
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                ["username"] = username,
                ["message"] = Text1
            };



            var msg = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            _client.GetStream().Write(msg, 0, msg.Length);


            Text1 = "";
            

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





                    Application.Current.Dispatcher.BeginInvoke(new Action(delegate ()
                    {
                        List1.Add(str);
                        //listBox1.SelectedIndex = listBox1.Items.Count - 1;
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
