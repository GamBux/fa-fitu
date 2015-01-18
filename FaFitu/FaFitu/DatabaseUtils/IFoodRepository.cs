using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.DatabaseUtils
{
    public interface IFoodRepository
    {
        int AddGroundFood(GroundFoodModel m); // should return inserted item's id
        int AddDish(DishModel m); // should return inserted item's id

        int UpdateFood(FoodModel m);

        bool DeleteFood(FoodModel m);

        HashSet<FoodModel> GetCustomFood(UserModel user);
        HashSet<FoodModel> GetDefaultFood();
       // NutrientsModel GetNutrientsReceived(DateTime from);
       // NutrientsModel GetNutrientsReceived(DateTime from, DateTime to);
        FoodModel GetFoodById(int id);
        HashSet<FoodModel> GetFoodsWithSubsequenceInName(string partial_name);
        HashSet<FoodModel> GetAllGroundFoods();
        HashSet<FoodModel> GetAllDishes();
    }
}
