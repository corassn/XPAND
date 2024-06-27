using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Planets")]
    public class Planet : BaseDocument
    {
        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("imageUrl")]
        public string? ImageUrl { get; set; }

        [Required]
        [BsonElement("status")]
        public PlanetStatus Status { get; set; }

        [BsonElement("robots")]
        public int Robots { get; set; }

        public Planet()
        {
            Name = string.Empty;
            ImageUrl = string.Empty;
            Description = string.Empty;
        }
    }
}
