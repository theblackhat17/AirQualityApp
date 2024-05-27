using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AirQualityApp.Models;
using Newtonsoft.Json.Linq;

namespace AirQualityApp.Services
{
    public class CityService
    {
        private readonly HttpClient _httpClient;
        private readonly string _geoNamesUsername;

        public CityService(string geoNamesUsername)
        {
            _httpClient = new HttpClient();
            _geoNamesUsername = geoNamesUsername;
        }

        public async Task<List<City>> GetCitiesAsync(string country)
        {
            var response = await _httpClient.GetStringAsync($"http://api.geonames.org/searchJSON?formatted=true&q=city&maxRows=15&country={country}&username={_geoNamesUsername}");
            var citiesData = JObject.Parse(response)["geonames"];
            var cities = new List<City>();

            if (citiesData != null)
            {
                foreach (var cityData in citiesData)
                {
                    cities.Add(new City
                    {
                        Name = cityData["name"]?.ToString(),
                        Latitude = cityData["lat"] != null ? (double)cityData["lat"] : 0,
                        Longitude = cityData["lng"] != null ? (double)cityData["lng"] : 0
                    });
                }
            }

            return cities;
        }
    }
}
