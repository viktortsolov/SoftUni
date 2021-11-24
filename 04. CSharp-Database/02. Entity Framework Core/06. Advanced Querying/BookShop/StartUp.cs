namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            
            int input = int.Parse(Console.ReadLine());
            var result = CountBooks(db, input);
            Console.WriteLine(result);
        }

        //Problem 1
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder stringBuilder = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, ignoreCase: true);

            var bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var bookTitle in bookTitles)
            {
                stringBuilder.AppendLine(bookTitle);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 2
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var goldenBooks = context
                .Books
                .Where(b => (int)b.EditionType == 2 && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in goldenBooks)
            {
                stringBuilder.AppendLine(book);
            }

            return stringBuilder.ToString().TrimEnd();
        }

        //Problem 3
        //TODO: Judje problem!
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(book => $"{book.Title} - ${book.Price}")
                .ToArray();

            foreach (var book in books)
            {
                stringBuilder.AppendLine(book);
            }

            return stringBuilder.ToString().Trim();
        }

        //Problem 4
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in books)
            {
                stringBuilder.AppendLine(book);
            }

            return stringBuilder.ToString().Trim();
        }

        //Problem 5
        //TODO: Loop the categories
        public static void GetBooksByCategory(BookShopContext context, string input)
        {
            var stringBuilder = new StringBuilder();

            var books = context
                .BooksCategories
                .Where(b => b.Category.Name.ToLower() == input.ToLower())
                .ToArray();

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        //Problem 7
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authorNames = context
                .Authors
                .ToArray()
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(n => n)
                .ToArray();

            foreach (var name in authorNames)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().Trim();
        }

        //Problem 8
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .ToArray()
                .Where(a => a.Title.ToLower().Contains(input.ToLower()))
                .Select(a => a.Title)
                .OrderBy(n => n)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 9
        //TODO: 25/100
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .ToArray()
                .OrderBy(b => b.BookId)
                .Where(a => a.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => $"{a.Title} ({a.Author.FirstName} {a.Author.LastName})")
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(a => a.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        }

        //Problem 11
        //TODO: 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            return null;
        }
    }
}
