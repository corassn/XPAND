namespace XPAND.Server.Mongo.Configuration
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}
