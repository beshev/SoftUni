
namespace BookShop
{
    using BookShop.Data;
    using BookShop.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            var context = new BookShopContext();

            Console.WriteLine(RemoveBooks(context));

        }


        // Problem - 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Where(b => b.AgeRestriction == GetAgeRestriction(command))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
        private static AgeRestriction? GetAgeRestriction(string value)
        {
            if (value.Equals("Minor", StringComparison.CurrentCultureIgnoreCase))
            {
                return AgeRestriction.Minor;
            }
            else if (value.Equals("Teen", StringComparison.CurrentCultureIgnoreCase))
            {
                return AgeRestriction.Teen;
            }
            else if (value.Equals("Adult", StringComparison.CurrentCultureIgnoreCase))
            {
                return AgeRestriction.Adult;
            }
            return null;
        }

        // Problem - 3
        public static string GetGoldenBooks(BookShopContext context)
        {


            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Where(x => x.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();

        }

        // Problem - 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParts = date.Split("-", StringSplitOptions.RemoveEmptyEntries);

            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            var dateTime = new DateTime(year, month, day);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.Price,
                    x.EditionType,
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var Titles = context.Books.
                Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var sb = new StringBuilder();

            foreach (var titel in Titles)
            {
                sb.AppendLine(titel);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksWhitLongerTitle = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return booksWhitLongerTitle;
        }

        // Problem - 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies),
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryAndProfid = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies),
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categoryAndProfid)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem - 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categoryBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // Problem - 15 
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // Problem - 16 
        public static int RemoveBooks(BookShopContext context)
        {
            int removeCount = context.Books
                .Where(x => x.Copies < 4200)
                .Delete();

            return removeCount;
        }

    }
}