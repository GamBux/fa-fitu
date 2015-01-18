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

        public bool AddGroundFood(FoodModel m)
        {
            // conn = DataBaseConnection.GetConnection();
           // string operation = "INSERT INTO Food" + PrettyPrinterFood.getFormatedFieldsNames() + " VALUES " + PrettyPrinterFood.getFormatedValues(m);

            // creating whole command

            // Command = new NpgsqlCommand(operation, conn);

            //conn.Open();
           // int ret = Command.ExecuteNonQuery();
//conn.Close();


            return 0 > 0;
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

        public int AddGroundFood(GroundFoodModel m)
        {
            throw new NotImplementedException();
        }
    }
}