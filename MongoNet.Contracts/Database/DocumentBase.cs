using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoNet.Contracts.Interfaces;

namespace MongoNet.Contracts.Database
{
    public class DocumentBase : IDocument
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
