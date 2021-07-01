namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using Data;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<GameInputModel[]>(jsonString);

            var sb = new StringBuilder();

            var games = new List<Game>();

            foreach (var game in gamesDto)
            {
                if (!IsValid(game) || game.Tags.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var releaseDate = DateTime.ParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                var develepor = context.Developers.FirstOrDefault(d => d.Name == game.Developer);
                if (develepor == null)
                {
                    develepor = new Developer { Name = game.Developer };
                }

                var genre = context.Genres.FirstOrDefault(d => d.Name == game.Genre);
                if (genre == null)
                {
                    genre = new Genre { Name = game.Genre };
                }


                var currentGame = new Game
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = releaseDate,
                    Developer = develepor,
                    Genre = genre,
                };


                foreach (var tag in game.Tags)
                {
                    var currentTag = context.Tags.FirstOrDefault(x => x.Name == tag);
                    if (currentTag == null)
                    {
                        currentTag = new Tag { Name = tag };
                    }

                    var currnetTag = currentGame.GameTags.FirstOrDefault(gt => gt.Tag.Name == tag);
                    if (currnetTag == null)
                    {
                        currnetTag = new GameTag { Tag = currentTag };
                    }

                    currentGame.GameTags.Add(currnetTag);
                }

                context.Games.Add(currentGame);
                context.SaveChanges();
                sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Count()} tags");
            }




            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersCards = JsonConvert.DeserializeObject<UserInputModel[]>(jsonString);

            var sb = new StringBuilder();

            var users = new List<User>();

            foreach (var user in usersCards)
            {
                if (!IsValid(user) || !user.Cards.All(x => IsValid(x)) || user.Cards.Count() == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currnetUser = new User
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age,
                    Cards = user.Cards.Select(c => new Card
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = Enum.Parse<CardType>(c.Type)
                    })
                    .ToList()
                };

                users.Add(currnetUser);
                sb.AppendLine($"Imported {currnetUser.Username} with {currnetUser.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PurchaseInputModel[]), new XmlRootAttribute("Purchases"));

            using var reader = new StringReader(xmlString);

            var purchasesDto = (PurchaseInputModel[])serializer.Deserialize(reader);

            var sb = new StringBuilder();
            foreach (var purchase in purchasesDto)
            {
                if (!IsValid(purchase))
                {
                    sb.AppendLine("Invalid Data");
                }

                var card = context.Cards.FirstOrDefault(c => c.Number == purchase.Card);
                var game = context.Games.FirstOrDefault(g => g.Name == purchase.Game);

                var currentPurchase = new Purchase
                {
                    ProductKey = purchase.Key,
                    Type = Enum.Parse<PurchaseType>(purchase.Type),
                    Card = card,
                    Game = game,
                    Date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                context.Purchases.Add(currentPurchase);
                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

            context.SaveChanges();

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