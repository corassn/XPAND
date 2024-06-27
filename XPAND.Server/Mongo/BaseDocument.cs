using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Mongo
{
    public abstract class BaseDocument
    {
        [Required]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.String)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
    }
}
