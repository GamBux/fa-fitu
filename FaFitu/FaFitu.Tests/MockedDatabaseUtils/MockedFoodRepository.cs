using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedFoodRepository : FaFitu.DatabaseUtils.IFoodRepository
    {
        public int AddGroundFood(Models.GroundFoodModel m)
        {
            throw new NotImplementedException();
        }

        public int AddDish(Models.DishModel m)
        {
            throw new NotImplementedException();
        }

        public int UpdateFood(Models.FoodModel m)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFood(Models.FoodModel m)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.FoodModel> GetCustomFood(Models.UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.FoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public Models.FoodModel GetFoodById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.FoodModel> GetFoodsWithSubsequenceInName(string partial_name)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.FoodModel> GetAllGroundFoods()
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.FoodModel> GetAllDishes()
        {
            throw new NotImplementedException();
        }
    }
}
