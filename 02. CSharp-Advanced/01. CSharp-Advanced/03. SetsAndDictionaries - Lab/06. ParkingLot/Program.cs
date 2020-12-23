using System;
using System.Collections.Generic;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArg[0];
                string numberOfCar = cmdArg[1];

                if (command == "IN")
                {
                    cars.Add(numberOfCar);
                }
                else
                {
                    cars.Remove(numberOfCar);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars));
            }
        }
    }
}
