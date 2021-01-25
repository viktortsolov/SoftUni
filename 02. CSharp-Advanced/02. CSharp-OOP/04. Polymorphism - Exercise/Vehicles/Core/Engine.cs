using System;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            Vehicle car = ProcessVehicleInfo();
            Vehicle truck = ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double argument = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, argument);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, argument);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, argument);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine()
                                          .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle currVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);

            return currVehicle;
        }
    }
}
