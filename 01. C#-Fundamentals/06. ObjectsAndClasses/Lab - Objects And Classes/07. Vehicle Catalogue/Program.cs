using System;

namespace _07._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split("/");

                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                int hpORkg = int.Parse(tokens[3]);

                if (type == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hpORkg
                    };
                    Catalogue catalogue = new Catalogue()
                    {
                    };
                }
            }
        }
    }
}
