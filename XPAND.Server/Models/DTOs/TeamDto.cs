using MongoDB.Bson.Serialization.Attributes;

namespace XPAND.Server.Models.DTOs
{
    public class TeamDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string CaptainId { get; set; }

        public ICollection<string> RobotIds { get; set; } = new List<string>();
    }
}
