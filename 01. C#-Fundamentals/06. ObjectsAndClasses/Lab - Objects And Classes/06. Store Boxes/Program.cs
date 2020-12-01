using System;
using System.Collections.Generic;

namespace _06._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                string[] tokens = line.Split();

                string serialNumber = tokens[0];
                string item = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = int.Parse(tokens[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Quantity = quantity,
                    PriceBox = quantity * price
                };
            }
        }
    }
}
