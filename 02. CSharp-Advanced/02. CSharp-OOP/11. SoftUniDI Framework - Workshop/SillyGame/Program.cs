using DIContainer.Injectors;
using SillyGame.DI;

namespace SillyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureDI module = new ConfigureDI();
            Injector injector = new Injector(module);
            Engine engine = injector.Inject<Engine>();

            engine.Start();
        }
    }
}
