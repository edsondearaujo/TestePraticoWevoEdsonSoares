using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WevoCRUD.Entities;

namespace WevoCRUD.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
        Task<IEnumerable<User>> GetUserByName(string name);
        
        Task CreatUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(string id);
    }
}
