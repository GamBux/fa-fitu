using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaFitu.Models;
using FaFitu.DatabaseUtils;

namespace FaFitu.Tests.MockedDatabaseUtils
{
    class MockedUsersRepository : FaFitu.DatabaseUtils.IUsersRepository
    {
        List<UserModel> users;

        public MockedUsersRepository()
        {
            users = new List<UserModel>();
        }

        public UserModel GetUser(string username, int service = 0)
        {
            if(UserExists(username, service))
            {
                return users.Find(m => m.Name.Equals(username) && m.Service == service);
            }
            else
            {
                throw new RepositoryExceptions.UsersRepositoryException(
                    String.Format("Couldn't find a user with username={0} and service={1}", username, service));
            }
        }

        public UserModel GetUser(int id)
        {
            if(UserExists(id))
            {
                return users.Find(m => m.Id == id);
            }
            else
            {
                throw new RepositoryExceptions.UsersRepositoryException(
                    String.Format("Couldn't find a user with id={0} and service={1}", id));
            }
        }

        public bool UserExists(string username, int service = 0)
        {
            return users.Any(m => m.Name.Equals(username) && m.Service == service);
        }

        protected bool UserExists(int id)
        {
            return users.Any(m => m.Id == id);
        }

        public int AddUser(string username, int service = 0, string password = null)
        {
            if(UserExists(username, service))
            {
                throw new FaFitu.DatabaseUtils.RepositoryExceptions.UsersRepositoryException(
                    String.Format("User with username={0} and service={1} already exists", username, service));
            }
            else
            {
                users.Add(new UserModel(username, service, password));
                return true;
            }
            
        }

        public int AddUser(Models.UserModel user)
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
