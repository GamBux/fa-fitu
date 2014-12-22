using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaFitu.Utils;
using FaFitu.Models;

namespace FaFitu.DatabaseUtils
{
    public class PrettyPrinterUser
    {
        public static string getFormatedFields()
        {
            return "(uname, email, pass, mass, activity, age, caloriesTarget, service)";
        }

        public static string getFormatedValues(UserModel um)
        {
            Queue<string> q = new Queue<string>();

            //uname
            string unameS = UtilS.wrap(um.Name);
            q.Enqueue(unameS);

            //email
            string emailS = UtilS.wrap(um.Email);
            q.Enqueue(emailS);

            //pass
            string passS = UtilS.wrap(um.Password);
            q.Enqueue(passS);

            //mass
            string massS = UtilS.maybeIntToS(um.Mass);
            q.Enqueue(massS);

            //activity
            string activityS = UtilS.maybeIntToS(um.Activity);
            q.Enqueue(activityS);

            //age
            string ageS = UtilS.maybeIntToS(um.Age);
            q.Enqueue(ageS);

            //caloriesTarget
            string caloriesTargetS = UtilS.maybeIntToS(um.CaloriesTarget);
            q.Enqueue(caloriesTargetS);

            //service
            string serviceS = UtilS.maybeIntToS(um.Service);
            q.Enqueue(serviceS);

            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            return record;
        }
    }
}