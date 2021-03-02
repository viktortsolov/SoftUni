namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + FUEL_CONSUMPTION_INCR;

    }
}
