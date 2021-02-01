using Logger.Common;
using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string result = string.Format(Layout.Template, dateTime, reportLevel, message) + Environment.NewLine;
                System.Console.Write(result);
            }
        }
    }
}
