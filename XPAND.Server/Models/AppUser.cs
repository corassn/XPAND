using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using XPAND.Server.Mongo;

namespace XPAND.Server.Models
{
    [BsonCollection("Users")]
    public class AppUser : MongoUser
    {
        [Required]
        public string Name { get; set; } 

        public string TeamId { get; set; }

    }
}
