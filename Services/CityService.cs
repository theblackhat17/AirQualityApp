using System.Collections.Generic;
using System.Linq;
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
            string countryCode = CountryCodeService.GetCountryCode(country);
            if (countryCode == null)
            {
                Console.WriteLine($"Code de pays introuvable pour '{country}'");
                return new List<City>();
            }

            var response = await _httpClient.GetStringAsync($"http://api.geonames.org/searchJSON?formatted=true&country={countryCode}&featureClass=P&featureCode=PPLA&featureCode=PPLA2&featureCode=PPLA3&featureCode=PPLA4&featureCode=PPLC&maxRows=1000&username={_geoNamesUsername}");
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
                        Longitude = cityData["lng"] != null ? (double)cityData["lng"] : 0,
                        Population = cityData["population"] != null ? (int)cityData["population"] : 0
                    });
                }
            }

            return cities.OrderByDescending(c => c.Population).Take(15).ToList();
        }
    }
}
