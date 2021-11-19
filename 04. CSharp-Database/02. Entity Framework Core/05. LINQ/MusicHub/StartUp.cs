namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var albumsInfo = context
                .Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy",
                        CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                       .ToArray()
                       .Select(s => new
                       {
                           SongName = s.Name,
                           Price = s.Price.ToString("f2"),
                           Writer = s.Writer.Name
                       })
                       .OrderByDescending(s => s.SongName)
                       .ThenBy(s => s.Writer)
                       .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var album in albumsInfo)
            {
                stringBuilder
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                int i = 1;
                foreach (var song in album.Songs)
                {
                    stringBuilder
                        .AppendLine($"---#{i}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.Writer}");

                    i++;
                }

                stringBuilder
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
            }

            return stringBuilder.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var songs = context
                .Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers
                        .ToArray()
                        .Select(sp =>
                            $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            int i = 1;
            foreach (var song in songs)
            {
                stringBuilder
                    .AppendLine($"-Song #{i++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.Writer}")
                    .AppendLine($"---Performer: {song.Performer}")
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duration}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
