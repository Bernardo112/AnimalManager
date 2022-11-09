using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalManager.Components
{
    internal class Login
    {
        public string User { get; }
        public string Password { get; }

        public Login(string user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
