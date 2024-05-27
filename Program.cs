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
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AirQualityApp <country> <GeoNamesUsername>");
                return;
            }

            string country = args[0];
            string geoNamesUsername = args[1];
            string openWeatherMapApiKey = "YOUR_OPENWEATHERMAP_API_KEY"; // Remplace par ta clé API OpenWeatherMap

            var cityService = new CityService(geoNamesUsername);
            var airQualityService = new AirQualityService(openWeatherMapApiKey);

            try
            {
                var cities = await cityService.GetCitiesAsync(country);
                var airQualities = await airQualityService.GetAirQualityAsync(cities);
                var sortedCities = airQualities.OrderBy(a => a.QualityIndex).Take(15);

                Console.WriteLine($"Les 15 plus grandes villes de {country} classées par la qualité de l'air:");
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
