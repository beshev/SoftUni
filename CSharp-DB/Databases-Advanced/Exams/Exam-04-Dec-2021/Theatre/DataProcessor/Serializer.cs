namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var result = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = x.Tickets
                    .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                    .Select(t => new
                    {
                        t.Price,
                        t.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var result = context.Plays
                .Include(x => x.Casts)
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new PlayXmlExportDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(a => a.IsMainCharacter)
                    .Select(a => new ActorXmlExportDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'.",
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PlayXmlExportDto[]), new XmlRootAttribute("Plays"));
            using var writer = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, result, ns);

            return writer.ToString();
        }
    }
}
