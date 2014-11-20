using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaFitu.Models;

namespace FaFitu.Utils
{
    /*
     * Trying to force some convention - if sth (be it of type string or not) should be null,
     * let it be null (and not "NULL" or "") everywhere but in method wrap that tests it.
     */
    public static class UtilS
    {
        public static string wrap(string a)
        {
            if (a == null)
                return "NULL";
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

        // pls change the name of this method
        public static string maybeIntToS(int a)
        {
            if (a == -1) return "NULL";
            else return a.ToString();
        }
        public static string ifEmptyThenNull(string s)
        {
            if (s == null || s.Equals(""))
                return null;
            return s;
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
                    return null;//"NULL";
                
                default:
                    return null;//"";
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

        public static int possibleNullObjectToInt(object o) 
        {
            // waaat?
            if (o == null)
                return -1;
            string s = o.ToString();
            if (s == "") return -1;
            else return (int)o;
        }

        public static string possibleNullObjectToString(object o)
        {
            if (o == null)
                return "";
            string s = o.ToString();
           // if (s == "") return "";
           // else return (string)o;
            return s; // right?
        }

        public static int serviceToInt(string service)
        {
            if(service.ToLower().Equals("email"))
            {
                return 0;
            }
            return 1;
        }
    }
 
}
