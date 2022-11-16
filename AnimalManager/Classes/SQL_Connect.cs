using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Classes
{
    public static class SQL_Connect
    {
        public static MySqlConnection Connection;

        public static string Connect(string connectString)
        {
            string message = "";
            try
            {
                Connection = new MySqlConnection(connectString);
            }
            catch(Exception e)
            {
                message = e.Message;
            }

            return message;
        }
    }
}
