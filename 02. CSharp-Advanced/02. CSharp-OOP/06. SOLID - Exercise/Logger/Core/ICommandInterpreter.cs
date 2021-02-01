using Logger.Loggers;

namespace Logger.Core
{
    public interface ICommandInterpreter
    {
        void Execute(ILogger logger, string reportLevel, string date, string message);
    }
}
