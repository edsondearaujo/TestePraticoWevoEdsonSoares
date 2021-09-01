using System;


using MongoDB.Driver;
using WevoCRUD.Entities;

namespace WevoCRUD.Data
{
    public interface IUserContext
    {
        //definição da Coleção de usuários
        IMongoCollection<User> Users { get; }
    }
}
