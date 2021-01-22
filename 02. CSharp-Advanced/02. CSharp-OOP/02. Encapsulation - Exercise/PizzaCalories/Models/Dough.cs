using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private const double baseCalloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get
            {
                return this.flourType;
            }

            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.INV_TYPE_OF_DOUGH_EXC_MSG);
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.INV_TYPE_OF_DOUGH_EXC_MSG);
                }
                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalConstants.DOUGH_WEIGHT_EXC_MSG);
                }
                this.weight = value;
            }
        }

        public double Callories()
        {
            double modifier = baseCalloriesPerGram;
            switch (this.FlourType.ToLower())
            {
                case "white": modifier *= 1.5; break;
                case "wholegrain": modifier *= 1.0; break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9; break;
                case "chewy": modifier *= 1.1; break;
                case "homemade": modifier *= 1.0; break;
            }

            return modifier * this.Weight;
        }
    }
}
