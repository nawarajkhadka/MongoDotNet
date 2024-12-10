using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoNet.Contracts.Models;

namespace MongoNet.Infra.DataBase
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase database { get; set; }
        private MongoClient client { get; set; }
        public MongoDbContext(IOptions<DatabaseSettings> databaseSettings)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            client = new MongoClient(databaseSettings.Value.ConnectionString);
            database = client.GetDatabase(databaseSettings.Value.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            return database.GetCollection<TEntity>(name);
        }

        public IMongoDatabase GetDataBase()
        {
            return database;
        }
    }
}
