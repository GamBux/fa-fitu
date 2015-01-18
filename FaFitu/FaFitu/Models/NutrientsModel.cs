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
        
        // really? we need it?
        public double Water { get; set; }

        public VitaminsModel Vitamins { get; set; }

        // currently i dont care for the vitamins, so i'll be using this constructor:
        public NutrientsModel(double proteins, double carbons, double fats)
        {
            Proteins = proteins;
            Fats = fats;
            Carbons = carbons;
        }

        public NutrientsModel(double proteins, double carbons, double fats, VitaminsModel vitamins)
        {
            Proteins = proteins;
            Fats = fats;
            Vitamins = vitamins;
            Carbons = carbons;
        }

        public static NutrientsModel OfMany(IEnumerable< Tuple<NutrientsModel, double> > foods)
        {
            return new NutrientsModel(
                foods.Sum(pair => pair.Item2 * pair.Item1.Proteins),
                foods.Sum(pair => pair.Item2 * pair.Item1.Proteins),
                foods.Sum(pair => pair.Item2 * pair.Item1.Proteins)
                
                // not sure, how it should work, so lets leave it commented for now
                //VitaminsModel.OfMany(foods.Select(nutr => nutr.Vitamins))
            );
        }

        public static NutrientsModel Add(NutrientsModel nm, double proteins, double carbons, double fats)
        {
            return new NutrientsModel(nm.Proteins + proteins, nm.Carbons + carbons, nm.Fats + fats);
        }

        public static NutrientsModel Add(NutrientsModel nm1, NutrientsModel nm2)
        {
            return Add(nm1, nm2.Proteins, nm2.Carbons, nm2.Fats);
        }
    }
}