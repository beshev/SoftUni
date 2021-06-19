using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Models;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.OutputEncoding = Encoding.Unicode;
           Console.InputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an potion");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive destricts");
                Console.WriteLine("3. Average price per square meter");
                Console.WriteLine("4. Add tag");
                Console.WriteLine("5. Bulk tag to properties");
                Console.WriteLine("6. Property full info");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(),out int option);

                if (parsed && option >= 0 && option <= 6)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistrict(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                        case 4:
                            AddTag(db);
                            break;
                        case 5:
                            BulkTagToProperties(db);
                            break;
                        case 6:
                            GetPropertyFullInfo(db);
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void GetPropertyFullInfo(ApplicationDbContext db)
        {
            IPropertiesService propertiesService = new PropertiesService(db);
            Console.WriteLine("Select count of propeties");
            int count = int.Parse(Console.ReadLine());
            var properties = propertiesService.GetFullData(count);

            var serizlizer = new XmlSerializer(typeof(PropertyInfoFullData[]),new XmlRootAttribute("Properties"));
            using var writer = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            serizlizer.Serialize(writer, properties, namespaces);

            Console.WriteLine(writer.GetStringBuilder().ToString().TrimEnd());
        }

        private static void BulkTagToProperties(ApplicationDbContext db)
        {
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);
            Console.WriteLine("Bulk operation started!");
            tagService.BulkTagToProperties();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext db)
        {
            Console.WriteLine("Tag name:");
            string tagName = Console.ReadLine();
            Console.WriteLine("Importance (optional)");
            bool isParsed = int.TryParse(Console.ReadLine(),out int tagImportance);
            int? importance = isParsed ? tagImportance : null;
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);

            tagService.Add(tagName, importance);

        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext db)
        {
            IPropertiesService propertiesService = new PropertiesService(db);

            Console.WriteLine($"Average price per square meter in Sofia: {propertiesService.AveragePricePerSquareMeter():f2}€/m²");
        }

        private static void MostExpensiveDistrict(ApplicationDbContext dbContext)
        {
            IDistrictsService districtsService = new DistrictsService(dbContext);

            Console.Write($"Select districts count: ");
            int count = int.Parse(Console.ReadLine());

            var districts = districtsService.GetMostExpensiveDistricts(count);

            foreach (var distric in districts)
            {
                Console.WriteLine($"DistrictName: {distric.Name} => AveragePrice {distric.AveragePricePerSquareMeter:f2}€/m² => PropertiesCount ({distric.PropertiesCount})");
            }
        }

        private static void PropertySearch(ApplicationDbContext dbContext)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService propertiesService = new PropertiesService(dbContext);

            var properties = propertiesService.Search(minPrice,maxPrice,minSize,maxSize);

            foreach (var prop in properties)
            {
                Console.WriteLine($"{prop.DistrictName}; {prop.BuildingType}; " +
                    $"{prop.PropertyType} => {prop.Price:f2}€ => {prop.Size}m²");
            }
        }
    }
}
