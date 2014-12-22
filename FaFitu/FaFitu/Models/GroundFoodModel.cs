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

        public string Name
        {
            get { return Name; }
            set { Name = value; DirtyBit = true; }
        }

        public string Description
        {
            get { return Description; }
            set { Description = value; DirtyBit = true; }
        }

        public NutrientsModel Nutrients
        {
            get { return Nutrients; }
            set { Nutrients = value; DirtyBit = true; }
        }

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
    }
}