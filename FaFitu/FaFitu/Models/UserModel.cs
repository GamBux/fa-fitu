﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaFitu.Utils;

namespace FaFitu.Models
{
public class UserModel : IDbModel
    {
        public UserModel(string name,string email, string password)
        {
            Id = null;
            IsFromDb = false;
            Name = name;
            Email = email;
            Password = password;
        }

        // do we need this?
        public enum Sex
        {
            MALE, FEMALE, UNDEFINEDLOL
        }

        public string Name
        {
            get { return Name; }
            set { Name = value; DirtyBit = true; }
        }

        public string Email
        {
            get { return Email; }
            set { Email = value; DirtyBit = true; }
        }

        public string Password
        {
            get { return Password; }
            set { Password = value; DirtyBit = true; }
        }

        public int Mass // in kg
        {
            get { return Mass; }
            set { Mass = value; DirtyBit = true; }
        }

        public int Activity // whatever it means
        {
            get { return Activity; }
            set { Activity = value; DirtyBit = true; }
        }
        
        public int Age
        {
            get { return Age; }
            set { Age = value; DirtyBit = true; }
        }

        public int CaloriesTarget // calories/day
        {
            get { return CaloriesTarget; }
            set { CaloriesTarget = value; DirtyBit = true; }
        }

        protected int service { get; set; }

        public int? Id { get; protected set; }

        public bool IsFromDb { get; protected set; }

        public bool DirtyBit { get; protected set; }

        // some more work for Piotr:
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

        // i recommend database abstraction class to implement such methods

        //public override string ToString()
        //{
        //    return String.Format("uname:{0}, email:{1}, pass:{2}, mass:{3}, activity:{4}, age:{5}, caloriesTarget:{6}, service:{7}", uname, email, pass, mass, activity, age, caloriesTarget, service);
        //}

        //public static string getFormatedFields() {
        //    return "(uname, email, pass, mass, activity, age, caloriesTarget, service)";
        //}

        //public string getFormatedValues() {
        //    Queue<string> q = new Queue<string>();

        //    //uname
        //    string unameS = UtilS.wrap(this.uname);
        //    q.Enqueue(unameS);

        //    //email
        //    string emailS = UtilS.wrap(this.email);
        //    q.Enqueue(emailS);

        //    //pass
        //    string passS = UtilS.wrap(this.pass);
        //    q.Enqueue(passS);

        //    //mass
        //    string massS = UtilS.maybeIntToS(this.mass);
        //    q.Enqueue(massS);

        //    //activity
        //    string activityS = UtilS.maybeIntToS(this.activity);
        //    q.Enqueue(activityS);

        //    //age
        //    string ageS = UtilS.maybeIntToS(this.age);
        //    q.Enqueue(ageS);

        //    //caloriesTarget
        //    string caloriesTargetS = UtilS.maybeIntToS(this.caloriesTarget);
        //    q.Enqueue(caloriesTargetS);

        //    //service
        //    string serviceS = UtilS.maybeIntToS(this.service);
        //    q.Enqueue(serviceS);

        //    //putting it together
        //    string record = UtilS.map(q, ", ");
        //    record = UtilS.wrap("(", record, ")");

        //    return record;
        //}
    }
}