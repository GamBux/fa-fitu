﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class FoodModel : IDbModel
    {
        public FoodModel(string n, string d)
        {
            this.Name = n;
            this.Description = d;
            IsFromDb = false;
            DirtyBit = true;
            Id = null;
        }
        public bool IsGround { get; set; }
        public int? Id;
        public string Name {get; set;}
        public NutrientsModel Nutrients{get; set;}
        public string Description { get; set; }
        
        

        virtual public bool IsFromDb { get; protected set; }

        virtual public bool DirtyBit { get; protected set; }

        int? IDbModel.Id
        {
            get { throw new NotImplementedException(); }
        }

        bool IDbModel.IsFromDb
        {
            get { throw new NotImplementedException(); }
        }

        bool IDbModel.DirtyBit
        {
            get { throw new NotImplementedException(); }
        }
    }
}