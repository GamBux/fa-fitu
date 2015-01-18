using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace FaFitu.DatabaseUtils
{
    public class FoodRepository : IFoodRepository
    {
        public HashSet<FoodModel> GetCustomFood(UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<FoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public FoodModel GetFoodById(int id)
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

        public bool AddGroundFood(GroundFoodModel m)
        {
            string operation = "INSERT INTO Food" + PrettyPrinterFood.getFormatedGroundNames() + " VALUES " + PrettyPrinterFood.getFormatedGroundValues(m);
            int ret = DataBaseConnection.ExecuteNonQuery(operation);
            return ret > 0;
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


        bool IFoodRepository.AddDish(DishModel m)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGroundFood(GroundFoodModel gm)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDish(DishModel dm)
        {
            throw new NotImplementedException();
        }

        public GroundFoodModel GetGroundFood(string name)
        {
            throw new NotImplementedException();
        }

        public HashSet<GroundFoodModel> GetGroundFoodBySubName(string subName)
        {
            throw new NotImplementedException();
        }

        public DishModel GetDish(string name, int uid)
        {
            throw new NotImplementedException();
        }

        public HashSet<DishModel> GetDishBySubName(string subName)
        {
            throw new NotImplementedException();
        }

        Tuple<HashSet<GroundFoodModel>, HashSet<DishModel>> IFoodRepository.GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public HashSet<GroundFoodModel> GetAllGround()
        {
            throw new NotImplementedException();
        }

        HashSet<DishModel> IFoodRepository.GetAllDishes()
        {
            throw new NotImplementedException();
        }
    }
}