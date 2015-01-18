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
        bool AddGroundFood(GroundFoodModel m); // should return inserted item's id
        bool AddDish(DishModel m); // should return inserted item's id

        /*
         * Update
         * */
        bool UpdateGroundFood(GroundFoodModel gm);
        bool UpdateDish(DishModel dm);

        /*GET
         * */

        //Ground food
        GroundFoodModel GetGroundFood(string name);
        HashSet<GroundFoodModel> GetGroundFoodBySubName(string subName);

        //Dish Food
        // Ludzie mają swoje dania a jako, że nie chcemy pozwolić tylko 
        // jednemu uzytkownikowi nazwac coś barszczem to mamy barszcz na uzytkownika
        DishModel GetDish(string name, int uid);
        HashSet<DishModel> GetDishBySubName(string subName, int uid);

        //User Food
        HashSet<FoodModel> GetCustomFood(UserModel user);

        //Default and All Ground
        Tuple<HashSet<GroundFoodModel>, HashSet<DishModel>> GetDefaultFood();

        //All Ground
        HashSet<GroundFoodModel> GetAllGround();

        //All Dishes
        HashSet<DishModel> GetAllDishes();


        /*
         * Delete
         * */
        bool DeleteFood(FoodModel m);
    }
}
