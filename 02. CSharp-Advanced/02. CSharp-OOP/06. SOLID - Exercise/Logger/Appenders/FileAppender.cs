using Logger.Common;
using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string result = string.Format(this.Layout.Template, dateTime, reportLevel, message) + Environment.NewLine;
                this.logFile.Write(result);
            }
        }
    }
}