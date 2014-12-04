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

            
            user.uname			= "Ada";
            user.email			= "Ada.Ramirez@gamil.com";
            user.pass			= "MySuperPass";
            user.mass			= 65;
            user.activity		= 100;
            user.age			= 45;
            user.caloriesTarget	= 2000;
            if (UsersRelated.UserExists("Ada") == false) UsersRelated.AddUser(user);
            UsersRelated.DeleteUser("Ada", 0);
            UsersRelated.AddUser(user);
            UserModel user2 = UsersRelated.GetUser("Ada", 0);

        }
    }
}
