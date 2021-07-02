namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(XmlBookImportModel[]), new XmlRootAttribute("Books"));
            using var reader = new StringReader(xmlString);

            var books = (XmlBookImportModel[])serializer.Deserialize(reader);

            var sb = new StringBuilder();

            foreach (var currentBook in books)
            {
                DateTime publishedOn;
                var isValidDate = DateTime
                    .TryParseExact(currentBook.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);


                if (!IsValid(currentBook) || !isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = currentBook.Name,
                    Genre = (Genre)currentBook.Genre,
                    Price = currentBook.Price,
                    Pages = currentBook.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);
                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price}.");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var jsonAuthors = JsonConvert.DeserializeObject<JsonAuthorImportModel[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var jsonAuthor in jsonAuthors)
            {
                if (!IsValid(jsonAuthor)
                    || jsonAuthor.Books.All(b => b.Id == null)
                    || context.Authors.Any(a => a.Email == jsonAuthor.Email))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var author = new Author
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                };

                foreach (var jsonBook in jsonAuthor.Books)
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == jsonBook.Id);
                    if (book == null)
                    {
                        continue;
                    }

                    var authorBook = new AuthorBook
                    {
                        Book = book
                    };

                    author.AuthorsBooks.Add(authorBook);
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                sb.AppendLine($"Successfully imported author - {author.FirstName + " " + author.LastName} with {author.AuthorsBooks.Count} books.");
                context.Authors.Add(author);
                context.SaveChanges();

            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}