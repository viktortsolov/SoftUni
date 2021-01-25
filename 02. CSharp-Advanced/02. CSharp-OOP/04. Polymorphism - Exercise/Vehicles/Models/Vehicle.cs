using System;
using Vehicles.Common;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVE_MSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; }

        public string Drive(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name));
            }

            this.FuelQuantity -= amount;

            return string.Format(SUCC_DRIVE_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NEGATIVE_FUEL_EXC_MSG);
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
