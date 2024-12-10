using MongoNet.Contracts.Models;

namespace MongoNet.Contracts.Interfaces.Services
{
    public interface IWeatherForeCastService
    {
        public  Task AddWeatherAsync(Weather weather);
        public Task<Weather> GetWeather(string id);
        public Task<IEnumerable<Weather>> GetAll();
    }
}
