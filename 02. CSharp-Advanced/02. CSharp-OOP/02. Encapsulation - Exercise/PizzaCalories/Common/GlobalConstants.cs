using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public class GlobalConstants
    {
        public const string INV_TYPE_OF_DOUGH_EXC_MSG = "Invalid type of dough.";
        public const string DOUGH_WEIGHT_EXC_MSG = "Dough weight should be in the range [1..200].";
        public const string PIZZA_NAME_EXC_MSG = "Pizza name should be between 1 and 15 symbols.";
        public const string NUM_OF_TOPPINGS_EXC_MSG = "Number of toppings should be in range [0..10].";
        public const string CANNOT_PLACE_EXC_MSG = "Cannot place {0} on top of your pizza.";
        public const string WEIGHT_IN_RANGE_EXC_MSG = "{0} weight should be in the range [1..50].";
    }
}
