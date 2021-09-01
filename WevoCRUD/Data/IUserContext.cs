using System;


using MongoDB.Driver;
using WevoCRUD.Entities;

namespace WevoCRUD.Data
{
    public interface IUserContext
    {
        IMongoCollection<User> Users { get; }
    }
}
