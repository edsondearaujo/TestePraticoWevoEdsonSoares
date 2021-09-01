using WevoCRUD.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WevoCRUD.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WevoCRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;
        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        // Definindo métodos da interface UserRepository, utilizando o Async.

        // Criando um usuário
        public async Task CreatUser(User user)
        {
           await _context.Users.InsertOneAsync(user);
        }

        public async Task<bool> DeleteUser(string id)
        {
            // Recurso do MongoDB para filtrar e DELETAR um usuário.
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(existUser => existUser.Id, id);

            DeleteResult deleteResult = await _context.Users.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<User> GetUser(string id)
        {
            // Procurando usuário pelo ID
            return await _context.Users.Find(userId => userId.Id == id).FirstOrDefaultAsync();
        }

        // Retornando uma lista de usuários fazendo a busca pelo NOME
        public async Task<IEnumerable<User>> GetUserByName(string name)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(existUser => existUser.Nome, name);

            DeleteResult deleteResult = await _context.Users.DeleteOneAsync(filter);

            return await _context.Users.Find(filter).ToListAsync();
        }

        // Retornando todos os usuários atráves do método GetUsers
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Find(userAll => true).ToListAsync();
        }

        // Método para editar os dados de um usuário
        public async Task<bool> UpdateUser(User user)
        {
            var updateResult = await _context.Users.ReplaceOneAsync(filter: userUpdate => userUpdate.Id == user.Id, replacement: user);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
