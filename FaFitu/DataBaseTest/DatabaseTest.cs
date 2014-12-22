using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public class DatabaseTest
    {
        public static void insertTest1(){
            Console.WriteLine("Performing insertTest1");
        }

        public  void insertTest2(){
            Console.WriteLine("Performing insertTest1");
        }

        public  void insertTest3() { 
            Console.WriteLine("Performing insertTest1");
        }

        public void insertTestMaser() { 
            insertTest1();
            insertTest2();
            insertTest3();
        }
    }
}