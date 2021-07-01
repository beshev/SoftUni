namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Serialization;
    using VaporStore.DataProcessor.Dto.Export;
    using VaporStore.Data.Models.Enums;
    using System.Globalization;
    using System.Xml;
    using System.IO;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var gamesGenres = context.Genres.ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                        Players = g.Purchases.Count()
                    })
                    .Where(g => g.Players > 0)
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id),
                    TotalPlayers = x.Games.Sum(g => g.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id);


            return JsonConvert.SerializeObject(gamesGenres, Newtonsoft.Json.Formatting.Indented);

        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users.ToArray()
                .Select(x => new UserViewModel
                {
                    Username = x.Username,
                    Purchases = x.Cards
                    .SelectMany(c => c.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType)))
                    .OrderBy(p => p.Date)
                    .Select(p => new PurchaseViewModel
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = $"{p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)}",
                        Game = new GameViewModel
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToArray(),
                    TotalSpent = x.Cards.SelectMany(c => c.Purchases.Where(p => p.Type == Enum.Parse<PurchaseType>(storeType))).Sum(p => p.Game.Price)
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            users = users.Where(u => u.Purchases.Count() > 0).ToArray();


            var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var setting = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using var streamWriter = new StringWriter();
            using (var writer = XmlWriter.Create(streamWriter,setting))
            {
                var seraizlizer = new XmlSerializer(typeof(UserViewModel[]), new XmlRootAttribute("Users"));
                seraizlizer.Serialize(writer, users, ns);

                return streamWriter.ToString().TrimEnd();
            }
        }
    }
}