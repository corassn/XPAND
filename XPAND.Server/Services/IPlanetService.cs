using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;

namespace XPAND.Server.Services
{
    public interface IPlanetService
    {
        Task<List<PlanetDto>> GetAllPlanets();

        Task<PlanetDto> GetPlanetById(string id);

        Task<PlanetDto> UpdatePlanet(string id, UpdatePlanetDto request);

        Task<PlanetDto> AddPlanet(AddPlanetDto request);

        Task DeletePlanetById(string id);
    }
}
