using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var contexr = new ProductShopContext();


            Console.WriteLine(GetCategoriesByProductsCount(contexr));
        }
        // Problem - 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(u => u.ProductsSold)
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .OrderByDescending(u => u.ProductsSold.Count)
                .Select(u => new UserWithProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ProductSoldCountDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                        .Select(pro => new SoldProductDto
                        {
                            Name = pro.Name,
                            Price = pro.Price
                        })
                        .OrderByDescending(pro => pro.Price)
                        .ToArray()
                    }
                })
                .ToArray();

            var result = new AllUserCount
            {
                Count = users.Length,
                Users = users.Take(10).ToArray()
            };


            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            ns.Add("", "");

            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            var serializer = new XmlSerializer(typeof(AllUserCount), new XmlRootAttribute("Users"));
            using var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter, settings))
            {
                serializer.Serialize(writer, result, ns);
            }



            return stringWriter.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem - 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new CategoryByProductCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = (c.CategoryProducts.Sum(cp => cp.Product.Price) / c.CategoryProducts.Count).ToString("F2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryByProductCountDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var settings = new XmlWriterSettings();
            settings.Indent = true;

            using var writer = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(writer, settings))
            {
                serializer.Serialize(xmlWriter, categories, namespaces);
            }

            return writer.GetStringBuilder().ToString().TrimEnd();

        }

        // Problem - 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(p => new SoldProductDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToList()
                })
                .ToList();

            using var writer = new StringWriter();

            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add("", "");

            var serializer = new XmlSerializer(typeof(List<UserSoldProductDto>), new XmlRootAttribute("Users"));
            serializer.Serialize(writer, users, nameSpace);


            return writer.GetStringBuilder().ToString().TrimEnd();
        }

        // Problem - 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            using var writer = new StringWriter();

            var nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add("", "");

            var serializer = new XmlSerializer(typeof(ProductInRangeDto[]), new XmlRootAttribute("Products"));
            serializer.Serialize(writer, products, nameSpaces);

            var productsXml = writer.GetStringBuilder();

            return productsXml.ToString().TrimEnd();
        }

        // Problem - 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {

            InitializeAutomapper();
            using var reader = new StringReader(inputXml);
            var serializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));

            var categoryProductInputModel = (CategoryProductInputModel[])serializer.Deserialize(reader);

            var categoryProducts = mapper.Map<CategoryProduct[]>(categoryProductInputModel)
                .Where(x => context.Categories.Any(c => c.Id == x.CategoryId) && context.Products.Any(p => p.Id == x.ProductId));

            context.CategoryProducts.AddRange(categoryProducts);

            return $"Successfully imported {context.SaveChanges()}";
        }

        // Problem - 3 
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutomapper();
            using var reader = new StringReader(inputXml);
            var serializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));

            var categoriesDto = (CategoryInputModel[])serializer.Deserialize(reader);

            var categories = mapper.Map<Category[]>(categoriesDto);
            context.Categories.AddRange(categories);

            return $"Successfully imported {context.SaveChanges()}";
        }

        // Problem - 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutomapper();
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            var productInputModel = (ProductInputModel[])serializer.Deserialize(reader);

            var products = mapper.Map<Product[]>(productInputModel);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // Problem - 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutomapper();
            using var reader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));

            var userInputModel = (UserInputModel[])serializer.Deserialize(reader);

            var users = mapper.Map<User[]>(userInputModel);
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }


        private static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}