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

        public async Task<List<AirQuality>> GetAirQualityAsync(string country)
        {
            var cities = await GetCitiesAsync(country);
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

        private async Task<List<City>> GetCitiesAsync(string country)
        {
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
    }
}
