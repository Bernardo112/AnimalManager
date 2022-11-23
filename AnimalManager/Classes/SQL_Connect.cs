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

        public static string Connect(string server, string user, string database, string password)
        {
            string message = "";
            try
            {
                if(server == "")
                {
                    message += "Server is missing;";
                }
                if(user == "")
                {
                    message += " User is missing;";
                }
                if(database == "")
                {
                    message += " Database is missing;";
                }
                if(password == "")
                {
                    message += " Password is missing;";
                }

                Connection = new MySqlConnection($"server = {server}; User Id = {user}; database = {database}; password = {password}");
            }
            catch(MySqlException e)
            {
                message = e.Message;
            }

            return message;
        }
    }
}
