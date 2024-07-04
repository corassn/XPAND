using Microsoft.AspNetCore.Identity;
using XPAND.Server.Models;
using XPAND.Server.Models.DataSeed;
using XPAND.Server.Mongo.Repository;
using JsonConvert = Newtonsoft.Json.JsonConvert;
using MongoDB.Bson;

namespace XPAND.Server.Mongo.SeedData
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IMongoRepository<Planet> _planetRepository;
        private readonly IMongoRepository<Team> _teamRepository;
        private readonly IMongoRepository<Captain> _captainRepository;
        private readonly IMongoRepository<Robot> _robotRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IDataSeedSettings _seedSettings;
        private readonly ILogger<IDataSeeder> _logger;

        public DataSeeder(
            IMongoRepository<Planet> planetRepository,
            IDataSeedSettings seedSettings,
            IWebHostEnvironment env,
            ILogger<IDataSeeder> logger,
            IMongoRepository<Robot> robotRepository,
            IMongoRepository<Captain> captainRepository,
            IMongoRepository<Team> teamRepository,
            UserManager<AppUser> userManager
            )
        {
            _planetRepository = planetRepository;
            _robotRepository = robotRepository;
            _captainRepository = captainRepository;
            _teamRepository = teamRepository;
            _seedSettings = seedSettings;
            _env = env;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task SeedPlanetsAsync()
        {
            try
            {
                var existingPlanets = await _planetRepository.GetAllAsync();

                if (existingPlanets.Any())
                {
                    _logger.LogInformation("Planets already exist in the database. Seeding skipped.");
                    return;
                }

                var filePath = Path.Combine(_env.ContentRootPath, _seedSettings.PlanetsSeedPath);
                var jsonData = await File.ReadAllTextAsync(filePath);
                var planets = JsonConvert.DeserializeObject<List<Planet>>(jsonData);

                foreach (var planet in planets)
                {
                    await _planetRepository.InsertAsync(planet);
                }

                _logger.LogInformation("[Planets] Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Planets] An error occurred during data seeding.");
            }
        }

        public async Task SeedTeamsAsync()
        {
            try
            {
                var existingCaptains = await _captainRepository.GetAllAsync();
                var existingRobots = await _robotRepository.GetAllAsync();

                if (existingCaptains.Any() || existingCaptains.Any())
                {
                    _logger.LogInformation("Captains/Robots already exist in the database. Seeding skipped.");
                    return;
                }

                var captainsFilePath = Path.Combine(_env.ContentRootPath, _seedSettings.CaptainsSeedPath);
                var captainsJsonData = await File.ReadAllTextAsync(captainsFilePath);
                var captains = JsonConvert.DeserializeObject<List<Captain>>(captainsJsonData);
                var captainIds = new List<string>();

                foreach (var captain in captains)
                {
                    var newCaptain = await _captainRepository.InsertAsync(captain);
                    captainIds.Add(newCaptain.Id);
                }

                _logger.LogInformation("[Captains] Data seeding completed successfully.");

                var robotsFilePath = Path.Combine(_env.ContentRootPath, _seedSettings.RobotsSeedPath);
                var robotsJsonData = await File.ReadAllTextAsync(robotsFilePath);
                var robots = JsonConvert.DeserializeObject<List<Robot>>(robotsJsonData);
                var robotIds = new List<string>();

                foreach (var robot in robots)
                {
                    var newRobot = await _robotRepository.InsertAsync(robot);
                    robotIds.Add(newRobot.Id);
                }

                _logger.LogInformation("[Robots] Data seeding completed successfully.");

                var teams = new List<Team>()
                {
                    new() { Name = "Space Ninjas", CaptainId = captainIds[0], RobotIds = { robotIds[0], robotIds[1], robotIds[2] } },
                    new() { Name = "Cosmic Beatles", CaptainId = captainIds[1], RobotIds = { robotIds[3], robotIds[4], robotIds[5] } },
                    new() { Name = "Pink Nebula", CaptainId = captainIds[2], RobotIds = { robotIds[6], robotIds[7], robotIds[8] } }
                };

                foreach (var team in teams)
                {
                    await _teamRepository.InsertAsync(team);
                }

                _logger.LogInformation("[Teams] Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Teams] An error occurred during data seeding.");
            }
        }

        public async Task SeedUsersAsync()
        {
            try
            {
                if (_userManager.Users.Any())
                {
                    _logger.LogInformation("Users already exist in the database. Seeding skipped.");
                    return;
                }

                var filePath = Path.Combine(_env.ContentRootPath, _seedSettings.UsersSeedPath);
                var jsonData = await File.ReadAllTextAsync(filePath);
                var users = JsonConvert.DeserializeObject<List<AppUser>>(jsonData);
                var teams = await _teamRepository.GetAllAsync();

                for (int i = 0; i < users.Count; i++)
                {
                    var appUser = new AppUser
                    {
                        Name = users[i].Name,
                        UserName = users[i].UserName,
                        Email = users[i].Email,
                        TeamId = teams[i].Id
                    };

                    await _userManager.CreateAsync(appUser, "User@42");
                }

                await UpdateTeamUserIds();

                _logger.LogInformation("[Users] Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[Users] An error occurred during data seeding.");
            }
        }

        private async Task UpdateTeamUserIds()
        {
            var users = _userManager.Users;
            var teams = await _teamRepository.GetAllAsync();

            foreach (var team in teams)
            {
                var matchingUser = users.FirstOrDefault(u => u.TeamId == team.Id);

                if (matchingUser != null)
                {
                    team.UserId = matchingUser.Id;
                    await _teamRepository.ReplaceAsync(team);
                }
            }
        }
    }
}
