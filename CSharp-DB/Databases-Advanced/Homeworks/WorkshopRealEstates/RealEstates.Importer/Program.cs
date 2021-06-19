using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ImportProperties("Houses.imot.bg.json");
            //ImportProperties("Apartments.imot.bg.json");
        }

        private static void ImportProperties(string fileName)
        {

            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);

            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(fileName));

            foreach (var jsonProp in properties)
            {
                propertiesService.Add(jsonProp.Size, jsonProp.YardSize, jsonProp.Floor, jsonProp.TotalFloors, jsonProp.District, jsonProp.Year, jsonProp.Type, jsonProp.BuildingType, jsonProp.Price);

                System.Console.Write('.');
            }
        }
    }
}
