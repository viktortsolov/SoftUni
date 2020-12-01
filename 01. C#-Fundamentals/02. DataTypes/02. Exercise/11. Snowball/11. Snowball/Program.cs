using System;
using System.Numerics;

namespace _11._Snowball
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger maxSnowballValue = 0;
            int snowballBiggestSnow = 0, 
                snowballBiggestTime = 0, 
                snowballBiggestQuality = 0;
            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int snowDividedByTime = snowballSnow / snowballTime;
                BigInteger snowballValue = BigInteger.Pow(snowDividedByTime, snowballQuality);

                if (snowballValue > maxSnowballValue)
                {
                    maxSnowballValue = snowballValue;
                    snowballBiggestTime = snowballTime; snowballBiggestSnow = snowballSnow; snowballBiggestQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{snowballBiggestSnow} : {snowballBiggestTime} = {maxSnowballValue} ({snowballBiggestQuality})");
        }
    }
}

/*using System;
 
namespace _01.Problem
{

    class Program
    {

        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            List<Tuple<double, double, BigInteger, double>> listOfValues = new List<Tuple<double, double, BigInteger, double>>();

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                double snowballSnow = double.Parse(Console.ReadLine());
                double snowballTime = double.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger numberOfThrows = (BigInteger)(snowballSnow / snowballTime);

                BigInteger snowballValue = BigInteger.Pow(numberOfThrows, snowballQuality);

                var tuple4Parts = new Tuple<double, double, BigInteger, double>
                      (snowballSnow, snowballTime, snowballValue, snowballQuality);

                listOfValues.Add(tuple4Parts);
            }

            var highestSnowBallValue = listOfValues.OrderByDescending(x => x.Item3).First();
            Console.WriteLine($"{highestSnowBallValue.Item1} : {highestSnowBallValue.Item2} = {highestSnowBallValue.Item3} ({highestSnowBallValue.Item4})");

        }

    }
} */ 