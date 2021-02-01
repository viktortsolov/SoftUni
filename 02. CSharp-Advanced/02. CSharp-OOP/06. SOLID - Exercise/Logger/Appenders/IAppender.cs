using Logger.Layouts;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string dateTime, string reportLevel, string message);
    }
}
