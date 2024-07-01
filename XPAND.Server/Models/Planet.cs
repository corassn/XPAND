using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Planets")]
    public class Planet : BaseDocument
    {
        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [Required]
        [BsonElement("status")]
        public PlanetStatus Status { get; set; }

        [BsonElement("teamId")]
        public string TeamId { get; set; } 
    }
}
