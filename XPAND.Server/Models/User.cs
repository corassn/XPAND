using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace XPAND.Server.Models
{
    public class User : BaseDocument
    {
        [Required]
        [BsonElement("role")]
        public string Role { get; set; }
    }
}
