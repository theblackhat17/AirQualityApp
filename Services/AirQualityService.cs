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
        private readonly string _apiKey;

        public AirQualityService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
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
                        QualityIndex = airQualityData["aqi"] != null ? (int)airQualityData["aqi"] : 0
                    });
                }
            }

            return airQualities;
        }
    }
}
