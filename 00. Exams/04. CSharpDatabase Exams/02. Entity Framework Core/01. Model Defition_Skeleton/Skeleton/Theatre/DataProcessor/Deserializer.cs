namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
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
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])xmlSerializer.Deserialize(stringReader);

            HashSet<Play> plays = new HashSet<Play>();
            foreach (var playDto in playDtos)
            {

                if (!IsValid(playDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDurationValid = TimeSpan.TryParseExact
                    (playDto.Duration,
                    "c",
                    CultureInfo.InvariantCulture,
                    out TimeSpan duration);

                if (!isDurationValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan timeSpan = TimeSpan.FromHours(1);

                if (duration < timeSpan)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                object genre;
                bool isGenreValid = Enum.TryParse(typeof(Genre), playDto.Genre, out genre);

                if (!isGenreValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = (Genre)genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                stringBuilder.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre.ToString(), play.Rating.ToString()));
            }

            context.Plays.AddRange(plays);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            ImportCastDto[] castDtos = (ImportCastDto[])xmlSerializer.Deserialize(stringReader);

            HashSet<Cast> casts = new HashSet<Cast>();
            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast()
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                string mainOrLesser = string.Empty;

                if (cast.IsMainCharacter)
                {
                    mainOrLesser = "main";
                }
                else
                {
                    mainOrLesser = "lesser";
                }

                stringBuilder.AppendLine(string.Format(SuccessfulImportActor, cast.FullName, mainOrLesser));
            }

            context.Casts.AddRange(casts);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ImportTheatreDto[] theatreDtos =
                JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            HashSet<Theatre> theatres = new HashSet<Theatre>();
            foreach (var theatreDto in theatreDtos)
            {
                if (!IsValid(theatreDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre theatre = new Theatre()
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };

                HashSet<Ticket> tickets = new HashSet<Ticket>();
                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    Ticket ticket = new Ticket()
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };
                    tickets.Add(ticket);
                }
                theatre.Tickets = tickets;

                theatres.Add(theatre);
                stringBuilder.AppendLine(string.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
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
