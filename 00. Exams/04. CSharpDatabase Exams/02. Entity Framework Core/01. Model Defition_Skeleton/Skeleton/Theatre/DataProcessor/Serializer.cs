namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .OrderByDescending(x => x.NumberOfHalls)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x
                        .Tickets
                        .ToArray()
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Sum(x => x.Price),
                    Tickets = x
                            .Tickets
                            .ToArray()
                            .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                            .OrderByDescending(x => x.Price)
                            .Select(x => new
                            {
                                Price = decimal.Parse(x.Price.ToString("f2")),
                                RowNumber = x.RowNumber
                            })
                            .ToArray()
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPlayDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(stringBuilder);

            ExportPlayDto[] playDtos = context
                .Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto()
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x
                        .Casts
                        .ToArray()
                        .Where(x => x.IsMainCharacter == true)
                        .OrderByDescending(x => x.FullName)
                        .Select(k => new ExportActorDto()
                        {
                            FullName = k.FullName,
                            MainCharacter = $"Plays main character in '{x.Title}'."
                        })
                        .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, playDtos, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
