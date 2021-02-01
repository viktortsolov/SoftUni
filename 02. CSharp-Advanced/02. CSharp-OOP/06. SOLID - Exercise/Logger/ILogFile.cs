namespace Logger
{
    public interface ILogFile
    {
        string AllText { get; }

        long Size { get; }

        void Write(string error);
    }
}
