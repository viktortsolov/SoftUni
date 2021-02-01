using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";
        private readonly StringBuilder reports;

        public LogFile()
        {
            this.reports = new StringBuilder();
        }

        // TODO check this property value
        public long Size
            => this.AllText
            .Where(char.IsLetter)
            .Sum(x => x);

        public string AllText
            => this.reports.ToString();

        public void Write(string error)
        {
            File.WriteAllText(FilePath, error);
            this.reports.Append(error);
        }
    }
}
