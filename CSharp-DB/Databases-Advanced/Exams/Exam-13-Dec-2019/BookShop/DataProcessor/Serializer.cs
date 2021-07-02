namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .Select(b => b.Book)
                    .OrderByDescending(b => b.Price)
                    .Select(b => new
                    {
                        BookName = b.Name,
                        BookPrice = $"{b.Price:F2}",
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(author => author.Books.Length)
                .ThenBy(author => author.AuthorName)
                .ToArray();

            return JsonConvert.SerializeObject(authors, Formatting.Indented);
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new XmlBookViewModel
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    PublishedOn = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .ToArray();


            var serializer = new XmlSerializer(typeof(XmlBookViewModel[]), new XmlRootAttribute("Books"));
            using var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, books, ns);

            return writer.GetStringBuilder().ToString().TrimEnd();
        }
    }
}