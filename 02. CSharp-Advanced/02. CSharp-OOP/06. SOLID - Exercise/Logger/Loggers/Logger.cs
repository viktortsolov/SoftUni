using Logger.Appenders;
using Logger.Common;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Warning, message);
        }

        private void AppendError( string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (IAppender appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }
    }
}
