using MongoDB.Driver;
using System.Linq;
using WevoCRUD.Entities;
using System;
using System.Collections.Generic;

namespace WevoCRUD.Data
{
    public class UserContextOk
    {
        public static void OkData(IMongoCollection<User> userCollection)
        {
            bool existUser = userCollection.Find(userOk => true).Any();
            if (!existUser)
            {
                userCollection.InsertManyAsync(GetMyUsers());
            }
        }

        private static IEnumerable<User> GetMyUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = "4rghiopl0987ytg",
                    Nome = "Mongo",
                    Cpf = "824.965.397-15",
                    Email = "mongodb@wevo.com",
                    Telefone = "34 98463-5862",
                    Sexo = "Masculino",
                    DataNascimento = new DateTime(1995, 05, 13),

                }
            };
        }
    }
}