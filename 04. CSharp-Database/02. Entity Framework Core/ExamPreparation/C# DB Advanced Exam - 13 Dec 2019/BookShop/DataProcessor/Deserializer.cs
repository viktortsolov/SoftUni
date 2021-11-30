namespace BookShop.DataProcessor
{
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;

    using Data;

    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]), xmlRoot);

            using StringReader stringReader = new StringReader(xmlString);

            ImportBookDto[] bookDtos = (ImportBookDto[])xmlSerializer.Deserialize(stringReader);

            ICollection<Book> books = new HashSet<Book>();
            foreach (var bookDto in bookDtos)
            {
                if (!IsValid(bookDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                bool isPublishOnValid =
                    DateTime.TryParseExact
                    (bookDto.PublishedOn,
                    "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime publishedOn);

                if (!isPublishOnValid)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book()
                {
                    Name = bookDto.Name,
                    Genre = (Genre)bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(book);
                stringBuilder.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder stringBuilder = new StringBuilder();

            ImportAuthorDto[] authorDtos =
                JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);

            HashSet<Author> authors = new HashSet<Author>();
            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(x => x.Email == authorDto.Email))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author()
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                foreach (var bookDto in authorDto.Books)
                {
                    if (bookDto.Id == null)
                    {
                        continue;
                    }

                    Book book = context
                        .Books
                        .FirstOrDefault(x => x.Id == int.Parse(bookDto.Id));

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author = author,
                        BookId = int.Parse(bookDto.Id)
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                stringBuilder.AppendLine(String.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
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