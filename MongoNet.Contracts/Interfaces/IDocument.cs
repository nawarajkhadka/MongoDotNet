
using MongoDB.Bson;

namespace MongoNet.Contracts.Interfaces
{
    public interface IDocument
    {
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
