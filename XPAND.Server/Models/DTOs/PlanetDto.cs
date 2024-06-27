using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;

namespace XPAND.Server.Models
{
    public class PlanetDto
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public PlanetStatus Status { get; set; }

        public int Robots { get; set; }

        public PlanetDto()
        {
            Name = string.Empty;
            ImageUrl = string.Empty;
            Description = string.Empty;
        }
    }
}
