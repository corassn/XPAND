using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Teams")]
    public class Team : BaseDocument
    {
        [BsonElement("captain")]
        public string Captain { get; set; }

        [BsonElement("robots")]
        public int Robots { get; set; }

        public Team()
        {
            Captain = string.Empty;
        }
    }
}
