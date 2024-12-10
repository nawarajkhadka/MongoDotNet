using MongoNet.Contracts.Interfaces;
using MongoNet.Contracts.Interfaces.Services;
using MongoNet.Contracts.Models;

namespace MongoNet.Infra.Implementation.Services
{
    public class WeatherForeCastService : IWeatherForeCastService
    {
        private IWeatherForeCastRepository _weatherForeCastRepository;
        
        public WeatherForeCastService(IWeatherForeCastRepository weatherForeCastRepository)
        {
            _weatherForeCastRepository = weatherForeCastRepository;
        }
        public async Task AddWeatherAsync(Weather weather)
        {
            await _weatherForeCastRepository.Create(weather);
            
        }
        public async Task<IEnumerable<Weather>> GetAll()
        {
             return await _weatherForeCastRepository.Get();
        }

        public async Task<Weather> GetWeather(string id)
        {
            return await GetWeather(id);
        }
    }
}
