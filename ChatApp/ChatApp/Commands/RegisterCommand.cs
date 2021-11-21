using ChatApp.Resources;
using ChatApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ChatApp.Commands
{
    public class RegisterCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private RegisterViewModel viewModel;
        public RegisterCommand(RegisterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(viewModel.Password == viewModel.PasswordConfirm)
            {
                HelperClasses.ClientHelper.SendMessage(HelperClasses.MessageHandleEnum.REGISTER, Constants.Separator + viewModel.Username + Constants.Separator + viewModel.Password);
            }
            
            /*
             
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
                                //myPersonalGUID = new GUID();
                                //send to server => "GUID-LOGIN-username-password";
                                //server send => "GUID-LOGIN-TRUE"
                                //nugget.encrypt(password)

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

            */
        }
    }
}
