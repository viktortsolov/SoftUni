using System;

namespace _04._Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            try
            {
                byte result = Convert.ToByte(numberOne * numberTwo);
                Console.WriteLine($"{numberOne} x {numberTwo} = {result}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Value was either too large or too small for an unsigned byte.");
            }
        }
    }
}
