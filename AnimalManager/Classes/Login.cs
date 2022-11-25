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
        public int UserID { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public char OnUse { get; set; } = 'n';

        public Login()
        {

        }

        public Login(int id, string user, string password)
        {
            UserID = id;
            UserName = user;
            Password = password;
        }
    }
}
