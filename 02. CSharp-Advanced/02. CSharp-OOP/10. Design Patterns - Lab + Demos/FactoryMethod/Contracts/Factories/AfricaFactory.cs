using SimpleFactory;

namespace FactoryMethod.Contracts
{
    public class AfricaFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Lion();
        }
    }
}
