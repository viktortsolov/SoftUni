using Logger.Layouts;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            string result = string.Format(Layout.Template, dateTime, reportLevel, message);
            System.Console.WriteLine(result);
        }
    }
}
