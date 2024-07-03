using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Models.DTOs
{
    public class UserDto
    {
        [Required]
        public ObjectId Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string TeamId { get; set; }

        public string Token { get; set; }
    }
}
