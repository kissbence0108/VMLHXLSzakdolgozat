using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.DatabaseObjects
{
    public class User
    {
        public Int64 Id { get; set; }

        public string Username {get;set;}

        public string Password { get; set; }
    }
}
