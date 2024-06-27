using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;

namespace XPAND.Server.Models.DTOs
{
    public class UpdatePlanetDto
    {
        [Required]
        public string PlanetId { get; set; }

        public PlanetStatus Status { get; set; }

        public string? Description { get; set; }
    }
}
