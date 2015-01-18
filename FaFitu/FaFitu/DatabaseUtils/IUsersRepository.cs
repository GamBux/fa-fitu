using FaFitu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaFitu.DatabaseUtils
{
    public interface IUsersRepository
    {
        UserModel GetUser(string username, int service = 0);
        UserModel GetUser(int id);
        bool UserExists(string username, int service = 0);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="service"></param>
        /// <param name="password"></param>
        /// <exception cref="UsersRepositoryException">Thrown when couldn't add a new user</exception>
        /// <returns>int being an id of a newly added user</returns>
        int AddUser(string username, int service = 0, string password = null); // returns id
        int AddUser(UserModel user); // returns id

        bool DeleteUser(UserModel m);

        bool DeleteUser(string username, int service = 0);
        //bool DeleteUser(UserModel user);

        // probably wrong signature - which guy shall we update?
        bool UpdateUser(UserModel m);

        //NutrientsModel GetNutrientsReceived(UserModel m, UserModel m, DateTime from);
       // NutrientsModel GetNutrientsReceived(UserModel m, DateTime from, DateTime to);
    }
}
