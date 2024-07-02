using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Models.DTOs
{
    public class RobotDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
