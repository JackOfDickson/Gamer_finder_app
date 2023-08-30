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

        public UserCredentials(string id, string user_id, string password)
        {
            Id = id;
            UserId = user_id;
            Password = password;
        }
    }
}

