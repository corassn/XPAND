using Microsoft.AspNetCore.Mvc;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
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
                _logger.LogError(ex, "A service exception occured while processing GetAllPlanets.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing GetPlanets.");
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
                _logger.LogError(ex, "A service exception occured while processing GetPlanedById.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing GetPlanedById.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
