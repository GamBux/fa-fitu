using FaFitu.DatabaseUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedStatisticsRepository : IStatisticsRepository
    {
        public Models.NutrientsModel GetNutrientsReceived(Models.UserModel m, Models.UserModel m, DateTime from)
        {
            throw new NotImplementedException();
        }

        public Models.NutrientsModel GetNutrientsReceived(Models.UserModel m, DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public Models.NutrientsModel AddEaten(Models.UserModel m, Models.NutrientsModel justEaten, DateTime? now)
        {
            throw new NotImplementedException();
        }
    }
}
