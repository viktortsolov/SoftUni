using Logger.Appenders;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender appender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public void Error(string dateTime, string message)
        {
            this.appender.Append(dateTime, "Error", message);
        }

        public void Info(string dateTime, string message)
        {
            this.appender.Append(dateTime, "Info", message);
        }
    }
}
