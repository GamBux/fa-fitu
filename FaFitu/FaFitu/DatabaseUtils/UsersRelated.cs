using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

using FaFitu.Models;
using FaFitu.DatabaseUtils;
using FaFitu.Utils;

namespace FaFitu.DatabaseUtils
{
    public class UsersRelated
    {
        public static UserModel GetUser(string service, string login)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();

            string operation = "SELECT * FROM Users WHERE comesfrom = " + "'" + comesFrom + "'";
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            object user = Command.ExecuteScalar();
            conn.Close();


            return null;
        }

        public static bool UserExists(string service, string login)
        {
            UserModel user = GetUser(comesFrom);

            if (user == null) return false;
            else return true;

        }

        //public static bool AddUser(RegisterModel user)
        // {
        /*   NpgsqlConnection conn = DataBaseConnection.GetConnection();

           string operation = "INSERT INTO Users(uname, comesfrom, pass) VALUES ('" + user.UserName +  "','" + user.Email +  "','" + user.Password  + "')";
           NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

           conn.Open();
           int ret = Command.ExecuteNonQuery();
           conn.Close();

           return ret > 0;*/
        // return false;
        // }

        public static bool AddUser(//string username, string comesFrom, string password)
            string service, string login, string password = null)
        {
            if (password == null)
            {
                // confirm that service = some external provider
            }

            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            string operation = "INSERT INTO Users(uname, comesfrom, pass) VALUES";

            Queue<string> q = new Queue<string>();

            //Name
            string unameS = UtilS.wrap(password);
            q.Enqueue(unameS);

            //ComesFrom
            string comeS = UtilS.wrap(comesFrom);
            q.Enqueue(unameS);

            //Password
            string passS = UtilS.wrap(password);
            q.Enqueue(unameS);

            string record = UtilS.map(q, ",");
            record = UtilS.wrap("(", record, ")");

            operation += record;

            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();

            return ret > 0;
        }

        // nigdy nie powinnismy wywolwac tej metody - formularz z mass, age etc dostepny tylko dla juz zarejestrowanych uzytkownikow!
        /*public static bool AddUser(UserModel user)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            string operation = "INSERT INTO Users(uname, comesfrom, pass, mass, age, gender, caloriesTarget, caloriesBurned, caloriesReceived) VALUES ";

            Queue<string> q = new Queue<string>();

            //Name handling
            string unameS = UtilS.wrap(user.UserName);
            q.Enqueue(unameS);

            //Comesfrom
            string comesS = UtilS.wrap(user.ComesFrom);
            q.Enqueue(comesS);

            //Comesfrom
            string passS = UtilS.wrap(user.Password);
            q.Enqueue(passS);

            //Mass
            string massS = UtilS.nullToS(user.Mass);
            q.Enqueue(massS);

            //Age
            string ageS = UtilS.nullToS(user.Age);
            q.Enqueue(ageS);

            //Gender
            string GenderS = UtilS.genderToS(user.Gender);
            q.Enqueue(GenderS);

            //ToBurn
            string CaloriesToBurnS = UtilS.nullToS(user.CaloriesToBurn);
            q.Enqueue(CaloriesToBurnS);

            //Received
            string CaloriesReceivedS = UtilS.nullToS(user.CaloriesToReceive);
            q.Enqueue(CaloriesReceivedS);

            //Burned
            string CaloriesBurnedS = UtilS.nullToS(user.CaloriesBurned);
            q.Enqueue(CaloriesBurnedS);

            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            // creating whole command
            operation += record;


            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();


            return ret > 0;

        }*/

        public static bool UpdateUser(UserModel user)//, string OLDcomesfrom)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();

            string operation = "Update Users SET (uname, comesfrom, mass, age, gender, caloriesTarget, caloriesBurned, caloriesReceived) = ";

            Queue<string> q = new Queue<string>();

            //Name handling
            string unameS = UtilS.wrap(user.UserName);
            q.Enqueue(unameS);

            //Comesfrom
            string comesS = UtilS.wrap(user.ComesFrom);
            q.Enqueue(comesS);

            //Mass
            string massS = UtilS.nullToS(user.Mass);
            q.Enqueue(massS);

            //Age
            string ageS = UtilS.nullToS(user.Age);
            q.Enqueue(ageS);

            //Gender
            string GenderS = UtilS.genderToS(user.Gender);
            q.Enqueue(GenderS);

            //ToBurn
            string CaloriesToBurnS = UtilS.nullToS(user.CaloriesToBurn);
            q.Enqueue(CaloriesToBurnS);

            //Received
            string CaloriesReceivedS = UtilS.nullToS(user.CaloriesToReceive);
            q.Enqueue(CaloriesReceivedS);

            //Burned
            string CaloriesBurnedS = UtilS.nullToS(user.CaloriesBurned);
            q.Enqueue(CaloriesBurnedS);

            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            // creating whole command
            operation += record + "WHERE comesfrom = " + UtilS.wrap(OLDcomesfrom);


            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();

            return ret > 0;

        }

    }
}