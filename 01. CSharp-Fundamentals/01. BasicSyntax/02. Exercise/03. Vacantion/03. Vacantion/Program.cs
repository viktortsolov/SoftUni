using System;

namespace _03._Vacantion
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfPeople = Console.ReadLine();
            string dayName = Console.ReadLine();

            double sum = 0;

            if (typeOfPeople == "Students")
            {
                if (dayName == "Friday")
                    sum = numberOfPeople * 8.45;
                else if (dayName == "Saturday")
                    sum = numberOfPeople * 9.8;
                else
                    sum = numberOfPeople * 10.46;

                if (numberOfPeople >= 30)
                    sum *= 0.85;
            }

            else if (typeOfPeople == "Business")
            {
                double priceOfTicket = 0;
                if (dayName == "Friday")
                { priceOfTicket = 10.9; sum = numberOfPeople * 10.9; }
                else if (dayName == "Saturday")
                { priceOfTicket = 15.6; sum = numberOfPeople * 15.6; }
                else
                { priceOfTicket = 16; sum = numberOfPeople * 16; }

                if (numberOfPeople >= 100)
                    sum = sum - 10 * priceOfTicket;
            }
            else if (typeOfPeople == "Regular")
            {
                if (dayName == "Friday")
                    sum = numberOfPeople * 15;
                else if (dayName == "Saturday")
                    sum = numberOfPeople * 20;
                else
                    sum = numberOfPeople * 22.5;

                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                    sum *= 0.95;
            }

            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
