using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dimatica.Application.Model
{
    public class Duty
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
