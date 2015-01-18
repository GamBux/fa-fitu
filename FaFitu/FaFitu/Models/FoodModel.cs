using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class FoodModel : IFoodModel
    {
        public FoodModel(string n, string d, NutrientsModel nut, int? id = null)
        {
            Name = n;
            Description = d;
            Nutrients = nut;
            Id = id;
        }

        public string name;
        virtual public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string description;
        virtual public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public NutrientsModel nutrients;
        virtual public NutrientsModel Nutrients
        {
            get { return nutrients; }
            set { nutrients = value; }
        }

        virtual public bool IsFromDb { get; protected set; }

        virtual public bool DirtyBit { get; protected set; }

        virtual public int? Id { get; protected set; }

       /* public bool AddToDb()
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
        }*/
    }
}