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
        HashSet<IFoodModel> GetCustomFood(UserModel user);
        HashSet<IFoodModel> GetDefaultFood();
        NutrientsModel GetNutrientsReceived(DateTime from);
        NutrientsModel GetNutrientsReceived(DateTime from, DateTime to);
    }
}
