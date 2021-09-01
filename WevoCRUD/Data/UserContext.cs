using WevoCRUD.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WevoCRUD.Data
{
    public class UserContext : IUserContext
    {
        public IMongoCollection<User> Users => throw new System.NotImplementedException();
    }
}
