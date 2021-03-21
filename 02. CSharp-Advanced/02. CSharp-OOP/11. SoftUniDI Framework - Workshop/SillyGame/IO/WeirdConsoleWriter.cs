using SillyGame.IO.Contracts;

namespace SillyGame.IO
{
    public class WeirdConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            System.Console.WriteLine($"{s} + Weirdo!");
        }
    }
}
