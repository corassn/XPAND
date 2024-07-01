using Microsoft.AspNetCore.Mvc;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Services;
using XPAND.Server.Services.Implementation;

namespace XPAND.Server.Controllers
{
    [ApiController]
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        private readonly ILogger<TeamController> _logger;

        public TeamController(ITeamService teamService, ILogger<TeamController> logger)
        {
            _teamService = teamService;
            _logger = logger;
        }

        [HttpGet("{id}/captain")]
        public async Task<ActionResult<CaptainDto>> GetCaptainByTeamId(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _logger.LogWarning("Invalid team ID format.");
                    return BadRequest("Invalid team ID format.");
                }

                var captainResponse = await _teamService.GetCaptainByTeamId(id);

                return Ok(captainResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'GetCaptainByTeamId'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'GetCaptainByTeamId'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}/robots")]
        public async Task<ActionResult<List<RobotDto>>> GetRobotsByTeamId(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    _logger.LogWarning("Invalid team ID format.");
                    return BadRequest("Invalid team ID format.");
                }

                var robotsResponse = await _teamService.GetRobotsByTeamId(id);

                return Ok(robotsResponse);
            }
            catch (ServiceException ex)
            {
                _logger.LogError(ex, "A service exception occured while processing 'GetRobotsByTeamId'.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while processing 'GetRobotsByTeamId'.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
