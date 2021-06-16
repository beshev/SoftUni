using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Export;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        // PRoblem - 11
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new ExportCarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartCars.Sum(cp => cp.Part.Price):f2}",
                    priceWithDiscount =
                    $"{s.Car.PartCars.Sum(cp => cp.Part.Price) * ((100 - s.Discount) / 100):f2}"
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales,Formatting.Indented);
        }

        // Problem - 10
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var setting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()

            };

            return JsonConvert.SerializeObject(customers, setting);
        }

        // Problem - 9
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new ExportCarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                    .Select(cp => new ExportPartDto
                    {
                        Name = cp.Part.Name,
                        Price = $"{cp.Part.Price:F2}"
                    })
                    .ToList()
                })
                .ToList();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        // Problem - 8
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        // Problem - 7
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);

            return JsonConvert.SerializeObject(carsToyota, Formatting.Indented);
        }

        // Problem - 6
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .Select(x => new
                {
                    x.Name,
                    x.BirthDate,
                    x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver);

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy"
            };

            return JsonConvert.SerializeObject(customers, settings);
        }

        // Problem - 5
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        // Problem - 4 
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        // Problem - 3
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<CarsInputModel[]>(inputJson);

            foreach (var carDto in carsDtos)
            {
                var currentCar = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        CarId = currentCar.Id,
                        PartId = partId
                    };

                    currentCar.PartCars.Add(partCar);
                }

                context.Cars.Add(currentCar);
            }

            context.SaveChanges();

            return $"Successfully imported {carsDtos.Count()}.";
        }

        // Problem - 2
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        // Problem - 1
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

    }
}