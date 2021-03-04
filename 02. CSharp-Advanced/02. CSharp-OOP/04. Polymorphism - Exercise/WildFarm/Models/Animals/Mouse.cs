using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += 0.1 * food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DIFF_TYPE_OF_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
