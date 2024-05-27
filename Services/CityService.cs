using System.Collections.Generic;
using System.Threading.Tasks;
using AirQualityApp.Models;
using NGeo.GeoNames;
using NGeo;

namespace AirQualityApp.Services
{
    public class CityService
    {
        private readonly GeoNamesClient _geoNamesClient;

        public CityService(string geoNamesUsername)
        {
            _geoNamesClient = new GeoNamesClient(new GeoNamesOptions { UserName = geoNamesUsername });
        }

        public async Task<List<City>> GetCitiesAsync(string country)
        {
            var cities = new List<City>();
            var result = await _geoNamesClient.SearchAsync(new SearchOptions
            {
                Q = "city",
                MaxRows = 15,
                Country = country
            });

            foreach (var geoName in result.GeoNames)
            {
                cities.Add(new City
                {
                    Name = geoName.Name,
                    Latitude = geoName.Latitude,
                    Longitude = geoName.Longitude
                });
            }

            return cities;
        }
    }
}
