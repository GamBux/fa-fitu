using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public class FoodRepository : IFoodRepository
    {
        public HashSet<IFoodModel> GetCustomFood(UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<IFoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public IFoodModel GetFoodById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<IFoodModel> GetFoodsWithSubsequenceInName(string partial_name)
        {
            throw new NotImplementedException();
        }

        public HashSet<IFoodModel> GetAllGroundFoods()
        {
            throw new NotImplementedException();
        }

        public HashSet<IFoodModel> GetAllDishes()
        {
            throw new NotImplementedException();
        }
    }
}