using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoNet.Infra.DataBase
{
    public interface IMongoDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
        IMongoDatabase GetDataBase();
    }
}
