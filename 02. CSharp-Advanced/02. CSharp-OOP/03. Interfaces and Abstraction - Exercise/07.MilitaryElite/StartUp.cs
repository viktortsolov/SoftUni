using _07.MilitaryElite.IO;
using _07.MilitaryElite.Core;
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.IO.Contracts;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IEngine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}
