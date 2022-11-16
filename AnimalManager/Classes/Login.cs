using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Classes
{
    public class Login
    {
        public string User { get; private set; }
        public string Password { get; private set; }
        public char Registered { get; set; } = 'n';

        public Login(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
