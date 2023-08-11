using webapi.Models;
using MongoDB.Driver;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Options;

namespace webapi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<GamerFinderDatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<User>(databaseSettings.Value.UserCollectionName);
        }
    }
}
