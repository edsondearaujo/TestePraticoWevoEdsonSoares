using WevoCRUD.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WevoCRUD.Data;

namespace WevoCRUD.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;
        public UserRepository(IUserContext context)
        {
            _context = context;
        }
    }
}
