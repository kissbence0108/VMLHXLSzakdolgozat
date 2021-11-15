﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

// State object for reading client data asynchronously  
public class StateObject
{
    // Size of receive buffer.  
    public const int BufferSize = 1024;

    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];

    // Received data string.
    public StringBuilder sb = new StringBuilder();

    // Client socket.
    public Socket workSocket = null;
}

public class AsynchronousSocketListener
{
    private static List<Socket> tcpClientsList = new List<Socket>();

    // Thread signal.  
    public static ManualResetEvent allDone = new ManualResetEvent(false);

    public AsynchronousSocketListener()
    {
    }

    public static void StartListening()
    {
        // Establish the local endpoint for the socket.  
        // The DNS name of the computer  
        // running the listener is "host.contoso.com".  
        IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 54000);
        Console.WriteLine(ipAddress.ToString());
        Console.WriteLine();


        // Create a TCP/IP socket.  
        Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

        // Bind the socket to the local endpoint and listen for incoming connections.  
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                // Set the event to nonsignaled state.  
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    listener);

                // Wait until a connection is made before continuing.  
                allDone.WaitOne();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }

    public static void AcceptCallback(IAsyncResult ar)
    {
        // Signal the main thread to continue.  
        allDone.Set();

        // Get the socket that handles the client request.  
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        tcpClientsList.Add(handler);



        // Create the state object.  
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
    }

    public static void ReadCallback(IAsyncResult ar)
    {
        String content = String.Empty;

        // Retrieve the state object and the handler socket  
        // from the asynchronous state object.  
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;

        // Read data from the client socket.
        int bytesRead = handler.EndReceive(ar);

        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.  
            state.sb.Append(Encoding.UTF8.GetString(
                state.buffer, 0, bytesRead));

            // Check for end-of-file tag. If it is not there, read
            // more data.  
            content = state.sb.ToString();


            try
            {
                IDictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

                IDictionary<string, string> message = new Dictionary<string, string>
                {
                    ["username"] = data["username"],
                    ["message"] = data["message"],
                    ["sentAt"] = DateTime.Now.ToString()
                };


                StoreMessage(message);



                // All the data has been read from the
                // client. Display it on the console.  
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                content.Length, content);
                // Echo the data back to the client.  
                Send(handler, JsonConvert.SerializeObject(message));





            }
            catch (Exception)
            {
                
                SendError(handler, "Hiba történt");
                Console.WriteLine("Nem sikerült feldolgozni az üzenetet");
                return;
            }


        }
    }


    private static void StoreMessage(IDictionary<string, string> messagedict)
    {


        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bence\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection = new SqlConnection(@connectionString);
        string query2 = "select Id from Users where Username = @username;";
        SqlCommand command2 = new SqlCommand(query2, connection);

        try
        {        
            

            command2.Parameters.Add("@username", SqlDbType.VarChar);
            command2.Parameters["@username"].Value = messagedict["username"];

            connection.Open();
            int userId = (int)command2.ExecuteScalar();
            Console.WriteLine(userId);

            string query = "INSERT INTO MessagesDatabase(UserID, Message, SentTime) VALUES (@userId, @message, @sentAt);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@userId", SqlDbType.Int);
            command.Parameters["@userId"].Value = userId;


            command.Parameters.Add("@message", SqlDbType.VarChar);
            command.Parameters["@message"].Value = messagedict["message"];

            command.Parameters.Add("@sentAt", SqlDbType.VarChar);
            command.Parameters["@sentAt"].Value = messagedict["sentAt"];
            command.ExecuteNonQuery();

        }
        catch (Exception)
        {
            throw;
            //Console.WriteLine("errorxd");
        }
        finally
        {
            connection.Close();
        }
    }













  



    private static void SendError(Socket handler, String error)
    {
        IDictionary<string, string> data = new Dictionary<string, string>
        {
            ["error"] = error,
            
        };

        

        byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        handler.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), handler);
    }

    private static void Send(Socket handler, String data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.UTF8.GetBytes(data);

        foreach (Socket client in tcpClientsList)
        {

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
        }
    }

    private static void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket handler = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = handler.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to client.", bytesSent);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}