using Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataConnection.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User Create(User user, string password);
        void Update(User userParam, string password = null);
        void Delete(int userId);
    }
}
