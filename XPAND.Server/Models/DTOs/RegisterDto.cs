using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Models.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        public string TeamName { get; set; }

        public ICollection<string> RobotNames { get; set; } = new List<string>();
    }
}
