using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            bool passwordLength = PasswordLength(password);
            bool passwordLettersAndDigits = PasswordLettersAndDigits(password);
            bool passwordDigitsCounter = PasswordDigitsCounter(password);

            if (passwordLength && passwordLettersAndDigits && passwordDigitsCounter)
                Console.WriteLine("Password is valid");

            if (!passwordLength)
                Console.WriteLine("Password must be between 6 and 10 characters");

            if (!passwordLettersAndDigits)
                Console.WriteLine("Password must consist only of letters and digits");

            if (!passwordDigitsCounter)
                Console.WriteLine("Password must have at least 2 digits");
        }

        static bool PasswordLength(string password)
        {
            bool isLengthSixToTen = false;

            if (password.Length >= 6 && password.Length <= 10)
                isLengthSixToTen = true;

            return isLengthSixToTen;
        }

        static bool PasswordLettersAndDigits(string password)
        {
            bool isTherePassAndDigits = true;

            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] < '0' || password[i] > '9') &&
                    (password[i] < 'A' || password[i] > 'Z') &&
                    (password[i] < 'a' || password[i] > 'z'))
                {
                    isTherePassAndDigits = false;
                    break;
                }
            }

            return isTherePassAndDigits;
        }

        static bool PasswordDigitsCounter(string password)
        {
            bool isCounterOK = true;

            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                    counter++;
            }

            if (counter < 2)
                isCounterOK = false;

            return isCounterOK;
        }
    }
}