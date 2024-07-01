using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Captains")]
    public class Captain : BaseDocument
    {
    }
}
