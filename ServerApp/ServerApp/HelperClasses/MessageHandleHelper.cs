using Newtonsoft.Json;
using ServerApp.DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServerApp.HelperClasses
{
    public static class MessageHandleHelper
    {
        private const char Separator = (char)007;
        public const char EndOfTransmissionSeparator = (char)004;
        private static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bence\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30";


        public static string HandleMessage(string content)
        {
            string response = string.Empty;

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
                    response = GetLogin(content);
                    break;
                case MessageHandleEnum.REGISTER:
                    response = RegisterNewUser(content);
                    break;
                case MessageHandleEnum.GETMESSAGEHISTORY:
                    response = GetMessageHistory();
                    break;
                case MessageHandleEnum.SENDMESSAGE:
                    response = MessageSentFromClient(content);
                    break;
                case MessageHandleEnum.GRAPHDATA:
                    response = GetGraphData();
                    break;
            }

            return response;
        }

        private static string RegisterNewUser(string content)
        {
            string response;
            content = content.Split(EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Separator);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Username='" + splittedContent[1] + "' ", conn);
                try
                 {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            string cmdString = "INSERT INTO Users (Username,Password) VALUES ('" + splittedContent[1] + "', '" + splittedContent[2] + "')";
                            using (SqlConnection connect = new SqlConnection(connString))
                            {
                                using (SqlCommand comm = new SqlCommand())
                                {
                                    comm.Connection = connect;
                                    comm.CommandText = cmdString;


                                    connect.Open();
                                    comm.ExecuteNonQuery();
                                    response = "REGISTER" + Separator + "SUCCESFUL";
                                }
                            }
                        }
                        else
                        {
                            response = "REGISTER" + Separator + "USERALREADYEXISTS";
                        }
                    }

                }
                catch (Exception ex)
                {
                    response = "REGISTER" + Separator + "FAILED";
                    Console.WriteLine(ex.Message);
                }
            }
            return response;
        }

        private static string MessageSentFromClient(string content)
        {
            string response = string.Empty;
            content = content.Split(EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Separator);
            Message message = JsonConvert.DeserializeObject<Message>(splittedContent[1]);
            message.SentTime = DateTime.Now;

            SqlConnection connection = new SqlConnection(connString);
            try
            {
                string query2 = "select Id from Users where Username = @username;";
                SqlCommand command2 = new SqlCommand(query2, connection);

                command2.Parameters.Add("@username", SqlDbType.VarChar);
                command2.Parameters["@username"].Value = message.Username;

                connection.Open();
                int userId = (int)command2.ExecuteScalar();

                string query = "INSERT INTO MessagesDatabase(UserID, Message, SentTime) VALUES (@userId, @message, @sentAt);";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@userId", SqlDbType.Int);
                command.Parameters["@userId"].Value = userId;


                command.Parameters.Add("@message", SqlDbType.VarChar);
                command.Parameters["@message"].Value = message.MessageText;

                command.Parameters.Add("@sentAt", SqlDbType.VarChar);
                command.Parameters["@sentAt"].Value = message.SentTime;
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            response = "SENDMESSAGE" + Separator + JsonConvert.SerializeObject(message);
            return response;
        }

        private static string GetMessageHistory()
        {
            string response = string.Empty;
            List<Message> messageList = new List<Message>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"SELECT u.Username,md.Message,md.SentTime
                        FROM MessagesDatabase md
                        INNER JOIN Users u on u.Id = md.UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        do
                        {
                            foreach (var element in reader)
                            {
                                string usernameFromDb = ((element as IDataRecord).GetValue(0)).ToString();
                                string messageFromDb = ((element as IDataRecord).GetValue(1)).ToString();
                                DateTime sentTimeFromDb = DateTime.ParseExact(((element as IDataRecord).GetValue(2)).ToString(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                                messageList.Add(new Message(usernameFromDb, messageFromDb, sentTimeFromDb));
                            }

                        } while (reader.Read());
                        response = "GETMESSAGEHISTORY"+Separator + JsonConvert.SerializeObject(messageList);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return response;
        }

        private static string GetLogin(string content)
        {
            string response = string.Empty;
            content = content.Split(EndOfTransmissionSeparator)[0];
            string[] splittedContent = content.Split(Separator);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Users where Username='" + splittedContent[1] + "' AND Password='" + splittedContent[2] + "'", conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            response = "LOGIN" + Separator + "TRUE";
                        }
                        else
                        {
                            response = "LOGIN" + Separator + "FALSE";
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return response;
        }

        private static string GetGraphData()
        {
            string response = string.Empty;
            List<Tuple<string,int>> graphList = new List<Tuple<string, int>>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"SELECT Users.Username, count(MessagesDatabase.Message) as MessagesSent FROM MessagesDatabase INNER JOIN Users ON MessagesDatabase.UserId = Users.Id GROUP BY Users.Username;";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        do
                        {
                            foreach (var element in reader)
                            {
                                string username = ((element as IDataRecord).GetValue(0)).ToString();
                                int messageNumber = Int32.Parse((element as IDataRecord).GetValue(1).ToString());
                                graphList.Add(new Tuple<string, int>(username, messageNumber));
                            }

                        } while (reader.Read());
                        response = "GRAPHDATA" + Separator + JsonConvert.SerializeObject(graphList);
                    }
                }
                catch (Exception e)
                {

                }


            }
            return response;
        }
    }
}

