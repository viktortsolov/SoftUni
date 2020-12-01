using System;

namespace _06._Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int valueInt;
            float valueFloat;
            char valueChar;
            bool valueBoolean;

            while (true)
            {
                string text = Console.ReadLine();
                if (text == "END")
                    break; 

                if (bool.TryParse(text, out valueBoolean))
                    Console.WriteLine($"{text} is boolean type");
                else if(int.TryParse(text, out valueInt))
                    Console.WriteLine($"{text} is integer type");
                else if (float.TryParse(text, out valueFloat))
                    Console.WriteLine($"{text} is floating point type");
                else if (char.TryParse(text, out valueChar))
                    Console.WriteLine($"{text} is character type");
                else
                    Console.WriteLine($"{text} is string type");
            }
        }
    }
}
