using Microsoft.AspNetCore.Mvc;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Services;

namespace XPAND.Server.Controllers
{
    [ApiController]
    [Route("api/planets")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;
        private readonly ILogger<PlanetController> _logger;

        public PlanetController(IPlanetService planetService, ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanetDto>>> GetPlanets()
        {
            try
            {
                var planetsResponse = await _planetService.GetAllPlanets();
                return Ok(planetsResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'GetAllPlanets'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'GetPlanets'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetDto>> GetPlanetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _logger.LogWarning("Invalid planet ID format.");
                    return BadRequest("Invalid planet ID format.");
                }

                var planetResponse = await _planetService.GetPlanetById(id);

                return Ok(planetResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'GetPlanetById'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'GetPlanetById'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<PlanetDto>> UpdatePlanet([FromBody] UpdatePlanetDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.PlanetId))
                {
                    _logger.LogWarning("Invalid planet ID format.");
                    return BadRequest("Invalid planet ID format.");
                }

                var planetResponse = await _planetService.UpdatePlanet(request);

                return Ok(planetResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'UpdatePlanet'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'UpdatePlanet'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PlanetDto>> AddPlanet([FromBody] AddPlanetDto request)
        {
            try
            {
                var planetResponse = await _planetService.AddPlanet(request);

                return Ok(planetResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'AddPlanet'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'AddPlanet'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanetDto>> DeletePlanet(string id)
        {
            try
            {
                await _planetService.DeletePlanetById(id);

                return Ok();
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'DeletePlanet'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'DeletePlanet'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
