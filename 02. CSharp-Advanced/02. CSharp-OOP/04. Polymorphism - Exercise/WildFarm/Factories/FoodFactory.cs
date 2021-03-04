using System;
using WildFarm.Common;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public FoodFactory()
        {

        }

        public Food CreateFood(string type, int quantity)
        {
            Food food;

            if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_FOOD_TYPE);
            }

            return food;
        }
    }
}
