using System;
using System.Text;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string article = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            result.AppendLine("<h1>");
            result.AppendLine("    " + title);
            result.AppendLine("</h1>");

            result.AppendLine("<article>");
            result.AppendLine("    " + article);
            result.AppendLine("</article>");

            string comment = string.Empty;

            while ((comment = Console.ReadLine()) != "end of comments")
            {
                result.AppendLine("<div>");
                result.AppendLine("    " + comment);
                result.AppendLine("</div>");
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
