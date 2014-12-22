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

        int UpdateFood(IFoodModel m);

        bool DeleteFood(IFoodModel m);

        HashSet<IFoodModel> GetCustomFood(UserModel user);
        HashSet<IFoodModel> GetDefaultFood();
       // NutrientsModel GetNutrientsReceived(DateTime from);
       // NutrientsModel GetNutrientsReceived(DateTime from, DateTime to);
        IFoodModel GetFoodById(int id);
        HashSet<IFoodModel> GetFoodsWithSubsequenceInName(string partial_name);
        HashSet<IFoodModel> GetAllGroundFoods();
        HashSet<IFoodModel> GetAllDishes();
    }
}
