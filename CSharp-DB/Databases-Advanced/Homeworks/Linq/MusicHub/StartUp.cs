namespace MusicHub
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            List<int> list = new List<int>();

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));


            // Console.WriteLine(ExportAlbumsInfo(context, 9));

            //Test your solutions here
        }


        //!!!!!
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                   .Include(a => a.Songs)
                   .Where(a => a.ProducerId == producerId)
                   .Select(a => new
                   {
                       AlbumName = a.Name,
                       ReleaseDate = a.ReleaseDate,
                       ProducerName = a.Producer.Name,
                       Songs = a.Songs.Select(s => new
                       {
                           SongName = s.Name,
                           s.Price,
                           Writer = s.Writer.Name
                       })
                       .OrderByDescending(s => s.SongName)
                       .ThenBy(s => s.Writer)
                       .ToList(),
                       AlbumPrice = a.Price
                   })
                   .ToList()
                   .OrderByDescending(a => a.AlbumPrice);

            StringBuilder sb = new StringBuilder();
            foreach (var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }



        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {

            var songs = context.Songs
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.Select(p => p.Performer.FirstName + " " + p.Performer.LastName).FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration);

            StringBuilder sb = new StringBuilder();

            int counter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
