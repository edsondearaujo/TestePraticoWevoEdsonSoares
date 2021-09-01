using WevoCRUD.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WevoCRUD.Data
{
    public class UserContext : IUserContext
    {
        // Definição dos dados de configuração (exemplo: Nome do Banco de Dados, coleção e Documentos) 
        public UserContext(IConfiguration configuration)
        {
            // Leitura do arquivo de configuração da connectionString
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            // Nome do Banco de Dados
            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));


            Users = database.GetCollection<User>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));
           
            UserContextOk.OkData(Users);
        }

        public IMongoCollection<User> Users { get; }

    }
}
