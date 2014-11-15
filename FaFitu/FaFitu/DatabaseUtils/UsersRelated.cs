using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public class UsersRelated
    {
        public static UserModel GetUser(string comesFrom)
        {
            // ask database
            return null;
        }

        public static bool UserExists(string comesFrom)
        {
            return true;
        }

        public static bool AddUser(RegisterModel user)
        {
            return true;
        }

        public static bool AddUser(string username, string comesFrom)
        {
            return true;
        }
    }
}