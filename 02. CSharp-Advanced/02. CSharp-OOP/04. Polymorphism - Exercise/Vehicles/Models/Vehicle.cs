using System;
using Vehicles.Common;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVE_MSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; }
        public double TankCapacity { get; private set; }

        public string Drive(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return string.Format(SUCC_DRIVE_MSG, this.GetType().Name, amount);
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NEGATIVE_FUEL_EXC_MSG);
            }
            else if (FuelQuantity + liters > TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MORE_FUEL_ADD_EXC_MSG, liters));
            }

            this.FuelQuantity += liters;
        }

        public string DriveEmpty(double amount)
        {
            double fuelNeeded = amount * this.FuelConsumption - 1.4;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return string.Format(SUCC_DRIVE_MSG, this.GetType().Name, amount);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
