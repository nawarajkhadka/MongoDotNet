using MongoNet.Contracts.Interfaces;
using MongoNet.Contracts.Models;
using MongoNet.Infra.DataBase;

namespace MongoNet.Infra.Implementation
{
    public class WeatherForeCastRepository : BaseRepository<Weather>, IWeatherForeCastRepository
    {
        public WeatherForeCastRepository(IMongoDbContext context) : base(context, "Weather")
        {

        }       
    }
}
