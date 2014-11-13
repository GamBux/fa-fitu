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
        NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=password;Database=Fa-fitu_DB;");

        /// <summary>
        /// Checks if there exist user of given name
        /// </summary>
        /// <param name="username">name to be checked</param>
        /// <returns>true if user of username exists else returns false</returns>
        public bool existUser(string username)
        {
            conn.Open();


            string operation = "SELECT * FROM Users WHERE uname = " + wrapS(username);
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);
            object user = Command.ExecuteScalar();

            conn.Close();
            if (user == null) return false;
            else return true;

           
        }
        /// <summary>
        /// Inserts a new user to DB
        /// </summary>
        /// <param name="username">name of user</param>
        /// <param name="mass">mass of user in kg</param>
        /// <param name="activity">average minutes of activity per week</param>
        /// <param name="age">self descriptory</param>
        /// <returns>returns number of rows affecteds if user exists returns -1</returns>
        public int addUser(string username, int mass, int activity, int age)
        {
            if (existUser(username)) return -1;
            conn.Open();
            

            string operation = 
                String.Format(
                "INSERT INTO Users(uname, mass, activity, age) VALUES" + "({0}, {1}, {2}, {3})"
                ,wrapS(username), mayNullToString(mass), mayNullToString(activity), mayNullToString(age)
                );
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);
            int ret = (int)Command.ExecuteNonQuery();

            conn.Close();
          
            return ret; 
        }

        string wrapS(string s)
        {
            return "'" + s + "'";
        }

        string mayNullToString(int i) {
            if (i == -1) return "NULL";
            else return i.ToString();
        }
    }
}
