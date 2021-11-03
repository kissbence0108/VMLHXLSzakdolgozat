
using System;
using System.Data.SqlClient;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var Username = RegisterUser;
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bence\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Username='" + RegisterUser.Text + "' ", conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            if (RegisterPass.Text == RegisterPassC.Text)
                            {
                                string cmdString = "INSERT INTO Users (Username,Password) VALUES ('" + RegisterUser.Text + "', '" + RegisterPass.Text + "')";
                                using (SqlConnection connect = new SqlConnection(connString))
                                {
                                    using (SqlCommand comm = new SqlCommand())
                                    {
                                        comm.Connection = connect;
                                        comm.CommandText = cmdString;


                                        connect.Open();
                                        comm.ExecuteNonQuery();

                                    }
                                }
                            }
                        }
                        else
                        {

                        }
                        while (reader.Read())
                        {

                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bence\Documents\Users.mdf;Integrated Security=True;Connect Timeout=30";
            var logined = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM Users where Username='" + LoginUser.Text + "' ", conn);
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(1) == LoginPassword.Text)
                            {
                                logined = true;
                                MainWindow mainWindow = new MainWindow(LoginUser.Text);
                                mainWindow.ShowDialog();
                            }
                            else
                            {
                                logined = false;
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
