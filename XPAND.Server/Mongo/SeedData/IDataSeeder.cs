namespace XPAND.Server.Mongo.SeedData
{
    public interface IDataSeeder
    {
        Task SeedUsersAsync();

        Task SeedPlanetsAsync();

        Task SeedTeamsAsync();
    }
}
