using WildFarm.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAskable, IFeedable
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string AskForFood();
        public abstract void Feed(Food food);
    }
}
