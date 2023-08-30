using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace webapi.Models
{
	public class UserCredentials
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        public UserCredentials(string id, string userId, string password)
        {
            Id = id;
            UserId = userId;
            Password = password;
        }
    }
}

