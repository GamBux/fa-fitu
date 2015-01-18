using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaFitu.Models
{
    public class DishModel : FoodModel
    {
        public DishModel(string name, string desc, string recipe, params Tuple<FoodModel, int>[] ingredients)
            :base(name,desc)
        {
            Recipe = recipe;
            Ingredients = new HashSet<Tuple<FoodModel, int>>(ingredients);
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
        
        // preparation instructions
        private string recipe;
        virtual public string Recipe {
            get { return recipe; }
            set { recipe = value; DirtyBit = true; }
        }

        private HashSet<Tuple<FoodModel, int>> ings;
        public HashSet<Tuple<FoodModel, int>> Ingredients {
            get { return ings; }
            set { ings = value; DirtyBit = true; }
        }

        public NutrientsModel Nutrients {
           get { return NutrientsModel.OfMany(Ingredients.Select(pair => new Tuple<NutrientsModel,int>(pair.Item1.Nutrients ,pair.Item2))); }
        }

        virtual public int? Id { get; protected set; }

        virtual public bool IsFromDb { get; protected set; }

        virtual public bool DirtyBit { get; protected set; }

        // Piotr, it's your job
        virtual public bool AddToDb() {
            //probably should use some smart method of FoodRelated
            throw new NotImplementedException();
        }

        // this one too
        virtual public bool DeleteFromDb() {
            throw new NotImplementedException();
        }

        // and guess what - this one is also yours
        virtual public bool UpdateInDb() {
            throw new NotImplementedException();
        }
    }
}