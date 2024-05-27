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
        private readonly string _geoNamesUsername = "cvandewalle"; // Remplace par ton nom d'utilisateur GeoNames

        public CityService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<City>> GetCitiesAsync(string country)
        {
            var response = await _httpClient.GetStringAsync($"http://api.geonames.org/searchJSON?formatted=true&q=city&maxRows=15&country={country}&username={_geoNamesUsername}");
            var citiesData = JObject.Parse(response)["geonames"];
            var cities = new List<City>();

            foreach (var cityData in citiesData)
            {
                cities.Add(new City
                {
                    Name = cityData["name"].ToString(),
                    Latitude = (double)cityData["lat"],
                    Longitude = (double)cityData["lng"]
                });
            }

            return cities;
        }
    }
}
