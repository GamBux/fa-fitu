using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public class FoodRelated
    {
        public HashSet<DishModel> GetCustomFood(UserModel user)
        {
            // ask a database
            return new HashSet<DishModel>();
        }

        public HashSet<DishModel> GetDefaultFood()
        {
            // ask a database
            return new HashSet<DishModel>();
        }

        public NutrientsModel GetNutrientsReceived(DateTime from)
        {
            return GetNutrientsReceived(from, DateTime.Now);
        }

        public NutrientsModel GetNutrientsReceived(DateTime from, DateTime to)
        {
            return new NutrientsModel(0, 0, 0, 
                new VitaminsModel(
                    new Dictionary<VitaminsModel.VitaminsNames, double>()));
        }
    }
}