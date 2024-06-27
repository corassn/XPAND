using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Mongo
{
    public abstract class BaseDocument
    {
        [Required]
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
    }
}
