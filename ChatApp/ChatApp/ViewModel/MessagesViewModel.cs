using ChatApp.Commands;
using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.Net;
using System.Collections.ObjectModel;
using ChatApp.HelperClasses;
using Newtonsoft.Json;
using ChatApp.Resources;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Data;

namespace ChatApp.ViewModel
{
    public class MessagesViewModel : BaseViewModel
    {
        public ICommand SendMessageCommand { get; set; }
        private System.ComponentModel.BackgroundWorker backgroundWorker;

        public string MessageToSend
        {
            get { return messageToSend; }
            set { messageToSend = value; }
        }

        private string messageToSend { get; set; }

        private object lockObject = new object();

        public ObservableCollection<string> MessagesCollection
        {
            get { return messagesCollection; }
            set
            {
                messagesCollection = value;
                SendPropertyChanged(nameof(MessagesCollection));
            }
        }

        public int ListIndex
        {
            get
            {
                return _listIndex;
            }
            set
            {
                _listIndex = value;
                SendPropertyChanged(nameof(ListIndex));
            }
        }

        private int _listIndex { get; set; }


        private ObservableCollection<string> messagesCollection { get; set; }


        public void Init()
        {

            SendMessageCommand = new SendMessageCommand(this);
            MessagesCollection = new ObservableCollection<string>();
            GetMessageHistory();
            ClientHelper.MessagesViewModel = this;
            //backgroundWorker = new System.ComponentModel.BackgroundWorker();
            //backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            //backgroundWorker.RunWorkerAsync();
            //BindingOperations.EnableCollectionSynchronization(MessagesCollection, lockObject);
        }


        private async void GetMessageHistory()
        {
            await ClientHelper.SendMessage(MessageHandleEnum.GETMESSAGEHISTORY, "");
            RefreshMessageList();
        }

        public void RefreshMessageList()
        {
            MessagesCollection = new ObservableCollection<string>();
            foreach (var message in ClientHelper.MessageList)
            {
                MessagesCollection.Add(message.ToString());
            }
            ListIndex = MessagesCollection.Count - 1;
        }

        public MessagesViewModel()
        {
            Init();
        }



        public async Task SendMessage()
        {
            Message message = new Message(Application.Current.Properties["username"].ToString(), MessageToSend, null);
            string messageJson = JsonConvert.SerializeObject(message);
            await ClientHelper.SendMessage(MessageHandleEnum.SENDMESSAGE, Constants.Separator + messageJson);
            MessageToSend = "";
            Thread.Sleep(1000);
            RefreshMessageList();

        }
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                //RefreshMessageList();
                Thread.Sleep(3000);
            }
        }

    }
}