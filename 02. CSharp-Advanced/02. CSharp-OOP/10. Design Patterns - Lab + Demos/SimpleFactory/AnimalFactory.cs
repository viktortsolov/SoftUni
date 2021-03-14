namespace SimpleFactory
{
    public class AnimalFactory
    {
        public static IAnimal CreateAnimal(string breed)
        {
            if (breed == "Lion")
            {
                return new Lion();
            }
            else if (breed == "Tiger")
            {
                return new Tiger();
            }
            return null;
        }
    }
}
