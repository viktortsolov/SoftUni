namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            //var mostCraziestAuthors = context
            //    .Authors
            //    .ToArray()
            //    .Select(x => new
            //    {
            //        AuthorName = $"{x.FirstName} {x.LastName}",
            //        Books = x.AuthorsBooks
            //                 .ToArray()
            //                 .OrderByDescending(x => x.Book.Price)
            //                 .Select(ab => new
            //                 {
            //                     BookName = ab.Book.Name,
            //                     BookPrice = ab.Book.Price.ToString("f2")
            //                 })
            //                 .ToArray()
            //    })
            //    .OrderByDescending(x => x.Books.Length)
            //    .ThenBy(x => x.AuthorName)
            //    .ToArray();

            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                        .Select(ab => ab.Book)
                        .OrderByDescending(b => b.Price)
                        .Select(b => new
                        {
                            BookName = b.Name,
                            BookPrice = b.Price.ToString("f2")
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            string json = JsonConvert.SerializeObject(mostCraziestAuthors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            StringBuilder stringBuilder = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Books");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(stringBuilder);

            ExportBookDto[] booksDtos = context
                .Books
                .ToArray()
                .Where(x => x.Genre.ToString() == "Science" && x.PublishedOn < date)
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(x => new ExportBookDto()
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            xmlSerializer.Serialize(stringWriter, booksDtos, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}