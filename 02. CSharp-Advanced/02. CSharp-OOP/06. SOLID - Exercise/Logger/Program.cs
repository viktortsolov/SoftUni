using System;

using Logger.Appenders;
using Logger.Common;
using Logger.Core;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfAppenders = int.Parse(Console.ReadLine());
            Engine engine = new Engine();
            engine.Run(countOfAppenders);
        }
    }
}
