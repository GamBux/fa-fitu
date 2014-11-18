using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using FaFitu.Models;
using FaFitu.DatabaseUtils;
using FaFitu.Utils;

namespace DataBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            UserModel user = new UserModel();

            user.UserName      		= "Ada Ramirez"; 
            user.ComesFrom     		= "FF:Ada.Ramirez@gamil.com"; 
            user.Mass             	= 65; 
            user.CaloriesToBurn   	= 1900; 
            user.CaloriesToReceive 	= 450; 
            user.CaloriesBurned   	= 300; 
            user.Age              	= 35;
            user.Password           = "QWERTY";
            user.Gender           	= UserModel.Sex.FEMALE;

            UsersRelated.AddUser(user);

            user.ComesFrom = "FF:Ada.Ramirez@gmail.com";

            UsersRelated.UpdateUser(user, "FF:Ada.Ramirez@gamil.com");
        }
    }
}
