namespace VaporStore.DataProcessor
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var gameDtos = JsonConvert.DeserializeObject<ImportGameDTO[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                if (!DateTime.TryParse(gameDto.ReleaseDate,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };

                Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = gameDto.Developer };
                    developers.Add(developer);
                }
                game.Developer = developer;

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = gameDto.Genre };
                    genres.Add(genre);
                }
                game.Genre = genre;

                foreach (var tagDto in gameDto.Tags)
                {
                    Tag tag = tags.FirstOrDefault(t => t.Name == tagDto);
                    if (tag == null)
                    {
                        tag = new Tag() { Name = tagDto };
                        tags.Add(tag);
                    }

                    game.GameTags.Add(new GameTag() { Tag = tag });
                }

                games.Add(game);
                stringBuilder.AppendLine($"Added {game.Name} ({game.Genre}) with {game.GameTags.Count} tags");
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(jsonString);
            StringBuilder stringBuilder = new StringBuilder();

            List<User> users = new List<User>();
            foreach (var userDto in userDtos)
            {
                bool hasInvalidCard = false;

                if (!IsValid(userDto))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                var cards = new List<Card>();
                foreach (var cardDto in userDto.Cards)
                {
                    string[] validTypes = new string[] { "Debit", "Credit" };
                    if (!IsValid(cardDto) || validTypes.Any(t => t == cardDto.Type) == false)
                    {
                        hasInvalidCard = true;
                        break;
                    }

                    Card card = new Card()
                    {
                        Cvc = cardDto.Cvc,
                        Number = cardDto.Number,
                        Type = (CardType)Enum.Parse(typeof(CardType), cardDto.Type)
                    };

                    user.Cards.Add(card);
                }

                if (hasInvalidCard)
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                users.Add(user);
                stringBuilder.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Purchases");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDTO[]), xmlRoot);
            ImportPurchaseDTO[] purchaseDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                purchaseDtos = (ImportPurchaseDTO[])xmlSerializer.Deserialize(sr);
            }

            var games = context.Games.ToList();
            var cards = context.Cards
                .AsQueryable()
                .Include(x => x.User)
                .ToList();

            List<Purchase> purchases = new List<Purchase>();
            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    ProductKey = purchaseDto.Key
                };

                if (!DateTime.TryParseExact(purchaseDto.Date,
                    "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime purchaseDate))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                purchase.Date = purchaseDate;

                if (!Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object purchaseType))
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                purchase.Type = (PurchaseType)purchaseType;

                var card = cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (card == null)
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                purchase.Card = card;

                var game = games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (game == null)
                {
                    stringBuilder.AppendLine("Invalid Data");
                    continue;
                }

                purchase.Game = game;

                purchases.Add(purchase);
                stringBuilder.AppendLine($"Imported {purchaseDto.Title} for {card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}