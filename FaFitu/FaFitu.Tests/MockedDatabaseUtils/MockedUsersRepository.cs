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
        int count;

        public MockedUsersRepository()
        {
            users = new List<UserModel>();
            count = 0;
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
                var nu = UserModel.FactoryMethod(username, service, password, count);
                count++;
                users.Add(nu);
                return (int)nu.Id;
            }
            
        }

        public int AddUser(Models.UserModel user)
        {
            return AddUser(user.Name, user.Service, user.Password);
        }

        public bool DeleteUser(string username, int service = 0)
        {
            if(UserExists(username, service))
            {
                int deleted = users.RemoveAll(m => username.Equals(m.Name) && service == m.Service);
                return deleted > 0;
            }
            return false;
        }

        public bool DeleteUser(UserModel user)
        {
            if (user.Id != null)
            {
                if (UserExists((int)user.Id))
                {
                    int deleted = users.RemoveAll(m => (int)user.Id == m.Id);
                    return deleted > 0;
                }
                else
                    return false;
            }
            return DeleteUser(user.Name, user.Service);
        }


        public NutrientsModel GetNutrientsReceived(DateTime from)
        {
            throw new NotImplementedException();
        }

        public NutrientsModel GetNutrientsReceived(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
