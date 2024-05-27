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
            string openWeatherMapApiKey = "d2dbcf9ede6b18f216459d3c829d2b21"; // Remplace par ta clé API OpenWeatherMap

            var airQualityService = new AirQualityService(openWeatherMapApiKey);

            try
            {
                var airQualities = await airQualityService.GetAirQualityAsync(country);
                var sortedCities = airQualities.OrderBy(a => a.QualityIndex).Take(15);

                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"{city.City}: {city.QualityIndex}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erreur de requête HTTP: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur: {e.Message}");
            }
        }
    }
}
