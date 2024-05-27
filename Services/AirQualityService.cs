using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AirQualityApp.Models;
using Newtonsoft.Json.Linq;

namespace AirQualityApp.Services
{
    public class AirQualityService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "d2dbcf9ede6b18f216459d3c829d2b21"; // Remplace par ta clé API OpenWeatherMap

        public AirQualityService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<AirQuality>> GetAirQualityAsync(List<City> cities)
        {
            var airQualities = new List<AirQuality>();

            foreach (var city in cities)
            {
                var response = await _httpClient.GetStringAsync($"http://api.openweathermap.org/data/2.5/air_pollution?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}");
                var airQualityData = JObject.Parse(response)["list"]?[0]?["main"];
                if (airQualityData != null)
                {
                    airQualities.Add(new AirQuality
                    {
                        City = city.Name,
                        QualityIndex = (int)airQualityData["aqi"]
                    });
                }
            }

            return airQualities;
        }
    }
}
