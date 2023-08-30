using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using webapi.Models;

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
	}
}

