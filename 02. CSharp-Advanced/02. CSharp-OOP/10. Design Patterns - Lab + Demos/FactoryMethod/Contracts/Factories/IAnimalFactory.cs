using SimpleFactory;

namespace FactoryMethod
{
    public interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();
    }
}
