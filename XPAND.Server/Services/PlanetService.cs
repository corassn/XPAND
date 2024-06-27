using XPAND.Server.Models;
using XPAND.Server.Mongo.Repository;

namespace XPAND.Server.Services
{
    public class PlanetService
    {
        private readonly IMongoRepository<Planet> _planetRepostory;

        public PlanetService(IMongoRepository<Planet> planetRepostory)
        {
            _planetRepostory = planetRepostory;
        }

        public async Task DeletePlanetById(string id)
        {
            await _planetRepostory.DeleteAsync(id);
        }
    }
}
