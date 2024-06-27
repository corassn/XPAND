using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Teams")]
    [BsonDiscriminator("Team")]
    public class Team : BaseDocument
    {
         public string Captain { get; set; } //should I make classes for Captain and robots also??

        public int RobotsNumber { get; set; }

        public Team()
        {
            Captain = string.Empty;
        }
    }
}
