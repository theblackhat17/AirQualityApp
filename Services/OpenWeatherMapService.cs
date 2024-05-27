using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AirQualityApp.Models;
using Newtonsoft.Json.Linq;

namespace AirQualityApp.Services
{
    public class OpenWeatherMapService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherMapService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<List<City>> GetCitiesAsync(string country)
        {
            // Utiliser une API ou une méthode appropriée pour obtenir les villes d'un pays
            // Ici, nous supposons que OpenWeatherMap peut nous donner les villes par nom de pays
            var response = await _httpClient.GetStringAsync($"http://api.openweathermap.org/data/2.5/find?q={country}&type=like&sort=population&cnt=15&appid={_apiKey}");
            var citiesData = JObject.Parse(response)["list"];
            var cities = new List<City>();

            foreach (var cityData in citiesData)
            {
                cities.Add(new City
                {
                    Name = cityData["name"].ToString(),
                    Latitude = (double)cityData["coord"]["lat"],
                    Longitude = (double)cityData["coord"]["lon"]
                });
            }

            return cities;
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
