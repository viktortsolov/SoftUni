using Logger.Layouts;

namespace Logger.Appenders
{
    class FileAppender : IAppender
    {
        private readonly ILogFile logFile;
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            Layout = layout;
            this.logFile = logFile;
        }

        public ILayout Layout { get; }

        public void Append(string dateTime, string reportLevel, string message)
        {
            string result = string.Format(Layout.Template, dateTime, reportLevel, message);
            logFile.Write(result);
        }
    }
}
