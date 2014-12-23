using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class GroundFoodModel : IFoodModel
    {
        // Constructor for ground food
        public GroundFoodModel(string name, NutrientsModel nutrients)
        {
            Id = null;
            IsFromDb = false;
            Name = name;
            Nutrients = nutrients;
        }

        private string name;
        virtual public string Name
        {
            get { return name; }
            set { name = value; DirtyBit = true; }
        }

        private string desc;
        virtual public string Description
        {
            get { return desc; }
            set { desc = value; DirtyBit = true; }
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