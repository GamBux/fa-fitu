using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class NutrientsModel
    {
        public double Proteins { get; set; }
        public double Carbons { get; set; }
        public double Fats { get; set; }
        
        public double Water { get; set; }

        public VitaminsModel Vitamins { get; set; }

        public NutrientsModel(double proteins, double carbons, double fats, VitaminsModel vitamins)
        {
            Proteins = proteins;
            Fats = fats;
            Vitamins = vitamins;
            Carbons = carbons;
        }

        public static NutrientsModel OfMany(IEnumerable<NutrientsModel> foods)
        {
            return new NutrientsModel(
                foods.Sum(nutr => nutr.Proteins),
                foods.Sum(nutr => nutr.Carbons),
                foods.Sum(nutr => nutr.Fats),
                VitaminsModel.OfMany(foods.Select(nutr => nutr.Vitamins))
                );
        }
    }
}