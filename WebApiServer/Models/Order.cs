using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiServer.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("startTime")]
        public string StartOrderTime { get; set; }

        [BsonElement("endTime")]
        public string EndOrdernTime { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public List<ObjectId> ProductId { get; set; }
    }
}
