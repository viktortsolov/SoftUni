using System;

namespace _03._Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5];

            weekdays[0] = "Monday";
            weekdays[1] = "Tuesday";
            weekdays[2] = "Wednesday";
            weekdays[3] = "Thursday";
            weekdays[4] = "Friday";

            for (int i = 0; i <= 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Index was outside the bounds of the array.");
                }
            }
        }
    }
}
