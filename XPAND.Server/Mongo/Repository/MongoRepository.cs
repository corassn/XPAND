﻿using MongoDB.Bson;
using MongoDB.Driver;
using XPAND.Server.Mongo.Configuration;

namespace XPAND.Server.Mongo.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : BaseDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(MongoRepository<TDocument>.GetCollectionName(typeof(TDocument)));
        }

        public Task DeleteByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, id);
            return _collection.DeleteOneAsync(id);
        }

        public async Task<TDocument> FindByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<List<TDocument>> GetAllAsync()
        {
            var filter = Builders<TDocument>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<TDocument> InsertAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public Task ReplaceAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(d => d.Id, document.Id);
            return _collection.ReplaceOneAsync(filter, document);
        }

        private static string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute), true)
                .FirstOrDefault()).CollectionName;
        }
    }
}
