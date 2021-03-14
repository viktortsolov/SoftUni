using SimpleFactory;

namespace FactoryMethod.Contracts.Factories
{
    public class EuroFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Wolf();
        }
    }
}
