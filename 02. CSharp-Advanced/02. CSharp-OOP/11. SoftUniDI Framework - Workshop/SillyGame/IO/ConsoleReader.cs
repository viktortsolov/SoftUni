using SillyGame.IO.Contracts;

namespace SillyGame.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return System.Console.ReadLine();
        }
    }
}
