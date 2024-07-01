using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;

namespace XPAND.Server.Models
{
    public class AddPlanetDto
    {

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public PlanetStatus Status { get; set; }

        public string TeamId { get; set; }
    }
}