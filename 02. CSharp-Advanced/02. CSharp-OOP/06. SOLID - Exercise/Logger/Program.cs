using System;

using Logger.Appenders;
using Logger.Layouts;
using Logger.Loggers;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            ILogFile file = new LogFile();
            IAppender fileAppender = new FileAppender(simpleLayout, file);

            ILogger logger = new Loggers.Logger(consoleAppender, fileAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsin JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
