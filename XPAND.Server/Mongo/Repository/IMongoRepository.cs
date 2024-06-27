namespace XPAND.Server.Mongo.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : BaseDocument
    {
        Task<List<TDocument>> GetAllAsync();

        Task<TDocument> FindByIdAsync(string id);

        Task<TDocument> InsertAsync(TDocument document);

        Task ReplaceAsync(TDocument document);

        Task DeleteByIdAsync(string id);
    }
}
