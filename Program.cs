﻿using System;
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
            string geoNamesUsername = "cvandewalle"; // Nom d'utilisateur GeoNames
            string openWeatherMapApiKey = "d2dbcf9ede6b18f216459d3c829d2b21"; // Clé API OpenWeatherMap

            var cityService = new CityService(geoNamesUsername);
            var airQualityService = new AirQualityService(openWeatherMapApiKey);

            try
            {
                var cities = await cityService.GetCitiesAsync(country);
                if (cities.Count == 0)
                {
                    Console.WriteLine($"Aucune ville trouvée pour le pays '{country}'");
                    return;
                }
                
                var airQualities = await airQualityService.GetAirQualityAsync(cities);

                Console.WriteLine($"Bienvenue en {country}, ici nos 15 plus grandes villes sont :");
                foreach (var city in cities)
                {
                    Console.WriteLine($"- {city.Name} avec {city.Population} habitants");
                }

                var sortedCities = airQualities.OrderBy(a => a.QualityIndex).ToList();
                int rank = 1;
                int? bestQualityIndex = sortedCities.FirstOrDefault()?.QualityIndex;

                Console.WriteLine($"\nClassement des villes par qualité de l'air (date du jour : {DateTime.Now:dd/MM/yyyy}) :");
                foreach (var city in sortedCities)
                {
                    string trophy = city.QualityIndex == bestQualityIndex ? "🏆" : "";
                    Console.WriteLine($"{rank}. {city.City}: {city.QualityIndex} {trophy}");
                    rank++;
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
