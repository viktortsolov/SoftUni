using System;

using Logger.Common;
using Logger.Loggers;

namespace Logger.Core
{
    public class LoggerInterpreter : ICommandInterpreter
    {
        public void Execute(ILogger logger, string reportLevel, string date, string message)
        {
            if (!Enum.TryParse(reportLevel, true, out ReportLevel reportLevelEnum))
            {
                throw new InvalidOperationException("Report level is invalid.");
            }

            switch (reportLevelEnum)
            {
                case ReportLevel.Info:
                    logger.Info(date, message);
                    break;

                case ReportLevel.Warning:
                    logger.Warning(date, message);
                    break;

                case ReportLevel.Error:
                    logger.Error(date, message);
                    break;

                case ReportLevel.Critical:
                    logger.Critical(date, message);
                    break;

                case ReportLevel.Fatal:
                    logger.Fatal(date, message);
                    break;
            }
        }
    }
}
