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
    public class UsersRepository : IUsersRepository
    {
        public UserModel GetUser(string username, int service = 0)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();

            string operation = "SELECT * FROM Users WHERE (uname,service) = (" + UtilS.wrap(username) + "," + service.ToString() + ")";
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            UserModel user = new UserModel();
            NpgsqlDataReader rd = Command.ExecuteReader();

            bool isResult = false;
            while (rd.Read()) {
                isResult = true;
                int i = 0;
                user.SetId((int)rd[i++]);
                user.Name          = UtilS.possibleNullObjectToString(rd[i++]);
                user.Email          = UtilS.possibleNullObjectToString(rd[i++]);
                user.Password           = UtilS.possibleNullObjectToString(rd[i++]);
                user.Mass           = UtilS.possibleNullObjectToInt(rd[i++]);
                user.Activity       = UtilS.possibleNullObjectToInt(rd[i++]);
                user.Age            = UtilS.possibleNullObjectToInt(rd[i++]);
                user.CaloriesTarget = UtilS.possibleNullObjectToInt(rd[i++]);
                user.Service        = UtilS.possibleNullObjectToInt(rd[i++]);
            }
            conn.Close();


            if (isResult) return user;
            else return null;
        }
      

        public bool UserExists(string username, int service = 0)
        {
            UserModel user = GetUser(username, service);

            if (user == null) return false;
            else return true;

        }

        public bool AddUser(string username, int service = 0, string password = null)
        {
            if(service == 0 && password == null) // i.e. native fafitu member without pass - sth wrong!
            {
                return false;
            }
            var um = new UserModel();
            um.Activity = -1;
            um.Age = -1;
            um.CaloriesTarget = -1;
            um.Email = null;
            um.Service = service;
            um.Name = UtilS.ifEmptyThenNull(username);//UtilS.possibleNullObjectToString(username);
            um.Password = UtilS.ifEmptyThenNull(password);

            return AddUser(um);
        }

        public bool AddUser(UserModel user)
        {
            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            string operation = "INSERT INTO Users" + PrettyPrinterUser.getFormatedFields() +"VALUES " + PrettyPrinterUser.getFormatedValues(user);
            
            // creating whole command
           
            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();


            return ret > 0;

        }

        public bool DeleteUser(string username, int service = 0)
        {

            if (UserExists(username, service) == false) return false;

            NpgsqlConnection conn = DataBaseConnection.GetConnection();
            string operation = "DELETE FROM Users WHERE uname = " + UtilS.wrap(username) + " AND service = " + service.ToString();

            // creating whole command

            NpgsqlCommand Command = new NpgsqlCommand(operation, conn);

            conn.Open();
            int ret = Command.ExecuteNonQuery();
            conn.Close();


            return ret > 0;
        }

      /*  public static bool UpdateUser(UserModel user, string OLDcomesfrom)
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

        }*/



        public UserModel GetUser(int id)
        {
            throw new NotImplementedException();
        }

        int IUsersRepository.AddUser(string username, int service = 0, string password = null)
        {
            throw new NotImplementedException();
        }

        int IUsersRepository.AddUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(UserModel m)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(UserModel m)
        {
            throw new NotImplementedException();
        }

        public NutrientsModel GetNutrientsReceived(DateTime from)
        {
            throw new NotImplementedException();
        }

        public NutrientsModel GetNutrientsReceived(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}