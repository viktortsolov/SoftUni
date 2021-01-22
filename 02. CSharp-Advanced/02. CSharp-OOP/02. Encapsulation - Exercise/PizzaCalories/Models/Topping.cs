using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Common;
namespace PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private int weight;
        private const int baseCalloriesPerGram = 2;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "sauce" && value.ToLower() != "cheese")
                {
                    throw new ArgumentException(string.Format(GlobalConstants.CANNOT_PLACE_EXC_MSG, value));
                }
                this.type = value;
            }
        }

        private int Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.WEIGHT_IN_RANGE_EXC_MSG, this.Type));
                }
                this.weight = value;
            }
        }

        public double Callories()
        {
            double modifier = baseCalloriesPerGram;

            switch (this.Type.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
            }

            return modifier * this.Weight;
        }
    }
}
