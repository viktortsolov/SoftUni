using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string file = fileLocation[fileLocation.Length - 1];
            int index = file.IndexOf('.');

            Console.WriteLine($"File name: {file.Substring(0, index)}");
            Console.WriteLine($"File extension: {file.Substring(index + 1)}");
        }
    }
}
