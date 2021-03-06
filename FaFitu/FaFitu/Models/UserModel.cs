﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaFitu.Utils;

namespace FaFitu.Models
{

    public class UserModel : IDbModel, IEquatable<UserModel>
    {
        public UserModel() {
            IsFromDb = false;
        }

        public void SetId(int id){
            Id = id;
        }
        public UserModel(string name, int service, string password, string email = null, int? id = null)
        {
            /*
            uid 		serial PRIMARY KEY,
	        uname 		varchar NOT NULL,
	        email		varchar UNIQUE,
	        pass		varchar,
	        mass 		int,
	        activity 	int,
	        age 		int,
	        caloriesTarget int,
	        service int NOT NULL DEFAULT 0,
             */
            Id = id;
            IsFromDb = false;
            Name = name;
            Service = service;
            Password = password;
            Email = email;
        }

        public static UserModel FactoryMethod(string name, int service, string password, int id, string email = null)
        {
            var nu = new UserModel(name, service, password, email);
            nu.Id = id;
            return nu;
        }

        // do we need this?
        public enum Sex
        {
            MALE, FEMALE, UNDEFINEDLOL
        }

        private string name;
        virtual public string Name
        {
            get { return name; }
            set { name = value; DirtyBit = true; }
        }

        private string email;
        virtual public string Email
        {
            get { return email; }
            set { email = value; DirtyBit = true; }
        }

        private string pass;
        virtual public string Password
        {
            get { return pass; }
            set { pass = value; DirtyBit = true; }
        }

        private int? mass;
        virtual public int? Mass // in kg
        {
            get { return mass; }
            set { mass = value; DirtyBit = true; }
        }

        private int? activity;
        virtual public int? Activity // whatever it means
        {
            get { return activity; }
            set { activity = value; DirtyBit = true; }
        }

        private int? age;
        virtual public int? Age
        {
            get { return age; }
            set { age = value; DirtyBit = true; }
        }

        private int? calTar;
        virtual public int? CaloriesTarget // calories/day
        {
            get { return calTar; }
            set { calTar = value; DirtyBit = true; }
        }

        private int serv;
        virtual public int Service
        {
            get { return serv; }
            set { serv = value; DirtyBit = true; }
        }

        virtual public int? Id { get; protected set; }

        virtual public bool IsFromDb { get; protected set; }

        virtual public bool DirtyBit { get; protected set; }

      /*  // some more work for Piotr:
        virtual public bool AddToDb()
        {
            throw new NotImplementedException();
        }

        virtual public bool DeleteFromDb()
        {
            throw new NotImplementedException();
        }

        virtual public bool UpdateInDb()
        {
            throw new NotImplementedException();
        }
        */
        virtual public bool Equals(UserModel other)
        {
            if(Id != null && other.Id != null)
            {
                return Id == other.Id;
            }
            return Name.Equals(other.Name) && Service == other.Service;
        }
        
        public override string ToString()
        {
            return String.Format("uname:{0}, email:{1}, pass:{2}, mass:{3}, activity:{4}, age:{5}, caloriesTarget:{6}, service:{7}", Name, Email, Password, Mass, Activity, Age, CaloriesTarget, Service);
        }

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