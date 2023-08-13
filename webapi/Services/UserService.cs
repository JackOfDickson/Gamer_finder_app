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

        public async Task<List<User>> GetUsers() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetUser(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateUser(User user) =>
            await _userCollection.InsertOneAsync(user);

        public async Task UpdateUser(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task DeleteUser(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
