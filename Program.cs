using System;
using System.Linq;
using System.Threading.Tasks;
using AirQualityApp.Services;

namespace AirQualityApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: AirQualityApp <country>");
                return;
            }

            string country = args[0];

            var cityService = new CityService("YOUR_GEONAMES_USERNAME"); // Remplacez par votre nom d'utilisateur GeoNames
            var airQualityService = new AirQualityService();

            var cities = await cityService.GetCitiesAsync(country);
            var airQualities = await airQualityService.GetAirQualityAsync(cities);

            var sortedCities = airQualities.OrderBy(a => a.QualityIndex).Take(15);

            foreach (var city in sortedCities)
            {
                Console.WriteLine($"{city.City}: {city.QualityIndex}");
            }
        }
    }
}
