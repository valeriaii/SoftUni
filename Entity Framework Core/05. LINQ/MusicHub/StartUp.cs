namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();
            //if DB already exists -> drop DB and create new instance
            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder result = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s=>s.SongName)
                        .ThenBy(s=>s.Writer)
                        .ToArray(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a=>a.TotalPrice)
                .ToArray();

            foreach (var a in albumsInfo)
            {
                result.AppendLine($"-AlbumName: {a.AlbumName}")
                      .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                      .AppendLine($"-ProducerName: {a.ProducerName}")
                      .AppendLine($"-Songs:");

                int songCount = 1;
                foreach (var s in a.Songs)
                {
                    result.AppendLine($"---#{songCount++}")
                          .AppendLine($"---SongName: {s.SongName}")
                          .AppendLine($"---Price: {s.SongPrice:f2}")
                          .AppendLine($"---Writer: {s.Writer}");
                }
                result.AppendLine($"-AlbumPrice: {a.TotalPrice:f2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songsInfo = context.Songs
                .Include(s=>s.SongPerformers)
                .ThenInclude(sp=>sp.Performer)
                .Include(s=>s.Writer)
                .Include(s=>s.Album)
                .ThenInclude(a=>a.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                                .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                                .FirstOrDefault(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")

                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.PerformerFullName)
                .ToArray();

            int songCount = 1;
            foreach (var s in songsInfo)
            {
                result.AppendLine($"-Song #{songCount++}")
                      .AppendLine($"---SongName: {s.SongName}")
                      .AppendLine($"---Writer: {s.Writer}")
                      .AppendLine($"---Performer: {s.PerformerFullName}")
                      .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                      .AppendLine($"---Duration: {s.Duration}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
