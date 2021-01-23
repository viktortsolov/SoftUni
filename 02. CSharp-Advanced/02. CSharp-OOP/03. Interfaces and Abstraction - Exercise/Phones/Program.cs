using System;

using Phones.Models;
using Phones.Exceptions;

namespace Phones
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumber = Console.ReadLine()
                .Split();

            string[] sites = Console.ReadLine()
                .Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                try
                {

                    if (phoneNumber[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumber[i]));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(phoneNumber[i]));
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            for (int i = 0; i < sites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(sites[i]));
                }
                catch (InvalidURLException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
