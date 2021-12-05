﻿namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var serizlizr = new XmlSerializer(typeof(PlayXmlImportDto[]), new XmlRootAttribute("Plays"));
            using var reader = new StringReader(xmlString);
            var xmlPlays = (PlayXmlImportDto[])serizlizr.Deserialize(reader);
            var sb = new StringBuilder();

            foreach (var xmlPlay in xmlPlays)
            {
                if (IsValid(xmlPlay) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidTime = TimeSpan.TryParseExact(xmlPlay.Duration,
                    "c",
                    CultureInfo.InvariantCulture, out TimeSpan time);

                if (isValidTime == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (time.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newPlay = new Play
                {
                    Title = xmlPlay.Title,
                    Duration = time,
                    Rating = xmlPlay.Rating,
                    Genre = Enum.Parse<Genre>(xmlPlay.Genre),
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter,
                };


                context.Add(newPlay);
                sb.AppendLine(String.Format(SuccessfulImportPlay, xmlPlay.Title, xmlPlay.Genre, xmlPlay.Rating));
            }

            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var serizlizr = new XmlSerializer(typeof(CastXmlImportDto[]), new XmlRootAttribute("Casts"));
            using var reader = new StringReader(xmlString);
            var xmlCasts = (CastXmlImportDto[])serizlizr.Deserialize(reader);
            var sb = new StringBuilder();

            foreach (var xmlCast in xmlCasts)
            {
                if (IsValid(xmlCast) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = context.Plays.Find(xmlCast.PlayId);

                var newCast = new Cast
                {
                    FullName = xmlCast.FullName,
                    IsMainCharacter = xmlCast.IsMainCharacter,
                    PhoneNumber = xmlCast.PhoneNumber,
                    Play = play
                };

                context.Add(newCast);
                var character = xmlCast.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine(String.Format(SuccessfulImportActor, xmlCast.FullName, character));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var allTheaters = JsonConvert.DeserializeObject<TheatreJsonImportDto[]>(jsonString);
            var sb = new StringBuilder();

            var theaters = new List<Theatre>();

            foreach (var jsonTheater in allTheaters)
            {
                if (IsValid(jsonTheater) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theater = new Theatre
                {
                    Name = jsonTheater.Name,
                    NumberOfHalls = (sbyte)jsonTheater.NumberOfHalls,
                    Director = jsonTheater.Director,
                };

                foreach (var jsonTicket in jsonTheater.Tickets)
                {
                    if (IsValid(jsonTicket) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Play play = context.Plays.FirstOrDefault(x => x.Id == jsonTicket.PlayId);

                    Ticket ticket = new Ticket
                    {
                        Price = jsonTicket.Price,
                        RowNumber = (sbyte)jsonTicket.RowNumber,
                        Play = play,
                        Theatre = theater,
                    };

                    theater.Tickets.Add(ticket);
                }

                theaters.Add(theater);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theater.Name, theater.Tickets.Count));
            }

            context.Theatres.AddRange(theaters);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
