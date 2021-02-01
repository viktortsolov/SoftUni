namespace Logger.Loggers
{
    public interface ILogger
    {

        void Error(string dateTime, string message);
        void Info(string dateTime, string message);
    }
}
