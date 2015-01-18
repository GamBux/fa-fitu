using FaFitu.DatabaseUtils;
using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedStatisticsRepository : IStatisticsRepository
    {

        Dictionary<int, History> user2nutrients;

        public MockedStatisticsRepository()
        {
            user2nutrients = new Dictionary<int, History>();

        }

        public NutrientsModel GetNutrientsReceived(UserModel m, DateTime from)
        {
            return GetNutrientsReceived(m, from, DateTime.Now);
        }

        public NutrientsModel GetNutrientsReceived(UserModel m, DateTime from, DateTime to)
        {
            if (user2nutrients.ContainsKey((int)m.Id))
            {
                var hist = user2nutrients[(int)m.Id];
                return hist.Get(from, to);
            }
            else
            {
                return new NutrientsModel(0, 0, 0);
            }
        }

        public void AddEaten(UserModel m, NutrientsModel justEaten, DateTime now)
        {
            if (user2nutrients.ContainsKey((int)m.Id))
            {
                var hist = user2nutrients[(int)m.Id];
                hist.Add(now, justEaten);
            }
            else
            {
                user2nutrients.Add((int)m.Id, new History());
            }
        }
    }

    class History
    {
        List<Tuple<DateTime, NutrientsModel>> hist;

        public History()
        {
            hist = new List<Tuple<DateTime, NutrientsModel>>();
        }

        public void Add(DateTime t, NutrientsModel newn)
        {
            hist.Add(new Tuple<DateTime, NutrientsModel>(t, newn));
        }

        public NutrientsModel Get(DateTime from, DateTime to)
        {
            var from_not_to = hist.SkipWhile(t => DateTime.Compare(t.Item1, from) < 0);
            var from_to = from_not_to.TakeWhile(t => DateTime.Compare(t.Item1, to) <= 0);
            return from_to.Aggregate(new NutrientsModel(0, 0, 0), (acc, t) => NutrientsModel.Add(acc, t.Item2));
        }
    }
}
