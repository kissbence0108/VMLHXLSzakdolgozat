using ChatApp.Resources;
using ChatApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace ChatApp.HelperClasses
{
    public class ClientHelper
    {
        // ManualResetEvent instances signal completion.  
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent isLoginDone =
            new ManualResetEvent(false);
        private static ManualResetEvent isGettingMessageHistoryDone =
            new ManualResetEvent(false);
        private static ManualResetEvent isSendingMessageDone =
            new ManualResetEvent(false);
        private static ManualResetEvent isRegistrationDone =
            new ManualResetEvent(false);
        private static ManualResetEvent isGraphDataDone =
            new ManualResetEvent(false);



        private static bool isConnected;
        private static bool isLoginValid;
        private static bool isRegistrationCompleted;

        public static Socket Client;
        public static List<Message> MessageList { get; set; }

        public static List<Tuple<string,int>> GraphData { get; set; }
        public static MessagesViewModel MessagesViewModel { get; set; }

        public static bool IsServerConnected()
        {
            return isConnected;
        }

        public static bool IsLoginValid()
        {
            return isLoginValid;
        }

        public static bool IsRegistrationCompleted()
        {
            return isRegistrationCompleted;
        }

        private static void SetIsLoginValidVariable(bool value)
        {
            isLoginValid = value;
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                connectDone.Set();

            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private  static void ReceiveCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            try
            {
                // Retrieve the state object and the client socket
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read
                    // more data.  
                    content = state.sb.ToString();
                    if (content.EndsWith(Constants.EndOfTransmissionSeparator))
                    {
                        // All the data has been read from the
                        // server. Handle the data

                        Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                            content.Length, content);

                        HandleTheMessageFromTheServer(content);

                        string[] messages = content.Split("<EOF>");

                        foreach (var message in messages)
                        {
                            if (message != "")
                            {
                                Application.Current.Dispatcher.BeginInvoke(new Action(delegate ()
                                {
                                   // List1.Add(message);
                                   // ListIndex = List1.Count - 1;
                                }));
                            }
                        }

                        state = new StateObject();
                        state.workSocket = Client;

                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        // Not all data received. Get more.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void HandleTheMessageFromTheServer(string content)
        {

            MessageHandleEnum messageEnum = MessageHandleEnum.LOGIN;
            if (content.StartsWith("REGISTER"))
            {
                messageEnum = MessageHandleEnum.REGISTER;
            }
            else if (content.StartsWith("GETMESSAGEHISTORY"))
            {
                messageEnum = MessageHandleEnum.GETMESSAGEHISTORY;
            }
            else if (content.StartsWith("SENDMESSAGE"))
            {
                messageEnum = MessageHandleEnum.SENDMESSAGE;
            }
            else if (content.StartsWith("GRAPHDATA"))
            {
                messageEnum = MessageHandleEnum.GRAPHDATA;
            }
            switch (messageEnum)
            {
                case MessageHandleEnum.LOGIN:
                    SetIsLoginValidVariable(CheckLoginResponse(content));
                    isLoginDone.Set();
                    break;
                case MessageHandleEnum.REGISTER:
                    CheckRegistrationResponse(content);
                    isRegistrationDone.Set();
                    break;
                case MessageHandleEnum.GETMESSAGEHISTORY:
                    PopulateMessageList(content);
                    isGettingMessageHistoryDone.Set();
                    break;
                case MessageHandleEnum.SENDMESSAGE:
                    AddMessageToMessageList(content);
                    isSendingMessageDone.Set();
                    break;
                case MessageHandleEnum.GRAPHDATA:
                    AddGraphData(content);
                    isGraphDataDone.Set();
                    break;
            }

        }

        private static void AddGraphData(string content)
        {
            content = content.Split(Constants.EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Constants.Separator);
            GraphData = JsonConvert.DeserializeObject<List<Tuple<string,int>>>(splittedContent[1]);
        }

        private static void CheckRegistrationResponse(string content)
        {
            content = content.Split(Constants.EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Constants.Separator);
            isRegistrationDone.Set();
            switch (splittedContent[1])
            {
                case "SUCCESFUL":
                    MessageBox.Show("Registration was successful!");
                    break;
                case "FAILED":
                    MessageBox.Show("Registration was not possible!");
                    break;
                case "USERALREADYEXISTS":
                    MessageBox.Show("Sorry but the username already exist in the database!");
                    break;
                default:
                    break;
            }
        }

        private static void AddMessageToMessageList(string content)
        {
            content = content.Split(Constants.EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Constants.Separator);
            var message = JsonConvert.DeserializeObject<Message>(splittedContent[1]);
            MessageList.Add(message);
            //MessagesViewModel.RefreshMessageList();
        }

        private static void PopulateMessageList(string content)
        {
            content = content.Split(Constants.EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Constants.Separator);
            MessageList = JsonConvert.DeserializeObject<List<Message>>(splittedContent[1]);
        }

        private static bool CheckLoginResponse(string content)
        {
            content = content.Split(Constants.EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Constants.Separator);
            if(splittedContent[1] == "TRUE")
            {
                return true;
            }
            return false;
        }

        public static void SendMessage(MessageHandleEnum messageEnum, string message)
        {
            switch (messageEnum)
            {
                case MessageHandleEnum.LOGIN:
                    message = "LOGIN" + message;
                    break;
                case MessageHandleEnum.REGISTER:
                    message = "REGISTER" + message;
                    break;
                case MessageHandleEnum.GETMESSAGEHISTORY:
                    message = "GETMESSAGEHISTORY";
                    break;
                case MessageHandleEnum.SENDMESSAGE:
                    message = "SENDMESSAGE" + message;
                    break;
                case MessageHandleEnum.GRAPHDATA:
                    message = "GRAPHDATA" + message;
                    break;
            }

            message = message + Constants.EndOfTransmissionSeparator;
            byte[] byteData = Encoding.UTF8.GetBytes(message);//Text1 + "<EOF>");

            // Begin sending the data to the remote device.
            Client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), Client);

            sendDone.WaitOne();

            switch (messageEnum)
            {
                case MessageHandleEnum.LOGIN:
                    isLoginDone.WaitOne();
                    break;
                case MessageHandleEnum.REGISTER:
                    isRegistrationDone.WaitOne();
                    break;
                case MessageHandleEnum.GETMESSAGEHISTORY:
                    isGettingMessageHistoryDone.WaitOne();
                    break;
                case MessageHandleEnum.SENDMESSAGE:
                    isSendingMessageDone.WaitOne();
                    break;
                case MessageHandleEnum.GRAPHDATA:
                    isGraphDataDone.WaitOne();
                    break;
            }


        }

        public static void InitServer()
        {
            isConnected = true;
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 54000);
            try
            {
                // Create a TCP/IP socket.  
                Client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                Client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), Client);
                connectDone.WaitOne();


                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = Client;

                // Begin receiving the data from the remote device.  
                Client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                isConnected = false;
            }

        }
    }
}
