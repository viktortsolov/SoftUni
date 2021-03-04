using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DIFF_TYPE_OF_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += 0.25 * food.Quantity;
        }
    }
}
