﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace webapi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("username")]
        public string Username {  get ; set; }
        [BsonElement("email")]
        public string Email { get; set; }


        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }
    }
}
