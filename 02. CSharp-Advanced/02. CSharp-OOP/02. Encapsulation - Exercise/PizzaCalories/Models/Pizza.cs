using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException(GlobalConstants.PIZZA_NAME_EXC_MSG);
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            private get
            {
                return this.dough;
            }

            set
            {
                this.dough = value;
            }
        }

        public int GetNumberOfToppings()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException(GlobalConstants.NUM_OF_TOPPINGS_EXC_MSG);
            }
            this.toppings.Add(topping);
        }

        public double Callories()
        {
            double callories = 0;
            callories += this.dough.Callories();
            foreach (Topping topping in this.toppings)
            {
                callories += topping.Callories();
            }

            return callories;
        }
    }
}
