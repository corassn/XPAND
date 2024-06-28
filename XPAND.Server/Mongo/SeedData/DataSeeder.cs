using System.Diagnostics;
using XPAND.Server.Models;
using XPAND.Server.Mongo.Repository;
using XPAND.Server.Mongo.SeedData.PathConfig;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace XPAND.Server.Mongo.SeedData
{
    public class DataSeeder : IDataSeeder
    {
        private readonly IMongoRepository<Planet> _planetRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IDataSeedSettings _seedSettings;
        private readonly ILogger<IDataSeeder> _logger;

        public DataSeeder(IMongoRepository<Planet> planetRepository, IDataSeedSettings seedSettings, IWebHostEnvironment env, ILogger<IDataSeeder> logger)
        {
            _planetRepository = planetRepository;
            _seedSettings = seedSettings;
            _env = env;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            try
            {
                var existingPlanets = await _planetRepository.GetAllAsync();

                if (existingPlanets.Any())
                {
                    _logger.LogInformation("Products already exist in the database. Seeding skipped.");
                    return;
                }

                var filePath = Path.Combine(_env.ContentRootPath, _seedSettings.PlanetsSeedPath);
                var jsonData = await File.ReadAllTextAsync(filePath);
                var planets = JsonConvert.DeserializeObject<List<Planet>>(jsonData);

                foreach (var planet in planets)
                {
                    await _planetRepository.InsertAsync(planet);
                }

                _logger.LogInformation("Data seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during data seeding.");
            }
        }
    }
}
