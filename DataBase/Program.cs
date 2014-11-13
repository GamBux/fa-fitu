using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Zwinne_Postgress;

namespace Zwinne_Postgress
{
    class Program
    {
        static void Main(string[] args)
        {

            DataBase DB = new DataBase();
            bool isFatty = DB.existUser("Fatty");
            bool isGonzales = DB.existUser("Gonzales");

            int succesInsertingGonzales1   = DB.addUser("Gonzales", 85, -1, 45);
            int succesInsertingGonzales2   = DB.addUser("Gonzales", 85, 50, 45);
            int succesInsertingAdam        = DB.addUser("Adam", 75, 150, 21);
            

        }
    }


    
         
        
}
