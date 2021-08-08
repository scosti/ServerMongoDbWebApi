using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstWebApp.Models
{
    public class Note
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("importance")]
        public string Importance { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("isActivity")]
        public bool isActivity { get; set; }

        [BsonElement("isCompleted")]
        public bool isCompleted { get; set; }
    }
}