using XPAND.Server.Enums;

namespace XPAND.Server.Models
{
    public class Planet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string ImageUrl { get; set; }

        public PlanetStatus Status { get; set; }

        // should think about this: The planet has a number of robots that are exploring it
        public int Robots { get; set; }
    }
}
