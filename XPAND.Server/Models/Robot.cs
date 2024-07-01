using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Robots")]
    public class Robot : BaseDocument
    {
    }
}
