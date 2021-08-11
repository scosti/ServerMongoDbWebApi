using System.Collections.Generic;
using System.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WebApiServer.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("name")]
        public string StartOrderTime { get; set; }

        [BsonElement("password")]
        public PasswordDeriveBytes Password { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

    }
}
