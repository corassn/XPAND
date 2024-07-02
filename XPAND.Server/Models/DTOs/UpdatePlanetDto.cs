using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;

namespace XPAND.Server.Models.DTOs
{
    public class UpdatePlanetDto
    {
        [Required]
        public string PlanetId { get; set; }

        [Required]
        public PlanetStatus Status { get; set; }

        public string? Description { get; set; }

        public string TeamId { get; set; }
    }
}
