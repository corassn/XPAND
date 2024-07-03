using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Teams")]
    public class Team : BaseDocument
    {
        [BsonElement("userId")]
        public ObjectId UserId { get; set; }

        [BsonElement("captainId")]
        public string CaptainId { get; set; }

        [BsonElement("robotIds")]
        public ICollection<string> RobotIds { get; set; } = new List<string>();
    }
}
