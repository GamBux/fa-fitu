using FaFitu.DatabaseUtils;
using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedFoodRepository : IFoodRepository
    {
        HashSet<GroundFoodModel> grounds;
        HashSet<DishModel> dishes;



        public int AddGroundFood(GroundFoodModel m)
        {
            grounds.Add(m);
        }

        public int AddDish(DishModel m)
        {
            throw new NotImplementedException();
        }


        public int UpdateFood(FoodModel m)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFood(FoodModel m)
        {
            throw new NotImplementedException();
        }


        public HashSet<Models.FoodModel> GetCustomFood(UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<FoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public Models.FoodModel GetFoodById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<FoodModel> GetFoodsWithSubsequenceInName(string partial_name)
        {
            throw new NotImplementedException();
        }

        public HashSet<FoodModel> GetAllGroundFoods()
        {
            throw new NotImplementedException();
        }

        public HashSet<FoodModel> GetAllDishes()
        {
            throw new NotImplementedException();
        }
    }
}
