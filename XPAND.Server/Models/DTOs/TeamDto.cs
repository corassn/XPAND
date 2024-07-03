using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Models.DTOs
{
    public class TeamDto
    {
        [Required]
        public string Id { get; set; }

        public string Name { get; set; }

        [Required]
        public ObjectId UserId { get; set; }

        [Required]
        public string CaptainId { get; set; }

        [Required]
        public ICollection<string> RobotIds { get; set; } = new List<string>();
    }
}
