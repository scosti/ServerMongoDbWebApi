using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiServer.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("Name")]
        public string StartOrderTime { get; set; }

        [BsonElement("details")]
        public string[] Details { get; set; }
    }
}
