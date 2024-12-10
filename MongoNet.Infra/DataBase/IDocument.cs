using MongoDB.Bson;

namespace MongoNet.Infra.DataBase
{
    public interface IDocument
    {
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
