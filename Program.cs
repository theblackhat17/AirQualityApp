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
            string geoNamesUsername = "cvandewalle"; // Remplace par ton nom d'utilisateur GeoNames
            string openWeatherMapApiKey = "d2dbcf9ede6b18f216459d3c829d2b21"; // Remplace par ta clé API OpenWeatherMap

            var cityService = new CityService(geoNamesUsername);
            var airQualityService = new AirQualityService(openWeatherMapApiKey);

            try
            {
                var cities = await cityService.GetCitiesAsync(country);
                var airQualities = await airQualityService.GetAirQualityAsync(cities);
                var sortedCities = airQualities.OrderBy(a => a.QualityIndex).Take(15).ToList();

                Console.WriteLine($"En {country}, voici la liste des 15 plus grandes villes classées par qualité de l'air:");
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
