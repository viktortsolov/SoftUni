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
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; private set; }
        public double TankCapacity { get; }

        public string Drive(double amount)
        {
            if (this.GetType().Name == "Bus")
            {
                this.FuelConsumption += 1.4;
            }

            double fuelNeeded = amount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return string.Format(SUCC_DRIVE_MSG, this.GetType().Name, amount);
        }

        public string DriveEmpty(double amount)
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
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_FUEL_AMOUNT_EXC_MSG, liters));
            }

            if (this.GetType().Name == "Truck")
            {
                this.FuelQuantity += liters * 0.95;
                return;
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
