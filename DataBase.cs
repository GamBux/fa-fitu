using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Zwinne_Postgress
{
    class DataBase
    {
        // Private connection to postgres database
        NpgsqlConnection conn;

        /// <summary>
        /// Checks if there exist user of given name
        /// </summary>
        /// <param name="username">name to be checked</param>
        /// <returns>true if user of username exists else returns false</returns>
        public bool existUser(string username)
        {
            conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;Database=Fa-fitu_DB;");
            conn.Open();


            string operation = "SELECT * FROM Users WHERE uname = " + wrapS(username);
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);
            object user = Command.ExecuteScalar();

            if (user == null) return false;
            else return true;
        }

        /*public bool addUser(string username, int mass, int activity, int age){
            string massString       = mass.ToString();
            string activityString   = activity.ToString()   
        }
        */
        string wrapS(string s)
        {
            return "'" + s + "'";
        }
    }
}
