using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.DatabaseUtils
{
    public interface IStatisticsRepository
    {
        NutrientsModel GetNutrientsReceived(UserModel m, UserModel m, DateTime from);
        NutrientsModel GetNutrientsReceived(UserModel m, DateTime from, DateTime to);

        NutrientsModel AddEaten(UserModel m, NutrientsModel justEaten, DateTime? now);

    }
}