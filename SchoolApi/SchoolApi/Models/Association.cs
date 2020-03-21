using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SchoolApi.Models
{
    public class Association
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string AssociationName { get; set; }

        [BsonElement("Description")]
        [JsonProperty("Description")]
        public string AssociationDescription { get; set; }
    }
}
