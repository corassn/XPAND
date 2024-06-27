using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Enums;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Planets")]
    [BsonDiscriminator("Planet")]
    public class Planet : BaseDocument
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public PlanetStatus Status { get; set; }

        // should think about this: The planet has a number of robots that are exploring it
        public int Robots { get; set; }

        public Planet()
        {
            Name = string.Empty;
            ImageUrl = string.Empty;
            Description = string.Empty;
        }
    }
}
