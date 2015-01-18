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
           /* FoodModel food = new FoodModel("jajo", 0, "Ale jaja", "Wezmisz czarno kure");
            food.Nutrients = new NutrientsModel(15, 5, 83);

            FoodRepository tester = new FoodRepository();

            tester.AddGroundFood(food);*/
            
        }

        static void TestDataBaseUser1() {
            UserModel user = new UserModel();
            UsersRepository tester = new UsersRepository();


            user.Name = "Ada";
            user.Email = "Ada.Ramirez@gamil.com";
            user.Password = "MySuperPass";
            user.Mass = 65;
            user.Activity = 100;
            user.Age = 45;
            user.CaloriesTarget = 2000;
            if (tester.UserExists("Ada") == false) tester.AddUser(user);
            tester.DeleteUser("Ada", 0);
            tester.AddUser(user);

            UserModel user2 = tester.GetUser("Ada", 0);
            user2.Password = "MySuperiorPass";
            tester.UpdateUser(user2);
        }
    }
}
