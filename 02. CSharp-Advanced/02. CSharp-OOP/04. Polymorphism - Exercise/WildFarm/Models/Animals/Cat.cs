using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.3 * food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DIFF_TYPE_OF_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }    
        }
    }
}
