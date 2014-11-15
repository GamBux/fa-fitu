using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaFitu.Models
{
    public class FoodModel
    {
        public bool IsGround { get; private set; }

        [Required]
        [Display(Name = "Name of food")]
        public string Name { get; private set; }

        public NutrientsModel Nutrients { get; private set; }

        public HashSet<FoodModel> Ingredients {get; private set; }

        // Constructor for ground food
        public FoodModel(string name, NutrientsModel nutrients)
        {
            IsGround = true;
            Name = name;
            Nutrients = nutrients;
        }

        // Constructor for complex food
        public FoodModel(string name, params FoodModel[] ingredients)
        {
            IsGround = false;
            Name = name;
            Ingredients = new HashSet<FoodModel>(ingredients);
            Nutrients = NutrientsModel.OfMany(ingredients.Select(food => food.Nutrients));
        }
    }
}