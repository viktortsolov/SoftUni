using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
            => System.Console.Write(text);

        public void WriteLine(ISoldier text)
            => System.Console.WriteLine(text);
    }
}
