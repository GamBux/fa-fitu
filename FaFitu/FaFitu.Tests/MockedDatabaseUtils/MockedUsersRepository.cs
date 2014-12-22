using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedUsersRepository : FaFitu.DatabaseUtils.IUsersRepository
    {
        List<Models.UserModel> users;

        public MockedUsersRepository()
        {
            users = new List<Models.UserModel>();
        }

        public Models.UserModel GetUser(string username, int service = 0)
        {
            return users.Find(m => m.uname.Equals(username) && m.service == service);
        }

        public bool UserExists(string username, int service = 0)
        {
            return users.Any(m => m.uname.Equals(username) && m.service == service);
        }

        public bool AddUser(string username, int service = 0, string password = null)
        {
            if(UserExists(username, service))
            {
                return false;
            }
            else
            {
                users.Add(new Models.UserModel { uname = username, service = service, pass = password });
                return true;
            }
            
        }

        public bool AddUser(Models.UserModel user)
        {
            return AddUser(user.uname, user.service, user.pass);
        }

        public bool DeleteUser(string username, int service = 0)
        {
            if(UserExists(username, service))
            {
                // need to check how equality is tested
                //users.Remove()
                return true;
            }
            return false;
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
