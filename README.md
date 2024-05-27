
# Guide d'utilisation du projet AirQualityApp

## Introduction

Bienvenue dans le projet AirQualityApp ! Cette application console .NET permet de récupérer et d'afficher les 15 plus grandes villes d'un pays, triées par la qualité de l'air du jour. L'application utilise les API de GeoNames et OpenWeatherMap pour obtenir les données nécessaires.

## Prérequis

Avant de commencer, assurez-vous d'avoir les éléments suivants installés sur votre machine :

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/downloads)

## Installation

1. **Cloner le dépôt GitHub**

   Ouvrez le terminal et clonez le dépôt GitHub du projet :

   ```bash
   git clone https://github.com/TonNomUtilisateur/NomDuDepot.git
   cd NomDuDepot
   ```

2. **Configurer les clés API**

   Ouvrez le fichier `Program.cs` et remplacez les placeholders pour le nom d'utilisateur GeoNames et la clé API OpenWeatherMap avec vos propres clés. Par exemple :

   ```csharp
   string geoNamesUsername = "cvandewalle"; // Nom d'utilisateur GeoNames
   string openWeatherMapApiKey = "d2dbcf9ede6b18f216459d3c829d2b21"; // Clé API OpenWeatherMap
   ```
   Ici en toute logique vous pouvez garder mes clés API pour l'utilisation mais libre à vous d'utiliser les vôtres.

3. **Restaurer les packages NuGet**

   Dans le terminal, exécutez la commande suivante pour restaurer les packages NuGet nécessaires :

   ```bash
   dotnet restore
   ```

## Utilisation

Pour lancer l'application, exécutez la commande suivante dans le terminal :

```bash
dotnet run <nom_du_pays>
```

Remplacez `<nom_du_pays>` par le nom du pays dont vous souhaitez obtenir les informations. Par exemple :

```bash
dotnet run france
```
Voici nos villes disponibles : 
# Afrique
- Algeria
- Angola
- Benin
- Botswana
- Burkina Faso
- Burundi
- Cape Verde
- Central African Republic
- Chad
- Comoros
- Congo
- Djibouti
- Egypt
- Equatorial Guinea
- Eritrea
- Eswatini
- Ethiopia
- Gabon
- Gambia
- Ghana
- Guinea
- Guinea-Bissau
- Ivory Coast
- Kenya
- Lesotho
- Liberia
- Libya
- Madagascar
- Malawi
- Mali
- Mauritania
- Mauritius
- Morocco
- Mozambique
- Namibia
- Niger
- Nigeria
- Rwanda
- Sao Tome and Principe
- Senegal
- Seychelles
- Sierra Leone
- Somalia
- South Africa
- South Sudan
- Sudan
- Tanzania
- Togo
- Tunisia
- Uganda
- Zambia
- Zimbabwe

# Amérique du Nord
- Bahamas
- Barbados
- Belize
- Canada
- Costa Rica
- Cuba
- Dominica
- Dominican Republic
- El Salvador
- Grenada
- Guatemala
- Haiti
- Honduras
- Jamaica
- Mexico
- Nicaragua
- Panama
- Saint Kitts and Nevis
- Saint Lucia
- Saint Vincent and the Grenadines
- Trinidad and Tobago
- United States

# Amérique du Sud
- Argentina
- Bolivia
- Brazil
- Chile
- Colombia
- Ecuador
- Guyana
- Paraguay
- Peru
- Suriname
- Uruguay
- Venezuela

# Asie
- Afghanistan
- Armenia
- Azerbaijan
- Bahrain
- Bangladesh
- Bhutan
- Brunei
- Cambodia
- China
- Cyprus
- Georgia
- India
- Indonesia
- Iran
- Iraq
- Israel
- Japan
- Jordan
- Kazakhstan
- Kuwait
- Kyrgyzstan
- Laos
- Lebanon
- Malaysia
- Maldives
- Mongolia
- Myanmar
- Nepal
- North Korea
- Oman
- Pakistan
- Palestine
- Philippines
- Qatar
- Saudi Arabia
- Singapore
- South Korea
- Sri Lanka
- Syria
- Taiwan
- Tajikistan
- Thailand
- Timor-Leste
- Turkmenistan
- United Arab Emirates
- Uzbekistan
- Vietnam
- Yemen

# Europe
- Albania
- Andorra
- Austria
- Belarus
- Belgium
- Bosnia and Herzegovina
- Bulgaria
- Croatia
- Cyprus
- Czech Republic
- Denmark
- Estonia
- Finland
- France
- Germany
- Greece
- Hungary
- Iceland
- Ireland
- Italy
- Kosovo
- Latvia
- Liechtenstein
- Lithuania
- Luxembourg
- Malta
- Moldova
- Monaco
- Montenegro
- Netherlands
- North Macedonia
- Norway
- Poland
- Portugal
- Romania
- Russia
- San Marino
- Serbia
- Slovakia
- Slovenia
- Spain
- Sweden
- Switzerland
- Ukraine
- United Kingdom
- Vatican City

# Océanie
- Australia
- Fiji
- Kiribati
- Marshall Islands
- Micronesia
- Nauru
- New Zealand
- Palau
- Papua New Guinea
- Samoa
- Solomon Islands
- Tonga
- Tuvalu
- Vanuatu


## Exemple de sortie

Après avoir exécuté la commande, vous verrez une sortie similaire à celle-ci :

```
Bienvenue en France, ici nos 15 plus grandes villes sont :
- Paris avec 2138551 habitants
- Marseille avec 870731 habitants
- Lyon avec 522969 habitants
- Toulouse avec 493465 habitants
- Strasbourg avec 274845 habitants
- Nantes avec 318808 habitants
- Bordeaux avec 260958 habitants
- Nice avec 342669 habitants
- Lille avec 234475 habitants
- Montpellier avec 248252 habitants
- Rennes avec 220488 habitants
- Reims avec 182592 habitants
- Le Havre avec 172807 habitants
- Saint-Étienne avec 172023 habitants
- Toulon avec 171953 habitants

Classement des villes par qualité de l'air (date du jour : 27/05/2024) :
1. Paris: 1 🏆
2. Lyon: 1 🏆
3. Marseille: 2
4. Toulouse: 3
5. Nice: 3
...
```

Les villes sont triées par qualité de l'air avec des numéros pour le classement, et un trophée 🏆 est affiché à côté des villes ayant la meilleure qualité de l'air.

## Contributions

Les contributions sont les bienvenues ! Si vous avez des idées d'amélioration ou des correctifs, n'hésitez pas à ouvrir une pull request sur le dépôt GitHub.

## Support

Pour toute question ou problème, veuillez ouvrir une issue sur GitHub ou me contacter sur mon adresse mail efficom.
----
Merci d'utiliser AirQualityApp ! Nous espérons que cette application vous sera utile.
