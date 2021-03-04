using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Feed(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DIFF_TYPE_OF_FOOD_EXC_MSG, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += 0.4 * food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
