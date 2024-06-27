using Amazon.Runtime.Internal;
using AutoMapper;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Mongo.Repository;

namespace XPAND.Server.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IMongoRepository<Planet> _planetRepostory;
        private readonly ILogger<PlanetService> _logger;
        private readonly IMapper _mapper;

        public PlanetService(IMongoRepository<Planet> planetRepostory, ILogger<PlanetService> logger, IMapper mapper)
        {
            _planetRepostory = planetRepostory;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<PlanetDto>> GetAllPlanets()
        {
            try
            {
                var planets = await _planetRepostory.GetAllAsync();

                return _mapper.Map<List<PlanetDto>>(planets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to fetch the planets.");
                throw new ServiceException("An error occured while trying to fetch the planets.", ex);
            }
        }

        public async Task<PlanetDto> GetPlanetById(string id)
        {
            try
            {
                var planet = await _planetRepostory.FindByIdAsync(id);

                if (planet == null)
                {
                    _logger.LogWarning($"Planet with ID {id} was not found.");
                    throw new ServiceException($"Planet with ID {id} was not found.");
                }

                    return _mapper.Map<PlanetDto>(planet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to get the planet with ID {id}.");
                throw new ServiceException($"An error occured while trying to get the planet with ID {id}.", ex);
            }
        }

        public async Task<PlanetDto> UpdatePlanet(UpdatePlanetDto request)
        {
            try
            {
                var planet = _planetRepostory.FindByIdAsync(request.PlanetId).Result;

                if (planet == null)
                {
                    _logger.LogWarning($"Planet with ID {request.PlanetId} was not found.");
                    throw new ServiceException($"Planet with ID {request.PlanetId} was not found.");
                }

                planet.Status = request.Status;
                planet.Description = request.Description;
                await _planetRepostory.ReplaceAsync(planet);

                return _mapper.Map<PlanetDto>(planet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to update the planet status with ID {request.PlanetId}.");
                throw new ServiceException("An error occured while trying to update the planet status.", ex);
            }
        }

        public async Task<PlanetDto> AddPlanet(PlanetDto planetDto)
        {
            try
            {
                var planet = _mapper.Map<Planet>(planetDto);
                var planetResponse = await _planetRepostory.InsertAsync(planet);

                return _mapper.Map<PlanetDto>(planetResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to insert a planet.");
                throw new ServiceException("An error occured while trying to insert a planet.", ex);
            }
        }

        public async Task DeletePlanetById(string id)
        {
            try
            {
                await _planetRepostory.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while trying to delete planet with ID {id}.");
                throw new ServiceException($"An error occured while trying to delete planet with ID {id}.", ex);
            }
        }
    }
}
