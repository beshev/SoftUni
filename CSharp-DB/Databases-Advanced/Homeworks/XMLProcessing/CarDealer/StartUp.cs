using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Xml.Serialization;
using CarDealer.Dtos.Export;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        // Problem - 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleWithDicountExportDto
                {
                    Car = new CarExportDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price)
                        - (s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100)
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SaleWithDicountExportDto[]), new XmlRootAttribute("sales"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            using var writer = new StringWriter();
            serializer.Serialize(writer, sales, namespaces);

            return writer.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem - 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerSaleExportDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                    .SelectMany(s => s.Car.PartCars)
                    .Sum(cp => cp.Part.Price)
                })
               .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerSaleExportDto[]), new XmlRootAttribute("customers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            using var writer = new StringWriter();
            serializer.Serialize(writer, customers, namespaces);

            return writer.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem - 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarWithPartExportDto
                {
                    Model = c.Model,
                    Make = c.Make,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                    .Select(pc => new PartExportDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithPartExportDto[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            using var writer = new StringWriter();
            serializer.Serialize(writer, cars, namespaces);

            return writer.ToString().TrimEnd();
        }

        // Problem - 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliersExportDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(LocalSuppliersExportDto[]), new XmlRootAttribute("suppliers"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using var writer = new StringWriter();
            serializer.Serialize(writer, suppliers, namespaces);

            return writer.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {

            var bwmCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarMakeExportDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            using var writer = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(writer, settings))
            {
                var serializer = new XmlSerializer(typeof(CarMakeExportDto[]), new XmlRootAttribute("cars"));
                serializer.Serialize(xmlWriter, bwmCars, namespaces);
                return writer.GetStringBuilder().ToString().TrimEnd();
            }

        }

        // Problem - 14 
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var serializer = new XmlSerializer(typeof(CarExportDto[]), new XmlRootAttribute("cars"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var carsWhitDistance = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new CarExportDto
                {
                    Model = c.Model,
                    Make = c.Make,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();
            using var writer = new StringWriter();

            serializer.Serialize(writer, carsWhitDistance, ns);

            return writer.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem - 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleInputDto[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);
            var saleInputDtos = (SaleInputDto[])serializer.Deserialize(reader);

            var sales = saleInputDtos
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    Discount = s.Discount,
                    CarId = s.CarId,
                    CustomerId = s.CustomerId
                });

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        // Problem - 12 
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerInputDto[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);
            var customerDtos = (CustomerInputDto[])serializer.Deserialize(reader);

            var customers = customerDtos
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                });

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count()}";
        }

        // Problem - 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarInputDto[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            var carsDto = (CarInputDto[])serializer.Deserialize(reader);


            foreach (var car in carsDto)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance
                };
                int[] partsId = car.Parts.Select(p => p.Id).ToArray();
                foreach (var partId in partsId.Distinct())
                {
                    if (context.Parts.Any(p => p.Id == partId))
                    {
                        var carPart = new PartCar
                        {
                            PartId = partId
                        };

                        currentCar.PartCars.Add(carPart);
                    }
                }

                context.Cars.Add(currentCar);
            }
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        // Problem - 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartInputDto[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);
            var partsDto = (PartInputDto[])serializer.Deserialize(reader);

            var parts = partsDto
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            return $"Successfully imported {context.SaveChanges()}";

        }

        // Problem - 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierInputDto[]), new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);
            var suppliersDto = (SupplierInputDto[])serializer.Deserialize(reader);

            var suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                });

            context.Suppliers.AddRange(suppliers);


            return $"Successfully imported {context.SaveChanges()}";
        }
    }
}