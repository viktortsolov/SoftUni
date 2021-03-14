using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LoggerSingleton.Instance;

            logger.LogToFile();

            LoggerSingleton.Instance.LogToFile();
        }
    }
}
