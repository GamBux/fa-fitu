using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{

    public class UserModel
    {
        public enum Sex
        {
            MALE, FEMALE, UNDEFINEDLOL
        }
        
        public string UserName { get; set; }
        public string ComesFrom { get; set; }
        public int Mass { get; set; }
        public int CaloriesToBurn { get; set; }
        public int CaloriesToReceive { get; set; }
        public int CaloriesBurned { get; set; }
        public int Age { get; set; }
        public Sex Gender { get; set; }
    }
}