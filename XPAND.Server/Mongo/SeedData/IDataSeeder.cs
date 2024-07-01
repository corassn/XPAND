namespace XPAND.Server.Mongo.SeedData
{
    public interface IDataSeeder
    {
        Task SeedPlanetsAsync();

        Task SeedTeamsAsync();
    }
}
