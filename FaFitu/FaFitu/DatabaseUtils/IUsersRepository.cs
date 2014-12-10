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
        bool UserExists(string username, int service = 0);
        bool AddUser(string username, int service = 0, string password = null);
        bool AddUser(UserModel user);
        bool DeleteUser(string username, int service = 0);

    }
}
