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
        List<GroundFoodModel> grounds;
        List<DishModel> dishes;
        IUsersRepository usersRepo;
      //  int count;
        
        public MockedFoodRepository()
        {
            grounds = new List<GroundFoodModel>();
            dishes = new List<DishModel>();
           // count = 0;
        }


        public bool AddGroundFood(GroundFoodModel m)
        {
            grounds.Add(m);
            return true;
        }

        public bool AddDish(DishModel m)
        {
            dishes.Add(m);
            return true;
        }

        public bool UpdateGroundFood(GroundFoodModel gm)
        {
            if(grounds.Any(m => m.Id == gm.Id))
            {
                grounds.RemoveAll(m => m.Id == gm.Id);
                return AddGroundFood(gm);
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDish(DishModel dm)
        {
            if (dishes.Any(m => m.Id == dm.Id))
            {
                dishes.RemoveAll(m => m.Id == dm.Id);
                return AddDish(dm);
            }
            else
            {
                return false;
            }
        }

        public GroundFoodModel GetGroundFood(string name)
        {
            return grounds.Where(m => m.Name == name).First();
        }

        public List<GroundFoodModel> GetGroundFoodBySubName(string subName)
        {
            return grounds.Where(m => m.Name.Contains(subName)).ToList();
        }

        public DishModel GetDish(string name, int uid)
        {
            return dishes.Where(m => m.Name == name && )
        }

        public List<DishModel> GetDishBySubName(string subName, int uid)
        {
            throw new NotImplementedException();
        }

        public List<FoodModel> GetCustomFood(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Tuple<List<GroundFoodModel>, List<DishModel>> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public List<GroundFoodModel> GetAllGround()
        {
            throw new NotImplementedException();
        }

        public List<DishModel> GetAllDishes()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFood(FoodModel m)
        {
            throw new NotImplementedException();
        }
    }
}
