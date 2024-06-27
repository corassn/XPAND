namespace XPAND.Server.Mongo.Configuration
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set; }
    }
}
