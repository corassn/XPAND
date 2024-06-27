using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;

namespace XPAND.Server.Services
{
    public interface IPlanetService
    {
        Task<List<PlanetDto>> GetAllPlanets();

        Task<PlanetDto> GetPlanetById(string id);

        Task<PlanetDto> UpdatePlanet(UpdatePlanetDto request);

        Task<PlanetDto> AddPlanet(PlanetDto planetDto);

        Task DeletePlanetById(string id);
    }
}
