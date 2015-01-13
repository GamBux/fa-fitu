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

        public int UpdateFood(Models.IFoodModel m)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFood(Models.IFoodModel m)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetCustomFood(Models.UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public Models.IFoodModel GetFoodById(int id)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetFoodsWithSubsequenceInName(string partial_name)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetAllGroundFoods()
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetAllDishes()
        {
            throw new NotImplementedException();
        }
    }
}
