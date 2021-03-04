using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Feed(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.35;
        }
    }
}
