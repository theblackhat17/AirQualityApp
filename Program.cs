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
            string openWeatherMapApiKey = "YOUR_OPENWEATHERMAP_API_KEY"; // Remplace par ta clé API OpenWeatherMap

            var airQualityService = new AirQualityService(openWeatherMapApiKey);

            var airQualities = await airQualityService.GetAirQualityAsync(country);

            var sortedCities = airQualities.OrderBy(a => a.QualityIndex).Take(15);

            foreach (var city in sortedCities)
            {
                Console.WriteLine($"{city.City}: {city.QualityIndex}");
            }
        }
    }
}
