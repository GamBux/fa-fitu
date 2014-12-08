using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaFitu.Models
{
    public class DishModel : IFoodModel
    {
        public DishModel(string name, params Tuple<IFoodModel, double>[] ingredients)
        {
            IsFromDb = false;
            Name = name;
            Ingredients = new HashSet<Tuple<IFoodModel, double>>(ingredients);
        }

        public string Name {
            get { return Name; }
            set { Name = value; DirtyBit = true; }
        }

        public string Description {
            get { return Description; }
            set { Description = value; DirtyBit = true; }
        }
        
        // preparation instructions
        public string Recipe {
            get { return Recipe; }
            set { Recipe = value; DirtyBit = true; }
        }

        public HashSet<Tuple<IFoodModel, double>> Ingredients {
            get { return Ingredients; }
            set { Ingredients = value; DirtyBit = true; }
        }

        public NutrientsModel Nutrients {
            get { return NutrientsModel.OfMany(Ingredients.Select(pair => new Tuple<NutrientsModel,double>(pair.Item1.Nutrients,pair.Item2))); }
        }

        public bool IsFromDb { get; protected set; }

        public bool DirtyBit { get; protected set; }

        // Piotr, it's your job
        public bool AddToDb() {
            //probably should use some smart method of FoodRelated
            throw new NotImplementedException();
        }

        // this one too
        public bool DeleteFromDb() {
            throw new NotImplementedException();
        }

        // and guess what - this one is also yours
        public bool UpdateInDb() {
            throw new NotImplementedException();
        }
    }
}