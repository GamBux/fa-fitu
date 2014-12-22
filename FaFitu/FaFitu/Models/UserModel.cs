using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaFitu.Utils;

namespace FaFitu.Models
{
    // TODO: should implement IDbModel
    public class UserModel : IDbModel
    {
        public enum Sex
        {
            MALE, FEMALE, UNDEFINEDLOL
        }
       // public int uid  { get; set; }
        public string uname { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public int mass { get; set; }
        public int activity { get; set; }
        public int age { get; set; }
        public int caloriesTarget { get; set; }
        public int service { get; set; }

        public override string ToString()
        {
            return String.Format("uname:{0}, email:{1}, pass:{2}, mass:{3}, activity:{4}, age:{5}, caloriesTarget:{6}, service:{7}", uname, email, pass, mass, activity, age, caloriesTarget, service);
        }

        public static string getFormatedFields() {
            return "(uname, email, pass, mass, activity, age, caloriesTarget, service)";
        }

        public string getFormatedValues() {
            Queue<string> q = new Queue<string>();

            //uname
            string unameS = UtilS.wrap(this.uname);
            q.Enqueue(unameS);

            //email
            string emailS = UtilS.wrap(this.email);
            q.Enqueue(emailS);

            //pass
            string passS = UtilS.wrap(this.pass);
            q.Enqueue(passS);

            //mass
            string massS = UtilS.maybeIntToS(this.mass);
            q.Enqueue(massS);

            //activity
            string activityS = UtilS.maybeIntToS(this.activity);
            q.Enqueue(activityS);

            //age
            string ageS = UtilS.maybeIntToS(this.age);
            q.Enqueue(ageS);

            //caloriesTarget
            string caloriesTargetS = UtilS.maybeIntToS(this.caloriesTarget);
            q.Enqueue(caloriesTargetS);

            //service
            string serviceS = UtilS.maybeIntToS(this.service);
            q.Enqueue(serviceS);

            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            return record;
        }

        public bool IsFromDb
        {
            get { throw new NotImplementedException(); }
        }

        public bool DirtyBit
        {
            get { throw new NotImplementedException(); }
        }

        public int? Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AddToDb()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFromDb()
        {
            throw new NotImplementedException();
        }

        public bool UpdateInDb()
        {
            throw new NotImplementedException();
        }
    }
}