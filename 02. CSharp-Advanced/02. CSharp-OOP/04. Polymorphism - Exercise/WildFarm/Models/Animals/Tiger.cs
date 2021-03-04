using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DIFF_TYPE_OF_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += 1 * food.Quantity;
        }
    }
}
