using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] cmdArg = input.Split();
                Tire[] tiresAsArray = new Tire[4];
                int count = 0;

                for (int i = 0; i < cmdArg.Length; i += 2)
                {
                    int year = int.Parse(cmdArg[i]);
                    double pressure = double.Parse(cmdArg[i]);

                    Tire newTire = new Tire(year, pressure);

                    tiresAsArray[count] = newTire;
                }

                tires.Add(tiresAsArray);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] cmdArg = input.Split();

                int horsePower = int.Parse(cmdArg[0]);
                double cubicCapacity = double.Parse(cmdArg[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] cmdArg = input.Split();

                string make = cmdArg[0];
                string model = cmdArg[1];
                int year = int.Parse(cmdArg[2]);

                double fuelQuantity = double.Parse(cmdArg[3]);
                double fuelConsumption = double.Parse(cmdArg[4]);

                int engineIndex = int.Parse(cmdArg[5]);
                int tiresIndex = int.Parse(cmdArg[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            DriveAllCars(cars);

        }

        private static void DriveAllCars(List<Car> cars)
        {
            var filtredCars = cars.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower > 330);
            foreach (Car car in cars)
            {
                StringBuilder stringBuilder = new StringBuilder();
                double sum = 0;

                foreach (Tire tire in car.Tires)
                {
                    sum += tire.Pressure;
                }

                if (sum >= 9 && sum <= 10)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}\n" +
                                      $"Model: {car.Model}\n" +
                                      $"Year:{car.Year}\n" +
                                      $"HorsePowers: {car.Engine.HorsePower}\n" +
                                      $"FuelQuantity: {car.FuelQuantity}");
                }

            }
        }
    }
}
