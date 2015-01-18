using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class GroundFoodModel : FoodModel
    {
        // Constructor for ground food
        public GroundFoodModel(string name, string desc, NutrientsModel nutrients)
            :base(name, desc)
        {
            Nutrients = nutrients;
        }

        

        private NutrientsModel nutrs;
        virtual public NutrientsModel Nutrients
        {
            get { return nutrs; }
            set { nutrs = value; DirtyBit = true; }
        }


        virtual public int? Id { get; protected set; }

        virtual public bool IsFromDb { get; protected set; }

        virtual public bool DirtyBit { get; protected set; }

        // some more work for Piotr:
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
    }
}