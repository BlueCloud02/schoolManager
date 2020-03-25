using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SchoolApi.Models
{
    public class Association
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("name")]
        public string AssociationName { get; set; }

        [BsonElement("Description")]
        [JsonProperty("description")]
        public string AssociationDescription { get; set; }
    }
}
