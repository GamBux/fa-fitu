﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedFoodRepository : FaFitu.DatabaseUtils.IFoodRepository
    {
        public HashSet<Models.IFoodModel> GetCustomFood(Models.UserModel user)
        {
            throw new NotImplementedException();
        }

        public HashSet<Models.IFoodModel> GetDefaultFood()
        {
            throw new NotImplementedException();
        }

        public Models.NutrientsModel GetNutrientsReceived(DateTime from)
        {
            throw new NotImplementedException();
        }

        public Models.NutrientsModel GetNutrientsReceived(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}