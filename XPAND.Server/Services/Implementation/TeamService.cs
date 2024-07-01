using AutoMapper;
using System.Numerics;
using XPAND.Server.Exceptions;
using XPAND.Server.Models;
using XPAND.Server.Models.DTOs;
using XPAND.Server.Mongo.Repository;

namespace XPAND.Server.Services.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly IMongoRepository<Team> _teamRepository;
        private readonly IMongoRepository<Captain> _captainRepository;
        private readonly IMongoRepository<Robot> _robotRepository;
        private readonly ILogger<PlanetService> _logger;
        private readonly IMapper _mapper;

        public TeamService(
            IMongoRepository<Team> teamRepository,
            IMongoRepository<Captain> captainRepository,
            IMongoRepository<Robot> robotRepository,
            ILogger<PlanetService> logger,
            IMapper mapper
            )
        {
            _teamRepository = teamRepository;
            _captainRepository = captainRepository;
            _robotRepository = robotRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CaptainDto> GetCaptainByTeamId(string teamId)
        {
            try
            {
                var team = await _teamRepository.FindByIdAsync(teamId);

                if (team == null)
                {
                    _logger.LogWarning($"Team with ID {teamId} was not found.");
                    throw new ServiceException($"Team with ID {teamId} was not found.");
                }

                var captainId = team.CaptainId;
                var captain = await _captainRepository.FindByIdAsync(captainId);

                return _mapper.Map<CaptainDto>(captain);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to fetch the captain by team ID.");
                throw new ServiceException("An error occured while trying to fetch the captain by team ID.", ex);
            }
        }

        public async Task<List<RobotDto>> GetRobotsByTeamId(string teamId)
        {
            try
            {
                var team = await _teamRepository.FindByIdAsync(teamId);

                if (team == null)
                {
                    _logger.LogWarning($"Team with ID {teamId} was not found.");
                    throw new ServiceException($"Team with ID {teamId} was not found.");
                }

                var robotIds = team.RobotIds;
                var robots = new List<Robot>();

                foreach (var robotId in robotIds)
                {
                    var robot = await _robotRepository.FindByIdAsync(robotId);
                    robots.Add(robot);
                }

                return _mapper.Map<List<RobotDto>>(robots);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to fetch the robots by team ID.");
                throw new ServiceException("An error occured while trying to fetch the robots by team ID.", ex);
            }
        }
    }
}
