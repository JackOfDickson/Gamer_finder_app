using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using webapi.Models;
using webapi.Models.AppSettings;

namespace webapi.Services
{
	public class UserCredentialsService
	{
        private readonly IMongoCollection<UserCredentials> _userCredentialsCollection;

        public UserCredentialsService(IOptions<GamerFinderDatabaseSettings> databaseSettings)
		{
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _userCredentialsCollection = mongoDatabase.GetCollection<UserCredentials>(databaseSettings.Value.UserCredentialsCollectionName);
        }

        public async Task<List<UserCredentials>> GetUsersCredentials() =>
            await _userCredentialsCollection.Find(_ => true).ToListAsync();

        public async Task<UserCredentials?> GetUserCredentials(string id) =>
            await _userCredentialsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateUserCredentials(UserCredentials UserCredentials) =>
            await _userCredentialsCollection.InsertOneAsync(UserCredentials);

        public async Task UpdateUserCredentials(string id, UserCredentials updatedCredentialsUser) =>
            await _userCredentialsCollection.ReplaceOneAsync(x => x.Id == id, updatedCredentialsUser);

        public async Task DeleteUserCredentials(string id) =>
            await _userCredentialsCollection.DeleteOneAsync(x => x.Id == id);
    }
}

