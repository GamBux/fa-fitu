using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaFitu.Models;

namespace FaFitu.Utils
{
    public static class UtilS
    {
        public static string wrap(string a)
        {
            return wrap("'", a, "'");
        }
        public static string wrap(string a, string b)
        {
            return wrap(b, a, b);
        }
        public static string wrap(string l, string a, string r)
        {
            return l + a + r;
        }
        public static string nullToS(int a)
        {
            if (a == -1) return "NULL";
            else return a.ToString();
        }
        public static string genderToS(UserModel.Sex gender)
        {
            switch (gender)
            {
                case UserModel.Sex.MALE:
                    return "'MALE'";
             
                case UserModel.Sex.FEMALE:
                    return "'FEMALE'";
                
                case UserModel.Sex.UNDEFINEDLOL:
                    return "NULL";
                
                default:
                    return "";
            }
        }
        public static string map(Queue<string> q, string mapped){
            string record = "";
            while (q.Count > 0)
            {
                record += q.Dequeue();
                if (q.Count == 0) continue;
                record += mapped;
            }

            return record;
        }

  
    }
 
}
